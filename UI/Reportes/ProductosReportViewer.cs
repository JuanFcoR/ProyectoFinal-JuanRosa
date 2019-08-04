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

namespace ProyectoFinalAlpha.UI.Reportes
{
    public partial class ProductosReportViewer : Form
    {
        private List<Productos> ProductosList;
        public ProductosReportViewer(List<Productos> productos)
        {
            InitializeComponent();
            this.ProductosList= productos;
            ProductosReport pr = new ProductosReport();
            pr.SetDataSource(ProductosList);

            ProdReportViewer.ReportSource = ProductosList;
            ProdReportViewer.Refresh();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
