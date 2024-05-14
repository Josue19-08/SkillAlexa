using Microsoft.AspNetCore.Mvc;
using Skill.BC.Modelos;
using Skill.BW.Interfaces.BW;

namespace Skill.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDeseosController : ControllerBase
    {

        private readonly IGestionarListaDeseosBW gestionarListaDeseosBW;

        public ListaDeseosController(IGestionarListaDeseosBW estionarListaDeseosBW)
        {
            this.gestionarListaDeseosBW = estionarListaDeseosBW;
        }

        [HttpPost("{codigo}")]
        public async Task<bool> registrarProducto(string codigo, int cantidad)
        {
            return await this.gestionarListaDeseosBW.registrarProducto(codigo, cantidad);
        }

        [HttpPut("aumentar/{codigo}")]
        public async Task<bool> aumentarCantidadProducto(string codigo, int cantidad)
        {
            return await this.gestionarListaDeseosBW.aumentarCantidadProducto(codigo, cantidad);
        }

        [HttpPut("disminuir/{codigo}")]
        public async Task<bool> disminuirCantidadProducto(string codigo, int cantidad)
        {
            return await this.gestionarListaDeseosBW.disminuirCantidadProducto(codigo, cantidad);
        }

        [HttpDelete("{codigo}")]
        public async Task<bool> eliminarProducto(string codigo)
        {
            return await this.gestionarListaDeseosBW.eliminarProducto(codigo.Trim());
        }

        [HttpGet("{codigo}")]
        public async Task<Producto> obtenerProducto(string codigo)
        {
            return await this.gestionarListaDeseosBW.obtenerProducto(codigo.Trim());
        }

        [HttpGet]
        public async Task<IEnumerable<Producto>> obtenerProductos()
        {
            return await this.gestionarListaDeseosBW.obtenerProductos();
        }

        [HttpGet("calcularTotal")]
        public async Task<double> obtenerTotalAPagar()
        {
            return await this.gestionarListaDeseosBW.obtenerTotalAPagar();
        }

    }
}
