namespace ProyectoFinalAlpha.UI.Reportes
{
    partial class UsersReportViewer
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
            this.UsrReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // UsrReportViewer
            // 
            this.UsrReportViewer.ActiveViewIndex = -1;
            this.UsrReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsrReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.UsrReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsrReportViewer.Location = new System.Drawing.Point(0, 0);
            this.UsrReportViewer.Name = "UsrReportViewer";
            this.UsrReportViewer.Size = new System.Drawing.Size(800, 450);
            this.UsrReportViewer.TabIndex = 0;
            // 
            // UsersReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UsrReportViewer);
            this.Name = "UsersReportViewer";
            this.Text = "UsersReportViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer UsrReportViewer;
    }
}