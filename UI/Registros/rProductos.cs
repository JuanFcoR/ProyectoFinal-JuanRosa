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
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            NoProductoNumericUpDown.Value = 0;
            DescripcionTextBox.Text = String.Empty;
            CostoNumericUpDown.Value = 0;
            GananciaNumericUpDown.Value = 0;
            CantidadNumericUpDown.Value = 0;
            MinimoNumericUpDown.Value = 0;
            UnidadTextBox.Text = string.Empty;
            PrecioNumericUpDown.Value = 0;
            SuperErrorProvider.Clear();
        }
        private Productos llenarClase()
        {
            Productos Pro = new Productos();
            Pro.NoProducto = Convert.ToInt32(NoProductoNumericUpDown.Value);
            Pro.Descripcion = DescripcionTextBox.Text.ToString();
            Pro.Cantidad = Convert.ToInt32(CantidadNumericUpDown.Value);
            Pro.Costo = CostoNumericUpDown.Value;
            Pro.Minimo = Convert.ToInt32(MinimoNumericUpDown.Value);
            Pro.Precio = PrecioNumericUpDown.Value;
            Pro.Ganancia = GananciaNumericUpDown.Value;
            Pro.Unidad = UnidadTextBox.Text;

            return Pro;
        }

        private bool ExisteEnLaBasedeDatos()
        {
            Repositorio<Productos> rep = new Repositorio<Productos>();
            Productos Pro = rep.Buscar((int)NoProductoNumericUpDown.Value);
            return (Pro != null);
        }

        private bool Validar()
        {
            bool paso = true;

            {
                if (String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
                {
                    SuperErrorProvider.SetError(DescripcionTextBox, "Este campo no debe estar vacio");
                    DescripcionTextBox.Focus();
                    paso = false;
                }

                if (String.IsNullOrWhiteSpace(UnidadTextBox.Text))
                {
                    SuperErrorProvider.SetError(UnidadTextBox, "Este campo no debe estar vacio");
                    UnidadTextBox.Focus();
                    paso = false;
                }

                //if (String.IsNullOrWhiteSpace(MinimoTextBox.Text))
                //{
                //    SuperErrorProvider.SetError(MinimoTextBox, "Este campo no debe estar vacio");
                //    MinimoTextBox.Focus();
                //    paso = false;
                //}

            }

            return paso;
        }

        private void LlenarCampos(Productos Pro)
        {
            
            NoProductoNumericUpDown.Value = Convert.ToInt32(Pro.NoProducto);
            DescripcionTextBox.Text = Pro.Descripcion;
            CantidadNumericUpDown.Value = Pro.Cantidad;
            CostoNumericUpDown.Value = Convert.ToDecimal(Pro.Costo);
            PrecioNumericUpDown.Value = Convert.ToDecimal(Pro.Precio);
            UnidadTextBox.Text = Pro.Unidad;
            MinimoNumericUpDown.Value = Pro.Minimo;
            GananciaNumericUpDown.Value = Convert.ToDecimal(Pro.Ganancia);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Productos asi = new  Productos();
            Repositorio<Productos> rep = new  Repositorio<Productos>();
            int.TryParse(NoProductoNumericUpDown.Text, out id);
            cProductos asig = new cProductos();
            asig.ShowDialog();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Productos> rep = new Repositorio<Productos>();
            Productos ast = new Productos();
            if (!Validar())
                return;
            ast = llenarClase();
            if (NoProductoNumericUpDown.Value == 0)
                paso = rep.Guardar(ast);
            else
            {
                if (!ExisteEnLaBasedeDatos())
                {
                    MessageBox.Show("No se puede Modififcar un Estudiante que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    paso = rep.Modificar(ast);
            }
            if (paso)
                MessageBox.Show("Guardado!!!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se guardo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> rep = new Repositorio<Productos>();
            int id;
            SuperErrorProvider.Clear();
            int.TryParse(NoProductoNumericUpDown.Text, out id);
            limpiar();
            if (rep.Eliminar(id))
                MessageBox.Show("Elminado");
            else
                SuperErrorProvider.SetError(NoProductoNumericUpDown, "No se puede un Producto que no existe");
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
