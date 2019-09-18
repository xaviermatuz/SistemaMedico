using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMedico.Controllers
{
    public class LesionesController : Controller
    {
        // GET: Lesiones
        public ActionResult Index()
        {
            return View();
        }
    }
}