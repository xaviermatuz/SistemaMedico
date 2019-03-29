using SistemaMedico.Models;
using SistemaMedico.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ViewBag.genero = nom.Genero;
            return View();
        }
        [HttpPost]
        public ActionResult Crear(ExamenFisicoViewModel model, FormCollection collection)
        {
           
            //ficha antroprometrica

            return Redirect("~/HomeAdmin/");
           
        }
        public ActionResult Actualizar()
        {
            return View();
        }
    }
}