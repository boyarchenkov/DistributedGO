using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ServiceModel;
using M.Tools;

namespace DGO
{
    public partial class MainForm : Form
    {
        public static bool paused = true;
        public static TextBox details;
        public static TimeSpan log_write_interval = new TimeSpan(0, 1, 0);
        public static string log_filename = "DGO.log";
        public static float radius = 2;
        public static string estimates = String.Empty;

        public int Dim
        {
            get
            {
                return manager.Golden.bounds.Length / 2;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            MainForm.details = textBoxDetails;

            workers = new List<Thread>();
            //manager = new TaskManager(new double[] { 0.57, 0.7, 2.33, 2.39, 0.3, 0.5 }); // Pow2
            //manager = new TaskManager(new double[] { 0.59, 0.64, 2.33, 2.37, 0.3, 0.5 }); // Pow2-13
            //manager = new TaskManager(new double[] { 0.3, 0.5, 8, 16, 3, 8 }); // Exp3
            //manager = new TaskManager(new double[] { 0.56, 0.64, 0.32, 0.44, 9.5, 11.5, 4.4, 5.1 }); // Exp4
            //manager = new TaskManager(new double[] { 0.58, 0.61, 0.32, 0.44, 9.8, 11.2, 4.5, 5.4 }); // Exp4
            //manager = new TaskManager(new double[] { 0.54, 0.7, 0.28, 0.5, 9, 15, 4.2, 7.2 }); // Exp4
            //manager = new TaskManager(new double[] { 0.54, 0.7, 0.28, 0.48, 9, 12 }); // Exp4 (x4 = 0.483 * x3 - 0.310)
            //manager = new TaskManager(new double[] { 0.25, 0.45, 12, 16, 5.5, 7.0 }); // Exp4 (x1 = 0.555)
            //manager = new TaskManager(new double[] { 0.4, 0.5, 12, 15, 5.6, 7.2, 0, 80 }); // Exp4 (x1 = 0.555)
            //manager = new TaskManager(new double[] { 0.54, 0.64, 0.25, 0.5, 9, 14, 4, 7 }); // Exp4

            //manager = new TaskManager(new double[] { 0.53, 0.58, 0.28, 0.5, 9, 15, 4.2, 7.2, 0.25, 4 }); // Exp5
            //manager = new TaskManager(new double[] { 0.56, 0.61, 0.3, 0.5, 8, 12 }); // Exp4 x4 = 4.581E-01 * x3 - 1.499E-02
            //manager = new TaskManager(new double[] { 0.54, 0.61, 0.2, 0.55, 7, 16 }); // Exp4 x4 = 0.4898 * x3 - 0.3313
            //manager = new TaskManager(new double[] { 0.54, 0.58, 0.3, 0.5, 2.16, 2.3, 5, 6.8, 0.2, 1.1 }); // Exp5
            //manager = new TaskManager(new double[] { 0.5, 0.65, 0.25, 0.45, 2.12, 2.28, 3, 6, 0.5, 2 }); // Exp5

            //manager = new TaskManager(new double[] { 0.54, 0.58, 0.3, 0.5, 2.165, 2.195, 5, 6.8, 0.8, 1.1 }); // Exp5

            //manager = new TaskManager(new[] { 0.5, 0.7, 0.25, 0.5, 2.13, 2.3, 3, 7.5 }); // Exp4 2011-08-15
            //manager = new TaskManager(new[] { 0.5, 0.7, 0.25, 0.5, 2.1, 2.4, 2.5, 7.5 }); // Exp4 2011-08-21
            //manager = new TaskManager(new[] { 0.5, 0.7, 2.13, 2.4, 2.5, 5.5 }); // Exp3 2011-08-21
            //manager = new TaskManager(new[] { 0.55, 0.75, 2.15, 2.45, 2.8, 7.8 }); // Exp3 2011-08-22
            //manager = new TaskManager(new[] { 0.53, 0.69, 2.16, 2.34, 3.1, 5.9 }); // Exp3 2011-08-22

            //manager = new TaskManager(new[] { 2.2, 2.3, 2.5, 5.0 }); // Exp2 2011-08-29
            // Q = 0.6, 14000 trials, 35 minutes, box size <= 9.546e-3, cost >= 0.8867
            //manager = new TaskManager(new[] { 2.16, 2.3, 3.0, 6.0 }); // Exp2 2011-08-30

            //manager = new TaskManager(new[] { 0.5, 0.7, 2.14, 2.4, 2.5, 6.0 }); // Exp4 with 3 params (1)
            //manager = new TaskManager(new[] { 0.54, 0.68, 2.16, 2.32, 3.2, 5.6 }); // Exp4 with 3 params

            //MOX-07: 0.68623, exp(4.7), -5.52, 74.796, exp(2.941), -2.78385
            //manager = new TaskManager(new[] { 3.0, 6.0, 5.0, 7.0, 10, 50, 2.95, 3.2, 2.8, 3.1 }); // BM5 with 5 params: "MOX-07"-like potentials
            //manager = new TaskManager(new[] { 2.7, 4.0, 2.5, 4.0 }); // BM2 with 2 params: "MOX-07"-like potentials for ThO2 (only Th-O potential is parameterized)
            // 7.8, 8.3, 3.25, 3.45
            //manager = new TaskManager(new[] { 5.4, 5.6, 2.2, 2.4 }); // BM2 with 2 params: "MOX-07"-like potentials for ThO2 (only Th-O potential is parameterized)
            //manager = new TaskManager(new[] { 5.0, 24.0, 2.0, 10.0 }); // BM2 with 2 params: "MOX-07"-like potentials for ThO2 (only Th-O potential is parameterized)
            //manager = new TaskManager(new[] { 8.0, 11.0, 3.0, 4.0 }); // BM2 with 2 params: "MOX-07"-like potentials for ThO2 (only Th-O potential is parameterized)
            //manager = new TaskManager(new[] { 7.95, 8.25, 3.27, 3.44 }); // BM2 with 2 params: "MOX-07"-like potentials for ThO2 (only Th-O potential is parameterized)
            //manager = new TaskManager(new[] { 7.7, 8.4, 3.2, 3.5 }); // BM2 with 2 params: "MOX-07"-like potentials for ThO2 (only Th-O potential is parameterized)
            manager = new TaskManager(new[] { 8.055, 8.1, 3.34, 3.36 }); // BM2 with 2 params: "MOX-07"-like potentials for ThO2 (only Th-O potential is parameterized)
            //manager = new TaskManager(new[] { 0.4, 1.6, 0.6, 2.5, 1.2, 4.7 }); // Morse3 with 3 params: "Yamada-00"-like potentials for UO2

            calls0 = manager.Golden.calls;
            Run(manager.PrepareNextPointsLoop);

            try
            {
                host = new ServiceHost(manager);
                host.Open();
            }
            catch (TimeoutException timeProblem) { MessageBox.Show(timeProblem.Message, "TimeoutException"); }
            catch (CommunicationException commProblem) { MessageBox.Show(commProblem.Message, "CommunicationException"); }

            DefaultBounds();
            for (int i = 1; i <= Dim; i++)
            {
                comboBoxXAxis.Items.Add("x" + i);
                comboBoxYAxis.Items.Add("x" + i);
            }
            comboBoxXAxis.Items.Add("cost");
            comboBoxYAxis.Items.Add("cost");
            comboBoxXAxis.SelectedIndex = 0;
            comboBoxYAxis.SelectedIndex = comboBoxYAxis.Items.Count - 1;

            panelMap.Cursor = Cursors.Cross;
            map_kx = map_ky = float.PositiveInfinity; map_bx = map_by = 0;

            timer = new System.Threading.Timer(UpdateSummaryInvoke, null, 0, 1000);
        }

        private void DefaultBounds()
        {
            bounds = new double[manager.Golden.bounds.Length + 2];
            manager.Golden.bounds.CopyTo(bounds, 0);
            bounds[bounds.Length - 2] = 0;
            bounds[bounds.Length - 1] = 4;

            UpdateBoundsInTextbox();
        }
        private void GetBound(TextBox text, ref double new_value, ref double saved_value)
        {
            if (double.TryParse(text.Text, out new_value))
                saved_value = new_value;
            else
                text.Text = saved_value.ToString();
        }
        private void UpdateBoundsInTextbox()
        {
            int x = comboBoxXAxis.SelectedIndex, y = comboBoxYAxis.SelectedIndex;
            if (x >= 0)
            {
                textBoxXFrom.Text = bounds[x * 2].ToString();
                textBoxXTo.Text = bounds[x * 2 + 1].ToString();
            }
            if (y >= 0)
            {
                textBoxYFrom.Text = bounds[y * 2].ToString();
                textBoxYTo.Text = bounds[y * 2 + 1].ToString();
            }
        }
        private void Save()
        {
            using (System.IO.StreamWriter w = new System.IO.StreamWriter("results.txt"))
                foreach (M.Tools.MySortedList<Golden.Cell> list in manager.Golden.cells_by_size)
                    foreach (Golden.Cell cell in list)
                    {
                        for (int i = 0; i < cell.x.Length; i++) { w.Write(cell.x[i]); w.Write('\t'); }
                        w.Write(cell.cost);
                        w.WriteLine();
                    }
        }
        private void Run(ThreadStart start)
        {
            Thread t = new Thread(start); t.IsBackground = true;
            workers.Add(t);
            t.Start();
        }

        private void UpdateSummary()
        {
            double speed = 0, flops = 0;
            lock (manager.Computers)
            {
                listViewClients.BeginUpdate();
                listViewClients.Items.Clear();
                foreach (Computer c in manager.Computers)
                {
                    flops += c.Perfomance; speed += c.Speed;
                    listViewClients.Items.Add(new ListViewItem(new string[] {
                        c.ID.ToString(),
                        c.Processed.ToString(),
                        c.Speed.ToString("F3"),
                        c.EffPerfomance.ToString("F3"),
                        c.UsefulTime.ToString(),
                        c.LastReceive.ToString(),
                        (!c.IsTimedOut).ToString(),
                        c.Lag.ToString("F3")
                    }));
                }
                listViewClients.EndUpdate();
            }
            TimeSpan running = DateTime.Now.Subtract(Process.GetCurrentProcess().StartTime);
            labelRunning.Text = String.Format("{0}:{1}:{2}",
                Math.Floor(running.TotalHours).ToString().PadLeft(2, '0'),
                running.Minutes.ToString().PadLeft(2, '0'),
                running.Seconds.ToString().PadLeft(2, '0'));
            labelComputers.Text = manager.Computers.Count.ToString();
            labelTotalPerfomance.Text = String.Format("{0:F1} GFLOPS", flops);
            labelTotalSpeed.Text = String.Format("{0:F0} steps/sec", speed);
            labelSentPoints.Text = manager.SentPoints.Count.ToString();
            labelLastAutosave.Text = manager.LastAutosaveTime.ToString();

            Golden g = manager.Golden;
            labelTrials.Text = g.calls.ToString();
            if (Monitor.TryEnter(g, 100))
            {
                if (g.cells_by_size != null)
                {
                    int count = g.cells_by_size.Count;
                    labelBoxSizeCount.Text = count.ToString();
                    if (count > 0)
                        labelBoxMaxSize.Text = String.Format("{0:E3} (count={1})", g.cells_by_size[count - 1][0].size, g.cells_by_size[count - 1].Count);
                }
                Monitor.Exit(g);
            }
            labelMinCost.Text = manager.Golden.fbest.ToString("F8");

            if (DateTime.Now.Subtract(log_written) >= log_write_interval)
            {
                using (StreamWriter w = new StreamWriter(log_filename, true))
                {
                    w.Write(DateTime.Now); w.Write('\t');
                    w.Write(labelRunning.Text); w.Write('\t');
                    w.Write(labelComputers.Text); w.Write('\t');
                    w.Write(labelTotalPerfomance.Text); w.Write('\t');
                    w.Write(labelTotalSpeed.Text); w.Write('\t');
                    w.Write(labelSentPoints.Text); w.Write('\t');
                    w.Write(labelTrials.Text); w.Write('\t');
                    w.Write(labelBoxSizeCount.Text); w.Write('\t');
                    w.Write(labelBoxMaxSize.Text); w.Write('\t');
                    w.Write(labelMinCost.Text);
                    if (paused) w.Write("\tPAUSED");
                    w.WriteLine();
                }
                log_written = DateTime.Now;
            }
            lock (this) update_started = false;
        }
        delegate void VoidDelegate();
        private void UpdateSummaryInvoke(object state)
        {
            lock (this)
            {
                if (update_started) return;
                update_started = true;
            }
            try
            {
                Invoke(new VoidDelegate(UpdateSummary));
            }
            catch (ObjectDisposedException)
            {
            }
        }

        private void Render(Bitmap bitmap)
        {
            int i, x = comboBoxXAxis.SelectedIndex, y = comboBoxYAxis.SelectedIndex;
            if (x < 0 || y < 0) return;
            double[] from_x = new double[Dim], to_x = new double[Dim];
            double from_cost = bounds[Dim * 2], to_cost = bounds[Dim * 2 + 1];
            //double from_cost = double.NegativeInfinity, to_cost = double.PositiveInfinity;
            double x0 = 0, x1 = 0, y0 = 0, y1 = 0, kx, ky;

            // Get bounds from textboxes
            for (i = 0; i < from_x.Length; i++)
            {
                from_x[i] = bounds[i * 2]; to_x[i] = bounds[i * 2 + 1];
                //from_x[i] = double.NegativeInfinity; to_x[i] = double.PositiveInfinity;
                if (x == i)
                {
                    GetBound(textBoxXFrom, ref from_x[i], ref bounds[i * 2]); x0 = bounds[i * 2];
                    GetBound(textBoxXTo, ref to_x[i], ref bounds[i * 2 + 1]); x1 = bounds[i * 2 + 1];
                }
                if (y == i)
                {
                    GetBound(textBoxYFrom, ref from_x[i], ref bounds[i * 2]); y0 = bounds[i * 2];
                    GetBound(textBoxYTo, ref to_x[i], ref bounds[i * 2 + 1]); y1 = bounds[i * 2 + 1];
                }
            }
            if (x == Dim)
            {
                GetBound(textBoxXFrom, ref from_cost, ref bounds[x * 2]); x0 = bounds[i * 2];
                GetBound(textBoxXTo, ref to_cost, ref bounds[x * 2 + 1]); x1 = bounds[i * 2 + 1];
            }
            if (y == Dim)
            {
                GetBound(textBoxYFrom, ref from_cost, ref bounds[y * 2]); y0 = bounds[i * 2];
                GetBound(textBoxYTo, ref to_cost, ref bounds[y * 2 + 1]); y1 = bounds[i * 2 + 1];
            }                

            // Get the points inside the specified boundaries
            List<double[]> points;
            lock (manager.Golden)
            {
                double from = 0, to = 10;
                if (!double.TryParse(textBoxCostFrom.Text, out from)) textBoxCostFrom.Text = from.ToString();
                if (!double.TryParse(textBoxCostTo.Text, out to)) textBoxCostTo.Text = to.ToString();
                points = new List<double[]>();
                i = 0;
                foreach (MySortedList<Golden.Cell> cells in manager.Golden.cells_by_size)
                {
                    foreach (Golden.Cell cell in cells)
                    {
                        bool passed = true;
                        double[] xx = manager.Golden.CellForOutput(cell);
                        for (i = 0; i < from_x.Length; i++)
                            if (xx[i] < from_x[i] || xx[i] > to_x[i]) { passed = false; break; }
                        i = from_x.Length;
                        if (xx[i] < from_cost || xx[i] > to_cost || double.IsNaN(xx[i])) passed = false;
                        if (passed) points.Add(xx);
                    }

                    PleaseWaitForm.Value = (double)(i++) / manager.Golden.cells_by_size.Count / 2.0;
                }
                foreach (Golden.Bisection bi in manager.Golden.bisection_queue)
                {
                    Golden.Cell cell = bi.c;
                    bool passed = true;
                    double[] xx = manager.Golden.CellForOutput(cell);
                    for (i = 0; i < from_x.Length; i++)
                        if (xx[i] < from_x[i] || xx[i] > to_x[i]) { passed = false; break; }
                    i = from_x.Length;
                    if (xx[i] < from_cost || xx[i] > to_cost || double.IsNaN(xx[i])) passed = false;
                    if (passed) points.Add(xx);
                }
            }

            // Prepare the render target
            Brush brush = new SolidBrush(Color.FromArgb(100, Color.Green));
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.LightGray);

            // Compute linear coordinate transformation
            RectangleF g_bounds = g.VisibleClipBounds;
            kx = (g_bounds.Width - 2 * radius) / (x1 - x0);
            ky = (g_bounds.Height - 2 * radius) / (y1 - y0);
            if (bitmap == this.bitmap)
            {
                map_kx = (float)kx; map_ky = (float)ky;
                map_bx = (float)x0; map_by = (float)y1;
            }

            // Draw grid
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            double dx = x1 - x0, step_x = Math.Pow(10, Math.Round(Math.Log10(dx)) - 1); // Excel: =10^(ÎÊÐÓÃË(LOG(A1;10);0)-1)
            if (dx / step_x > 20) step_x *= 4; if (dx / step_x > 10) step_x *= 2; // 4-10 lines
            double dy = y1 - y0, step_y = Math.Pow(10, Math.Round(Math.Log10(dy)) - 1);
            if (dy / step_y > 20) step_y *= 4; if (dy / step_y > 10) step_y *= 2;
            if (drawVerticalLinesToolStripMenuItem.Checked)
                for (double grid_x = Math.Ceiling(x0 / step_x) * step_x; grid_x < x1; grid_x += step_x)
                {
                    float px = (float)((grid_x - x0) * kx + g_bounds.Left + radius);
                    g.DrawLine(Pens.Black, px, 0, px, g_bounds.Height);
                }
            if (drawHorizontalLinesToolStripMenuItem.Checked)
                for (double grid_y = Math.Ceiling(y0 / step_y) * step_y; grid_y < y1; grid_y += step_y)
                {
                    float py = (float)((grid_y - y0) * ky + g_bounds.Left + radius);
                    g.DrawLine(Pens.Black, 0, py, g_bounds.Width, py);
                }
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Draw points
            for (i = 0; i < points.Count; i++)
            {
                double[] p = points[i];
                float px = (float)((p[x] - x0) * kx + g_bounds.Left + radius);
                float py = (float)((y1 - p[y]) * ky + g_bounds.Top + radius);
                g.FillEllipse(brush, px - radius, py - radius, 2 * radius, 2 * radius);
                PleaseWaitForm.Value = (double)i / points.Count / 2.0 + 1 / 2.0;
            }
            PleaseWaitForm.Value = 1;
        }
        private void SaveMap(string filename)
        {
            Bitmap bitmap = new Bitmap(1024, 768);
            Render(bitmap);
            bitmap.Save(filename);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            host.Close();
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (buttonPause.Text == "=")
            {
                buttonPause.Text = ">";
                paused = true;
            }
            else
            {
                buttonPause.Text = "=";
                paused = false;
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            lock (manager.Golden)
            {
                double from = 0, to = 10;
                if (!double.TryParse(textBoxCostFrom.Text, out from)) textBoxCostFrom.Text = from.ToString();
                if (!double.TryParse(textBoxCostTo.Text, out to)) textBoxCostTo.Text = to.ToString();
                var points = new List<double[]>();
                var s = new StringBuilder();
                foreach (var cells in manager.Golden.cells_by_size)
                    foreach (var cell in cells)
                        if (cell.cost >= from && cell.cost <= to)
                            points.Add(manager.Golden.CellForOutput(cell));
                foreach (var bi in manager.Golden.bisection_queue)
                    if (bi.c.cost >= from && bi.c.cost <= to)
                        points.Add(manager.Golden.CellForOutput(bi.c));
                points.Sort((a, b) => a[a.Length - 1].CompareTo(b[b.Length - 1]));
                foreach (var line in points)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        s.Append(line[i].ToString("F9"));
                        if (i < line.Length - 1) s.Append('\t');
                    }
                    s.AppendLine();
                }
                textBoxDetails.Clear();
                textBoxDetails.Paste(s.ToString());
            }
        }
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            buttonShow_Click(sender, e);
            Clipboard.SetText(textBoxDetails.Text, TextDataFormat.UnicodeText);
        }

        private void comboBoxXYAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBoundsInTextbox();
        }
        private void buttonRender_Click(object sender, EventArgs e)
        {
            Graphics g = panelMap.CreateGraphics(); SizeF size = g.VisibleClipBounds.Size;
            if (bitmap == null || bitmap.Width != size.Width || bitmap.Height != size.Height)
                bitmap = new Bitmap((int)size.Width, (int)size.Height);
            Render(bitmap);
            map_filename = String.Format("{0},{1} @{2}.png",
                comboBoxXAxis.SelectedItem, comboBoxYAxis.SelectedItem, manager.Golden.calls);
            saveToolStripMenuItem.Text = "Save As <" + map_filename + ">";
            panelMap.Refresh();
        }
        private void buttonDefaultBounds_Click(object sender, EventArgs e)
        {
            DefaultBounds();
        }
        private void panelMap_Paint(object sender, PaintEventArgs e)
        {
            float border = radius;
            Graphics g = e.Graphics;
            SizeF size = g.VisibleClipBounds.Size;
            if (bitmap == null || bitmap.Width != size.Width || bitmap.Height != size.Height) return;
            g.DrawImageUnscaled(bitmap, 0, 0);
        }
        private void panelMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = panelMap.PointToClient(Form.MousePosition);
                if (p.X < radius || p.Y < radius || p.X > panelMap.ClientSize.Width - radius || p.Y > panelMap.ClientSize.Height - radius)
                    return;
                float x = (p.X - radius) / map_kx + map_bx, y = map_by - (p.Y - radius) / map_ky;
                toolTipCoords.Show(String.Format("{0}  {1}", x, y), panelMap, p.X, p.Y + Cursor.Size.Height / 2, 2000);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap(map_filename);
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveMapDialog.FileName = map_filename;
            if (saveMapDialog.ShowDialog() == DialogResult.OK) SaveMap(saveMapDialog.FileName);
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedTab.Text)
            {
                case "Bounds":
                    lock (manager.Golden)
                    {
                        Golden g = manager.Golden;
                        StringBuilder bounds = new StringBuilder(), farthest = new StringBuilder();
                        for (int i = 0; i < g.bounds.Length; i += 2)
                        {
                            bounds.AppendFormat("{0}; {1}\r\n", g.bounds[i], g.bounds[i + 1]);
                            farthest.AppendFormat("{0}; {1}\r\n", g.farthest_bounds[i], g.farthest_bounds[i + 1]);
                        }
                        textBoxCurrentBoundaries.Text = bounds.ToString();
                        textBoxFarthestBoundaries.Text = farthest.ToString();
                    }
                    break;
                case "Top":
                    textBoxTop.Clear();
                    textBoxTop.AppendText(manager.TopList);
                    break;
                case "Estimate":
                    textBoxEstimate.Text = estimates;
                    break;
            }
        }
        private void buttonApplyBoundaries_Click(object sender, EventArgs e)
        {
            List<double> new_bounds = new List<double>();
            foreach (string number in textBoxCurrentBoundaries.Text.Split('\r', '\n', ';', ' '))
            {
                if (number.Length == 0) continue;
                double d = 0;
                if (double.TryParse(number, out d)) new_bounds.Add(d);
            }
            manager.ChangeBoundaries(new_bounds.ToArray());
            DefaultBounds();
        }
        private void buttonAppendEstimate_Click(object sender, EventArgs e)
        {
            Utility.SetDecimalSeparator();

            List<double> parameters = new List<double>();
            string s = textBoxEstimateParams.Text;
            if (s.IndexOf('.') < 0)
            {
                s = s.Replace(", ", "; ");
                s = s.Replace(',', '.');
            }
            foreach (string word in s.Split(' ', ',', ';', '\t'))
            {
                string w = word.Trim();
                if (w.Length == 0) continue;
                if (w.StartsWith("/")) break;
                double number = 0;
                if (double.TryParse(w, out number)) parameters.Add(number);
            }
            if (parameters.Count > 1)
            {
                manager.AddEstimate(parameters.ToArray());
                textBoxEstimateParams.Text = "/" + textBoxEstimateParams.Text;
                textBoxEstimate.Text = estimates += textBoxEstimateParams.Text + "\r\n";
            }
            else
            {
                textBoxEstimate.Text = estimates += "not enough parameters. \r\n";
            }
        }
        private void buttonSaveExit_Click(object sender, EventArgs e)
        {
            manager.Close();
            manager.Save();
            Close();
        }

        List<Thread> workers;
        TaskManager manager;
        ServiceHost host;
        System.Threading.Timer timer;
        int calls0;
        bool update_started = false;
        DateTime log_written;
        double[] bounds;
        Bitmap bitmap;
        float map_kx, map_ky, map_bx, map_by;
        string map_filename;
    }
}