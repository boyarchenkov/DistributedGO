using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using M.Tools;

namespace DGO
{
    // TODO: проверять клиенты на честность: если они некоторые точки подолгу не обрабатывают, то снова их передавать.
    // ServiceThrottlingBehavior..::.MaxConcurrentSessions Property 
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TaskManager : ITaskManager
    {
        public static int latency = 1;
        public static int max_calls = 0;
        public static string state_filename = "state.bin";
        public static TimeSpan autosave_interval = new TimeSpan(0, 5, 0);

        public bool Closing
        {
            get
            {
                return closing;
            }
        }
        public Golden Golden
        {
            get
            {
                return golden;
            }
        }
        public List<Computer> Computers
        {
            get
            {
                return computers;
            }
        }
        public List<Golden.Point> SentPoints
        {
            get
            {
                return sent_points;
            }
        }
        public DateTime LastAutosaveTime
        {
            get
            {
                return last_autosave_time;
            }
        }
        public string TopList
        {
            get
            {
                return top.ToString();
            }
        }

        public TaskManager(double[] bounds)
        {
            closing = false;
            computers = new List<Computer>();
            sent_points = new List<Golden.Point>();
            returned_tasks = new Queue<TaskInfo>();
            top = new TopList();
            estimates = new List<double[]>();

            SearchForPastRuns();
            if (File.Exists(state_filename)) golden = Golden.BinaryDeserialize(state_filename, ref top); // Load saved state
            else golden = new Golden(bounds);
        }

        public int RegisterComputer(string description)
        {
            lock (computers)
            {
                Computer c = new Computer(description);
                computers.Add(c);
                return c.ID;
            }
        }

        // parameter steps: to compute FLOPS.
        public TaskInfo[] Next(int id, TaskInfo[] finished, out int error_code)
        {
            error_code = 0;
            int c_index, t_index; //, received_count;
            var next = new List<TaskInfo>();
            lock (computers)
            {
                c_index = computers.FindIndex(delegate(Computer computer) { return computer.ID == id; });
                if (c_index < 0) { error_code = -1; return next.ToArray(); } // New Registration Required.
                var c = computers[c_index];

                // for Debug:
                //received_count = finished.Length;
                //foreach (var t in finished) x_sent_pairs.Remove(t.x[0]);

                // Receive finished tasks
                top.Add(finished);
                foreach (var task in finished)
                {
                    if (task.result == 0) { MainForm.estimates += task.info; File.AppendText("estimates.txt").WriteLine(task.info); }
                    t_index = sent_points.FindIndex(delegate(Golden.Point p) { return task.CompareInputTo(p.x) == 0; });
                    if (t_index >= 0)
                    {
                        if (task.result != 0) sent_points[t_index].f(task.result);
                        sent_points.RemoveAt(t_index);
                        if (c.Receive(task) != 0) Console.WriteLine("! Finished task not found in Computer.Input");
                    } else Console.WriteLine("! Finished task not found in TaskManager.sent_points");
                }
                //sent_to_client -= received_count;
 
                // Send new tasks
                lock (golden)
                {
                    if (golden.queue.Count + returned_tasks.Count == 0) error_code = 1;
                    else
                    {
                        lock (estimates)
                        {
                            foreach (var x in estimates)
                            {
                                var task = new TaskInfo(0, x, true);
                                c.Send(task); next.Add(task);
                            }
                            estimates.Clear();
                        }
                        while (golden.queue.Count + returned_tasks.Count > 0 && c.Input.Count < c.MinInput)
                        {
                            TaskInfo task;
                            if (returned_tasks.Count > 0) task = returned_tasks.Dequeue();
                            else
                            {
                                int priority;
                                Golden.Point p = golden.queue.Dequeue(out priority);
                                sent_points.Add(p);
                                task = new TaskInfo(priority, p.x, false);
                            }
                            c.Send(task); next.Add(task);
                        }
                    }
                    //if (next.Count > 0 || received_count > 0) using (var w = File.AppendText("sent.log")) w.WriteLine("{0}\t{1}\t{2}", sent_to_client, next.Count, received_count);
                }
            }
            //sent_to_client += next.Count;
            return next.ToArray();
        }

        public void PrepareNextPointsLoop()
        {
            while (!Closing)
            {
                int buffer = 0;
                lock (computers)
                {
                    for (int i = computers.Count - 1; i >= 0; i--)
                    {
                        Computer c = computers[i];
                        if (c.IsTimedOut)
                        {
                            foreach (TaskInfo task in c.Input) returned_tasks.Enqueue(new TaskInfo(task));
                            c.Input.Clear();
                            computers.RemoveAt(i);
                        }
                        else buffer += c.MinInput;
                    }

                    if (!MainForm.paused)
                        lock (golden)
                        {
                            if (DateTime.Now.Subtract(last_autosave_time) >= autosave_interval) Save();

                            if (golden.queue.Count == 0 || (golden.calls > buffer + 10 && golden.queue.Count < buffer))
                            {
                                golden.Next();
                                //Console.WriteLine(golden.calls.ToString());
                            }
                            if (max_calls > 0 && golden.calls > max_calls) closing = true;

                            // debugging:
                            //string s = String.Format("\t\t\t{0}\t{1}\t{2}", golden.bisection_queue.Count, golden.queue.Count, sent_points.Count);
                            //if (s != printed)
                            //{
                            //    using (var w = File.AppendText("sent.log")) w.WriteLine(s);
                            //    printed = s;
                            //}

                            // short circuit
                            //foreach (var p in sent_points) p.f(1);
                            //sent_points.Clear();

                            //foreach (var p in golden.queue) sent_points.Add(p);
                            //golden.queue.Clear();
                        }
                }

                System.Threading.Thread.Sleep(latency);
            }
        }

        public void AddEstimate(double[] x)
        {
            lock (estimates) estimates.Add(x);
        }
        public void Close()
        {
            closing = true;
        }
        private void Backup(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename + ".bak");
                File.Move(filename, filename + ".bak");
            }
        }
        private void SearchForPastRuns()
        {
            int max = 0, index;
            string[] files = Directory.GetFiles(".", "state*.bin");
            foreach (string file in files)
                if (int.TryParse(Path.GetFileNameWithoutExtension(file).Substring(5), out index))
                    if (index > max) max = index;
            max++;
            if (File.Exists(state_filename)) File.Copy(state_filename, "state" + max + ".bin", true);
        }
        public void Save()
        {
            PriorityQueue<int, Golden.Point> queue = golden.queue;
            Golden.queue = new PriorityQueue<int, Golden.Point>();
            foreach (Golden.Point p in sent_points) golden.queue.Enqueue(1, p);
            foreach (Golden.Point p in queue) golden.queue.Enqueue(1, p);
            Backup(state_filename);
            Golden.Save(state_filename, golden, top);
            //Golden.BinarySerialize(golden, state);
            golden.queue = queue;

            last_autosave_time = DateTime.Now;
            using (StreamWriter w = new StreamWriter("TOP.txt")) w.Write(TopList);
        }

        public void ChangeBoundaries(double[] new_bounds)
        {
            lock (computers)
                lock (golden)
                {
                    foreach (Computer c in computers) c.Input.Clear();
                    sent_points.Clear();
                    returned_tasks.Clear();
                    golden.ChangeBoundaries(new_bounds);
                }
        }

        bool closing;
        List<Computer> computers;
        Golden golden;
        List<Golden.Point> sent_points;
        List<double[]> estimates;
        Queue<TaskInfo> returned_tasks;
        DateTime last_autosave_time;
        TopList top;

        //string printed;
        //int sent_to_client = 0;
        //int counter = 0;
        //Dictionary<double, DateTime> x_sent_pairs = new Dictionary<double, DateTime>();
    }
}
