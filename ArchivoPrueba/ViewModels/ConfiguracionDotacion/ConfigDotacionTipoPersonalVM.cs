using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ArchivoPrueba.ViewModels.ConfiguracionDotacion
{
    public class ConfigDotacionTipoPersonalVM
    {
        public int? ConfigId { get; set; }

        [Required(ErrorMessage = "Seleccione un tipo de personal")]
        public string TipoPersonalSeleccionado { get; set; }

        public List<SelectListItem> TiposPersonal { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PrendasDisponibles { get; set; } = new List<SelectListItem>();

        public List<ConfigDotacionItemVM> Items { get; set; } = new List<ConfigDotacionItemVM>();
    }
}