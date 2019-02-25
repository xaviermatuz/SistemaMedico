using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMedico.Controllers
{
    public class ExamenFisicoController : Controller
    {
        // GET: ExamenFisico
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear()
        {
            return View();
        }
        public ActionResult Actualizar()
        {
            return View();
        }
    }
}