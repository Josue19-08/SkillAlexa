using Entidades;
using Microsoft.EntityFrameworkCore;
using Skill.DA.Entdidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill.DA.Contexto
{
    public class TareaIIIContext: DbContext
    {

        public TareaIIIContext(DbContextOptions options) :base (options) { }

        public DbSet<ProductoDA> ProductoDA { get; set; }

        public DbSet<ListaDeseosDA> ListaDeseosDA { get;set; }
    }
}
