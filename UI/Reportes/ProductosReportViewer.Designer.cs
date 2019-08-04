namespace ProyectoFinalAlpha.UI.Reportes
{
    partial class ProductosReportViewer
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
            this.ProdReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ProdReportViewer
            // 
            this.ProdReportViewer.ActiveViewIndex = -1;
            this.ProdReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProdReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProdReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProdReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ProdReportViewer.Name = "ProdReportViewer";
            this.ProdReportViewer.Size = new System.Drawing.Size(800, 450);
            this.ProdReportViewer.TabIndex = 0;
            this.ProdReportViewer.Load += new System.EventHandler(this.CrystalReportViewer1_Load);
            // 
            // ProductosReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProdReportViewer);
            this.Name = "ProductosReportViewer";
            this.Text = "ProductosReportViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ProdReportViewer;
    }
}