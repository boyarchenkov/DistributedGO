using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using M.Tools;
using Float = System.Double;

namespace DGO
{
    [Serializable]
    public class Golden
    {
        public static bool GOLDEN = true;
        public static int stagnation_max = 2;
        public static Float cent = 1e-2, tolerance = 1e-4, golden = 0.5 * (Math.Sqrt(5) - 1);

        //public static void BinarySerialize(Golden state, string filename)
        //{
        //    using (StreamWriter w = new StreamWriter(filename))
        //    {
        //        BinaryFormatter f = new BinaryFormatter();
        //        f.Serialize(w.BaseStream, state);
        //    }
        //}
        //public static Golden BinaryDeserialize(string filename)
        //{
        //    using (StreamReader r = new StreamReader(filename))
        //    {
        //        BinaryFormatter f = new BinaryFormatter();
        //        return f.Deserialize(r.BaseStream) as Golden;
        //    }
        //}
        public static Golden Load(string filename, ref TopList top)
        {
            Golden g;
            using (StreamReader s = new StreamReader(filename))
            using (BinaryReader r = new BinaryReader(s.BaseStream))
            {
                if (sizeof(Float) != sizeof(double)) throw new NotImplementedException();
                int i, j, dim = r.ReadInt32();
                double[] bounds = new double[dim * 2];
                for (i = 0; i < bounds.Length; i++) bounds[i] = r.ReadDouble();
                g = new Golden(bounds);
                g.list_cost = delegate(MySortedList<Cell> list) { return list[0].size; };
                g.cell_cost = delegate(Cell cell) { return -cell.cost; };
                g.bisection_queue = new LinkedList<Bisection>();
                g.cells_by_size = new MySortedList<MySortedList<Cell>>(g.list_cost);
                g.queue = new PriorityQueue<int, Point>();

                g.calls = r.ReadInt32();
                g.stagnation = r.ReadInt32();
                g.iterations = r.ReadInt32();
                g.size_count = r.ReadInt32();
                g.fbest = r.ReadDouble();
                g.fbest_last = r.ReadDouble();
                g.fbest_local = r.ReadDouble();
                g.epsilon = r.ReadDouble();
                g.xbest = new Float[dim];
                for (i = 0; i < g.xbest.Length; i++) g.xbest[i] = r.ReadDouble();
                g.farthest_bounds = new Float[dim * 2];
                for (i = 0; i < g.farthest_bounds.Length; i++) g.farthest_bounds[i] = r.ReadDouble();
                int size_count = r.ReadInt32(), count;
                for (i = 0; i < size_count; i++)
                {
                    MySortedList<Cell> list = new MySortedList<Cell>(g.cell_cost);
                    count = r.ReadInt32();
                    for (j = 0; j < count; j++) list.AddMaxElement(new Cell(r, dim));
                    g.cells_by_size.AddMaxElement(list);

                    PleaseWaitForm.Value = (double)i / size_count;
                }
                count = r.ReadInt32();
                for (i = 0; i < count; i++)
                {
                    Bisection b = new Bisection(r, g);
                    g.bisection_queue.AddLast(b);
                    g.queue.Enqueue(1, new Point(b.Evaluate, g.Transform(b.cc.x)));
                }
                count = r.ReadInt32();
                for (i = 0; i < count; i++) g.unfeasible.Add(new Cell(r, dim));

                //System.Windows.Forms.MessageBox.Show(s.BaseStream.Position + " / " + s.BaseStream.Length);
                if (!s.EndOfStream) // "if" is for back compatibility
                {
                    try
                    {
                        BinaryFormatter f = new BinaryFormatter();
                        top = f.Deserialize(r.BaseStream) as TopList;
                    }
                    catch (System.Runtime.Serialization.SerializationException) // Ignore it
                    {
                    }
                }
            }
            return g;
        }
        public static void Save(string filename, Golden state, TopList top)
        {
            Golden g = state;
            using (Stream s = File.Open(filename, FileMode.Create))
            using (BinaryWriter w = new BinaryWriter(s))
            {
                int i;
                w.Write(g.xbest.Length); // dim
                for (i = 0; i < g.bounds.Length; i++) w.Write(g.bounds[i]);
                w.Write(g.calls);
                w.Write(g.stagnation);
                w.Write(g.iterations);
                w.Write(g.size_count);
                w.Write(g.fbest);
                w.Write(g.fbest_last);
                w.Write(g.fbest_local);
                w.Write(g.epsilon);
                for (i = 0; i < g.xbest.Length; i++) w.Write(g.xbest[i]);
                for (i = 0; i < g.farthest_bounds.Length; i++) w.Write(g.farthest_bounds[i]);
                w.Write(g.cells_by_size.Count);
                foreach (MySortedList<Cell> list in g.cells_by_size)
                {
                    w.Write(list.Count);
                    foreach (Cell c in list) c.Save(w);
                }
                w.Write(g.bisection_queue.Count);
                foreach (Bisection b in g.bisection_queue) b.Save(w);
                w.Write(g.unfeasible.Count);
                foreach (Cell c in g.unfeasible) c.Save(w);

                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(w.BaseStream, top);
            }
        }
        public static Golden BinaryDeserialize(string filename, ref TopList top)
        {
            Clock clock = new Clock();
            Float started = clock.ElapsedTime;
            Golden g;

            //using (StreamReader r = new StreamReader(filename))
            //{
            //    BinaryFormatter f = new BinaryFormatter();
            //    g = f.Deserialize(r.BaseStream) as Golden;
            //}
            //System.Windows.Forms.MessageBox.Show((clock.ElapsedTime - started).ToString());
            //started = clock.ElapsedTime;
            g = Load(filename, ref top);
            //System.Windows.Forms.MessageBox.Show((clock.ElapsedTime - started).ToString());
            //started = clock.ElapsedTime;
            //Save(g, filename + ".pak");
            //BinarySerialize(g, filename + ".1");
            //System.Windows.Forms.MessageBox.Show((clock.ElapsedTime - started).ToString());
            return g;
        }

