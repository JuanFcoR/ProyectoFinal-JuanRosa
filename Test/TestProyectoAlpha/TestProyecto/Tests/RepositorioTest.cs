using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProyecto.Tests
{
    [TestClass]
    public class RepositorioTest
    {   
        [TestMethod()]
        public void GuardarTest()
        {
            Repositorio<Productos> test = new Repositorio<Productos>();
            Productos productos = new Productos();
            productos.NoProducto = 0;
            productos.Descripcion = "Algo";
            productos.Fecha = DateTime.Now;
            productos.Cantidad = 0;
            productos.Precio = 20;
            productos.Costo = 5;
            productos.Ganancia = 15;
            productos.Minimo = 5;
            productos.Cantidad = 12;

            Assert.IsTrue(test.Guardar(productos));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Repositorio<Productos> test = new Repositorio<Productos>();
            Productos productos = new Productos();
            productos.NoProducto = 0;
            productos.Descripcion = "Acetaminofen";
            productos.Cantidad = 50;


            Assert.IsTrue(test.Modificar(productos));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Repositorio<Productos> test = new Repositorio<Productos>();

            Assert.IsNotNull(test.Buscar(0));

        }

        [TestMethod()]
        public void GetListTest()
        {
            Repositorio<Productos> test = new Repositorio<Productos>();

            Assert.IsNotNull(test.GetList(t => true));

        }

        [TestMethod()]
        public void EliminarTest()
        {
            Repositorio<Productos> test = new Repositorio<Productos>();

            Assert.IsTrue(test.Eliminar(0));
        }
        
    }
}
