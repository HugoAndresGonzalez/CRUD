using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ArchivoPrueba.ViewModels.ConfiguracionDotacion
{
    public class ConfigDotacionTipoAreaVM
    {
        public int? ConfigId { get; set; }

        [Required(ErrorMessage = "Seleccione un tipo de área")]
        public string TipoAreaSeleccionada { get; set; }

        public List<SelectListItem> TiposArea { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PrendasDisponibles { get; set; } = new List<SelectListItem>();

        public List<ConfigDotacionItemVM> Items { get; set; } = new List<ConfigDotacionItemVM>();
    }
}