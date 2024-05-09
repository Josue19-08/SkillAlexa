

using Josue_Daniel_Tarea_III_IF4101.API.DTOs;
using Skill.BC.Modelos;

namespace Josue_Daniel_Tarea_III_IF4101.API.Utilitarios
{
    public static class ProductoDTOMapper
    {

        public  static ProductoDTO convertirProductoADTO(Producto producto)
        {
            return new ProductoDTO()
            {
                codigo = producto.codigo,
                nombre = producto.nombre,
                precio = producto.precio,

            };


        }

        public  static Producto convertirDTOAProducto(ProductoDTO productoDTO)
        {
            return new Producto()
            {
                codigo = productoDTO.codigo,
                nombre = productoDTO.nombre,
                precio = productoDTO.precio,

            };


        }

        public static IEnumerable<ProductoDTO> convertirListaProductosADTO(IEnumerable<Producto> productos)
        {
             IEnumerable <ProductoDTO> productosDTO = productos.Select(p => new ProductoDTO()
            {
                codigo = p.codigo,
                nombre = p.nombre,
                precio = p.precio,


            });

            return productosDTO;

        }

    }
}
