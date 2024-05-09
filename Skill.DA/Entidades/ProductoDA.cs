using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill.DA.Entdidades
{
    [Table("Producto")]
    public class ProductoDA
    {

        [Key]
        [Required]
        public string codigo { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public double precio { get; set; }

    }
}
