using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchivoPrueba.Models
{
    [Table("DotacionConfigTipoArea")]
    public class DotacionConfigTipoArea
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string TipoArea { get; set; }

        public bool Activo { get; set; } = true;

        public DateTime A_Creacion { get; set; } = DateTime.Now;
        public DateTime? A_Modificacion { get; set; }

        [StringLength(100)]
        public string A_UsuarioCreador { get; set; }

        [StringLength(100)]
        public string A_UsuarioModifica { get; set; }

        public virtual ICollection<DotacionConfigTipoAreaDetalle> Detalles { get; set; }
            = new List<DotacionConfigTipoAreaDetalle>();
    }
}