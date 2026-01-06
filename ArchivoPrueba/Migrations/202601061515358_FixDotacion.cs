namespace ArchivoPrueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDotacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DotacionConfigTipoArea",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoArea = c.String(nullable: false, maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                        A_Creacion = c.DateTime(nullable: false),
                        A_Modificacion = c.DateTime(),
                        A_UsuarioCreador = c.String(maxLength: 100),
                        A_UsuarioModifica = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DotacionConfigTipoAreaDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DotacionConfigTipoAreaId = c.Int(nullable: false),
                        PrendaId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DotacionConfigTipoArea", t => t.DotacionConfigTipoAreaId, cascadeDelete: true)
                .ForeignKey("dbo.Prendas", t => t.PrendaId, cascadeDelete: true)
                .Index(t => t.DotacionConfigTipoAreaId)
                .Index(t => t.PrendaId);
            
            CreateTable(
                "dbo.Prendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrendaNombre = c.String(nullable: false, maxLength: 200),
                        Codigo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DotacionConfigTipoPersonal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoPersonal = c.String(nullable: false, maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                        A_Creacion = c.DateTime(nullable: false),
                        A_Modificacion = c.DateTime(),
                        A_UsuarioCreador = c.String(maxLength: 100),
                        A_UsuarioModifica = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DotacionConfigTipoPersonalDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DotacionConfigTipoPersonalId = c.Int(nullable: false),
                        PrendaId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DotacionConfigTipoPersonal", t => t.DotacionConfigTipoPersonalId, cascadeDelete: true)
                .ForeignKey("dbo.Prendas", t => t.PrendaId, cascadeDelete: true)
                .Index(t => t.DotacionConfigTipoPersonalId)
                .Index(t => t.PrendaId);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Documento = c.String(maxLength: 50),
                        NroEmpleado = c.String(maxLength: 50),
                        Nombres = c.String(maxLength: 200),
                        Correo = c.String(maxLength: 200),
                        TipoArea = c.String(maxLength: 150),
                        AreaDescripcion = c.String(maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DotacionConfigTipoPersonalDetalle", "PrendaId", "dbo.Prendas");
            DropForeignKey("dbo.DotacionConfigTipoPersonalDetalle", "DotacionConfigTipoPersonalId", "dbo.DotacionConfigTipoPersonal");
            DropForeignKey("dbo.DotacionConfigTipoAreaDetalle", "PrendaId", "dbo.Prendas");
            DropForeignKey("dbo.DotacionConfigTipoAreaDetalle", "DotacionConfigTipoAreaId", "dbo.DotacionConfigTipoArea");
            DropIndex("dbo.DotacionConfigTipoPersonalDetalle", new[] { "PrendaId" });
            DropIndex("dbo.DotacionConfigTipoPersonalDetalle", new[] { "DotacionConfigTipoPersonalId" });
            DropIndex("dbo.DotacionConfigTipoAreaDetalle", new[] { "PrendaId" });
            DropIndex("dbo.DotacionConfigTipoAreaDetalle", new[] { "DotacionConfigTipoAreaId" });
            DropTable("dbo.Empleadoes");
            DropTable("dbo.DotacionConfigTipoPersonalDetalle");
            DropTable("dbo.DotacionConfigTipoPersonal");
            DropTable("dbo.Prendas");
            DropTable("dbo.DotacionConfigTipoAreaDetalle");
            DropTable("dbo.DotacionConfigTipoArea");
        }
    }
}
