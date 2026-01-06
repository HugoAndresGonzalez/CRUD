using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchivoPrueba.Models
{
    [Table("Empleadoes")]
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Documento { get; set; }

        [StringLength(50)]
        public string NroEmpleado { get; set; }

        [StringLength(200)]
        public string Nombres { get; set; }

        [StringLength(200)]
        public string Correo { get; set; }

        // Tipo de personal
        [StringLength(150)]
        public string TipoArea { get; set; }

        // Tipo de área
        [StringLength(150)]
        public string AreaDescripcion { get; set; }

        public bool Activo { get; set; } = true;
    }
}