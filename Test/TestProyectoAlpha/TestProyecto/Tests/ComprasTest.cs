using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using Entidades;

namespace TestProyecto.Tests
{
    
    [TestClass]
    public class ComprasTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            OrdenRepositorio test = new OrdenRepositorio();
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

            //Assert.IsTrue(test.Guardar(productos));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            OrdenRepositorio test = new OrdenRepositorio();
            Productos productos = new Productos();
            productos.NoProducto = 0;
            productos.Descripcion = "Acetaminofen";
            productos.Cantidad = 50;


          //  Assert.IsTrue(test.Modificar(productos));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            OrdenRepositorio test = new OrdenRepositorio();

            Assert.IsNotNull(test.Buscar(0));

        }

        [TestMethod()]
        public void GetListTest()
        {
            OrdenRepositorio test = new OrdenRepositorio();

            Assert.IsNotNull(test.GetList(t => true));

        }

        [TestMethod()]
        public void EliminarTest()
        {
            OrdenRepositorio test = new OrdenRepositorio();

            Assert.IsTrue(test.Eliminar(0));
        }

    }
}
