using Skill.BC.Modelos;
using Skill.BW.Interfaces.BW;
using Skill.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Skill.BW.CU
{
    public class GestionarListaDeseosBW : IGestionarListaDeseosBW
    {
        private readonly IGestionarListaDeseosDA gestionarListaDeseosDA;

        public GestionarListaDeseosBW(IGestionarListaDeseosDA gestionarListaDeseosDA)
        {
            this.gestionarListaDeseosDA = gestionarListaDeseosDA;
        }

        public async Task<bool> editarCantidadProducto(string codigo, int cantidad)
        {
            return await this.gestionarListaDeseosDA.editarCantidadProducto(codigo, cantidad);
        }

        public async Task<bool> eliminarProducto(string codigo)
        {
            return await this.gestionarListaDeseosDA.eliminarProducto(codigo);
        }

        public async Task<Producto> obtenerProducto(string codigo)
        {
            return await this.gestionarListaDeseosDA.obtenerProducto(codigo);
        }

        public async Task<IEnumerable<Producto>> obtenerProductos()
        {
            return await this.gestionarListaDeseosDA.obtenerProductos();
        }

        public async Task<bool> registrarProducto(string codigo, int cantidad)
        {
            return await this.gestionarListaDeseosDA.registrarProducto(codigo,cantidad);
        }
    }
}
