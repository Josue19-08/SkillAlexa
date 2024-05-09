using Skill.BC.Modelos;
using Skill.BC.ReglasDeNegocio;
using Skill.BW.Interfaces.BW;
using Skill.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Skill.BW.CU
{
    public class GestionarProductoBW : IGestionarProductoBW
    {
        private readonly IGestionarProductoDA gestionarProductoDA;

        public GestionarProductoBW(IGestionarProductoDA gestionarProductoDA)
        {
            this.gestionarProductoDA = gestionarProductoDA;
        } 

        public async Task<bool> editarProducto(string codigo, Producto producto)
        {
            (bool esValido, string mensaje) validarProducto = ReglasDeProducto.validarProducto(producto);
            (bool esValido, string mensaje) validarCodigoProducto = ReglasDeProducto.validarCodigo(producto.codigo);
            (bool esValido, string mensaje) validarCodigoBusqueda = ReglasDeProducto.validarCodigo(codigo);

            try
            {
                if(!validarProducto.esValido)
                {
                    return false;
                }

                if (!validarCodigoProducto.esValido)
                {
                    return false;
                }

                if (!validarCodigoBusqueda.esValido)
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return await this.gestionarProductoDA.editarProducto(codigo, producto);
        }

        public async Task<bool> eliminarProducto(string codigo)
        {
            (bool esValido, string mensaje) validarCodigo = ReglasDeProducto.validarCodigo(codigo);

            try
            {

                if (!validarCodigo.esValido)
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return await this.gestionarProductoDA.eliminarProducto(codigo);
        }

        public async Task<Producto> obtenerProducto(string codigo)
        {
            (bool esValido, string mensaje) validarCodigo = ReglasDeProducto.validarCodigo(codigo);

            try
            {

                if (!validarCodigo.esValido)
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return await this.gestionarProductoDA.obtenerProducto(codigo);
        }

        public async Task<IEnumerable<Producto>> obtenerProductos()
        {
            return await this.gestionarProductoDA.obtenerProductos();
        }

    }
}
