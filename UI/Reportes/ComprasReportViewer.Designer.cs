﻿namespace ProyectoFinalAlpha.UI.Reportes
{
    partial class ComprasReportViewer
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
            this.CompReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CompReportViewer
            // 
            this.CompReportViewer.ActiveViewIndex = -1;
            this.CompReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CompReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CompReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CompReportViewer.Name = "CompReportViewer";
            this.CompReportViewer.Size = new System.Drawing.Size(800, 450);
            this.CompReportViewer.TabIndex = 0;
            // 
            // ComprasReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CompReportViewer);
            this.Name = "ComprasReportViewer";
            this.Text = "ComprasReportViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CompReportViewer;
    }
}