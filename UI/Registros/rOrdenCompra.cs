using BLL;
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

namespace ProyectoFinalAlpha.UI.Consultas
{
    public partial class cOrdenCompra : Form
    {
        public List<DetalleProductos> Detalle { get; set; }
        public cOrdenCompra()
        {
            InitializeComponent();
            this.Detalle = new List<DetalleProductos>();
        }


        private void limpiar()
        {
            NoOrdenNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            SuperErrorProvider.Clear();
            this.Detalle = new List<DetalleProductos>();
            CargarGrid();
        }

        private OrdenDeCompra llenarClase()
        {
            OrdenDeCompra Pro = new OrdenDeCompra();
            Pro.NoOrden = Convert.ToInt32(NoOrdenNumericUpDown.Value);
            Pro.Fecha = FechaDateTimePicker.Value;
            Pro.Impuesto = ImpuestoNumericUpDown.Value = 0;
            Pro.ListaProductos= this.Detalle;


            return Pro;
        }

        private bool Validar()
        {
            bool paso = true;
            try
            {
                if(ImpuestoNumericUpDown.Value<0)
                {
                    SuperErrorProvider.SetError(ImpuestoNumericUpDown, "Este campo no debe estar vacio");
                    ImpuestoNumericUpDown.Focus();
                    paso = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        private bool ExisteEnLaBasedeDatos()
        {
            OrdenRepositorio ord = new OrdenRepositorio();
            OrdenDeCompra Pro = ord.Buscar((int)NoOrdenNumericUpDown.Value);
            return (Pro != null);
        }

        private void LlenarCampos(OrdenDeCompra Pro)
        {
            FechaDateTimePicker.Value = Pro.Fecha;
            NoOrdenNumericUpDown.Value = Pro.NoOrden;
            ImpuestoNumericUpDown.Value = Pro.Impuesto;
            this.Detalle = Pro.ListaProductos;
            CargarGrid();
        }


        private void GuardarButton_Click(object sender, EventArgs e)
        {
            OrdenDeCompra Pro;
            OrdenRepositorio orr = new OrdenRepositorio();
            bool paso = false;


            if (!Validar())
                return;
            Pro = llenarClase();
            //limpiar();

            if (NoOrdenNumericUpDown.Value == 0)
            {
                paso = orr.Guardar(Pro);
            }
            else
            {
                if (!ExisteEnLaBasedeDatos())
                {
                    MessageBox.Show("No se puede modificar una orden de compra que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = orr.Modificar(Pro);
            }
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se pudo guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            OrdenRepositorio ordr = new OrdenRepositorio();
            Repositorio<Productos> rp = new Repositorio<Productos>();
            if (DetalleDataGridView.DataSource != null)
                this.Detalle = (List<DetalleProductos>)DetalleDataGridView.DataSource;
            OrdenDeCompra p = ordr.Buscar((int)NoOrdenNumericUpDown.Value);
            Productos prod = rp.Buscar((int)NoProductoNumericUpDown.Value);

            this.Detalle.Add(
                new DetalleProductos(iD: 0,
                noProducto: (int)NoProductoNumericUpDown.Value,
                descripcion: prod.Descripcion,
                cantidad: (int)CantidadNumericUpDown.Value,
                precio: prod.Precio,
                importe: prod.Precio * (int)NoProductoNumericUpDown.Value
                )); 

            CargarGrid();
        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if (DetalleDataGridView.Rows.Count > 0 && DetalleDataGridView.CurrentRow != null)
                Detalle.RemoveAt(DetalleDataGridView.CurrentRow.Index);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            OrdenRepositorio rep = new OrdenRepositorio();
            int id;
            SuperErrorProvider.Clear();
            int.TryParse(NoOrdenNumericUpDown.Text, out id);
            limpiar();
            if (rep.Eliminar(id))
                MessageBox.Show("Elminado");
            else
                SuperErrorProvider.SetError(NoOrdenNumericUpDown, "No se puede una orden de compra que no existe");
        }

        public void CargarGrid()
        {
            DetalleDataGridView.DataSource = null;
            DetalleDataGridView.DataSource = this.Detalle;
        }

    }
}
