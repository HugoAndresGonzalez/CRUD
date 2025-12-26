namespace ArchivoPrueba.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArchivoPrueba.Models.PruebasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ArchivoPrueba.Models.PruebasContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Usuarios.AddOrUpdate(
                u => u.Id,
                new ArchivoPrueba.Models.Usuarios { Id = 1, Nombres = "Admin",Apellidos = "Robledo", Estado = true },
                new ArchivoPrueba.Models.Usuarios { Id = 2, Nombres = "Invitado", Apellidos="Tarazona",Estado=true }
            );
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
