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
        }

        public bool ExisteUsuario()
        {

            Contexto con = new Contexto();
            var ud = (from Us in con.Usuarios where Us.Usuario.Contains(UserTextBox.Text) select Us.Usuario);




            return (ud!=null);
        }
        public Usuarios Contrasenia()
        {
            Usuarios us = new Usuarios();

            Contexto con = new Contexto();
            var ud = (from Us in con.Usuarios where Us.Psw.Equals(PasswordTextBox.Text) select Us.UsuarioId);



            return us;
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(ExisteUsuario())
            {
                Contrasenia();
                Form1 fm = new Form1();
                fm.Show();
                
            }
            
        }
    }
}
