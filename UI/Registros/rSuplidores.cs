using BLL;
using DAL;
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

        public rSuplidores(Suplidores s)
        {
            InitializeComponent();
            LlenarCampos(s);
        }

        private void limpiar()
        {
            NoSuplidorNumericUpDown.Value = 0;
            NombreTextBox.Text = String.Empty;
            DireccionTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
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
            Pro.Telefono = TelefonoMaskedTextBox.Text;
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

                if (String.IsNullOrWhiteSpace(TelefonoMaskedTextBox.Text))
                {
                    SuperErrorProvider.SetError(TelefonoMaskedTextBox, "Este campo no debe estar vacio");
                    TelefonoMaskedTextBox.Focus();
                    paso = false;
                }

                if (String.IsNullOrWhiteSpace(RNCTextBox.Text))
                {
                    SuperErrorProvider.SetError(RNCTextBox, "Este campo no debe estar vacio");
                    RNCTextBox.Focus();
                    paso = false;
                }

                if(!TelefonoMaskedTextBox.MaskFull)
                {
                    SuperErrorProvider.SetError(TelefonoMaskedTextBox, "Este campo no esta correctamente lleno");
                    TelefonoMaskedTextBox.Focus();
                    paso = false;
                }

            }

            return paso;
        }

        private bool ValidarBase()
        {
            Contexto c = new Contexto();
            bool paso = true;

            {
                if (c.Suplidores.Any(p=>p.Nombre.Equals(NombreTextBox.Text)))
                {
                    SuperErrorProvider.SetError(NombreTextBox, "Este nombre ya existe");
                    NombreTextBox.Focus();
                    paso = false;
                }

                if (c.Suplidores.Any(p => p.Direccion.Equals(DireccionTextBox.Text)))
                {
                    SuperErrorProvider.SetError(DireccionTextBox, "Esta direccion Existe");
                    DireccionTextBox.Focus();
                    paso = false;
                }

                if (c.Suplidores.Any(p => p.Telefono.Equals(TelefonoMaskedTextBox.Text)))
                {
                    SuperErrorProvider.SetError(TelefonoMaskedTextBox, "Este numero ya existe");
                    TelefonoMaskedTextBox.Focus();
                    paso = false;
                }

                if (c.Suplidores.Any(p => p.RNC.Equals(RNCTextBox.Text)))
                {
                    SuperErrorProvider.SetError(RNCTextBox, "Este RNC ya esta registrado");
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
            TelefonoMaskedTextBox.Text = Pro.Telefono;
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
            Suplidores ast;
            if (!Validar())
                return;
            else
            ast = llenarClase();
            if (NoSuplidorNumericUpDown.Value == 0)
            {
                if (!ValidarBase())
                    return;
                else
                    paso = rep.Guardar(ast);
            }
                
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
