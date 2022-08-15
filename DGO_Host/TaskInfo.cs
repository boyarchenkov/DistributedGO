using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DGO
{
    [DataContract]
    public class TaskInfo
    {
        public TaskInfo(TaskInfo task)
        {
            x = task.x;
            priority = task.priority;
            created = task.created;
            sent_last = DateTime.Now;
        }
        public TaskInfo(int priority, double[] x, bool estimate)
        {
            this.priority = priority;
            this.x = x;
            this.created = this.sent_last = DateTime.Now;
            if (estimate) info = "estimate";
        }

        public int CompareInputTo(double[] xx)
        {
            int i;
            for (i = 0; i < x.Length; i++)
            {
                if (i >= xx.Length) return 2;
                int c = x[i].CompareTo(xx[i]);
                if (c != 0) return c;
            }
            if (i < xx.Length) return -2;
            return 0;
        }

        [DataMember]
        public double[] x;
        [DataMember]
        public double result;
        [DataMember]
        public double time;
        [DataMember]
        public int steps;
        [DataMember]
        public string info;

        [DataMember]
        public int priority;

        public DateTime created, sent_last;

        public double total_time;
    }
}