        public delegate void EvaluateFunction(Float cost);

        [Serializable]
        public class Cell
        {
            internal static ListSizeComparer list_size_comparer = new ListSizeComparer();
            internal class ListSizeComparer : IComparer<MySortedList<Cell>>
            {
                public ListSizeComparer() { }
                public int Compare(MySortedList<Cell> a, MySortedList<Cell> b)
                {
                    if (a[0].size < tolerance && b[0].size > tolerance) return -1;
                    if (a[0].size > tolerance && b[0].size < tolerance) return 1;
                    if (Math.Abs(a[0].size - b[0].size) < tolerance) return 0;
                    return a[0].size.CompareTo(b[0].size);
                }
            }
            public Cell(int divisions, Float[] min, Float[] max, Float[] x)
            {
                this.divisions = divisions;
                this.min = new Float[min.Length]; min.CopyTo(this.min, 0);
                this.max = new Float[max.Length]; max.CopyTo(this.max, 0);
                this.x = new Float[x.Length]; x.CopyTo(this.x, 0);
            }
            public Cell(BinaryReader r, int dim)
            {
                Load(r, dim);
            }
            public Float Volume() { double v = 1; for (int i = 0; i < x.Length; i++) v *= max[i] - min[i]; return v; }
            public Float SizeMax() { size = 0; for (int i = 0; i < x.Length; i++) size = Math.Max(size, max[i] - min[i]); return size; }
            public Float SizeSum() { size = 0; for (int i = 0; i < x.Length; i++) size += (max[i] - min[i]) * (max[i] - min[i]); size = Math.Sqrt(size / x.Length); return size; }
            public Float SizeDiv() { return size = Math.Pow(0.5, divisions); } // size = 1.0 / divisions; }
            public Float SizeVol() { return size = Math.Pow(Volume(), 1.0 / x.Length); }
            public Float Size() { return SizeVol(); }
            public override string ToString()
            {
                return String.Format("size:{0:E4} cost:{1:E4} x:{2:F4} y:{3:F4}", size, cost, x[0], x[1]);
            }
            public Float[] min, max, x;
            public Float cost, size;
            public int divisions, size_index;

