using System;
using System.Collections;
using Float = System.Double;

namespace M.Tools
{
    public class MeanQueue : IEnumerable
    {
        public int Count
        {
            get
            {
                return buffer.Length;
            }
        }
        public Float[] Buffer
        {
            get
            {
                return buffer;
            }
        }
        public Float this[int index]
        {
            get
            {
                return buffer[(i + buffer.Length - count) % buffer.Length + index];
            }
        }
        public Float Mean
        {
            get
            {
                int j, k;
                Float mean = 0;
                //if (count == 0) return mean;
                for (j = 0, k = i; j < count; j++, k--)
                {
                    if (k < 0) k = buffer.Length - 1;
                    mean += buffer[k];
                }
                return mean / count;
            }
        }

        public MeanQueue(int count)
        {
            buffer = new Float[count];
        }

        public void Clear()
        {
            count = 0;
        }
        public void Enqueue(Float item)
        {
            i++; if (i >= buffer.Length) i = 0;
            buffer[i] = item;
            if (count < buffer.Length) count++;
        }
        public Float Peek()
        {
            return buffer[i];
        }
        public Float Dequeue()
        {
            if (count == 0) throw new IndexOutOfRangeException("The queue is empty");
            Float x = this[0];
            count--;
            return x;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        Float[] buffer;
        int i, count;
    }
}
