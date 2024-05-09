using Microsoft.EntityFrameworkCore;
using Skill.BC.Modelos;
using Skill.BW.Interfaces.DA;
using Skill.DA.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Skill.DA.Acciones.GestionarProductoDA;

namespace Skill.DA.Acciones
{
    public class GestionarProductoDA : IGestionarProductoDA
    {

            private readonly TareaIIIContext tareaIIIContext;

            public GestionarProductoDA(TareaIIIContext tareaIIIContext)
            {
                this.tareaIIIContext = tareaIIIContext;
            }

            public async Task<bool> editarProducto(string codigo, Producto producto)
            {
                var productoDA = await this.tareaIIIContext.ProductoDA.FirstOrDefaultAsync(p => p.codigo.Equals(codigo));

                if (productoDA != null)
                {

                    productoDA.codigo = producto.codigo;
                    productoDA.nombre = producto.nombre;
                    productoDA.precio = producto.precio;


                    var resultado = await this.tareaIIIContext.SaveChangesAsync();

                    return resultado > 0 ? true : false;

                }

                return false;
            }

            public async Task<bool> eliminarProducto(string codigo)
            {
                var productoDA = await this.tareaIIIContext.ProductoDA.FirstOrDefaultAsync(p => p.codigo.Equals(codigo));

                if (productoDA != null)
                {
                    this.tareaIIIContext.ProductoDA.Remove(productoDA);
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
                    precio = productoDA.precio
                };

                return producto;
            }

            public async Task<IEnumerable<Producto>> obtenerProductos()
            {

                return await this.tareaIIIContext.ProductoDA
                    .Select(productoDA => new Producto
                    {
                        codigo = productoDA.codigo,
                        nombre = productoDA.nombre,
                        precio = productoDA.precio


                    }).ToListAsync();

            }

        }
}
