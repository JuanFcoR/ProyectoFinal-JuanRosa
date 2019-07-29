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
    public partial class cCompras : Form
    {
        public cCompras()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var listado = new List<OrdenDeCompra>();
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

                        

                    case 5:
                        listado = or.GetList(p => true);
                        listado = listado.Where(c=>c.Fecha >= DesdeDateTimePicker.Value.Date && c.Fecha <= HastaDateTimePicker.Value.Date).ToList();
                        break;

                }
                if(FechasCheckBox.Checked==true)
                listado = listado.Where(c => c.Fecha >= DesdeDateTimePicker.Value.Date && c.Fecha <= HastaDateTimePicker.Value.Date).ToList();

            }
            else
            {
                listado = or.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConsultaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FechasCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
