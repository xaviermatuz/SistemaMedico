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
using SistemaMedico.Models.ViewModel;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Helpers;

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
            IEnumerable<Equipo_Deportivo> equipo = db.Equipo_Deportivo.Where(s => s.Activo.ToString() == "true");

            Datos_Atleta datos_Atleta = db.Datos_Atleta
              .Include(x => x.Atleta_Categoria).
              Include(x=>x.Equipo_Deportivo)
              .Where(x => x.ID == x.ID).FirstOrDefault();
            if (datos_Atleta == null)
            {
                return HttpNotFound();
            }
            CargarListasVistaAtleta(datos_Atleta);

            foreach (Atleta_Categoria atleta_Categoria in datos_Atleta.Atleta_Categoria)
            {
                atleta_Categoria.Categorias.Deporte = db.Deporte.Find(atleta_Categoria.Categorias.ID_Deporte);
            }

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
            CargarListasVistaAtleta(null);
            return View("/Views/Atleta/Crear.cshtml", new AtletaView() { Model = new Datos_Atleta() });
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
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            if (db.Datos_Atleta.Any(x=>x.Numero_De_Cedula==view.Model.Numero_De_Cedula))
            {

            }
            else
            {
                var pic = string.Empty;
                //var folder = "Perfiles";

                if (view.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(view.ImageFile.FileName);
                    string extension = Path.GetExtension(view.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    pic = fileName;
                    //Image Img2 = ResizeImage(100, 100,pic);
                    pic = string.Format("{0}/{1}", "Perfiles", pic);
                    view.ImageFile.SaveAs(Path.Combine(Server.MapPath("/Perfiles"), fileName));
                }

                Datos_Atleta datos_Atleta = new Datos_Atleta();
                datos_Atleta.Foto = pic;
                

                datos_Atleta.Primer_Nombre = myTI.ToTitleCase(view.Model.Primer_Nombre);
                datos_Atleta.Segundo_Nombre = myTI.ToTitleCase(view.Model.Segundo_Nombre);
                datos_Atleta.Primer_Apellido = myTI.ToTitleCase(view.Model.Primer_Apellido);
                datos_Atleta.Segundo_Apellido = myTI.ToTitleCase(view.Model.Segundo_Apellido);
                datos_Atleta.Nombre_Completo = myTI.ToTitleCase(view.Model.Primer_Nombre + " " + view.Model.Segundo_Nombre + " " + view.Model.Primer_Apellido + " " + view.Model.Segundo_Apellido);
                datos_Atleta.Edad = view.Model.Edad;
                datos_Atleta.Fecha_De_Registro = DateTime.Today;

                if (view.Model.Genero == "Masculino")
                {
                    datos_Atleta.Genero = view.Model.Genero;
                    datos_Atleta.Embarazo = "No";


                }
                else
                {
                    datos_Atleta.Genero = view.Model.Genero;
                    datos_Atleta.Embarazo = view.Model.Embarazo;
                }
                datos_Atleta.Numero_De_Cedula = myTI.ToTitleCase(view.Model.Numero_De_Cedula);
                datos_Atleta.Correo_Electronico = view.Model.Correo_Electronico;
                datos_Atleta.Telefono_Convencional = view.Model.Telefono_Convencional;
                datos_Atleta.Telefono_Celular = view.Model.Telefono_Celular;

                datos_Atleta.Tiene_Seguro = view.Model.Tiene_Seguro;

                datos_Atleta.Hospital = view.Model.Hospital;

                datos_Atleta.Dirreccion = myTI.ToTitleCase(view.Model.Dirreccion);
                datos_Atleta.Municipio = view.Model.Municipio;
                datos_Atleta.Nombre_Madre = myTI.ToTitleCase(view.Model.Nombre_Madre);
                datos_Atleta.Telefono_Madre = view.Model.Telefono_Madre;
                datos_Atleta.Nombre_Padre = myTI.ToTitleCase(view.Model.Nombre_Padre);
                datos_Atleta.Telefono_Padre = view.Model.Telefono_Padre;
                datos_Atleta.Emergencia = myTI.ToTitleCase(view.Model.Emergencia);
                datos_Atleta.Dirreccion_Emergencia = myTI.ToTitleCase(view.Model.Dirreccion_Emergencia);

           
             
                datos_Atleta.Activo = true;

                if (view.Model.Atleta_Categoria != null)
                {
                    foreach (Atleta_Categoria atle in view.Model.Atleta_Categoria)
                    {
                        atle.ID_Atleta = view.Model.ID;
                        
                        atle.activo = true;
                        db.Atleta_Categoria.AddRange(view.Model.Atleta_Categoria);
                    }


                }


                Equipo_Deportivo equi = new Equipo_Deportivo();

                equi.ID_Atleta = view.Model.ID;

                equi.equipdep = view.equip.equipdep;


                if (view.equip.relaentre == "Inadecuadas")
                {
                    equi.relaentre = view.equip.relaentre;
                    equi.ra_ina_entre = myTI.ToTitleCase(view.equip.ra_ina_entre);
                }
                else
                {
                    equi.relaentre = view.equip.relaentre;
                    equi.ra_ina_entre = "";
                }
                if (view.equip.relacompa == "Inadecuadas")
                {
                    equi.relacompa = view.equip.relacompa;
                    equi.ra_ina_compa = myTI.ToTitleCase(view.equip.ra_ina_compa);
                }
                else
                {
                    equi.relacompa = view.equip.relacompa;
                    equi.ra_ina_compa = "";
                }

                equi.Activo = true;

                db.Equipo_Deportivo.Add(equi);
                db.Datos_Atleta.Add(datos_Atleta);
                db.SaveChanges();
                CargarGeneros();

               

            }

             
                //Hospital();
                return RedirectToAction("Index");
            //}

            //return RedirectToAction("Index");
        }

        //Tal como lo platicas puedes crear un método que regrese un booleano y consumirlo con jQuery Ajax.
        //El método en MVC sería algo así:

