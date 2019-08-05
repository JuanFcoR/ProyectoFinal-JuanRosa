using BLL;
using Entidades;
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
    public partial class cCompras : Form
    {
        List<OrdenDeCompra> listado;
        public cCompras()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            try
            {
               
                OrdenRepositorio or = new OrdenRepositorio();

                if (CriterioTextBox.Text.Trim().Length > 0)
                {
                    switch (FiltrarComboBox.SelectedIndex)
                    {
                        case 0://Todo
                            listado = or.GetList(p => true);
                            break;

                        case 1:
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            listado = or.GetList(p => p.NoOrden == id);
                            break;

                        case 2:
                            listado = or.GetList(p => true);
                            listado = listado.Where(c => c.Fecha >= DesdeDateTimePicker.Value.Date && c.Fecha <= HastaDateTimePicker.Value.Date).ToList();
                            break;

                    }
                    

                }
                else
                {

                    listado = or.GetList(p => true);

                }
                if (FechasCheckBox.Checked == true)
                    listado = listado.Where(c => c.Fecha >= DesdeDateTimePicker.Value.Date && c.Fecha <= HastaDateTimePicker.Value.Date).ToList();

                ConsultaDataGridView.DataSource = null;
                ConsultaDataGridView.DataSource = listado;
            }
            catch (Exception)
            {

                throw;
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
                OrdenRepositorio or = new OrdenRepositorio();
                if(ConsultaDataGridView.CurrentRow.Cells[0].Value!=null)
                {
                    OrdenDeCompra odc;
                    int id;
                    int.TryParse(ConsultaDataGridView.CurrentRow.Cells[0].Value.ToString(), out id);
                    odc = or.Buscar(id);
                    new rOrdenCompra(odc);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (listado.Count == 0)
            {
                MessageBox.Show("No Hay Datos Que Imprimir");
                return;
            }
            else
            {
                ComprasReportViewer reportViewer = new ComprasReportViewer(listado);
                reportViewer.ShowDialog();
            }
        }
    }
}