            public void Load(BinaryReader r, int dim)
            {
                int i;
                min = new double[dim]; max = new double[dim]; x = new double[dim];
                for (i = 0; i < dim; i++) min[i] = r.ReadDouble();
                for (i = 0; i < dim; i++) max[i] = r.ReadDouble();
                for (i = 0; i < dim; i++) x[i] = r.ReadDouble();
                cost = r.ReadDouble();
                size = r.ReadDouble();
                divisions = r.ReadInt32();
                size_index = r.ReadInt32();
            }
            public void Save(BinaryWriter w)
            {
                foreach (Float f in min) w.Write(f);
                foreach (Float f in max) w.Write(f);
                foreach (Float f in x) w.Write(f);
                w.Write(cost);
                w.Write(size);
                w.Write(divisions);
                w.Write(size_index);
            }
        }
        [Serializable]
        public class Bisection
        {
            public Bisection(Golden optimizer, Cell c, bool first)
            {
                // Debug:
                created = DateTime.Now;

                this.optimizer = optimizer; this.c = c;
                evaluated = first ? 0 : 1;
                int j = 0; Float g = 0.5; xx = new Float[c.x.Length];
                //g = golden; // xx closer to x
                //g = 1 - golden; // xx farther from x
                for (i = 0; i < xx.Length; i++)
                {
                    //g = rand.Next(2) == 0 ? golden : 1 - golden;
                    if (c.max[i] - c.x[i] > c.x[i] - c.min[i])
                        xx[i] = g * c.x[i] + (1 - g) * c.max[i];
                    else
                        xx[i] = g * c.x[i] + (1 - g) * c.min[i];
                }
                for (i = 1; i < xx.Length; i++) if (Math.Abs(xx[i] - c.x[i]) > Math.Abs(xx[j] - c.x[j])) j = i; // j = first longest side
                do i = optimizer.rand.Next(c.x.Length); while (Math.Abs(xx[i] - c.x[i]) != Math.Abs(xx[j] - c.x[j])); // i = random longest side
                cc = new Cell(c.divisions + 1, c.min, c.max, xx);
            }
            public Bisection(BinaryReader r, Golden g)
            {
                Load(r, g);
            }

            public Cell Finish()
            {
                Float g;
                if (GOLDEN)
                {
                    g = c.cost > cc.cost ? golden : 1 - golden;
                    g = g * c.x[i] + (1 - g) * xx[i]; // bound closer to worst point
                }
                else g = 0.5 * (c.x[i] + xx[i]);
                if (c.x[i] > xx[i]) c.min[i] = cc.max[i] = g; else c.max[i] = cc.min[i] = g;
		        c.divisions++;
                c.Size(); cc.Size();

                return cc;
            }

            public void EvaluateBase(Float cost)
            {
                optimizer.Evaluate(c, cost);
                evaluated |= 1;
            }
            public void Evaluate(Float cost)
            {
                optimizer.Evaluate(cc, cost);
                evaluated |= 2;
            }

            public void Load(BinaryReader r, Golden g)
            {
                optimizer = g;
                int j, dim = g.xbest.Length;
                i = r.ReadInt32();
                evaluated = r.ReadInt32();
                c = new Cell(r, dim);
                cc = new Cell(r, dim);
                xx = new double[dim];
                for (j = 0; j < dim; j++) xx[j] = r.ReadDouble();
                if ((evaluated & 1) == 0) g.queue.Enqueue(1, new Point(EvaluateBase, c.x));
                if ((evaluated & 2) == 0) g.queue.Enqueue(1, new Point(Evaluate, cc.x));
            }
            public void Save(BinaryWriter w)
            {
                w.Write(i);
                w.Write(evaluated);
                c.Save(w);
                cc.Save(w);
                foreach (Float f in xx) w.Write(f);
            }

            public Golden optimizer;
            public int i, evaluated;
            public Cell c, cc;
            public Float[] xx;
            public DateTime created;
            public static DateTime started = DateTime.Now;
        }
        [Serializable]
        public class Point
        {
            public Point(EvaluateFunction f, Float[] x) { this.f = f; this.x = x; }

            public EvaluateFunction f;
            public Float[] x;
        }

        public Golden(Float[] bounds)
        {
            this.bounds = new Float[bounds.Length]; bounds.CopyTo(this.bounds, 0);
            farthest_bounds = new Float[bounds.Length]; bounds.CopyTo(farthest_bounds, 0);
            rand = new Random(0);
            queue = new PriorityQueue<int, Golden.Point>();
            unfeasible = new List<Cell>();

            Init();
        }

