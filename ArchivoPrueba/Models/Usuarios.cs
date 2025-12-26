using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchivoPrueba.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public bool Estado { get; set; }
    }
}