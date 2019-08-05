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
    public partial class UsersReportViewer : Form
    {
        private List<Usuarios> SuplidoresList;
        public UsersReportViewer(List<Usuarios> suplidores)
        {
            InitializeComponent();
            this.SuplidoresList = suplidores;
            UserReport pr = new UserReport();
            pr.SetDataSource(SuplidoresList);

            UsrReportViewer.ReportSource = pr;
            UsrReportViewer.Refresh();
        }
    }
}
