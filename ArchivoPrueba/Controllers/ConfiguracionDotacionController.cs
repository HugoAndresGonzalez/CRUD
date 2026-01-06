using ArchivoPrueba.Models;
using ArchivoPrueba.ViewModels.ConfiguracionDotacion;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ArchivoPrueba.Controllers
{
    public class ConfiguracionDotacionController : Controller
    {
        private readonly PruebasContext _db = new PruebasContext();

        // Menú simple
        public ActionResult Index()
        {
            return View();
        }

        // ==========================
        // CONFIGURACIÓN POR TIPO PERSONAL (Empleadoes.TipoArea)
        // ==========================
        [HttpGet]
        public ActionResult TipoPersonal(string tipoPersonal = null)
        {
            var vm = new ConfigDotacionTipoPersonalVM
            {
                TiposPersonal = GetTiposPersonal(),
                PrendasDisponibles = GetPrendas()
            };

            if (!string.IsNullOrWhiteSpace(tipoPersonal))
            {
                vm.TipoPersonalSeleccionado = tipoPersonal.Trim();

                var cfg = _db.DotacionConfigTipoPersonal
                    .Include(x => x.Detalles.Select(d => d.Prenda))
                    .FirstOrDefault(x => x.Activo && x.TipoPersonal == vm.TipoPersonalSeleccionado);

                if (cfg != null)
                {
                    vm.ConfigId = cfg.Id;

                    vm.Items = cfg.Detalles
                        .Where(d => d.Activo)
                        .Select(d => new ConfigDotacionItemVM
                        {
                            PrendaId = d.PrendaId,
                            Cantidad = d.Cantidad,
                            PrendaNombre = d.Prenda != null ? d.Prenda.PrendaNombre : "",
                            Codigo = d.Prenda != null ? d.Prenda.Codigo : ""
                        })
                        .ToList();
                }
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarTipoPersonal(ConfigDotacionTipoPersonalVM vm)
        {
            vm.TiposPersonal = GetTiposPersonal();
            vm.PrendasDisponibles = GetPrendas();

            vm.TipoPersonalSeleccionado = vm.TipoPersonalSeleccionado?.Trim();

            vm.Items = (vm.Items ?? Enumerable.Empty<ConfigDotacionItemVM>())
                .Where(i => i != null && i.PrendaId > 0 && i.Cantidad > 0)
                .ToList();

            if (string.IsNullOrWhiteSpace(vm.TipoPersonalSeleccionado))
                ModelState.AddModelError(nameof(vm.TipoPersonalSeleccionado), "Seleccione un tipo de personal.");

            if (!vm.Items.Any())
                ModelState.AddModelError("", "Agregue al menos una prenda con cantidad.");

            if (vm.Items.GroupBy(i => i.PrendaId).Any(g => g.Count() > 1))
                ModelState.AddModelError("", "No se permiten prendas duplicadas.");

            if (!ModelState.IsValid)
                return View("TipoPersonal", vm);

            var usuario = User?.Identity?.Name ?? "Sistema";

            var cfg = _db.DotacionConfigTipoPersonal
                .Include(x => x.Detalles)
                .FirstOrDefault(x => x.Activo && x.TipoPersonal == vm.TipoPersonalSeleccionado);

            if (cfg == null)
            {
                cfg = new DotacionConfigTipoPersonal
                {
                    TipoPersonal = vm.TipoPersonalSeleccionado,
                    Activo = true,
                    A_Creacion = DateTime.Now,
                    A_UsuarioCreador = usuario
                };

                _db.DotacionConfigTipoPersonal.Add(cfg);
                _db.SaveChanges(); // para tener cfg.Id
            }
            else
            {
                cfg.A_Modificacion = DateTime.Now;
                cfg.A_UsuarioModifica = usuario;

                // Reemplazar detalle (MVP)
                foreach (var det in cfg.Detalles.ToList())
                    _db.DotacionConfigTipoPersonalDetalle.Remove(det);
            }

            foreach (var it in vm.Items)
            {
                _db.DotacionConfigTipoPersonalDetalle.Add(new DotacionConfigTipoPersonalDetalle
                {
                    DotacionConfigTipoPersonalId = cfg.Id,
                    PrendaId = it.PrendaId,
                    Cantidad = it.Cantidad,
                    Activo = true
                });
            }

            _db.SaveChanges();

            TempData["Ok"] = "Configuración por Tipo de Personal guardada correctamente.";
            return RedirectToAction(nameof(TipoPersonal), new { tipoPersonal = vm.TipoPersonalSeleccionado });
        }

        // ==========================
        // CONFIGURACIÓN POR ÁREA (Empleadoes.AreaDescripcion)
        // ==========================
        [HttpGet]
        public ActionResult TipoArea(string tipoArea = null)
        {
            var vm = new ConfigDotacionTipoAreaVM
            {
                TiposArea = GetTiposArea(),
                PrendasDisponibles = GetPrendas()
            };

            if (!string.IsNullOrWhiteSpace(tipoArea))
            {
                vm.TipoAreaSeleccionada = tipoArea.Trim();

                var cfg = _db.DotacionConfigTipoArea
                    .Include(x => x.Detalles.Select(d => d.Prenda))
                    .FirstOrDefault(x => x.Activo && x.TipoArea == vm.TipoAreaSeleccionada);

                if (cfg != null)
                {
                    vm.ConfigId = cfg.Id;

                    vm.Items = cfg.Detalles
                        .Where(d => d.Activo)
                        .Select(d => new ConfigDotacionItemVM
                        {
                            PrendaId = d.PrendaId,
                            Cantidad = d.Cantidad,
                            PrendaNombre = d.Prenda != null ? d.Prenda.PrendaNombre : "",
                            Codigo = d.Prenda != null ? d.Prenda.Codigo : ""
                        })
                        .ToList();
                }
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarTipoArea(ConfigDotacionTipoAreaVM vm)
        {
            vm.TiposArea = GetTiposArea();
            vm.PrendasDisponibles = GetPrendas();

            vm.TipoAreaSeleccionada = vm.TipoAreaSeleccionada?.Trim();

            vm.Items = (vm.Items ?? Enumerable.Empty<ConfigDotacionItemVM>())
                .Where(i => i != null && i.PrendaId > 0 && i.Cantidad > 0)
                .ToList();

            if (string.IsNullOrWhiteSpace(vm.TipoAreaSeleccionada))
                ModelState.AddModelError(nameof(vm.TipoAreaSeleccionada), "Seleccione un tipo de área.");

            if (!vm.Items.Any())
                ModelState.AddModelError("", "Agregue al menos una prenda con cantidad.");

            if (vm.Items.GroupBy(i => i.PrendaId).Any(g => g.Count() > 1))
                ModelState.AddModelError("", "No se permiten prendas duplicadas.");

            if (!ModelState.IsValid)
                return View("TipoArea", vm);

            var usuario = User?.Identity?.Name ?? "Sistema";

            var cfg = _db.DotacionConfigTipoArea
                .Include(x => x.Detalles)
                .FirstOrDefault(x => x.Activo && x.TipoArea == vm.TipoAreaSeleccionada);

            if (cfg == null)
            {
                cfg = new DotacionConfigTipoArea
                {
                    TipoArea = vm.TipoAreaSeleccionada,
                    Activo = true,
                    A_Creacion = DateTime.Now,
                    A_UsuarioCreador = usuario
                };

                _db.DotacionConfigTipoArea.Add(cfg);
                _db.SaveChanges();
            }
            else
            {
                cfg.A_Modificacion = DateTime.Now;
                cfg.A_UsuarioModifica = usuario;

                foreach (var det in cfg.Detalles.ToList())
                    _db.DotacionConfigTipoAreaDetalle.Remove(det);
            }

            foreach (var it in vm.Items)
            {
                _db.DotacionConfigTipoAreaDetalle.Add(new DotacionConfigTipoAreaDetalle
                {
                    DotacionConfigTipoAreaId = cfg.Id,
                    PrendaId = it.PrendaId,
                    Cantidad = it.Cantidad,
                    Activo = true
                });
            }

            _db.SaveChanges();

            TempData["Ok"] = "Configuración por Área guardada correctamente.";
            return RedirectToAction(nameof(TipoArea), new { tipoArea = vm.TipoAreaSeleccionada });
        }

        // ==========================
        // Helpers para combos
        // ==========================
        private System.Collections.Generic.List<SelectListItem> GetTiposPersonal()
        {
            return _db.Empleadoes
                .Where(e => e.Activo && e.TipoArea != null && e.TipoArea.Trim() != "")
                .Select(e => e.TipoArea)
                .Distinct()
                .OrderBy(x => x)
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x.Trim(), Text = x.Trim() })
                .ToList();
        }

        private System.Collections.Generic.List<SelectListItem> GetTiposArea()
        {
            return _db.Empleadoes
                .Where(e => e.Activo && e.AreaDescripcion != null && e.AreaDescripcion.Trim() != "")
                .Select(e => e.AreaDescripcion)
                .Distinct()
                .OrderBy(x => x)
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x.Trim(), Text = x.Trim() })
                .ToList();
        }

        private System.Collections.Generic.List<SelectListItem> GetPrendas()
        {
            var prendas = _db.Prendas
                .Select(p => new { p.Id, p.PrendaNombre, p.Codigo })
                .ToList(); // <-- aquí ya trae a memoria

            return prendas
                .OrderBy(p => p.PrendaNombre)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.PrendaNombre + (string.IsNullOrWhiteSpace(p.Codigo) ? "" : " (" + p.Codigo + ")")
                })
                .ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();
            base.Dispose(disposing);
        }
    }
}