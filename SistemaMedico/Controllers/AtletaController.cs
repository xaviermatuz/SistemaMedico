using SistemaMedico.Models;
using SistemaMedico.Models.ViewModel;
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
        public ActionResult Mostrar(int ID)
        {
            //IEnumerable<Datos_Atleta> Atleta = ME.Datos_Atleta.Find(ID);
            //ViewBag.Atleta = Atleta;
            MostrarViewModel model = new MostrarViewModel();
            Datos_Atleta da = ME.Datos_Atleta.Find(ID);
            ViewBag.foto = da.Foto;
            model.Nombre_Completo = da.Nombre_Completo;
            model.Genero = da.Genero;
            model.Edad = da.Edad;
            model.Numero_De_Cedula = da.Numero_De_Cedula;
            model.Correo_Electronico = da.Correo_Electronico;
            model.Dirreccion = da.Dirreccion;
            model.Telefono_Celular = da.Telefono_Celular;
            model.Telefono_Convencional = da.Telefono_Convencional;
            model.Tiene_Seguro = da.Tiene_Seguro;
            //borra todos los datos de la base de datos 
            //cuando se haga corregir validador de hospital en mostrar
            if (da.Tiene_Seguro == "Si")
            {
                ViewBag.hosp = "si";
                var hos = ME.Hospital.Where(s => s.ID == da.Hospital).ToList();
                foreach (var item in hos)
                {
                    model.Hospital = item.Nombre;
                }
            }
            ViewBag.idatleta = ID;
            var mun = ME.Municipio.Where(x => x.ID == da.Municipio).ToList(); foreach (var item in mun)
            {
                var dep = ME.Departamentos.Where(x => x.ID == item.ID_Departamento).ToList();
                ViewBag.munici = item.Nombre;
                foreach (var items in dep)
                {
                    ViewBag.depa = items.Nombre;
                }

            }
            model.Nombre_Madre = da.Nombre_Madre;//
            model.Nombre_Padre = da.Nombre_Padre;//validar si esta null todos estos comentarios 
            model.Telefono_Madre = da.Telefono_Madre;//
            model.Telefono_Padre = da.Telefono_Padre;//
            model.Dirreccion_Emergencia = da.Dirreccion_Emergencia;
            //model.DA.Activo = da.Activo;
            ViewBag.Fecha_De_Registro = Convert.ToDateTime(da.Fecha_De_Registro).ToShortDateString();
            //Alergias

            IEnumerable<Alergias> aler = ME.Alergias.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.alergias = aler;
            IEnumerable<Medicamentos> medicamento = ME.Medicamentos.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.medicamentos = medicamento;
            IEnumerable<Historial_Medico> HM = ME.Historial_Medico.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.historial = HM;
            IEnumerable<Aparato_Locomotor> AP = ME.Aparato_Locomotor.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.aparato = AP;
            IEnumerable<Historia_Familiar> HF = ME.Historia_Familiar.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.historialf = HF;
            IEnumerable<Carrera_Deportiva> cd = ME.Carrera_Deportiva.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.carrera_deportiva = cd;
            IEnumerable <Carrera_Deportiva_Evento> cde = ME.Carrera_Deportiva_Evento.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.carrera_deportiva_E = cde;
            IEnumerable<Carrera_Deportiva_Familiar> cdf = ME.Carrera_Deportiva_Familiar.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.carrera_deportiva_F = cdf;
            IEnumerable<Situacion_Laboral> sl = ME.Situacion_Laboral.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.SL = sl;
            IEnumerable<Apoyo_Economico> ap = ME.Apoyo_Economico.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.AP = ap;
            IEnumerable<Consiste_Apoyo> ca = ME.Consiste_Apoyo.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.CA = ca;
            IEnumerable<Informacion_Familiar> iF = ME.Informacion_Familiar.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.If = iF;
            IEnumerable<Educacion> ED = ME.Educacion.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.ed = ED;
            IEnumerable<Habitacion> LH = ME.Habitacion.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.lh = LH;
            IEnumerable<Habitos> habitos = ME.Habitos.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.hab = habitos;
            IEnumerable<Examen_Fisico_Principal> EFP = ME.Examen_Fisico_Principal.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.efp = EFP;
            IEnumerable<Anexos> anexos = ME.Anexos.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.anex = anexos;
            IEnumerable<Condiciones_Clinicas_Actuales_Principal> cca = ME.Condiciones_Clinicas_Actuales_Principal.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.CCA = cca;
            IEnumerable<Ficha_Antropometrica> ficha_Antropometricas = ME.Ficha_Antropometrica.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.ficha = ficha_Antropometricas;

            return View(model);
        }

        //POST

    }
}