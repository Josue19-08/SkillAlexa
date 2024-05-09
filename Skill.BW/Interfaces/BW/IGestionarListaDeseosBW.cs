using Skill.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill.BW.Interfaces.BW
{
    public interface IGestionarListaDeseosBW
    {

        Task<bool> registrarProducto(string codigo, int cantidad);

        Task<bool> editarCantidadProducto(string codigo, int cantidad);

        Task<bool> eliminarProducto(string codigo);

        Task<Producto> obtenerProducto(string codigo);

        Task<IEnumerable<Producto>> obtenerProductos();

    }
}
