using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace SistemaMedico.Controllers
{
    public class AtletaController : Controller
    {
        DAL objdal = new DAL();
        // GET: Atleta
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Crear()
        {
            string countrystring = "select * from Departamentos";
            DataSet ds = new DataSet();
            List<string> li = new List<string>();
            DataTable dt = new DataTable();
            dt = objdal.MyMethod(countrystring);
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "--Seleccionar Departamento--", Value = "0" });
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SelectListItem { Text = Convert.ToString(row.ItemArray[1]), Value = Convert.ToString(row.ItemArray[0]) });
            }
            ViewBag.country = list;
            return View();
        }
        public JsonResult getstate(int id)
        {
            string countrystring = "select * from Municipio where ID_Departamento='" + id + "'";
            DataTable dt = new DataTable();
            dt = objdal.MyMethod(countrystring);
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "--Seleccionar Municipio--", Value = "0" });
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SelectListItem { Text = Convert.ToString(row.ItemArray[2]), Value = Convert.ToString(row.ItemArray[0]) });
            }
            return Json(new SelectList(list, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        public ActionResult Actualizar()
        {
            return View();
        }
    }
}