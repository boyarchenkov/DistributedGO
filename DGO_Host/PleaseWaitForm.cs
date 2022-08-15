using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DGO
{
    public partial class PleaseWaitForm : Form
    {
        public static bool IsBusy
        {
            get
            {
                return last_value > 0 && last_value < 1;
            }
        }
        public static double Value
        {
            get
            {
                return (double)form.progressBar1.Value / form.progressBar1.Maximum;
            }
            set
            {
                last_value = value;
                if (form.IsDisposed) form = new PleaseWaitForm();
                int i = form.progressBar1.Value = (int)Math.Round(value * form.progressBar1.Maximum);
                if (i == 0 && !form.Visible) ShowIt(); else if (i == 100 && form.Visible) HideIt();
                if (DateTime.Now.Subtract(updated).TotalSeconds > 0.5)
                {
                    form.labelPercents.Text = (value * form.progressBar1.Maximum).ToString("F1") + "%";
                    Application.DoEvents();
                    updated = DateTime.Now;
                }
            }
        }
        public static void ShowIt() { form.Location = center_location; form.Show(); }
        public static void HideIt() { form.Hide(); }

        static DateTime updated;
        static PleaseWaitForm form;
        static Point center_location;
        static double last_value;
        static PleaseWaitForm()
        {
            form = new PleaseWaitForm();
            form.Show(); center_location = form.Location; form.Hide();
            form.progressBar1.Value = 0; last_value = 0;
            updated = DateTime.Now;
        }

        public PleaseWaitForm()
        {
            InitializeComponent();
        }
    }
}