using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArchivoPrueba.Models
{
    public class PruebasContext : DbContext
    {
        public PruebasContext() : base("Conexion")
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Empleado> Empleadoes { get; set; }
        public DbSet<Prenda> Prendas { get; set; }
        public DbSet<DotacionConfigTipoPersonal> DotacionConfigTipoPersonal { get; set; }
        public DbSet<DotacionConfigTipoPersonalDetalle> DotacionConfigTipoPersonalDetalle { get; set; }
        public DbSet<DotacionConfigTipoArea> DotacionConfigTipoArea { get; set; }
        public DbSet<DotacionConfigTipoAreaDetalle> DotacionConfigTipoAreaDetalle { get; set; }
    }
}