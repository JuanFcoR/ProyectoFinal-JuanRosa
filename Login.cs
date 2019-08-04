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
            bool paso = false;
            Contexto con = new Contexto();
            
            var ud = ((from Us in con.Usuarios where Us.Usuario.Equals(UserTextBox.Text) select Us.Usuario).FirstOrDefault());
            if (ud != null)
                paso = true;
            else
                paso = false;
            return paso;
        }
        public bool Contrasenia()
        {
            Usuarios us = new Usuarios();
            bool paso = false;
           
            Contexto con = new Contexto();
            var ud= ((from Us in con.Usuarios where Us.Psw.Equals(PasswordTextBox.Text) select Us.Usuario).FirstOrDefault());


            if (ud!=null)
                paso = true;
            else
                paso = false;
            return paso;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(ExisteUsuario())
            {
                if (Contrasenia())
                {
                    MainForm fm = new MainForm();
                    fm.Show();
                }
                else
                    MessageBox.Show("error");
                
            }
            else
                MessageBox.Show("error");
        }
    }
}
