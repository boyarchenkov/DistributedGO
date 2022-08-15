using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DGO
{
    // Origin: http://blogs.msdn.com/b/ericlippert/archive/2007/10/08/path-finding-using-a-in-c-3-0-part-three.aspx
    // Added Count, Peek(), Clear(), GetEnumerator(), Dequeue(priority)
    public class PriorityQueue<P, V> : IEnumerable<V>
    {
        private SortedDictionary<P, Queue<V>> list = new SortedDictionary<P, Queue<V>>();

        public int Count
        {
            get { return list.Sum(q => q.Value.Count); }
        }
        public void Clear()
        {
            list.Clear();
        }
        public void Enqueue(P priority, V value)
        {
            Queue<V> q;
            if (!list.TryGetValue(priority, out q))
            {
                q = new Queue<V>();
                list.Add(priority, q);
            }
            q.Enqueue(value);
        }
        public V Peek()
        {
            return list.First().Value.Peek();
        }
        public V Dequeue()
        {
            // will throw if there isn’t any first element!
            var pair = list.First();
            var v = pair.Value.Dequeue();
            if (pair.Value.Count == 0) // nothing left of the top priority.
                list.Remove(pair.Key);
            return v;
        }
        public V Dequeue(out P priority)
        {
            // will throw if there isn’t any first element!
            var pair = list.First();
            var v = pair.Value.Dequeue();
            if (pair.Value.Count == 0) // nothing left of the top priority.
                list.Remove(pair.Key);
            priority = pair.Key;
            return v;
        }
        public bool IsEmpty
        {
            get { return !list.Any(); }
        }

        public IEnumerator<V> GetEnumerator()
        {
            return list.SelectMany(q => q.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.SelectMany(q => q.Value).GetEnumerator();
        }
    }
}