public bool TienePropositos(string nombre)
        {
            using (var db = new MeSysEntities())
            {
                return db.Datos_Atleta.Any(x => x.Nombre_Completo == nombre);
            }
        }


        //private void SaveFileToDisk(HttpPostedFileBase file)
        //{
        //    WebImage img = new WebImage(file.InputStream);
        //    if (img.Width > 190)
        //    {
        //        img.Resize(190, img.Height);
        //    }
        //    img.Save(Constants.ProductImagePath + file.FileName);
        //    if (img.Width > 100)
        //    {
        //        img.Resize(100, img.Height);
        //    }
        //    img.Save(Constants.ProductThumbnailPath + file.FileName);
        //}
        //public Image ResizeImage(int newWidth, int newHeight, string stPhotoPath)
        //{
        //    Image imgPhoto = null;
        //    try
        //    {
        //        imgPhoto= Image.FromFile(stPhotoPath);

        //        int sourceWidth = imgPhoto.Width;
        //        int sourceHeight = imgPhoto.Height;

        //        //Consider vertical pics
        //        if (sourceWidth < sourceHeight)
        //        {
        //            int buff = newWidth;

        //            newWidth = newHeight;
        //            newHeight = buff;
        //        }

        //        int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
        //        float nPercent = 0, nPercentW = 0, nPercentH = 0;

        //        nPercentW = ((float)newWidth / (float)sourceWidth);
        //        nPercentH = ((float)newHeight / (float)sourceHeight);
        //        if (nPercentH < nPercentW)
        //        {
        //            nPercent = nPercentH;
        //            destX = System.Convert.ToInt16((newWidth -
        //                      (sourceWidth * nPercent)) / 2);
        //        }
        //        else
        //        {
        //            nPercent = nPercentW;
        //            destY = System.Convert.ToInt16((newHeight -
        //                      (sourceHeight * nPercent)) / 2);
        //        }

        //        int destWidth = (int)(sourceWidth * nPercent);
        //        int destHeight = (int)(sourceHeight * nPercent);


        //        Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
        //                      PixelFormat.Format24bppRgb);

        //        bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
        //                     imgPhoto.VerticalResolution);

        //        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        //        grPhoto.Clear(Color.Black);
        //        grPhoto.InterpolationMode =
        //            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        //        grPhoto.DrawImage(imgPhoto,
        //            new Rectangle(destX, destY, destWidth, destHeight),
        //            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
        //            GraphicsUnit.Pixel);

        //        grPhoto.Dispose();
        //        imgPhoto.Dispose();
        //        return bmPhoto;
        //    }
        //    catch (FileNotFoundException e)
        //    {


        //    }

        //    return imgPhoto;
        //}

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
        public ActionResult Actualizar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos_Atleta datos_Atleta = db.Datos_Atleta
                .Include(x => x.Atleta_Categoria).
                Include(x=>x.Equipo_Deportivo)
                .Where(x => x.ID == id).FirstOrDefault();
            if (datos_Atleta == null)
            {
                return HttpNotFound();
            }
            CargarListasVistaAtleta(datos_Atleta);
            foreach (Atleta_Categoria atleta_Categoria in datos_Atleta.Atleta_Categoria)
            {
                atleta_Categoria.Categorias.Deporte = db.Deporte.Find(atleta_Categoria.Categorias.ID_Deporte);
            }
            //datos_Atleta.Foto = ChangeFilePath(datos_Atleta.Foto);
            AtletaView atletaView = new AtletaView() { Model = datos_Atleta };
            return View(atletaView);
        }

        private void CargarListasVistaAtleta(Datos_Atleta datos_Atleta)
        {
            CargarGeneros();

            ViewBag.ListaDepartamentos = CargarDepartamentos();
            ViewBag.ListaDeportes = CargarDeportes();
            ViewBag.ListaMunicipios = new SelectList(Enumerable.Empty<SelectListItem>());

            if (datos_Atleta != null)
            {
                ViewBag.Hospital = new SelectList(db.Hospital, "ID", "Nombre", datos_Atleta.Hospital);

                foreach (Atleta_Categoria catg in datos_Atleta.Atleta_Categoria)
                {
                    catg.Categorias = db.Categorias.Find(catg.ID_Categoria);
                }
                datos_Atleta.Municipio1 = db.Municipio.Where(x => x.ID == datos_Atleta.Municipio).FirstOrDefault();

               // datos_Atleta = db.Datos_Atleta.Include(x=> x.Equipo_Deportivo);

                List<SelectListItem> ls = new List<SelectListItem>();
                List<Municipio> lm = db.Municipio.Where(x => x.ID_Departamento == datos_Atleta.Municipio1.ID_Departamento).ToList();
                foreach (var temp in lm)
                {
                    ls.Add(new SelectListItem() { Text = temp.Nombre, Value = temp.ID.ToString() });
                }
                ViewBag.ListaMunicipios = new SelectList(ls, "Value", "Text");
            }
        }

        // POST: Atleta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar(AtletaView view)
        {
            if (ModelState.IsValid)
            {


                var pic = view.Model.Foto;


                Datos_Atleta datos_Atleta = db.Datos_Atleta.Find(view.Model.ID);
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                if (view.ImageFile != null)
                {
                    //    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    //    pic = string.Format("{0}/{1}", "Perfiles", pic);
                    //    datos_Atleta.Foto = pic;

                    string fileName = Path.GetFileNameWithoutExtension(view.ImageFile.FileName);
                    string extension = Path.GetExtension(view.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    pic = fileName;
                    // Image img= resizeImage(100,100,pic);
                    pic = string.Format("{0}/{1}", "Perfiles", pic);
                    view.ImageFile.SaveAs(Path.Combine(Server.MapPath("/Perfiles"), fileName));

                    datos_Atleta.Foto = pic;
                }


                datos_Atleta.Primer_Nombre = myTI.ToTitleCase(view.Model.Primer_Nombre);
                datos_Atleta.Segundo_Nombre = myTI.ToTitleCase(view.Model.Segundo_Nombre);
                datos_Atleta.Primer_Apellido = myTI.ToTitleCase(view.Model.Primer_Apellido);
                datos_Atleta.Segundo_Apellido = myTI.ToTitleCase(view.Model.Segundo_Apellido);
                datos_Atleta.Nombre_Completo = myTI.ToTitleCase(view.Model.Primer_Nombre + " " + view.Model.Segundo_Nombre + " " + view.Model.Primer_Apellido + " " + view.Model.Segundo_Apellido);
                datos_Atleta.Edad = view.Model.Edad;
                datos_Atleta.Fecha_De_Registro = DateTime.Today;
                if (view.Model.Genero == "Masculino")
                {
                    datos_Atleta.Genero = view.Model.Genero;
                    datos_Atleta.Embarazo = "No";


                }
                else
                {
                    datos_Atleta.Genero = view.Model.Genero;
                    datos_Atleta.Embarazo = view.Model.Embarazo;
                }
                datos_Atleta.Numero_De_Cedula = myTI.ToTitleCase(view.Model.Numero_De_Cedula);
                datos_Atleta.Correo_Electronico = view.Model.Correo_Electronico;
                datos_Atleta.Telefono_Convencional = view.Model.Telefono_Convencional;
                datos_Atleta.Telefono_Celular = view.Model.Telefono_Celular;

                if (view.Model.Tiene_Seguro == "no")
                {

                    datos_Atleta.Tiene_Seguro = view.Model.Tiene_Seguro;
                    datos_Atleta.Hospital = int.Parse("No Tiene");
                }
                else
                {
                    datos_Atleta.Tiene_Seguro = view.Model.Tiene_Seguro;
                    datos_Atleta.Hospital = view.Model.Hospital;
                }
                datos_Atleta.Dirreccion = myTI.ToTitleCase(view.Model.Dirreccion);
                datos_Atleta.Municipio = view.Model.Municipio;
                datos_Atleta.Nombre_Madre = myTI.ToTitleCase(view.Model.Nombre_Madre);
                datos_Atleta.Telefono_Madre = view.Model.Telefono_Madre;
                datos_Atleta.Nombre_Padre = myTI.ToTitleCase(view.Model.Nombre_Padre);
                datos_Atleta.Telefono_Padre = view.Model.Telefono_Padre;
                datos_Atleta.Emergencia = myTI.ToTitleCase(view.Model.Emergencia);
                datos_Atleta.Dirreccion_Emergencia = myTI.ToTitleCase(view.Model.Dirreccion_Emergencia);



                if (view.Model.Atleta_Categoria != null)
                {
                    foreach (Atleta_Categoria atle in view.Model.Atleta_Categoria)
                    {


                        //Datos_Atleta categoria = db.Datos_Atleta.Where(x => x.ID == view.Model.ID).FirstOrDefault();

                        if (db.Atleta_Categoria.Any(x => x.ID_Categoria == atle.ID_Categoria && x.ID_Atleta == view.Model.ID))
                        {

                        }
                        else
                        {
                            view.Model.ID = view.Model.ID;
                            atle.ID_Atleta = view.Model.ID;
                            atle.ID_Categoria = atle.ID_Categoria;
                            atle.activo = true;
                            db.Atleta_Categoria.Add(atle);
                            db.SaveChanges();



                        }
                    }
                }

                //if (db.equipo_deportivo.any(x =>x.id_atleta == view.model.id))
                //{

                //}
                //else
                //{
                Equipo_Deportivo equi = db.Equipo_Deportivo.Where(x =>x.ID_Atleta==view.Model.ID).FirstOrDefault();
                equi.ID_Atleta = view.Model.ID;

                equi.equipdep = view.equip.equipdep;


                if (view.equip.relaentre == "Inadecuadas")
                {
                    equi.relaentre = view.equip.relaentre;
                    equi.ra_ina_entre = myTI.ToTitleCase(view.equip.ra_ina_entre);
                }
                else
                {
                    equi.relaentre = view.equip.relaentre;
                    equi.ra_ina_entre = "";
                }
                if (view.equip.relacompa == "Inadecuadas")
                {
                    equi.relacompa = view.equip.relacompa;
                    equi.ra_ina_compa = myTI.ToTitleCase(view.equip.ra_ina_compa);
                }
                else
                {
                    equi.relacompa = view.equip.relacompa;
                    equi.ra_ina_compa = "";
                }
                db.Entry(equi).State = EntityState.Modified;
               // db.SaveChanges();
            //}
                
 
            
                db.Entry(datos_Atleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CargarListasVistaAtleta(view.Model);
            return View(view);
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



        [HttpPost]
        public ActionResult DeleteAtletaCat(int Id)
        {
            using (MeSysEntities entities = new MeSysEntities())
            {
                // Employee emp = db.Employee.Where(x => x.EmployeeID == id)

                if (Id != 0)
                {
                    Atleta_Categoria atlecat = (from c in entities.Atleta_Categoria where c.ID == Id select c).FirstOrDefault();

                    entities.Atleta_Categoria.Remove(atlecat);
                    entities.SaveChanges();
                }
                else { return new EmptyResult(); }






            }
            return new EmptyResult();
        }
    }
}
