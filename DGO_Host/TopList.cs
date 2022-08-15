using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DGO
{
    [Serializable]
    public class TopList
    {
        public static readonly int count = 10;

        public TopList()
        {
            top_list = new SortedDictionary<double, string>();
            max_cost = double.PositiveInfinity;
        }

        public void Add(ICollection<TaskInfo> tasks)
        {
            lock (top_list)
                foreach (var task in tasks)
                {
                    if (task.result == 0) ;
                    else if (task.result < max_cost)
                    {
                        if (top_list.Count >= count) top_list.Remove(max_cost);
                        if (!top_list.ContainsKey(task.result)) top_list.Add(task.result, "cost = " + task.result + "\r\n" + task.info);

                        max_cost = double.NegativeInfinity;
                        foreach (var cost in top_list.Keys) max_cost = Math.Max(max_cost, cost);
                    }
                    else task.info = String.Empty;
                }
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            lock (top_list) foreach (var info in top_list.Values) s.Append(info).AppendLine();
            return s.ToString();
        }

        double max_cost;
        SortedDictionary<double, string> top_list;
    }
}
