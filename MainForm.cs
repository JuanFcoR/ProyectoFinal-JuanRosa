using ProyectoFinalAlpha.UI.Consultas;
using ProyectoFinalAlpha.UI.Registros;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuarios ru = new rUsuarios();
            ru.ShowDialog();
        }

        private void OrdenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rOrdenCompra ro = new rOrdenCompra();
            ro.ShowDialog();
        }

        private void SuplidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rSuplidores rs = new rSuplidores();
            rs.ShowDialog();
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos rp = new rProductos();
            rp.ShowDialog();
        }

        private void SuplidoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cSuplidores cs = new cSuplidores();
            cs.ShowDialog();
        }

        private void OrdenDeCompraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cCompras cc = new cCompras();
            cc.ShowDialog();
        }

        private void ProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cProductos cp = new cProductos();
            cp.ShowDialog();
        }
    }
}
