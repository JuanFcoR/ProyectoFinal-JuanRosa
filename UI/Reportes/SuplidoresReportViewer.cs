using System;
using Entidades;
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
    public partial class SuplidoresReportViewer : Form
    {

        private List<Suplidores> SuplidoresList;
        public SuplidoresReportViewer(List<Suplidores> suplidores)
        {
            InitializeComponent();
            this.SuplidoresList = suplidores;
            SuplidoresReport pr = new SuplidoresReport();
            pr.SetDataSource(SuplidoresList);

            SupReportViewer.ReportSource = pr;
            SupReportViewer.Refresh();
        }
    }
}
