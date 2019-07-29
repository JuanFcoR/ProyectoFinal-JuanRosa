using BLL;
using Entidades;
using ProyectoFinalAlpha.UI.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAlpha.UI.Registros
{
    public partial class rSuplidores : Form
    {
        public rSuplidores()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            NoSuplidorNumericUpDown.Value = 0;
            NombreTextBox.Text = String.Empty;
            DireccionTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            RNCTextBox.Text = string.Empty;
            FechaCreacionDateTimePicker.Value = DateTime.Now;
            SuperErrorProvider.Clear();
        }
        private Suplidores llenarClase()
        {
            Suplidores Pro = new Suplidores();
            Pro.CodigoSuplidor = Convert.ToInt32(NoSuplidorNumericUpDown.Value);
            Pro.Nombre = NombreTextBox.Text.ToString();
            Pro.Direccion = DireccionTextBox.Text;
            Pro.Telefono = TelefonoTextBox.Text;
            Pro.RNC = RNCTextBox.Text;
            Pro.FechaCreacion = FechaCreacionDateTimePicker.Value;

            return Pro;
        }

        private bool ExisteEnLaBasedeDatos()
        {
            Repositorio<Suplidores> rep = new Repositorio<Suplidores>();
            Suplidores Pro = rep.Buscar((int)NoSuplidorNumericUpDown.Value);
            return (Pro != null);
        }

        private bool Validar()
        {
            bool paso = true;

            {
                if (String.IsNullOrWhiteSpace(NombreTextBox.Text))
                {
                    SuperErrorProvider.SetError(NombreTextBox, "Este campo no debe estar vacio");
                    NombreTextBox.Focus();
                    paso = false;
                }

                if (String.IsNullOrWhiteSpace(DireccionTextBox.Text))
                {
                    SuperErrorProvider.SetError(DireccionTextBox, "Este campo no debe estar vacio");
                    DireccionTextBox.Focus();
                    paso = false;
                }

                if (String.IsNullOrWhiteSpace(TelefonoTextBox.Text))
                {
                    SuperErrorProvider.SetError(TelefonoTextBox, "Este campo no debe estar vacio");
                    TelefonoTextBox.Focus();
                    paso = false;
                }

                if (String.IsNullOrWhiteSpace(RNCTextBox.Text))
                {
                    SuperErrorProvider.SetError(RNCTextBox, "Este campo no debe estar vacio");
                    RNCTextBox.Focus();
                    paso = false;
                }

            }

            return paso;
        }

        private void LlenarCampos(Suplidores Pro)
        {

            NoSuplidorNumericUpDown.Value = Convert.ToInt32(Pro.CodigoSuplidor);
            NombreTextBox.Text = Pro.Nombre;
            DireccionTextBox.Text = Pro.Direccion;
            TelefonoTextBox.Text = Pro.Telefono;
            RNCTextBox.Text = Pro.RNC;
            FechaCreacionDateTimePicker.Value = Pro.FechaCreacion;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Suplidores> rep = new Repositorio<Suplidores>();
            Suplidores ast = new Suplidores();
            if (!Validar())
                return;
            ast = llenarClase();
            if (NoSuplidorNumericUpDown.Value == 0)
                paso = rep.Guardar(ast);
            else
            {
                if (!ExisteEnLaBasedeDatos())
                {
                    MessageBox.Show("No se puede Modififcar un suplidor que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    paso = rep.Modificar(ast);
            }
            if (paso)
                MessageBox.Show("Guardado!!!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se guardo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Suplidores> rep = new Repositorio<Suplidores>();
            int id;
            SuperErrorProvider.Clear();
            int.TryParse(NoSuplidorNumericUpDown.Text, out id);
            limpiar();
            if (rep.Eliminar(id))
                MessageBox.Show("Elminado");
            else
                SuperErrorProvider.SetError(NoSuplidorNumericUpDown, "No se puede eliminar un suplidor que no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            cSuplidores cs = new cSuplidores();
            cs.ShowDialog();
        }
    }
}
