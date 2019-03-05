using SistemaMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMedico.Controllers
{
    public class ExamenFisicoController : Controller
    {
        public MeSysEntities db = new MeSysEntities();
        // GET: ExamenFisico
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear(int ID)
        {
            var nom = db.Datos_Atleta.Find(ID);
            ViewBag.id = ID;
            ViewBag.nombre = nom.Nombre_Completo;
            return View();
        }
        public ActionResult Actualizar()
        {
            return View();
        }
    }
}