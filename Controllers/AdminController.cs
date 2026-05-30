using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestion_semilleros.Models;

namespace Gestion_semilleros.Controllers
{
    public class AdminController : Controller
    {
        private Gestion_de_semilleroEntities1 db = new Gestion_de_semilleroEntities1();

        // Cambiado de 'Admin' a 'Index' para seguir la convención de rutas
        public ActionResult Index()
        {
            var model = new AdminDashboardViewModel
            {
                TotalSemilleros = db.Semillero.Count(),
                TotalUsuarios = db.Usuario.Count(),
                TotalProyectos = db.Proyecto.Count(),
                TotalReuniones = db.Reunion.Count(),
                TotalPatrocinadores = db.Patrocinadores.Count()
            };

            // Retornamos explícitamente la vista "Admin.cshtml"
            return View("Admin", model);
        }
    }
}