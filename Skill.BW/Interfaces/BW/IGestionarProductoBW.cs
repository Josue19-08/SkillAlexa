using Skill.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill.BW.Interfaces.BW
{
    public interface IGestionarProductoBW
    {


        Task<bool> editarProducto(string codigo, Producto producto);

        Task<bool> eliminarProducto(string codigo);

        Task<Producto> obtenerProducto(string codigo);

        Task<IEnumerable<Producto>> obtenerProductos();

    }
}
