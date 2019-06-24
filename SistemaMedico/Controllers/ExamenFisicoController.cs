using SistemaMedico.Models;
using SistemaMedico.Models.ViewModel;
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
        [HttpPost]
        public ActionResult Crear(ExamenFisicoViewModel model)
        {
            //pregunta 1 
            Examen_Fisico_Principal Examen1 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = model.ID_Atleta;
            Examen1.ID_Examen_Fisico = 1;
            Examen1.Normal = "Si";
            Examen1.Hallazgos_Anormales = "";
            db.Examen_Fisico_Principal.Add(Examen1);
            db.SaveChanges();
            return Redirect("~/HomeAdmin/");
           
        }
        public ActionResult Actualizar()
        {
            return View();
        }
    }
}