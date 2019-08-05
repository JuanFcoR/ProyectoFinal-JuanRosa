using BLL;
using DAL;
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

namespace ProyectoFinalAlpha
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CrearUsuario();
        }

        public void CrearUsuario()
        {
            Repositorio<Usuarios> rep = new Repositorio<Usuarios>();
            Usuarios us= new Usuarios();
            var listado = rep.GetList(p => true).ToList();
            if(listado==null)
            {
                us.UsuarioId = 1;
                us.Nombres = "Administrado";
                us.NivelAcceso = "Administrador";
                us.Fecha = DateTime.Now;
                us.Correo = "juan_rosa1@ucne.edu.do";
                us.Usuario = "Admin";
                us.Psw = "Admin";
                rep.Guardar(us);
            }
            
        }

        public string DesEncriptar(string cadena)
        {
            string resultado = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadena);
            resultado = System.Text.Encoding.Unicode.GetString(decryted);

            return resultado;
        }
        public bool ExisteUsuario()
        {
            bool paso = false;
            Contexto con = new Contexto();
            try
            {
                Usuarios ud = ((from Us in con.Usuarios where Us.Usuario.Equals(UserTextBox.Text) select Us).FirstOrDefault());
                if (ud != null)
                {
                    string pass = DesEncriptar(ud.Psw);
                    if (!pass.Equals(PasswordTextBox.Text))
                        MessageBox.Show("Contrasenia no coincide con usuario");
                    else
                        paso = true;
                }
                
                else
                    MessageBox.Show("Usuario no existe");
                
            }
            catch (Exception)
            {

                throw;
            }
           
            return paso;
        }
        

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(ExisteUsuario())
            {
                MainForm fm= new MainForm();
                fm.Show();
                
                
            }
            else
                MessageBox.Show("error");
        }

        private void Login_Load(object sender, EventArgs e)
        {
            CrearUsuario();
        }
    }
}
