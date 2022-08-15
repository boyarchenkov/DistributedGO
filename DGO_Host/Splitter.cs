using System;
using System.Collections.Generic;
using System.Drawing;
using Float = System.Double;

namespace DGO
{
    public class Splitter
    {
        public static Float golden = 0.5 * (Math.Sqrt(5) - 1);

        public class Point
        {
            public Point(double[] x, double cost)
            {
                this.x = x; this.cost = cost;
            }

            public override string ToString()
            {
                return M.Tools.Utility.Join(x, ' ') + ": " + cost;
            }

            public double[] x;
            public double cost;
        }
        public class Cell
        {
            public Cell(double[] min, double[] max)
            {
                this.min = new Float[min.Length]; min.CopyTo(this.min, 0);
                this.max = new Float[max.Length]; max.CopyTo(this.max, 0);
                points = new List<Point>();
            }
            public Cell Split(int dim, double value)
            {
                Cell cell = new Cell(min, max);
                List<Point> new_points = new List<Point>();
                cell.min[dim] = max[dim] = value;
                for (int i = 0; i < points.Count; i++)
                    if (points[i].x[dim] < value) new_points.Add(points[i]); else cell.points.Add(points[i]);
                if (cell.points.Count == 0 || new_points.Count == 0) return null; // there must be at least one point in each cell
                points = new_points;
                return cell;
            }

            public double[] min, max;
            public List<Point> points;
        }

