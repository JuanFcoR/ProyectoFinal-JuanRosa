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
            this.ConsultaDataGridView = new System.Windows.Forms.DataGridView();
            this.EditarButton = new System.Windows.Forms.Button();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CriterioTextBox = new System.Windows.Forms.TextBox();
            this.FiltrarComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FechasCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HastaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DesdeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ImprimirButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultaDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsultaDataGridView
            // 
            this.ConsultaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsultaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultaDataGridView.Location = new System.Drawing.Point(6, 99);
            this.ConsultaDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.ConsultaDataGridView.Name = "ConsultaDataGridView";
            this.ConsultaDataGridView.RowTemplate.Height = 24;
            this.ConsultaDataGridView.Size = new System.Drawing.Size(968, 307);
            this.ConsultaDataGridView.TabIndex = 29;
            // 
            // EditarButton
            // 
            this.EditarButton.Location = new System.Drawing.Point(879, 60);
            this.EditarButton.Name = "EditarButton";
            this.EditarButton.Size = new System.Drawing.Size(93, 20);
            this.EditarButton.TabIndex = 34;
            this.EditarButton.Text = "Editar Seleccion";
            this.EditarButton.UseVisualStyleBackColor = true;
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Location = new System.Drawing.Point(879, 17);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(93, 37);
            this.ConsultarButton.TabIndex = 33;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CriterioTextBox);
            this.panel2.Controls.Add(this.FiltrarComboBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(394, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(470, 53);
            this.panel2.TabIndex = 31;
            // 
            // CriterioTextBox
            // 
            this.CriterioTextBox.Location = new System.Drawing.Point(240, 18);
            this.CriterioTextBox.Name = "CriterioTextBox";
            this.CriterioTextBox.Size = new System.Drawing.Size(219, 20);
            this.CriterioTextBox.TabIndex = 8;
            // 
            // FiltrarComboBox
            // 
            this.FiltrarComboBox.FormattingEnabled = true;
            this.FiltrarComboBox.Items.AddRange(new object[] {
            "Id",
            "Nombres",
            "Usuarios",
            "Acceso"});
            this.FiltrarComboBox.Location = new System.Drawing.Point(54, 17);
            this.FiltrarComboBox.Name = "FiltrarComboBox";
            this.FiltrarComboBox.Size = new System.Drawing.Size(121, 21);
            this.FiltrarComboBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(9, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filtro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(181, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Criterio";
            // 
            // FechasCheckBox
            // 
            this.FechasCheckBox.AutoSize = true;
            this.FechasCheckBox.Checked = true;
            this.FechasCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FechasCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.FechasCheckBox.Location = new System.Drawing.Point(72, 12);
            this.FechasCheckBox.Name = "FechasCheckBox";
            this.FechasCheckBox.Size = new System.Drawing.Size(107, 21);
            this.FechasCheckBox.TabIndex = 32;
            this.FechasCheckBox.Text = "Usar Fechas";
            this.FechasCheckBox.UseVisualStyleBackColor = true;
            this.FechasCheckBox.CheckedChanged += new System.EventHandler(this.FechasCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.HastaDateTimePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DesdeDateTimePicker);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 53);
            this.panel1.TabIndex = 30;
            // 
            // HastaDateTimePicker
            // 
            this.HastaDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.HastaDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.HastaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HastaDateTimePicker.Location = new System.Drawing.Point(242, 22);
            this.HastaDateTimePicker.Name = "HastaDateTimePicker";
            this.HastaDateTimePicker.Size = new System.Drawing.Size(115, 23);
            this.HastaDateTimePicker.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(187, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta";
            // 
            // DesdeDateTimePicker
            // 
            this.DesdeDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.DesdeDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.DesdeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DesdeDateTimePicker.Location = new System.Drawing.Point(58, 22);
            this.DesdeDateTimePicker.Name = "DesdeDateTimePicker";
            this.DesdeDateTimePicker.Size = new System.Drawing.Size(115, 23);
            this.DesdeDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde";
            // 
            // ImprimirButton
            // 
            this.ImprimirButton.Location = new System.Drawing.Point(881, 424);
            this.ImprimirButton.Name = "ImprimirButton";
            this.ImprimirButton.Size = new System.Drawing.Size(93, 37);
            this.ImprimirButton.TabIndex = 35;
            this.ImprimirButton.Text = "Imprimir";
            this.ImprimirButton.UseVisualStyleBackColor = true;
            this.ImprimirButton.Click += new System.EventHandler(this.ImprimirButton_Click);
            // 
            // cUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 473);
            this.Controls.Add(this.ImprimirButton);
            this.Controls.Add(this.EditarButton);
            this.Controls.Add(this.ConsultarButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.FechasCheckBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ConsultaDataGridView);
            this.Name = "cUsuarios";
            this.Text = "Control de Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.ConsultaDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView ConsultaDataGridView;
        private System.Windows.Forms.Button EditarButton;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox CriterioTextBox;
        private System.Windows.Forms.ComboBox FiltrarComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox FechasCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker HastaDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DesdeDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ImprimirButton;
    }
}