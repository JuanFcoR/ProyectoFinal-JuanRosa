using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrdenRepositorio:Repositorio<OrdenDeCompra>
    {
        public override OrdenDeCompra Buscar(int id)
        {
            OrdenDeCompra ins = new OrdenDeCompra();
            try
            {
                ins = _contexto.OrdenDeCompra.Find(id);



                if (ins != null)
                {
                    ins.ListaProductos.Count();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return ins;
        }

        public override bool Modificar(OrdenDeCompra entity)
        {
            Repositorio<OrdenDeCompra> ord = new Repositorio<OrdenDeCompra>();
            OrdenDeCompra ord1 = new OrdenDeCompra();
            bool paso = false;
    
            try
            {
                _contexto.Entry(ord1).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
                _contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {

            bool paso = false;
           
            try
            {
               OrdenDeCompra Pro = _contexto.OrdenDeCompra.Find(id);
                _contexto.OrdenDeCompra.Remove(Pro);
                paso = _contexto.SaveChanges() > 0;
                _contexto.Dispose();
            }

            catch (Exception)
            {

                throw;
            }

            return paso;
           
            
        }

        public override bool Guardar(OrdenDeCompra entity)
        {
            bool paso = false;
            //decimal resultado;
            try
            {
                Repositorio<OrdenDeCompra> Est = new Repositorio<OrdenDeCompra>();
                if (_contexto.OrdenDeCompra.Add(entity) != null)
                {

                    foreach (var items in entity.ListaProductos)
                    {
                        var resultado = _contexto.Productos.Find(items.NoProducto);
                        resultado.Cantidad -= items.Cantidad;


                    }
                    paso = _contexto.SaveChanges() > 0;

                }



            }

            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public bool Existe(int id)
        {
            bool paso = false;
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }
    }
}