        // Start from point with max size (max distance to any border)
        public static List<Cell> Split(double[] min, double[] max, IList<double[]> x, IList<double> cost)
        {
            int i, j, k, l, dim, count;
            List<Cell> cells = new List<Cell>();
            Cell c = new Cell(min, max);
            for (i = 0; i < x.Count; i++) c.points.Add(new Point(x[i], cost[i]));
            c.points.Sort(delegate(Point a, Point b) { return a.cost.CompareTo(b.cost); });
            cells.Add(c);
            while (cells.Count > 0 && cells.Count < x.Count)
            {
                count = cells.Count;
                for (l = 0; l < count; l++)
                {
                    c = cells[l]; if (c.points.Count <= 1) continue;
                    j = dim = 0;
                    double size, max_size = 0;

                    double[] min_ = new double[min.Length], max_ = new double[max.Length];
                    for (k = 0; k < min.Length; k++)
                    {
                        min_[k] = double.PositiveInfinity;
                        max_[k] = double.NegativeInfinity;
                    }
                    for (i = 0; i < c.points.Count; i++)
                        for (k = 0; k < min.Length; k++)
                        {
                            if (c.points[i].x[k] < min_[k]) min_[k] = c.points[i].x[k];
                            if (c.points[i].x[k] > max_[k]) max_[k] = c.points[i].x[k];
                        }

                    // Select point with max size (size = max distance to any border)
                    for (i = 0; i < c.points.Count; i++)
                    {
                        if (c.points[i].cost > c.points[0].cost) break; // Consider only points with best cost
                        for (k = 0; k < min.Length; k++)
                        {
                            size = Math.Max(c.points[i].x[k] - min_[k], max_[k] - c.points[i].x[k]);
                            if (size > max_size)
                            {
                                j = i;
                                dim = k;
                                max_size = size;
                            }
                        }
                    }

                    // Split box by selected dimension
                    Cell next;
                    if (c.points[j].x[dim] - min_[dim] < max_[dim] - c.points[j].x[dim])
                        next = c.Split(dim, (1 - golden) * c.points[j].x[dim] + golden * max_[dim]);
                    else
                        next = c.Split(dim, (1 - golden) * c.points[j].x[dim] + golden * min_[dim]);
                    cells.Add(next);
                }
            }
            return cells;
        }
        // Start from the most distant pair (best point), (worst point)
        public static List<Cell> Split2(double[] min, double[] max, IList<double[]> x, IList<double> cost)
        {
            int i, j, k, l, dim, count, max_i, max_j;
            List<Cell> cells = new List<Cell>();
            Cell c = new Cell(min, max);
            for (i = 0; i < x.Count; i++) c.points.Add(new Point(x[i], cost[i]));
            c.points.Sort(delegate(Point a, Point b) { return a.cost.CompareTo(b.cost); });
            cells.Add(c);
            while (cells.Count > 0 && cells.Count < x.Count)
            {
                count = cells.Count;
                for (l = 0; l < count; l++)
                {
                    c = cells[l]; if (c.points.Count <= 1) continue;
                    max_i = max_j = dim = 0;
                    double size, max_size = 0;

                    // Select the most distant pair (best point), (worst point)
                    for (i = 0; i < c.points.Count; i++)
                    {
                        if (c.points[i].cost > c.points[0].cost) break; // Consider only points with best cost
                        for (j = c.points.Count - 1; j >= 0; j--)
                        {
                            if (c.points[j].cost < c.points[c.points.Count - 1].cost) break; // Consider only points with worst cost
                            for (k = 0; k < min.Length; k++)
                            {
                                size = Math.Abs(c.points[i].x[k] - c.points[j].x[k]);
                                if (size > max_size)
                                {
                                    max_i = i;
                                    max_j = j;
                                    dim = k;
                                    max_size = size;
                                }
                            }
                        }
                    }

                    // Split box by selected dimension
                    cells.Add(c.Split(dim, (1 - golden) * c.points[max_i].x[dim] + golden * c.points[max_j].x[dim]));
                }
            }
            return cells;
        }
        // Start from the most distant neighbours by the selected dimension
        public static List<Cell> Split3(double[] min, double[] max, IList<double[]> x, IList<double> cost)
        {
            int i, k, l, dim, count, max_i;
            List<Cell> cells = new List<Cell>();
            Cell c = new Cell(min, max);
            for (i = 0; i < x.Count; i++)
            {
                c.points.Add(new Point(x[i], cost[i]));
                PleaseWaitForm.Value = (double)i / x.Count / 5.0 + 2 / 5.0;
            }
            //c.points.Sort(delegate(Point a, Point b) { return a.cost.CompareTo(b.cost); });
            cells.Add(c);
            int iterations = 0;
            while (cells.Count > 0 && cells.Count < x.Count)
            {
                count = cells.Count;
                for (l = 0; l < count; l++)
                {
                    c = cells[l]; if (c.points.Count <= 1) continue;
                    max_i = dim = 0;
                    double size, max_size = 0;

                    double[] min_ = new double[min.Length], max_ = new double[max.Length];
                    for (k = 0; k < min.Length; k++)
                    {
                        min_[k] = double.PositiveInfinity;
                        max_[k] = double.NegativeInfinity;
                    }
                    for (i = 0; i < c.points.Count; i++)
                        for (k = 0; k < min.Length; k++)
                        {
                            if (c.points[i].x[k] < min_[k]) min_[k] = c.points[i].x[k];
                            if (c.points[i].x[k] > max_[k]) max_[k] = c.points[i].x[k];
                        }
                    // Select dimension with maximum variance of point coordinates
                    for (k = 1; k < min.Length; k++)
                        if ((max_[k] - min_[k]) / (max[k] - min[k]) > (max_[dim] - min_[dim]) / (max[k] - min[k])) dim = k;

                    // Select the most distant neighbours by the selected dimension
                    c.points.Sort(delegate(Point a, Point b) { return a.x[dim].CompareTo(b.x[dim]); });
                    for (i = 0; i < c.points.Count - 1; i++)
                    {
                        size = c.points[i + 1].x[dim] - c.points[i].x[dim];
                        if (max_size < size)
                        {
                            max_i = i;
                            max_size = size;
                        }
                    }

                    // Split box by selected dimension
                    i = max_i;
                    if (c.points[i].cost < c.points[i + 1].cost)
                        cells.Add(c.Split(dim, (1 - golden) * c.points[i].x[dim] + golden * c.points[i + 1].x[dim]));
                    else
                        cells.Add(c.Split(dim, (1 - golden) * c.points[i + 1].x[dim] + golden * c.points[i].x[dim]));

                    PleaseWaitForm.Value = (double)(iterations++) / x.Count / 5.0 + 3 / 5.0;
                }
            }
            return cells;
        }

        public static void Render(List<Cell> cells, Graphics g)
        {
            SizeF size = g.VisibleClipBounds.Size;
            float kx = size.Width, ky = size.Height, padding = 1;
            foreach (Cell c in cells)
            {
                float left = (float)(c.min[0]) * kx, right = (float)(c.max[0]) * kx;
                float top = (float)(c.min[1]) * ky, bottom = (float)(c.max[1]) * ky;
                g.DrawRectangle(Pens.Green, left + padding, top + padding, right - left - 2 * padding, bottom - top - 2 * padding);
            }
        }
    }
}
