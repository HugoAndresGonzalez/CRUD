using System.ComponentModel.DataAnnotations;

namespace ArchivoPrueba.ViewModels.ConfiguracionDotacion
{
    public class ConfigDotacionItemVM
    {
        [Required]
        public int PrendaId { get; set; }

        [Range(1, 999)]
        public int Cantidad { get; set; }

        // Solo para mostrar
        public string PrendaNombre { get; set; }

        public string Codigo { get; set; }
    }
}