        public void Init()
        {
            list_cost = delegate(MySortedList<Cell> list) { return list[0].size; };
            cell_cost = delegate(Cell cell) { return -cell.cost; };
            epsilon = cent; iterations = calls = stagnation = 0; fbest = fbest_last = fbest_local = Float.PositiveInfinity;
            int n = bounds.Length / 2; xbest = new Float[n];
            Float[] min = new Float[n], max = new Float[n], x = new Float[n];
            for (int i = 0; i < n; i++) { min[i] = 0; max[i] = 1; x[i] = 2/3.0; }
            bisection_queue = new LinkedList<Bisection>();
            Cell root = new Cell(0, min, max, x);
            cells_by_size = new MySortedList<MySortedList<Cell>>(list_cost);
            bisection_queue.AddLast(new Bisection(this, root, true));

            queue.Enqueue(1, new Point(bisection_queue.First.Value.EvaluateBase, Transform(bisection_queue.First.Value.c.x)));
            queue.Enqueue(1, new Point(bisection_queue.First.Value.Evaluate, Transform(bisection_queue.First.Value.cc.x)));
        }
        public void Add(Cell c)
        {
            MySortedList<Cell> list = new MySortedList<Cell>(cell_cost); list.Add(c);
            int index = cells_by_size.BinarySearch(list, Cell.list_size_comparer);
            if (index < 0) cells_by_size.Add(list); else cells_by_size[index].Add(c);
        }
        public void ChooseMode()
        {
            if (epsilon == 0) // local search
            {
                if (fbest < fbest_last - cent * Math.Abs(fbest_last)) stagnation = 0; else stagnation++;
                if (stagnation > stagnation_max) { fbest_local = fbest; epsilon = cent; stagnation = 0; }
            }
            else // global search
            {
                if (fbest < fbest_last - cent * Math.Abs(fbest_last)) stagnation = 0; else stagnation++;
                if (stagnation > stagnation_max && fbest < fbest_local - cent * Math.Abs(fbest_local)) { epsilon = 0; stagnation = 0; }
            }
            fbest_last = fbest;
        }
        public Float[] Transform(Float[] x)
        {
            Float[] xx = new Float[x.Length];
            for (int i = 0; i < xx.Length; i++) xx[i] = x[i] * (bounds[i * 2 + 1] - bounds[i * 2]) + bounds[i * 2];
            return xx;
        }
        public bool Transform(Cell c, double[] new_bounds)
        {
            bool feasible = true;
            for (int i = 0; i < c.x.Length; i++)
            {
                c.x[i] = c.x[i] * (bounds[i * 2 + 1] - bounds[i * 2]) + bounds[i * 2];
                c.x[i] = (c.x[i] - new_bounds[i * 2]) / (new_bounds[i * 2 + 1] - new_bounds[i * 2]);
                if (c.x[i] < 0 || c.x[i] > 1) feasible = false;
            }
            return feasible;
        }
        public Float[] CellForOutput(Cell c)
        {
            Float[] xx = new Float[c.x.Length + 1];
            for (int i = 0; i < c.x.Length; i++) xx[i] = c.x[i] * (bounds[i * 2 + 1] - bounds[i * 2]) + bounds[i * 2];
            xx[c.x.Length] = c.cost;
            return xx;
        }
        public void Next()
        {
            //if (cells_by_size == null)
            //if (cells_by_size.Count + queue.Count == 0)
            //{
            //    Init();
            //    return;
            //}
            ChooseMode();
            for (LinkedListNode<Bisection> node = bisection_queue.First, next; node != null; node = next)
            {
                next = node.Next;
                if (node.Value.evaluated == 3)
                {
                    Add(node.Value.Finish());
                    Add(node.Value.c);
                    bisection_queue.Remove(node);
                }
            }
            size_count = cells_by_size.Count;

            var candidates = Candidates();
            candidates.Reverse();
            var max_size = candidates.Count == 0 ? 0 : candidates[0].size;
            //var max_size = candidates.Count == 0 ? 0 : candidates[candidates.Count - 1].size;
            foreach (Cell c in candidates)
            {
                var b = new Bisection(this, c, false);
                queue.Enqueue(c.size == max_size ? 0 : 1, new Point(b.Evaluate, Transform(b.cc.x)));
                bisection_queue.AddLast(b);
            }

            // Debug:
            //double v1 = 0, v2 = 0, c1 = 0, c2 = 0;
            //var x = new double[] { 0, 0 };
            //DateTime created = DateTime.Now;
            //foreach (MySortedList<Cell> list in cells_by_size) foreach (Cell c in list)
            //{
            //    var v = c.Volume();
            //    if (v > v1)
            //    {
            //        v1 = v;
            //        c1 = c.cost;
            //    }
            //}
            //foreach (Bisection node in bisection_queue)
            //{
            //    var v = Math.Max(node.c.Volume(), node.cc.Volume());
            //    if (v > v2)
            //    {
            //        v2 = v;
            //        c2 = node.c.cost;
            //        created = node.created;
            //        x = Transform(node.c.x);
            //    }
            //}
        }
        public Float Volume()
        {
            Float v = 0;
            foreach (MySortedList<Cell> list in cells_by_size) foreach (Cell c in list) v += c.Volume();
            foreach (Bisection node in bisection_queue)
            {
                double v1 = node.c.Volume(), v2 = node.cc.Volume();
                v += (v1 == v2) ? v1 : v1 + v2;
            }
            return v;
        }
        public Float Integral()
        {
            Float I = 0, scale = 1;
            for (int i = 0; i < bounds.Length / 2; i++) scale *= bounds[i * 2 + 1] - bounds[i * 2];
            foreach (MySortedList<Cell> list in cells_by_size)
                foreach (Cell c in list)
                    I += c.cost * c.Volume();
            return -I * scale;
        }

