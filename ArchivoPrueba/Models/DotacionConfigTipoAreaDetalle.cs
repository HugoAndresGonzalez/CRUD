using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchivoPrueba.Models
{
    [Table("DotacionConfigTipoAreaDetalle")]
    public class DotacionConfigTipoAreaDetalle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DotacionConfigTipoAreaId { get; set; }

        [ForeignKey(nameof(DotacionConfigTipoAreaId))]
        public virtual DotacionConfigTipoArea Configuracion { get; set; }

        [Required]
        public int PrendaId { get; set; }

        [ForeignKey(nameof(PrendaId))]
        public virtual Prenda Prenda { get; set; }

        [Range(1, 999)]
        public int Cantidad { get; set; }

        public bool Activo { get; set; } = true;
    }
}