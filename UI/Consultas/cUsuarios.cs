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
    public partial class cUsuarios : Form
    {
        List<Usuarios> listado;
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click_1(object sender, EventArgs e)
        {
            
            
            Repositorio<Usuarios> rep = new Repositorio<Usuarios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = rep.GetList(p => true);
                        break;

                    case 1://Id
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = rep.GetList(p => p.UsuarioId == id);
                        break;

                    case 2:
                        listado = rep.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 3:
                        listado = rep.GetList(p => p.Usuario.Contains(CriterioTextBox.Text));
                        break;

                    case 4:
                        string acceso = (CriterioTextBox.Text);
                        listado = rep.GetList(p => p.NivelAcceso.Equals(acceso));
                        break;

                }


            }
            else
            {
                listado = rep.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }

        private void EditarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> rep = new Repositorio<Usuarios>();
            int id;
            Usuarios es = new Usuarios();
            int.TryParse(ConsultaDataGridView.CurrentRow.Cells[0].Value.ToString(), out id);
            es = rep.Buscar(id);
            rUsuarios re = new rUsuarios(es);
            this.Hide();
            re.ShowDialog();
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

        private void ConsultarButton_Click(object sender, EventArgs e)
        {

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
                UsersReportViewer reportViewer = new UsersReportViewer(listado);
                reportViewer.ShowDialog();
            }
        }
    }
}
