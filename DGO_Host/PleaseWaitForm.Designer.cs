namespace DGO
{
    partial class PleaseWaitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelPercents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(517, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Value = 50;
            // 
            // labelPercents
            // 
            this.labelPercents.AutoSize = true;
            this.labelPercents.BackColor = System.Drawing.Color.Transparent;
            this.labelPercents.Location = new System.Drawing.Point(240, 3);
            this.labelPercents.Name = "labelPercents";
            this.labelPercents.Size = new System.Drawing.Size(36, 13);
            this.labelPercents.TabIndex = 1;
            this.labelPercents.Text = "50.0%";
            this.labelPercents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PleaseWaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 23);
            this.Controls.Add(this.labelPercents);
            this.Controls.Add(this.progressBar1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PleaseWaitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please wait...";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelPercents;
    }
}