        public void Evaluate(Cell c, Float cost)
        {
            calls++;
            Float[] xx = new Float[c.x.Length];
            for (int i = 0; i < xx.Length; i++) xx[i] = c.x[i] * (bounds[i * 2 + 1] - bounds[i * 2]) + bounds[i * 2];
            c.cost = cost; // objective(xx);
            if (c.cost < fbest) { fbest = c.cost; xbest = xx; }
        }

        public List<Cell> Candidates()
        {
            if (cells_by_size.Count == 0) return new List<Cell>();
            Cell[] points = SetUpCandidates(), hull = new Cell[points.Length];

            if (points.Length == 0) return new List<Cell>();
            int i, j, k, hull_count = 0;
            Float slope_0n, cost;
            hull[hull_count++] = points[0];
            slope_0n = (points[points.Length - 1].cost - points[0].cost) / (points[points.Length - 1].size - points[0].size);
            for (i = 1; i < points.Length; i++)
            {
                Cell c = points[i];
                cost = points[0].cost + slope_0n * (c.size - points[0].size);
                if (c.cost > cost + tolerance) continue; // ignore points, that are upper than line(first, last).

                if (hull_count == 1) { hull[hull_count++] = c; continue; }
                j = hull_count - 1; k = j - 1;
                cost = hull[k].cost + (hull[j].cost - hull[k].cost) * (c.size - hull[k].size) / (hull[j].size - hull[k].size);
                if (c.cost < cost + tolerance)
                {
                    hull_count--;
                    i--;
                    continue;
                }
                else hull[hull_count++] = c;
            }
            for (i = 0; i < hull_count - 1; i++)
                if (hull[i].cost - hull[i].size * (hull[i + 1].cost - hull[i].cost) / (hull[i + 1].size - hull[i].size) > fbest - epsilon * Math.Abs(fbest));
                else break;

            List<Cell> candidates = new List<Cell>();
            List<int> empties = new List<int>();
            for (; i < hull_count; i++)
            {
                Cell c = hull[i];
                MySortedList<Cell> list = cells_by_size[c.size_index];
                //for (j = list.Count - 1; j >= 0 && Math.Abs(list[j].cost - c.cost) < tolerance * tolerance; j--)
                for (j = list.Count - 1; j >= 0 && (list[j].cost == c.cost || (double.IsNaN(list[j].cost) && double.IsNaN(c.cost))); j--)
                    candidates.Add(list[j]);
                //j = list.Count - 1; candidates.Add(list[j]);
                if (j < 0) empties.Add(c.size_index); else list.RemoveRange(j + 1);
            }
            empties.Reverse(); foreach (int l in empties) cells_by_size.RemoveAt(l);
            return candidates;
        }
        public Cell[] SetUpCandidates()
        {
            int i, min_i = -1;
            for (i = 0; i < cells_by_size.Count; i++)
            {
                Cell c = cells_by_size[i][cells_by_size[i].Count - 1];
                if (min_i < 0 && Math.Abs(c.cost - fbest) < tolerance) { min_i = i; break; }
            }
            for (i = Math.Max(0, min_i); i < cells_by_size.Count && cells_by_size[i][0].size < tolerance; i++) ;
            min_i = i;
            Cell[] candidates = new Cell[cells_by_size.Count - i];
            for (; i < cells_by_size.Count; i++)
            {
                MySortedList<Cell> list = cells_by_size[i];
                candidates[i - min_i] = list[list.Count - 1];
                candidates[i - min_i].size_index = i;
            }
            return candidates;
        }

