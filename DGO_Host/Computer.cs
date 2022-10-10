using System;
using System.Collections.Generic;
using M.Tools;

namespace DGO
{
    public class Computer
    {
        public static int next_id = 0;
        public static TimeSpan timeout = new TimeSpan(0, 10, 0);
        public static TimeSpan perfomance_mean_interval = new TimeSpan(0, 3, 0);
        public static int lags_mean_count = 100;
        //public static double flops_for_MD_step = 13515271 / 1.0e+9; // 324 ions
        public static double flops_for_MD_step = 62710915 / 1.0e+9; // 768 ions

        public int ID
        {
            get
            {
                return id;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
        }
        public int MinInput
        {
            get
            {
                return min_points;
            }
            set { min_points = value; }
        }
        public int MaxInput
        {
            get
            {
                return max_points;
            }
        }
        public List<TaskInfo> Input
        {
            get
            {
                return input;
            }
        }
        public DateTime LastSend
        {
            get
            {
                return last_send;
            }
        }
        public DateTime LastReceive
        {
            get
            {
                return last_receive;
            }
        }
        public bool IsTimedOut
        {
            get
            {
                return DateTime.Now.Subtract(last_receive) > timeout;
            }
        }
        public int Processed
        {
            get
            {
                return processed;
            }
        }
        public double Perfomance
        {
            get
            {
                SortedDictionary<DateTime, List<TaskInfo>>.Enumerator e;
                while (true)
                {
                    e = perfomance.GetEnumerator();
                    if (!e.MoveNext()) return 0;
                    if (DateTime.Now.Subtract(e.Current.Key) <= perfomance_mean_interval) break;
                    perfomance.Remove(e.Current.Key);
                }
                double flops = 0, time = 0;
                foreach (List<TaskInfo> tasks in perfomance.Values)
                    foreach (TaskInfo task in tasks)
                    {
                        flops += task.steps * flops_for_MD_step;
                        time += task.time;
                    }
                return flops / time; // in GFLOPS
            }
        }
        public double Speed
        {
            get
            {
                SortedDictionary<DateTime, List<TaskInfo>>.Enumerator e;
                while (true)
                {
                    e = perfomance.GetEnumerator();
                    if (!e.MoveNext()) return 0;
                    if (DateTime.Now.Subtract(e.Current.Key) <= perfomance_mean_interval) break;
                    perfomance.Remove(e.Current.Key);
                }
                double steps = 0, time = 0;
                foreach (List<TaskInfo> tasks in perfomance.Values)
                    foreach (TaskInfo task in tasks)
                    {
                        steps += task.steps;
                        time += task.time;
                    }
                return steps / time; // in GFLOPS
            }
        }
        public double EffPerfomance
        {
            get
            {
                SortedDictionary<DateTime, List<TaskInfo>>.Enumerator e;
                while (true)
                {
                    e = perfomance.GetEnumerator();
                    if (!e.MoveNext()) return 0;
                    if (DateTime.Now.Subtract(e.Current.Key) <= perfomance_mean_interval) break;
                    perfomance.Remove(e.Current.Key);
                }
                double flops = 0, time = 0;
                foreach (List<TaskInfo> tasks in perfomance.Values)
                {
                    if (time == 0)
                        time = DateTime.Now.Subtract(tasks[0].sent_last).TotalSeconds;
                    foreach (TaskInfo task in tasks)
                        flops += task.steps * flops_for_MD_step;
                }
                return flops / time; // in GFLOPS
            }
        }
        public TimeSpan UsefulTime
        {
            get
            {
                return new TimeSpan(0, 0, (int)(useful_time));
            }
        }
        public double Lag
        {
            get
            {
                return lags.Mean;
            }
        }

        public Computer(string description)
        {
            id = next_id++;

            min_points = 256; max_points = 512; processed = 0;
            //min_points = 8192; max_points = 16384; processed = 0;
            //min_points = 10; max_points = 16384; processed = 0;

            this.description = description;
            last_send = last_receive = DateTime.Now;
            input = new List<TaskInfo>();
            lags = new MeanQueue(lags_mean_count);
            perfomance = new SortedDictionary<DateTime, List<TaskInfo>>();
        }

        public void Send(TaskInfo task)
        {
            input.Add(task);
            last_send = DateTime.Now;
        }
        public int Receive(TaskInfo finished)
        {
            var index = input.FindIndex(t => finished.CompareInputTo(t.x) == 0);
            if (index < 0) return -1;

            // Update stats
            var received = DateTime.Now;
            useful_time += finished.time;
            finished.sent_last = input[index].sent_last;
            finished.total_time = received.Subtract(input[index].sent_last).TotalSeconds;
            if (!perfomance.ContainsKey(received))
                perfomance.Add(received, new List<TaskInfo>(new TaskInfo[] { finished }));
            else
                perfomance[received].Add(finished);
            last_receive = received;
            lags.Enqueue(finished.total_time);
            processed++;

            input.RemoveAt(index);
            return 0;
        }

        List<TaskInfo> input;
        string description;
        int id, min_points, max_points, processed;
        double useful_time;
        DateTime last_send, last_receive;
        MeanQueue lags;
        SortedDictionary<DateTime, List<TaskInfo>> perfomance;
    }
}
