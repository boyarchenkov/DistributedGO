using System;
using System.Collections;
using System.Collections.Generic;

namespace M.Tools
{
    [Serializable]
    public class MySortedList<T> : ICollection<T>
    {
        public delegate double Cost(T item);

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public MySortedList(Cost cost)
        {
            list = new List<T>();
            this.cost = cost;
        }

        public T this[int i]
        {
            get
            {
                return list[i];
            }
        }

        public void Add(T item)
        {
            if (list.Count == 0) { list.Add(item); return; }
            int low = 0, hi = list.Count - 1, median;
            double x = cost(item);
            while (hi - low > 1)
            {
                median = (low + hi) >> 1;
                if (x < cost(list[median])) hi = median - 1; else low = median + 1;
            }
            if (x <= cost(list[low])) list.Insert(low, item);
            else if (x >= cost(list[hi])) list.Insert(hi + 1, item);
            else list.Insert(hi, item);

            //int low = 0, hi = list.Count - 1, median, compare;
            //double x = cost(item);
            //while (low <= hi)
            //{
            //    median = (low + hi) >> 1;
            //    compare = cost(list[median]).CompareTo(x);
            //    if (compare == 0) { list.Insert(median, item); return; }
            //    if (compare < 0) low = median + 1; else hi = median - 1;
            //}
            //list.Insert(low, item);
        }
        public void AddMaxElement(T item)
        {
            //if (list.Count > 0 && cost(list[list.Count - 1]) - cost(item) > 3 * DGO.Golden.tolerance) throw new ArgumentOutOfRangeException("Adding to the end of MySortedList: must be a maximum");
            //if (list.Count > 0 && cost(list[list.Count - 1]) > cost(item)) throw new ArgumentOutOfRangeException("Adding to the end of MySortedList: must be a maximum");
            list.Add(item);
        }
        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return list.BinarySearch(item, comparer);
        }
        public void Clear()
        {
            list.Clear();
        }
        public bool Contains(T item)
        {
            return list.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(T item)
        {
            return list.Remove(item);
        }
        public void RemoveAt(int i)
        {
            list.RemoveAt(i);
        }
        public void RemoveRange(int start_index)
        {
            list.RemoveRange(start_index, list.Count - start_index);
        }
        public T[] ToArray()
        {
            return list.ToArray();
        }
        public T Pop()
        {
            T pop = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return pop;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            IEnumerable<T> ie = list;
            return ie.GetEnumerator();
        }
        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerable ie = list;
            return ie.GetEnumerator();
        }

        List<T> list;
        Cost cost;
    }
}
