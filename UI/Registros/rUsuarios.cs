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
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
        }

        public rUsuarios(Usuarios u)
        {
            
            InitializeComponent();
            LlenarCampos(u);
        }

        public bool validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                SuperErrorProvider.SetError(NombresTextBox, "Este campo no puede estar vacio");
                NombresTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(UsuarioTextBox.Text))
            {
                SuperErrorProvider.SetError(UsuarioTextBox, "Este campo no puede estar vacio");
                UsuarioTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                SuperErrorProvider.SetError(PasswordTextBox, "Este campo no puede estar vacio");
                PasswordTextBox.Focus();
                paso = false;
            }


            return paso;
        }

        public string Encriptar(string cadena)
        {
            string resultado = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadena);
            resultado = Convert.ToBase64String(encryted);

            return resultado;
        }

        public string DesEncriptar(string cadena)
        {
            string resultado = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadena);
            resultado = System.Text.Encoding.Unicode.GetString(decryted);

            return resultado;
        }

        public bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<Usuarios> rep = new Repositorio<Usuarios>();
            Usuarios asig = rep.Buscar((int)UsuarioIdNumericUpDown.Value);


            return (asig != null);
        }

        private void limpiar()
        {
            UsuarioIdNumericUpDown.Value = 0;
            NombresTextBox.Text = string.Empty;
            UsuarioTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            NivelAccesoNumericUpDown.Value = 0;

        }

        private Usuarios LlenarCalse()
        {
            Usuarios us = new Usuarios();
            us.UsuarioId= Convert.ToInt32(UsuarioIdNumericUpDown.Value);
            us.Nombres = NombresTextBox.Text.Trim();
            us.Usuario = UsuarioTextBox.Text.Trim();
            us.Psw = PasswordTextBox.Text.ToString().Trim();
            us.Psw = Encriptar(PasswordTextBox.Text.Trim());
            us.NivelAcceso = Convert.ToInt32(NivelAccesoNumericUpDown.Value);
            return us;
        }

        public void LlenarCampos(Usuarios asig)
        {
            UsuarioIdNumericUpDown.Value = asig.UsuarioId;
            NombresTextBox.Text = asig.Nombres;
            UsuarioTextBox.Text = asig.Usuario;
            PasswordTextBox.Text = asig.Psw;
            PasswordTextBox.Text = DesEncriptar(asig.Psw);
            NivelAccesoNumericUpDown.Value = asig.NivelAcceso;

        }


        private void NuevoButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Usuarios> rep = new Repositorio<Usuarios>();
            Usuarios ast = new Usuarios();
            if (!validar())
                return;
            ast = LlenarCalse();
            if (UsuarioIdNumericUpDown.Value == 0)
                paso = rep.Guardar(ast);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modififcar un Usuario que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    paso = rep.Modificar(ast);
            }
            if (paso)
                MessageBox.Show("Guardado!!!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se guardo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            cUsuarios asig = new cUsuarios();
            asig.ShowDialog();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> rep = new Repositorio<Usuarios>();
            int id;
            SuperErrorProvider.Clear();
            int.TryParse(UsuarioIdNumericUpDown.Text, out id);
            limpiar();
            if (rep.Eliminar(id))
                MessageBox.Show("Elminado");
            else
                SuperErrorProvider.SetError(UsuarioIdNumericUpDown, "No se puede una asignatura que no existe");
        }
    }
}
