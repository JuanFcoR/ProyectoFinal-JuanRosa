using BLL;
using Entidades;
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
        public cProductos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Productos>();
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

                        //if (FechasCheckBox.Checked == true)
                        //  listado = listado.Where(c => c. >= DesdeDateTimePicker.Value.Date && c.Fecha <= HastaDateTimePicker.Value.Date).ToList();
                
            }
            else
            {
                listado = or.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
