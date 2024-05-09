using Skill.DA.Entdidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Entidades
{
    [Table("ListaDeseos")]
    public class ListaDeseosDA
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }


        public string codigoProducto { get; set; }

        [ForeignKey("codigoProducto")]
        [AllowNull]
        public virtual ProductoDA? Producto { get; set; }

        [Required]
        public int cantidadProducto { get; set; }
    }
}