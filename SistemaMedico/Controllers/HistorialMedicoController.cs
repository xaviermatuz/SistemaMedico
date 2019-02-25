using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMedico.Controllers
{
    public class HistorialMedicoController : Controller
    {
        // GET: HistorialMedico
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