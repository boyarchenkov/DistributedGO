using System;
using System.Collections.Generic;
using System.Text;

namespace DGO
{
    public class LocalInitializer
    {
        static Queue<Computer> add_queue;
        static Queue<int> remove_queue;
        static LocalInitializer()
        {
            add_queue = new Queue<Computer>();
            remove_queue = new Queue<int>();
        }
        public static int latency = 1000;

        public static void Add(Computer c)
        {
            lock (add_queue) add_queue.Enqueue(c);
        }
        public static void Remove(int id)
        {
            lock (remove_queue) remove_queue.Enqueue(id);
        }

        public TaskManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
            }
        }

        public LocalInitializer()
        {
        }

        private void AddComputer(Computer c)
        {
            lock (manager) manager.Computers.Add(c);
        }
        private void RemoveComputer(int id)
        {
            int index = manager.Computers.FindIndex(delegate(Computer c) { return c.ID == id; });
        }
        public void Run()
        {
            while (!manager.Closing)
            {
                lock (add_queue) while (add_queue.Count > 0) AddComputer(add_queue.Dequeue());
                lock (remove_queue) while (remove_queue.Count > 0) RemoveComputer(remove_queue.Dequeue());
                System.Threading.Thread.Sleep(latency);
            }
        }

        TaskManager manager;
    }
}
