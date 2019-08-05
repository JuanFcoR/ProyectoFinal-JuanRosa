using BLL;
using Entidades;
using ProyectoFinalAlpha.UI.Registros;
using ProyectoFinalAlpha.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAlpha.UI.Consultas
{
    public partial class cSuplidores : Form
    {
        List<Suplidores> listado;
        public cSuplidores()
        {
            InitializeComponent();
            
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            
            Repositorio<Suplidores> or = new Repositorio<Suplidores>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = or.GetList(p => true);
                        break;

                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = or.GetList(p => p.CodigoSuplidor == id);
                        break;

                    case 2://Nombre
                        listado = or.GetList(p=>p.Nombre.Contains(CriterioTextBox.Text));
                        break;

                    case 3://Direccion
                        listado = or.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));

                        break;

                    case 4://Telefono
                        listado = or.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));

                        break;
                    case 5://RNC
                        listado = or.GetList(p => p.RNC.Contains(CriterioTextBox.Text));

                        break;
                    

                }
                if (FechasCheckBox.Checked == true) 
                    listado = listado.Where(c => c.FechaCreacion >= DesdeDateTimePicker.Value.Date && c.FechaCreacion <= HastaDateTimePicker.Value.Date).ToList();
            }
            
            else
            {
                listado = or.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }

        private void CSuplidores_Load(object sender, EventArgs e)
        {
            if (FechasCheckBox.Checked == true)
            {
                DesdeDateTimePicker.Enabled = true;
                HastaDateTimePicker.Enabled = true;
            }
            else
            {
                DesdeDateTimePicker.Enabled = false;
                HastaDateTimePicker.Enabled = false;
            }
        }

        private void FechasCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FechasCheckBox.Checked == true)
            {
                DesdeDateTimePicker.Enabled = true;
                HastaDateTimePicker.Enabled = true;
            }
            else
            {
                DesdeDateTimePicker.Enabled = false;
                HastaDateTimePicker.Enabled = false;
            }
        }

        private void EditarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Repositorio<Suplidores> res = new Repositorio<Suplidores>();
                Suplidores sup;
                if (ConsultaDataGridView.CurrentRow.Cells[0].Value != null)
                {
                    int id;
                    int.TryParse(ConsultaDataGridView.CurrentRow.Cells[0].Value.ToString(), out id);
                    sup = res.Buscar(id);
                    new rSuplidores(sup).ShowDialog();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (listado.Count == 0)
                {
                    MessageBox.Show("No Hay Datos Que Imprimir");
                    return;
                }
                else
                {
                    SuplidoresReportViewer reportViewer = new SuplidoresReportViewer(listado);
                    reportViewer.ShowDialog();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
