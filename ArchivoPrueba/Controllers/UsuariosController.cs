using ArchivoPrueba.Models;
using ArchivoPrueba.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchivoPrueba.Controllers
{
    public class UsuariosController : Controller
    {
        public UsuariosRepository Repo = new UsuariosRepository();

        // GET: Usuarios
        public ActionResult Index()
        {
            List<Usuarios> todos = new List<Usuarios>();
            try
            {
                todos = Repo.ConsultaTodos();
            }
            catch (Exception ex)
            {
            }
            return View(todos);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            Usuarios Result = Repo.ObtenerDato(id);
            return View(Result);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            Usuarios usuarios = new Usuarios();
            return View(usuarios);
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuarios model)
        {
            try
            {
                Repo.AddUsuario(model);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            Usuarios Result = Repo.ObtenerDato(id);
            return View(Result);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuarios model)
        {
            try
            {
                var result = Repo.EditUsuarios(id, model);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            Usuarios Result = Repo.ObtenerDato(id);
            return View(Result);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Usuarios model)
        {
            try
            {
                Repo.DeleteUsuario(id, model);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}