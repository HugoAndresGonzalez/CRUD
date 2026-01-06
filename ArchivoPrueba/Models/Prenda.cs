using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchivoPrueba.Models
{
    [Table("Prendas")]
    public class Prenda
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string PrendaNombre { get; set; }

        [StringLength(50)]
        public string Codigo { get; set; }
    }
}