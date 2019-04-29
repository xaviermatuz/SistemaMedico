using SistemaMedico.Clases;
using SistemaMedico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SistemaMedico.Controllers
{
    public class AtletaController : Controller
    {
        private MeSysEntities db = new MeSysEntities();
        DAL objdal = new DAL();

        // GET: Atleta
        public ActionResult Index()
        {
            IEnumerable<Datos_Atleta> Atleta = db.Datos_Atleta.Where(s => s.Activo.ToString() == "true");
            ViewBag.Atleta = Atleta;
            return View();
        }

        // GET: Atleta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos_Atleta datos_Atleta = db.Datos_Atleta.Find(id);
            if (datos_Atleta == null)
            {
                return HttpNotFound();
            }
            return View(datos_Atleta);
        }

        // GET: Atleta/Create
        public ActionResult Crear()
        {
            CargarGeneros();


            ViewBag.ListaDepartamentos = CargarDepartamentos();
            ViewBag.ListaDeportes = CargarDeportes();

            return View(new AtletaView());
        }

        private void CargarGeneros()
        {
            IEnumerable<SelectListItem> items = new List<SelectListItem>() { new SelectListItem() { Text = "Masculino", Value = "Masculino" }, new SelectListItem() { Text = "Femenino", Value = "Femenino" } };
            ViewBag.Genero = items;
        }


        //hospital

        // POST: Atleta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(AtletaView view)
        {
            var pic = string.Empty;
            var folder = "~/Perfiles";

            if (view.ImageFile != null)
            {
                pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                pic = string.Format("{0}/{1}", folder, pic);
            }

            Datos_Atleta datos_Atleta = new Datos_Atleta();
            datos_Atleta.Foto = pic;

            datos_Atleta.Primer_Nombre = view.Primer_Nombre;
            datos_Atleta.Segundo_Nombre = view.Segundo_Nombre;
            datos_Atleta.Primer_Apellido = view.Primer_Apellido;
            datos_Atleta.Segundo_Apellido = view.Segundo_Apellido;
            datos_Atleta.Nombre_Completo = view.Primer_Nombre + " " + view.Segundo_Nombre + " " + view.Primer_Apellido + " " + view.Segundo_Apellido;
            datos_Atleta.Edad = view.Edad;
            datos_Atleta.Fecha_De_Registro = DateTime.Today;

            if (view.Genero == "Masculino")
            {
                datos_Atleta.Genero = view.Genero;
                datos_Atleta.Embarazo = "No";
            }
            else
            {
                datos_Atleta.Genero = view.Genero;
                datos_Atleta.Embarazo = view.Embarazo;
            }
            datos_Atleta.Numero_De_Cedula = view.Numero_De_Cedula;
            datos_Atleta.Correo_Electronico = view.Correo_Electronico;
            datos_Atleta.Telefono_Convencional = view.Telefono_Convencional;
            datos_Atleta.Telefono_Celular = view.Telefono_Celular;

            datos_Atleta.Tiene_Seguro = view.Tiene_Seguro;

            datos_Atleta.Hospital = view.Hospital;

            datos_Atleta.Dirreccion = view.Dirreccion;
            datos_Atleta.Municipio = view.Municipio;
            datos_Atleta.Nombre_Madre = view.Nombre_Madre;
            datos_Atleta.Telefono_Madre = view.Telefono_Madre;
            datos_Atleta.Nombre_Padre = view.Nombre_Padre;
            datos_Atleta.Telefono_Padre = view.Telefono_Padre;
            datos_Atleta.Emergencia = view.Emergencia;
            datos_Atleta.Dirreccion_Emergencia = view.Dirreccion;

            datos_Atleta.Activo = true;

            if (view.categorias != null)
            {
                view.categorias.ForEach(x => x.ID_Atleta = view.ID);
                db.Atleta_Categoria.AddRange(view.categorias);
            }

            db.Datos_Atleta.Add(datos_Atleta);
            db.SaveChanges();
            CargarGeneros();
            //Hospital();
            return RedirectToAction("~/Home/Admin/");
        }

        public static List<SelectListItem> GetDropDown()
        {
            MeSysEntities db1 = new MeSysEntities();
            List<SelectListItem> ls = new List<SelectListItem>();
            var lm = db1.Hospital.ToList();
            foreach (var temp in lm)
            {
                ls.Add(new SelectListItem() { Text = temp.Nombre, Value = temp.ID.ToString() });
            }
            return ls;
        }


        public SelectList CargarDepartamentos()
        {
            MeSysEntities db1 = new MeSysEntities();
            List<SelectListItem> ls = new List<SelectListItem>();
            List<Departamentos> lm = db1.Departamentos.ToList();
            foreach (var temp in lm)
            {
                ls.Add(new SelectListItem() { Text = temp.Nombre, Value = temp.ID.ToString() });
            }
            SelectList selectLists = new SelectList(ls, "Value", "Text");
            return selectLists;
        }

        //....GetMunicipiosPorDpto?IdDpto=1 -> Query strings
        //....GetMunicipiosPorDpto/1        -> Url friendly
        [HttpGet]
        [Route("[action]/{IdDpto}")]
        public JsonResult GetMunicipiosPorDpto(int IdDpto)
        {
            MeSysEntities db1 = new MeSysEntities();
            List<Municipio> lm = db1.Municipio.Where(x => x.ID_Departamento == IdDpto).ToList();
            return Json(lm, JsonRequestBehavior.AllowGet);
        }

        public SelectList CargarDeportes()
        {
            MeSysEntities db1 = new MeSysEntities();
            List<SelectListItem> ls = new List<SelectListItem>();
            List<Deporte> lm = db1.Deporte.ToList();
            foreach (var temp in lm)
            {
                ls.Add(new SelectListItem() { Text = temp.Nombre, Value = temp.ID.ToString() });
            }
            SelectList selectLists = new SelectList(ls, "Value", "Text");
            return selectLists;
        }
        //....GetCategoriaDeporte?IdDep=1 -> Query strings
        //....GetCategoriaDeporte/1        -> Url friendly
        [HttpGet]
        [Route("[action]/{IdDeporte}")]
        public JsonResult GetCategoriaDeporte(int IdDeporte)
        {
            MeSysEntities db1 = new MeSysEntities();
            List<Categorias> lm = db1.Categorias.Where(x => x.ID_Deporte == IdDeporte).ToList();
            return Json(lm, JsonRequestBehavior.AllowGet);
        }
        // GET: Atleta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos_Atleta datos_Atleta = db.Datos_Atleta.Find(id);
            if (datos_Atleta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hospital = new SelectList(db.Hospital, "ID", "Nombre", datos_Atleta.Hospital);
            return View(datos_Atleta);
        }

        // POST: Atleta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Foto,Primer_Nombre,Segundo_Nombre,Primer_Apellido,Segundo_Apellido,Nombre_Completo,Edad,Fecha_De_Registro,Genero,Numero_De_Cedula,Correo_Electronico,Telefono_Convencional,Telefono_Celular,Tiene_Seguro,Hospital,Dirreccion,Municipio,Nombre_Madre,Telefono_Madre,Nombre_Padre,Telefono_Padre,Emergencia,Dirreccion_Emergencia,Embarazo")] Datos_Atleta datos_Atleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datos_Atleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hospital = new SelectList(db.Hospital, "ID", "Nombre", datos_Atleta.Hospital);
            return View(datos_Atleta);
        }

        // GET: Atleta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos_Atleta datos_Atleta = db.Datos_Atleta.Find(id);
            if (datos_Atleta == null)
            {
                return HttpNotFound();
            }
            return View(datos_Atleta);
        }

        // POST: Atleta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Datos_Atleta datos_Atleta = db.Datos_Atleta.Find(id);
            db.Datos_Atleta.Remove(datos_Atleta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public async Task<ActionResult> AddCategoryToAthlete(int IdCategoria)
        {
            if (IdCategoria <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "El ID proporcionado no es válido");
            }
            MeSysEntities db1 = new MeSysEntities();
            Categorias categoria = await db1.Categorias.Where(x => x.ID == IdCategoria).FirstOrDefaultAsync();
            if (categoria == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "No se encontró ninguna categoria con el ID proporcionado");
            }
            Atleta_Categoria atleta_Categoria = new Atleta_Categoria()
            {
                ID_Categoria = IdCategoria,
                Categorias = categoria
            };
            return PartialView("/Views/Atleta/_Category.cshtml", atleta_Categoria);
        }
    }
}
