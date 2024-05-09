using Josue_Daniel_Tarea_III_IF4101.API.DTOs;
using Josue_Daniel_Tarea_III_IF4101.API.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using Skill.BC.Modelos;
using Skill.BW.Interfaces.BW;

namespace Skill.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController: ControllerBase
    {

        private readonly IGestionarProductoBW gestionarProductoBW;

        public ProductoController(IGestionarProductoBW gestionarProductoBW)
        {
            this.gestionarProductoBW = gestionarProductoBW;
        }

        [HttpPut("{codigo}")]
        public async Task<bool> editarProducto(string codigo, ProductoDTO productoDTO)
        {
            Producto producto = ProductoDTOMapper.convertirDTOAProducto(productoDTO);

            return await this.gestionarProductoBW.editarProducto(codigo, producto);
        }

        [HttpDelete]
        public async Task<bool> eliminarProducto(string codigo)
        {
            return await this.gestionarProductoBW.eliminarProducto(codigo);
        }

        [HttpGet("{codigo}")]
        public async Task<ProductoDTO> obtenerProducto(string codigo)
        {
            var producto = await gestionarProductoBW.obtenerProducto(codigo);


            return ProductoDTOMapper.convertirProductoADTO(producto);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductoDTO>> obtenerProductos()
        {
            var productos = await gestionarProductoBW.obtenerProductos();

            return ProductoDTOMapper.convertirListaProductosADTO(productos);
        }


    }
}
