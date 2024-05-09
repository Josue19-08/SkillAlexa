using Microsoft.EntityFrameworkCore;
using Skill.BC.Modelos;
using Skill.BW.Interfaces.DA;
using Skill.DA.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Skill.DA.Acciones
{
    public class GestionarListaDeseosDA : IGestionarListaDeseosDA
    {

        private readonly TareaIIIContext tareaIIIContext;

        public GestionarListaDeseosDA(TareaIIIContext tareaIIIContext)
        {
            this.tareaIIIContext = tareaIIIContext;
        }

        public async Task<bool> editarCantidadProducto(string codigo, int cantidad)
        {
            
            var listaDA = await this.tareaIIIContext.ListaDeseosDA.FirstOrDefaultAsync(l => l.codigoProducto.Equals(codigo));

            if (listaDA != null) 
            {

                listaDA.cantidadProducto = cantidad;

                var resultado = await this.tareaIIIContext.SaveChangesAsync();

                return resultado > 0 ? true : false;

            }

            return false;

        }

        public async  Task<bool> eliminarProducto(string codigo)
        {

            var listaDA = await this.tareaIIIContext.ListaDeseosDA.FirstOrDefaultAsync(l => l.codigoProducto.Equals(codigo));

            if (listaDA != null)
            {
                this.tareaIIIContext.ListaDeseosDA.Remove(listaDA);

                var resultado = await this.tareaIIIContext.SaveChangesAsync();

                return resultado > 0 ? true : false;
            }

            return false;
        }

        public async Task<Producto> obtenerProducto(string codigo)
        {
            
            var productoDA = await this.tareaIIIContext.ProductoDA.FirstOrDefaultAsync(p => p.codigo.Equals(codigo));

            if (productoDA is null)
                return null;

            Producto producto = new()
            {
                codigo = productoDA.codigo,
                nombre = productoDA.nombre,
                precio = productoDA.precio,

            };

            return producto;
        }

        public async Task<IEnumerable<Producto>> obtenerProductos()
        {

            return await (from listaDeseos in this.tareaIIIContext.ListaDeseosDA
                                          join productoDA in this.tareaIIIContext.ProductoDA
                                          on listaDeseos.codigoProducto equals productoDA.codigo
                                          select new Producto
                                          {
                                              codigo = productoDA.codigo,
                                              nombre = productoDA.nombre,
                                              precio = productoDA.precio }).ToListAsync();
 
        }

        public async Task<bool> registrarProducto(string codigo, int cantidad)
        {

            var productoDA = await this.tareaIIIContext.ProductoDA.FirstOrDefaultAsync(p => p.codigo.Equals(codigo));

            if(productoDA != null)
            {

                Entidades.ListaDeseosDA listaBD = new()
                {

                    codigoProducto = productoDA.codigo,
                    cantidadProducto = cantidad

                };

                await this.tareaIIIContext.ListaDeseosDA.AddAsync(listaBD);

                var resultado = await this.tareaIIIContext.SaveChangesAsync();

                return resultado > 0 ? true : false;

            }

            return false;
        }
    }
}
