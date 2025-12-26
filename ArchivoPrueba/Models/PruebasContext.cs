using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace ArchivoPrueba.Models
{
    public class PruebasContext: DbContext
    {
        public PruebasContext(): base("Conexion") { }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}