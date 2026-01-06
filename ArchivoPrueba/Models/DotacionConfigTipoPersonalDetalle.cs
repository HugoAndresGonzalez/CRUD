using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchivoPrueba.Models
{
    [Table("DotacionConfigTipoPersonalDetalle")]
    public class DotacionConfigTipoPersonalDetalle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DotacionConfigTipoPersonalId { get; set; }

        [ForeignKey(nameof(DotacionConfigTipoPersonalId))]
        public virtual DotacionConfigTipoPersonal Configuracion { get; set; }

        [Required]
        public int PrendaId { get; set; }

        [ForeignKey(nameof(PrendaId))]
        public virtual Prenda Prenda { get; set; }

        [Range(1, 999)]
        public int Cantidad { get; set; }

        public bool Activo { get; set; } = true;
    }
}