using Skill.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill.BC.ReglasDeNegocio
{
    public static class ReglasDeProducto
    {
        public static (bool, string) validarProducto(Producto producto)
        {


            if (producto.nombre == null)
            {
                throw new NullReferenceException();
            }


            if (producto.precio == null)
            {
                throw new NullReferenceException();
            }

            if (producto.nombre.Equals(string.Empty))
            {
                return (false, "El nombre no puede ser vacio");
            }

            if (producto.precio < 0)
            {
                return (false, "El precio no puede ser inferior a cero");
            }



            return (true, string.Empty);
            
        }

        public static (bool, string) validarCodigo(string codigo)
        {
            if (codigo == null)
            {
                throw new NullReferenceException();
            }

            if (codigo.Equals(string.Empty))
            {
                return (false, "El codigo no puede ser vacio");
            }

            return (true, string.Empty);

        }
        
    }
}
