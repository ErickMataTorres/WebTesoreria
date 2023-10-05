using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTesoreria.Controllers
{
    public class TesoreriaController : Controller
    {
        // GET: Tesoreria
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OfrendaMatutina()
        {
            return View();
        }
        public ActionResult OfrendaVespertina()
        {
            return View();
        }
        public ActionResult Diezmo()
        {
            return View();
        }
        public JsonResult ListaMatutina(string concepto)
        {
            var a = Models.Tesoreria.DataMatutino(concepto);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaVespertina(string concepto)
        {
            var a = Models.Tesoreria.DataVespertino(concepto);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaDiezmo(string concepto)
        {
            var a = Models.Tesoreria.DataDiezmo(concepto);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalesMatutino(string concepto)
        {
            var a = Models.Tesoreria.TotalesMatutino(concepto);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalesVespertino(string concepto)
        {
            var a = Models.Tesoreria.TotalesVespertino(concepto);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalesDiezmo(string concepto)
        {
            var a = Models.Tesoreria.TotalesDiezmo(concepto);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalMatutinoWeb()
        {
            var a = Models.Tesoreria.TotalMatutinoWeb();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalVespertinoWeb()
        {
            var a = Models.Tesoreria.TotalVespertinoWeb();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalDiezmoWeb()
        {
            var a = Models.Tesoreria.TotalDiezmoWeb();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TabTotalMatutina(string concepto)
        {
            var a = Models.Tesoreria.TabTotalMatutina(concepto);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TabTotalVespertina(string concepto)
        {
            var a = Models.Tesoreria.TabTotalVespertina(concepto);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TabTotalDiezmo(string concepto)
        {
            var a = Models.Tesoreria.TabTotalDiezmo(concepto);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string GuardarOfrendaMatutina(Models.Tesoreria t)
        {
            string r = t.GuardarOfrendaMatutina();
            return r;
        }
        [HttpPost]
        public string GuardarOfrendaVespertina(Models.Tesoreria t)
        {
            string r = t.GuardarOfrendaVespertina();
            return r;
        }
        [HttpPost]
        public string GuardarDiezmo(Models.Tesoreria t)
        {
            string r = t.GuardarDiezmo();
            return r;
        }
    }
}