using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTesoreria.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }
        public JsonResult ListaUsuarios()
        {
            var a = Models.Usuario.ComboBoxUsuario();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TablaUsuarios()
        {
            var a = Models.Usuario.DataUsuario();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}