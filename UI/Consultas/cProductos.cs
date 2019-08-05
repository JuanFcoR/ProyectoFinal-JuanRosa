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
    public partial class cProductos : Form
    {
        private List<Productos> listado;
        public cProductos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            
            Repositorio<Productos> or = new Repositorio<Productos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = or.GetList(p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = or.GetList(p => p.NoProducto == id);
                        break;
                    case 2:
                        listado = or.GetList(p => p.Descripcion.Contains(CriterioTextBox.Text));
                        break;
                    case 3:
                        int cantidad = Convert.ToInt32(CriterioTextBox.Text);
                        listado = or.GetList(p => p.Cantidad == cantidad);
                        break;
                    case 4:
                        int minimo = Convert.ToInt32(CriterioTextBox.Text);
                        listado = or.GetList(p => p.Cantidad == minimo);
                        break;
                    case 5:
                        listado = or.GetList(p => p.Unidad.Contains(CriterioTextBox.Text));
                        break;
                    case 6:
                        decimal precio = Convert.ToDecimal(CriterioTextBox.Text);
                        listado = or.GetList(p => p.Precio == precio);
                        break;
                    case 7:
                        decimal costo = Convert.ToDecimal(CriterioTextBox.Text);
                        listado = or.GetList(p => p.Costo == costo);
                        break;
                    case 8:
                        decimal ganancia = Convert.ToDecimal(CriterioTextBox.Text);
                        listado = or.GetList(p => p.Ganancia == ganancia);
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

        private void FechasCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(FechasCheckBox.Checked==true)
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
            Repositorio<Productos> pr = new Repositorio<Productos>();
            Productos prod;
            try
            {
                if(ConsultaDataGridView.CurrentRow.Cells[0].Value!=null)
                {
                    int id;
                    int.TryParse(ConsultaDataGridView.CurrentRow.Cells[0].Value.ToString(),out id);
                    prod = pr.Buscar(id);
                    new rProductos(prod).ShowDialog();
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
                    ProductosReportViewer reportViewer = new ProductosReportViewer(listado);
                    reportViewer.ShowDialog();
                }
            }
            catch (Exception)
            {

                throw;
            }
                
            
        }

        private void FiltrarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
