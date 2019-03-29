using SistemaMedico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace SistemaMedico.Controllers
{
    public class AtletaController : Controller
    {
        DAL objdal = new DAL();
        MeSysEntities ME = new MeSysEntities();//LLamada a Entityframework, para seleccion de tabla
        // GET: Atleta
        public ActionResult Index()
        {

            IEnumerable<Datos_Atleta> Atleta = ME.Datos_Atleta.Where(s => s.Activo.ToString() == "true");
            ViewBag.Atleta = Atleta;
            return View();
        }
        
        public ActionResult Crear()
        {
            ////Deporte
            //string countrystring = "select * from Departamentos";
            //DataSet ds = new DataSet();
            //List<string> li = new List<string>();
            //DataTable dt = new DataTable();
            //dt = objdal.MyMethod(countrystring);
            //List<SelectListItem> list = new List<SelectListItem>();
            //list.Add(new SelectListItem { Text = "--Seleccionar Departamento--", Value = "0" });
            //foreach (DataRow row in dt.Rows)
            //{
            //    list.Add(new SelectListItem { Text = Convert.ToString(row.ItemArray[1]), Value = Convert.ToString(row.ItemArray[0]) });
            //}
            //ViewBag.country = list;
            ////Hospital
            //string Hospitalstring = "select * from Hospital";
            //DataSet dsh = new DataSet();
            //List<string> li1 = new List<string>();
            //DataTable dth = new DataTable();
            //dth = objdal.MyMethod(Hospitalstring);
            //List<SelectListItem> list1 = new List<SelectListItem>();
            //list1.Add(new SelectListItem { Text = "--Seleccionar Hospital--", Value = "0" });
            //foreach (DataRow row in dth.Rows)
            //{
            //    list1.Add(new SelectListItem { Text = Convert.ToString(row.ItemArray[1]), Value = Convert.ToString(row.ItemArray[0]) });
            //}
            //ViewBag.Hospital = list1;
            ////Deporte y Categoria
            //string Deportestring = "select * from Deporte";
            //DataSet dsd = new DataSet();
            //List<string> li2 = new List<string>();
            //DataTable dtd = new DataTable();
            //dtd = objdal.MyMethod(Deportestring);
            //List<SelectListItem> list2 = new List<SelectListItem>();
            //list2.Add(new SelectListItem { Text = "--Seleccionar Deporte--", Value = "0" });
            //foreach (DataRow row in dtd.Rows)
            //{
            //    list2.Add(new SelectListItem { Text = Convert.ToString(row.ItemArray[1]), Value = Convert.ToString(row.ItemArray[0]) });
            //}
            //ViewBag.Deporte = list2;
            return View();
        }
        //public JsonResult getstate(int id)
        //{
        //    //Municipio segun Departamento
        //    string countrystring = "select * from Municipio where ID_Departamento='" + id + "'";
        //    DataTable dt = new DataTable();
        //    dt = objdal.MyMethod(countrystring);
        //    List<SelectListItem> list = new List<SelectListItem>();
        //    list.Add(new SelectListItem { Text = "--Seleccionar Municipio--", Value = "0" });
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        list.Add(new SelectListItem { Text = Convert.ToString(row.ItemArray[2]), Value = Convert.ToString(row.ItemArray[0]) });
        //    }
        //    return Json(new SelectList(list, "Value", "Text", JsonRequestBehavior.AllowGet));
        //}
        //public JsonResult getsDeporte(int id)
        //{
        //    //Categoria segun Deporte
        //    string Deportestring = "select * from Categorias where ID_Deporte='" + id + "'";
        //    DataTable dt = new DataTable();
        //    dt = objdal.MyMethod(Deportestring);
        //    List<SelectListItem> list = new List<SelectListItem>();
        //    list.Add(new SelectListItem { Text = "--Seleccionar Categoria--", Value = "0" });
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        list.Add(new SelectListItem { Text = Convert.ToString(row.ItemArray[2]), Value = Convert.ToString(row.ItemArray[0]) });
        //    }
        //    return Json(new SelectList(list, "Value", "Text", JsonRequestBehavior.AllowGet));
        //}
        public ActionResult Actualizar()
        {
            return View();
        }

        //POST

    }
}