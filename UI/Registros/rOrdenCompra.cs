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

namespace ProyectoFinalAlpha.UI.Consultas
{
    public partial class rOrdenCompra : Form
    {
        decimal total=0;
        public List<DetalleProductos> Detalle { get; set; }
        public rOrdenCompra()
        {
            InitializeComponent();
            this.Detalle = new List<DetalleProductos>();
            CargarComboBox();
            
        }

        public rOrdenCompra(OrdenDeCompra ord)
        {
            InitializeComponent();
            this.Detalle = new List<DetalleProductos>();
            CargarComboBox();
            LlenarCampos(ord);

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
            Pro.Total = TotalNumericUpDown.Value;


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
            TotalNumericUpDown.Value = Pro.Total;
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
            if (CantidadNumericUpDown.Value<=prod.Cantidad)
            {
                this.Detalle.Add(
                    new DetalleProductos(iD: 0,
                    noProducto: (int)NoProductoNumericUpDown.Value,
                    descripcion: prod.Descripcion,
                    cantidad: (int)CantidadNumericUpDown.Value,
                    precio: prod.Precio,
                    importe: prod.Precio * (int)CantidadNumericUpDown.Value
                    )) ;


                foreach (var item in this.Detalle)
                {

                    total += item.Importe;
                    prod.Cantidad -= item.Cantidad;
                }
                TotalNumericUpDown.Value = total;
                CargarGrid();
            }
            else
                MessageBox.Show("Se piden mas productos de los que hay", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> rp = new Repositorio<Productos>();
            if (DetalleDataGridView.Rows.Count > 0 && DetalleDataGridView.CurrentRow != null)
            {
                int num=Convert.ToInt32(DetalleDataGridView.CurrentRow.Cells[1]);
                Productos p = new Productos();
                p = rp.Buscar(num);
                var indice = this.Detalle.FirstOrDefault(x=>x.ID==num);
                p.Cantidad += indice.Cantidad;
                TotalNumericUpDown.Value -= indice.Importe;
                Detalle.RemoveAt(DetalleDataGridView.CurrentRow.Index);
            }
           
            return;
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

        public void CargarComboBox()
        {
            Repositorio<Suplidores> resu = new Repositorio<Suplidores>();
            SuplidoresComboBox.DisplayMember = "Nombre";
            SuplidoresComboBox.ValueMember = "CodigoSuplidor";
            SuplidoresComboBox.DataSource = resu.GetList(p => true);
            
        }

        private void SuplidoresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SuplidoresComboBox.SelectedIndex != 0)
                {
                    Repositorio<Suplidores> resu = new Repositorio<Suplidores>();
                    Suplidores su = resu.Buscar(SuplidoresComboBox.SelectedIndex);
                    if (su != null)
                        TelefonoMaskedTextBox.Text = su.Telefono;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
