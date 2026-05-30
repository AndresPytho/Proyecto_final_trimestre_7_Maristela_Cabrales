using Gestion_semilleros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Gestion_semilleros.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            using (Gestion_de_semilleroEntities1 db = new Gestion_de_semilleroEntities1())
            {
                try
                {
                    var usuario = db.Usuario.FirstOrDefault(u =>
                        u.CorreoUsuario == model.CorreoUsuario &&
                        u.contraseñaUsuario == model.ContraseñaUsuario);

                    if (usuario != null)
                    {
                        FormsAuthentication.SetAuthCookie(usuario.CorreoUsuario, false);
                        // Redirige al método Index del AdminController
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Correo o contraseña incorrectos.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error de conexión: " + ex.Message);
                }
            }

            return View(model);
        }
    }
}