        public void ChangeBoundaries(Float[] new_bounds)
        {
            PleaseWaitForm.Value = 0;
            if (cells_by_size == null) Init();
            if (new_bounds.Length != bounds.Length) return;
            int i, dim = bounds.Length / 2;
            for (i = 0; i < bounds.Length; i += 2)
            {
                if (double.IsNaN(new_bounds[i]) || double.IsInfinity(new_bounds[i])) return;
                if (double.IsNaN(new_bounds[i + 1]) || double.IsInfinity(new_bounds[i + 1])) return;
                farthest_bounds[i] = Math.Min(farthest_bounds[i], new_bounds[i]);
                farthest_bounds[i + 1] = Math.Max(farthest_bounds[i + 1], new_bounds[i + 1]);
            }

            double[] min = new double[dim], max = new double[dim];
            for (i = 0; i < dim; i++) { min[i] = 0; max[i] = 1; }
            List<double[]> x = new List<double[]>();
            List<double> cost = new List<double>();

            // Check unfeasible cells if they are feasible again.
            for (i = unfeasible.Count - 1; i >= 0; i--)
            {
                Cell c;
                if (Transform(c = unfeasible[i], new_bounds))
                {
                    x.Add(c.x);
                    cost.Add(c.cost);
                    unfeasible.RemoveAt(i);
                }

                PleaseWaitForm.Value = (double)(unfeasible.Count - i) / unfeasible.Count / 5.0;
            }
            // Resort candidates
            foreach (Bisection bi in bisection_queue)
            {
                if ((bi.evaluated & 1) == 1)
                {
                    Cell c;
                    if (Transform(c = bi.c, new_bounds))
                    {
                        x.Add(c.x);
                        cost.Add(c.cost);
                    }
                    else unfeasible.Add(c);
                }
                else ;
            }
            // Resort active cells
            i = 0;
            foreach (MySortedList<Cell> cells in cells_by_size)
            {
                foreach (Cell c in cells)
                {
                    if (Transform(c, new_bounds))
                    {
                        x.Add(c.x);
                        cost.Add(c.cost);
                    }
                    else unfeasible.Add(c);
                }

                PleaseWaitForm.Value = (double)(i++) / cells_by_size.Count / 5.0 + 1 / 5.0;
            }
            // Add resplitted cells
            cells_by_size.Clear(); bisection_queue.Clear(); queue.Clear();
            List<Splitter.Cell> splitted = Splitter.Split3(min, max, x, cost);
            i = 0;
            foreach (Splitter.Cell c in splitted)
            {
                if (c.points.Count == 0) continue;
                Golden.Cell cell = new Golden.Cell(0, c.min, c.max, c.points[0].x);
                cell.cost = c.points[0].cost;
                cell.Size();
                Add(cell);

                PleaseWaitForm.Value = (double)(i++) / splitted.Count / 5.0 + 4 / 5.0;
            }
            bounds = new_bounds;
            if (cells_by_size.Count == 0)
            {
                //cells_by_size = null;
                //bisection_queue = null;
                queue = new PriorityQueue<int, Golden.Point>();
                Init();
            }
            PleaseWaitForm.Value = 1;
        }

        Random rand;
        public int calls, stagnation, iterations, size_count;
        public Float fbest, fbest_last, fbest_local, epsilon; // (default DIRECT's epsilon = 1e-4)
        public Float[] xbest, bounds, farthest_bounds;
        public MySortedList<MySortedList<Cell>> cells_by_size;
        public MySortedList<MySortedList<Cell>>.Cost list_cost;
        public MySortedList<Cell>.Cost cell_cost;
        public LinkedList<Bisection> bisection_queue;
        //public Queue<Point> queue;
        public PriorityQueue<int, Point> queue;
        public List<Cell> unfeasible;
    }
}