namespace ProyectoFinalAlpha.UI.Consultas
{
    partial class cUsuarios
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
            this.EditarButton = new System.Windows.Forms.Button();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.CriterioTextBox = new System.Windows.Forms.TextBox();
            this.FiltrarComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConsultaDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EditarButton
            // 
            this.EditarButton.Location = new System.Drawing.Point(660, 77);
            this.EditarButton.Name = "EditarButton";
            this.EditarButton.Size = new System.Drawing.Size(75, 23);
            this.EditarButton.TabIndex = 34;
            this.EditarButton.Text = "Editar";
            this.EditarButton.UseVisualStyleBackColor = true;
            this.EditarButton.Click += new System.EventHandler(this.EditarButton_Click);
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConsultarButton.Location = new System.Drawing.Point(660, 16);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(82, 33);
            this.ConsultarButton.TabIndex = 33;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // CriterioTextBox
            // 
            this.CriterioTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CriterioTextBox.Location = new System.Drawing.Point(278, 20);
            this.CriterioTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CriterioTextBox.Name = "CriterioTextBox";
            this.CriterioTextBox.Size = new System.Drawing.Size(377, 20);
            this.CriterioTextBox.TabIndex = 32;
            // 
            // FiltrarComboBox
            // 
            this.FiltrarComboBox.FormattingEnabled = true;
            this.FiltrarComboBox.Items.AddRange(new object[] {
            "Todo",
            "ID",
            "Nombre",
            "Cedula",
            "Telefono",
            "Direccion"});
            this.FiltrarComboBox.Location = new System.Drawing.Point(23, 23);
            this.FiltrarComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.FiltrarComboBox.Name = "FiltrarComboBox";
            this.FiltrarComboBox.Size = new System.Drawing.Size(92, 21);
            this.FiltrarComboBox.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Criterio";
            // 
            // ConsultaDataGridView
            // 
            this.ConsultaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsultaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultaDataGridView.Location = new System.Drawing.Point(11, 54);
            this.ConsultaDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.ConsultaDataGridView.Name = "ConsultaDataGridView";
            this.ConsultaDataGridView.RowTemplate.Height = 24;
            this.ConsultaDataGridView.Size = new System.Drawing.Size(632, 385);
            this.ConsultaDataGridView.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Filtro";
            // 
            // cUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditarButton);
            this.Controls.Add(this.ConsultarButton);
            this.Controls.Add(this.CriterioTextBox);
            this.Controls.Add(this.FiltrarComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConsultaDataGridView);
            this.Name = "cUsuarios";
            this.Text = "cUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.ConsultaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EditarButton;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.TextBox CriterioTextBox;
        private System.Windows.Forms.ComboBox FiltrarComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ConsultaDataGridView;
        private System.Windows.Forms.Label label1;
    }
}