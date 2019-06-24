using SistemaMedico.Models;
using SistemaMedico.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaMedico.Controllers
{
    public class HistorialMedicoController : Controller
    {
        public MeSysEntities db = new MeSysEntities();
        // GET: HistorialMedico
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
        public Datos_Atleta GetDA(int ID)
        {
            Datos_Atleta model = new Datos_Atleta();
            Datos_Atleta da = db.Datos_Atleta.Find(ID);
            model.ID = da.ID;
            model.Nombre_Completo = da.Nombre_Completo;
            ViewBag.Nombre = model.Nombre_Completo;
            return model;
        }
        public ActionResult Actualizar(int ID)
        {
            Actualizar BCVM = new Actualizar();
            ViewBag.randoma = GetDA(ID);
            ViewBag.id = ID;
            //Aqui va medicamentos
            var MEIE = db.Medicamentos.Where(s => s.ID_Atleta == ID);/*hm = db.Historial_Medico.Where(s => s.ID_Atleta == ID);*/
            foreach (var i in MEIE.ToList())
            {
                if (i.Medicamentos1 == "Relajante Musculares")
                {
                    ViewBag.medica = i.Medicamentos1;
                    ViewBag.desc1 = i.Descripcion;
                }
                if (i.Medicamentos1 == "Antiinflamatorios")
                {
                    ViewBag.anti = i.Medicamentos1;
                    ViewBag.desc2 = i.Descripcion;
                }
                if (i.Medicamentos1 == "Analgesicos")
                {
                    ViewBag.anal = i.Medicamentos1;
                    ViewBag.desc3 = i.Descripcion;
                }
                if (i.Medicamentos1 == "Otros Medicamentos")
                {
                    ViewBag.otr = i.Medicamentos1;
                    ViewBag.desc4 = i.Medicamentos1;
                }
            }
            //Aqui va Alergias
            var ALIE = db.Alergias.Where(s => s.ID_Atleta == ID);
            foreach (var i in ALIE.ToList())
            {
                if (i.Alergia == null)
                {
                    ViewBag.arb = "No";
                }
                if (i.Alergia == "Medicamentos")
                {
                    ViewBag.Al1 = i.Alergia;
                    ViewBag.Adesc1 = i.Descripcion;
                }
                if (i.Alergia == "Polen")
                {
                    ViewBag.Al2 = i.Alergia;
                    ViewBag.Adesc2 = i.Descripcion;
                }
                if (i.Alergia == "Comida")
                {
                    ViewBag.Al3 = i.Alergia;
                    ViewBag.Adesc3 = i.Descripcion;
                }
                if (i.Alergia == "Piquetes de insectos")
                {
                    ViewBag.Al4 = i.Alergia;
                    ViewBag.Adesc4 = i.Descripcion;
                }
                if (i.Alergia == "Otros")
                {
                    ViewBag.Al5 = i.Alergia;
                    ViewBag.Adesc5 = i.Descripcion;
                }
            }
            //Aqui va Historial Medico
            var HMIE = db.Historial_Medico.Where(s => s.ID_Atleta == ID);
            foreach (var i in HMIE.ToList())
            {
                //Pregunta A
                if (i.Preguntas == "¿Alguna vez un doctor te ha prohibido limitado tu participacion en deportes por alguna razon?")
                {
                    ViewBag.Hmr1 = i.Respuestas;
                }
                //Pregunta B
                if (i.Preguntas == "¿Has sido ingresado alguna vez en el hospital?")
                {
                    ViewBag.Hmr2 = i.Respuestas;
                }
                //Pregunta C
                if (i.Preguntas == "¿Has tenido cirugia alguna vez?")
                {
                    ViewBag.Hmr3 = i.Respuestas;
                }
                //Pregunta D
                if (i.Preguntas == "¿Usas lentes o lentes de contacto?")
                {
                    ViewBag.Hmr4 = i.Respuestas;
                }
                //Pregunta E
                if (i.Preguntas == "¿Naciste o te falta un riñon,un ojo,un testiculo u algun otro órgano?")
                {
                    ViewBag.Hmr5 = i.Respuestas;
                }
                //Pregunta F
                if (i.Preguntas == "¿Te has desmayado durante o despues de hacer ejercicios?")
                {
                    ViewBag.Hmr6 = i.Respuestas;
                }
                //Pregunta G
                if (i.Preguntas == "¿Has tenido alguna vez molestias dolor o presion en el pecho cuando haces ejercicios?")
                {
                    ViewBag.Hmr7 = i.Respuestas;
                }
                //Pregunta H
                if (i.Preguntas == "¿Alguna vez has tenido palpitaciones o latidos irregulares cuando haces ejercicios?")
                {
                    ViewBag.Hmr8 = i.Respuestas;
                }
                //Pregunta I
                if (i.Preguntas == "¿Te ha dicho un doctor que tienes un problema del Corazón?")
                {
                    ViewBag.Hmr9 = i.Respuestas;
                }
                //Anexo I A
                if (i.Preguntas == "I.A Presion Alta")
                {
                    ViewBag.HmrAA = i.Respuestas;
                }
                //Anexo I B
                if (i.Preguntas == "I.B Soplo en el Corazón")
                {
                    ViewBag.HmrAB = i.Respuestas;
                }
                //Anexo I C
                if (i.Preguntas == "I.C Nivel alto de Colesterol")
                {
                    ViewBag.HmrAC = i.Respuestas;
                }
                //Anexo I D
                if (i.Preguntas == "I.D Otro")
                {
                    ViewBag.HmrAD = i.Respuestas;
                    ViewBag.HmdAD = i.Detalles;
                }
                //Pregunta J
                if (i.Preguntas == "¿Alguna vez un doctor te ha pedido que te hagas una prueba del corazon¿Ej:Electrocardiograma?")
                {
                    ViewBag.Hmr10 = i.Respuestas;
                }
                //Pregunta K
                if (i.Preguntas == "¿Te sientes mareado o te falta el aire mas de lo esperado cuando haces ejercicios?")
                {
                    ViewBag.Hmr11 = i.Respuestas;
                }
                //Pregunta L
                if (i.Preguntas == "¿Has tenido una convulsion inexplicable?")
                {
                    ViewBag.Hmr12 = i.Respuestas;
                }
            }
            //
            //Aqui va Historial Medico
            var HFIE = db.Historia_Familiar.Where(s => s.ID_Atleta == ID);
            foreach (var i in HFIE.ToList())
            {
                //Pregunta M
                if (i.Preguntas == "¿Has tenido algun familiar que haya fallecido a causa de problemas de corazon, o bien que haya fallecido de forma inexplicable antes de los 50 años?")
                {
                    ViewBag.Hfr1 = i.Respuestas;
                }
                //Pregunta N
                if (i.Preguntas == "¿Alguien de tu familia tiene problemas del corazon, un marcapaso o un desfibrilador en su corazon?")
                {
                    ViewBag.Hfr2 = i.Respuestas;
                }
                //Pregunta Ñ
                if (i.Preguntas == "¿Ha sufrido algun familiar un desmayo inexplicable o convulsiones?")
                {
                    ViewBag.Hfr3 = i.Respuestas;
                }
                //Pregunta O
                if (i.Preguntas == "¿Alguien de su familia padece de Diabetes?")
                {
                    ViewBag.Hfr4 = i.Respuestas;
                }
                //Pregunta P
                if (i.Preguntas == "¿Alguien de su familia padece de asma?")
                {
                    ViewBag.Hfr5 = i.Respuestas;
                }
            }
            //Aqui va Aparato Locomotor
            var APLIE = db.Aparato_Locomotor.Where(s => s.ID_Atleta == ID);
            foreach (var i in APLIE.ToList())
            {
                //Pregunta Q
                if (i.Preguntas == "¿Alguna vez ha perdido un entrenamiento o evento por haber sufrido lesion en el hueso, tendon o musculo?")
                {
                    ViewBag.Alr1 = i.Respuestas;
                }
                //Pregunta R
                if (i.Preguntas == "¿Te has fracturado alguna vez un hueso o dislocado una articulacion?")
                {
                    ViewBag.Alr2 = i.Respuestas;
                }
                //Pregunta S
                if (i.Preguntas == "¿Has sufrido alguna lesion que haya requerido radiografias,tomografias, o resonancia magnetica, soporte ortopedico,como yeso o tablilla?")
                {
                    ViewBag.Alr3 = i.Respuestas;
                }
                //Pregunta T
                if (i.Preguntas == "¿Usas regularmente una tablilla/soporte ortopedico u otro dispositivo de asistencia?")
                {
                    ViewBag.Alr4 = i.Respuestas;
                }
                //Pregunta U
                if (i.Preguntas == "¿Tienes calambres frecuentes en los musculos cuando haces ejercicios?")
                {
                    ViewBag.Alr5 = i.Respuestas;
                }
                //Pregunta V
                if (i.Preguntas == "¿Has tenido Hinchazon en alguna de tus articulaciones?")
                {
                    ViewBag.Alr6 = i.Respuestas;
                }
                //Cirugias
                if (i.Preguntas == "Cirugias(especifique que tipo de cirugias y cuando fue realizada)")
                {
                    ViewBag.Alr7 = i.Respuestas;
                }
                //Hospitalizaciones
                if (i.Preguntas == "Hospitalizaciones(Especifique si ha sido hospitalizado,las fechas y las causas)")
                {
                    ViewBag.Alr8 = i.Respuestas;
                }
            }

            //Aqui va Carrera Deportiva
            var CDIE = db.Carrera_Deportiva.Where(s => s.ID_Atleta == ID);
            foreach (var i in CDIE.ToList())
            {
                //Cuanto Tiempo lleva Compitiendo
                if (i.Preguntas == "Cuanto Tiempo lleva Compitiendo")
                {
                    ViewBag.CDr1 = i.Respuestas;
                }
                //Entreno(dias por semana)
                if (i.Preguntas == "Entreno(dias por semana)")
                {
                    ViewBag.CDr2 = i.Respuestas;
                    ViewBag.CDd2 = i.Detalles;
                }
                //Horas de entrenamiento por sesion
                if (i.Preguntas == "Horas de entrenamiento por sesion")
                {
                    ViewBag.CDr3 = i.Respuestas;
                }
                //Modalidad de entrenamiento
                if (i.Preguntas == "Modalidad de entrenamiento")
                {
                    ViewBag.CDr4 = i.Respuestas;
                    ViewBag.CDd4 = i.Detalles;
                }
                //Cuento con un plan de entrenamiento que:
                if (i.Preguntas == "Cuento con un plan de entrenamiento que:")
                {
                    ViewBag.CDr5 = i.Respuestas;
                    ViewBag.CDd5 = i.Detalles;
                }
                //Sus actividades se adaptan a sus horararios y sesiones de entrenamiento
                if (i.Preguntas == "Sus actividades se adaptan a sus horararios y sesiones de entrenamiento")
                {
                    ViewBag.CDr6 = i.Respuestas;
                    ViewBag.CDd6 = i.Detalles;
                }
                //Su sitio de entrenamiento es:
                if (i.Preguntas == "Su sitio de entrenamiento es:")
                {
                    ViewBag.CDr7 = i.Respuestas;
                    ViewBag.CDd7 = i.Detalles;
                }
            }
            //Aqui va Informacion Laboral Economica
            //Situacion Laboral
            var SLIE = db.Situacion_Laboral.Where(s => s.ID_Atleta == ID);
            foreach (var i in SLIE.ToList())
            {
                //Trabaja Actualmente
                if (i.Preguntas == "Trabaja Actualmente")
                {
                    ViewBag.SLabr1 = i.Respuestas;
                }
                //Tiene personas a cargo
                if (i.Preguntas == "Tiene personas a cargo")
                {
                    ViewBag.SLabr2 = i.Respuestas;
                }
            }
            //Apoyo Economico
            var AECIE = db.Apoyo_Economico.Where(s => s.ID_Atleta == ID);
            foreach (var i in AECIE.ToList())
            {
                if (i.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:")
                {
                    if (i.Respuestas == "Atleta")
                    {
                        ViewBag.AEcr1 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Padre")
                    {
                        ViewBag.AEcr2 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Madre")
                    {
                        ViewBag.AEcr3 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Pareja")
                    {
                        ViewBag.AEcr4 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Otros Familiares")
                    {
                        ViewBag.AEcr5 = i.Respuestas;
                        ViewBag.AEcd5 = i.Detalles;
                    }
                    if (i.Respuestas == "Otros")
                    {
                        ViewBag.AEcr6 = i.Respuestas;
                        ViewBag.AEcd6 = i.Detalles;
                    }
                    else if (i.Respuestas == "No recibe apoyo Monetario")
                    {
                        ViewBag.AEcr7 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Apoyo monetario de programa deportivo")
                    {
                        ViewBag.AEcr8 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Federación")
                    {
                        ViewBag.AEcr9 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Otros apoyos")
                    {
                        ViewBag.AEcr10 = i.Respuestas;
                        ViewBag.AEcd10 = i.Detalles;
                    }
                }
                if (i.Preguntas == "En que invierte su apoyo monetario")
                {
                    if (i.Respuestas == "Practica deportiva")
                    {
                        ViewBag.AEcr11 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Economia Familiar")
                    {
                        ViewBag.AEcr12 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Educacion")
                    {
                        ViewBag.AEcr13 = i.Respuestas;
                    }
                }
            }
            //Consiste Apoyo
            var CAIE = db.Consiste_Apoyo.Where(s => s.ID_Atleta == ID);
            foreach (var i in CAIE.ToList())
            {
                if (i.Preguntas == "En que consiste el apoyo que recibe:")
                {
                    if (i.Respuestas == "Monetario")
                    {
                        ViewBag.CAcr1 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Equipo ciencias del deporte")
                    {
                        ViewBag.CAcr2 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Educativo")
                    {
                        ViewBag.CAcr3 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Alojamiento")
                    {
                        ViewBag.CAcr4 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Transporte")
                    {
                        ViewBag.CAcr5 = i.Respuestas;
                    }
                    if (i.Respuestas == "Alimentacion")
                    {
                        ViewBag.CAcr6 = i.Respuestas;
                    }
                }
            }
            //Infomacion Familiar
            var IFCIE = db.Informacion_Familiar.Where(s => s.ID_Atleta == ID);
            foreach (var i in IFCIE.ToList())
            {
                if (i.Preguntas == "Con quien vive")
                {
                    if (i.Respuestas == "Soltero(a)")
                    {
                        ViewBag.IFcr1 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Acompañado")
                    {
                        ViewBag.IFcr2 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Padre")
                    {
                        ViewBag.IFcr3 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Madre")
                    {
                        ViewBag.IFcr4 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Hermanos")
                    {
                        ViewBag.IFcr5 = i.Respuestas;
                        ViewBag.IFcd5 = i.Detalles;
                    }
                    else if (i.Respuestas == "Hijos")
                    {
                        ViewBag.IFcr6 = i.Respuestas;
                        ViewBag.IFcd6 = i.Detalles;
                    }
                    else if (i.Respuestas == "Otros Familiares")
                    {
                        ViewBag.IFcr7 = i.Respuestas;
                        ViewBag.IFcd7 = i.Detalles;
                    }
                    else if (i.Respuestas == "Otros")
                    {
                        ViewBag.IFcr8 = i.Respuestas;
                        ViewBag.IFcd8 = i.Detalles;
                    }
                    else if (i.Respuestas == "Alojamiento Deportivo")
                    {
                        ViewBag.IFcr9 = i.Respuestas;
                    }
                }
                if (i.Preguntas == "¿Tiene Hijos?")
                {
                    ViewBag.IFcr10 = i.Respuestas;
                }
                else if (i.Preguntas == "¿Proyecta Tener Hijos?")
                {
                    ViewBag.IFcr11 = i.Respuestas;
                }
                else if (i.Preguntas == "Números de personas con las que Vive")
                {
                    if (i.Respuestas == "4 o menos")
                    {
                        ViewBag.IFcr12 = i.Respuestas;
                        ViewBag.IFcd12 = i.Detalles;
                    }
                    else if (i.Respuestas == "De 4 a 7")
                    {
                        ViewBag.IFcr13 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Mas de 7")
                    {
                        ViewBag.IFcr14 = i.Respuestas;
                    }
                    else if (i.Respuestas == "Con Compañeros en alojamiento deportivo")
                    {
                        ViewBag.IFcr15 = i.Respuestas;
                    }
                }
            }
            //Educacion
            var EDIE = db.Educacion.Where(s => s.ID_Atleta == ID);
            foreach (var i in EDIE.ToList())
            {
                //Estudia Actualmente
                if (i.Preguntas == "Estudia Actualmente")
                {
                    ViewBag.EDabr1 = i.Respuestas;
                }
                //Ultimo nivel academico terminado
                if (i.Preguntas == "Ultimo nivel academico terminado")
                {
                    ViewBag.EDabr2 = i.Respuestas;
                    ViewBag.EDabd2 = i.Detalles;
                }
                //¿Donde Estudia?
                if (i.Preguntas == "¿Donde Estudia?")
                {
                    ViewBag.EDabr3 = i.Respuestas;
                }
            }
            //Habitacion
            var HABIE = db.Habitacion.Where(s => s.ID_Atleta == ID);
            foreach (var i in HABIE.ToList())
            {
                //Cómo calificaría su barrio
                if (i.Preguntas == "Cómo calificaría su barrio")
                {
                    ViewBag.HAabr1 = i.Respuestas;
                    ViewBag.HAabd1 = i.Detalles;
                }
                //Como describiria el estado de la vivienda en que reside actualmente
                if (i.Preguntas == "Como describiria el estado de la vivienda en que reside actualmente")
                {
                    ViewBag.HAabr2 = i.Respuestas;
                }
            }
            //Habitos
            var HABSIE = db.Habitos.Where(s => s.ID_Atleta == ID);
            foreach (var i in HABSIE.ToList())
            {
                //¿Usted Fuma?
                if (i.Preguntas == "¿Usted Fuma?")
                {                    
                    ViewBag.HABabr1 = i.Respuestas;
                    ViewBag.HABabd1 = i.Detalles;
                }
                //¿Usted Toma?
                if (i.Preguntas == "¿Usted Toma?")
                {                    
                    ViewBag.HABabr2 = i.Respuestas;
                    ViewBag.HABabd2 = i.Detalles;
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Crear(FormCollection collection)
        {
            //MEDICAMENTOS
            //Relajantes Musculares
            if (!string.IsNullOrEmpty(collection["btnrelajantes"]))
            {
                Medicamentos Medica1 = new Medicamentos();
                Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                Medica1.Medicamentos1 = "Relajante Musculares";
                Medica1.Descripcion = collection["txt_medicamentos"];
                //Debug.WriteLine("Relajante Muscular");
                //Debug.WriteLine(collection["txt_medicamentos"]);
                db.Medicamentos.Add(Medica1);
                db.SaveChanges();
            }
            else
            {

            }
            //Antiinflamatorios
            if (!string.IsNullOrEmpty(collection["antiflamatorio"]))
            {
                Medicamentos Medica2 = new Medicamentos();
                Medica2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                Medica2.Medicamentos1 = "Antiinflamatorios";
                Medica2.Descripcion = collection["txt_antiinflamatorios"];
                db.Medicamentos.Add(Medica2);
                db.SaveChanges();
                //Debug.WriteLine("Antiinflamatorios");
                //Debug.WriteLine(collection["txt_antiinflamatorios"]);
            }
            else
            {

            }
            //Analgesico
            if (!string.IsNullOrEmpty(collection["analgesico"]))
            {
                Medicamentos Medica3 = new Medicamentos();
                Medica3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                Medica3.Medicamentos1 = "Analgesico";
                Medica3.Descripcion = collection["txt_analgesicos"];
                db.Medicamentos.Add(Medica3);
                db.SaveChanges();
                //Debug.WriteLine("Analgesico");
                //Debug.WriteLine(collection["txt_analgesicos"]);
            }
            else
            {

            }
            //Otros
            if (!string.IsNullOrEmpty(collection["btn_otros"]))
            {
                Medicamentos Medica4 = new Medicamentos();
                Medica4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                Medica4.Medicamentos1 = "Otros Medicamentos";
                Medica4.Descripcion = collection["txt_medicamentos_otros"];
                db.Medicamentos.Add(Medica4);
                db.SaveChanges();
                //Debug.WriteLine("Otros");
                //Debug.WriteLine(collection["txt_medicamentos_otros"]);
            }
            else
            {

            }
            //ALERGIAS
            //Medicamentos
            if (collection["alergia"] == "Si")
            {
                if (!string.IsNullOrEmpty(collection["medicamento_alergia"]))
                {
                    Alergias Alergia1 = new Alergias();
                    Alergia1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Alergia1.Alergia = "Medicamento";
                    Alergia1.Descripcion = collection["txt_medicamentos_alergicos"];
                    db.Alergias.Add(Alergia1);
                    db.SaveChanges();
                    //Debug.WriteLine("Medicamento");
                    //Debug.WriteLine(collection["txt_medicamentos_alergicos"]);
                }
                else
                {

                }
                //Polen
                if (!string.IsNullOrEmpty(collection["polen"]))
                {
                    Alergias Alergia2 = new Alergias();
                    Alergia2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Alergia2.Alergia = "Polen";
                    Alergia2.Descripcion = collection["txt_alergia_polen"];
                    db.Alergias.Add(Alergia2);
                    db.SaveChanges();
                    //Debug.WriteLine("Polen");
                    //Debug.WriteLine(collection["txt_alergia_polen"]);
                }
                else
                {

                }
                //Comida
                if (!string.IsNullOrEmpty(collection["comida"]))
                {
                    Alergias Alergia3 = new Alergias();
                    Alergia3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Alergia3.Alergia = "Comida";
                    Alergia3.Descripcion = collection["txtalergiacomida"];
                    db.Alergias.Add(Alergia3);
                    db.SaveChanges();
                    //Debug.WriteLine("Comida");
                    //Debug.WriteLine(collection["txtalergiacomida"]);
                }
                else
                {

                }
                //Piquetes de Insectos
                if (!string.IsNullOrEmpty(collection["piquetesdeinsectos"]))
                {
                    Alergias Alergia4 = new Alergias();
                    Alergia4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Alergia4.Alergia = "Piquetes de insectos";
                    Alergia4.Descripcion = collection["txtpiquete"];
                    db.Alergias.Add(Alergia4);
                    db.SaveChanges();
                    //Debug.WriteLine("Piquetes de insectos");
                    //Debug.WriteLine(collection["txtpiquete"]);
                }
                else
                {

                }
                //Otros
                if (!string.IsNullOrEmpty(collection["otrosalergias"]))
                {
                    Alergias Alergia5 = new Alergias();
                    Alergia5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Alergia5.Alergia = "Otros";
                    Alergia5.Descripcion = collection["txtotra_alergia"];
                    db.Alergias.Add(Alergia5);
                    db.SaveChanges();
                    //Debug.WriteLine("Otros");
                    //Debug.WriteLine(collection["txtotra_alergia"]);
                }
                else
                {

                }
            }
            else
            {
                //Alergias rda = new Alergias();
                //rda.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                //rda.Alergia = "No tiene Alergias";
                //rda.Descripcion = "";
                //db.Alergias.Add(rda);
                //db.SaveChanges();
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //PREGUNTAS
            //Historial Medico
            /*Pregunta A*/
            if (!string.IsNullOrEmpty(collection["pregunta_A"]))
            {
                Historial_Medico HM1 = new Historial_Medico();
                HM1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM1.Preguntas = "¿Alguna vez un doctor te ha prohibido limitado tu participacion en deportes por alguna razon?";
                HM1.Respuestas = collection["pregunta_A"];
                HM1.Detalles = "";
                db.Historial_Medico.Add(HM1);
                db.SaveChanges();
                //Debug.WriteLine("¿Alguna vez un doctor te ha prohibido limitado tu participacion en deportes por alguna razon?");
                //Debug.WriteLine(collection["pregunta_A"]);
            }
            else
            {

            }
            /*Pregunta B*/
            if (!string.IsNullOrEmpty(collection["pregunta_B"]))
            {
                Historial_Medico HM2 = new Historial_Medico();
                HM2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM2.Preguntas = "¿Has sido ingresado alguna vez en el hospital?";
                HM2.Respuestas = collection["pregunta_B"];
                HM2.Detalles = "";
                db.Historial_Medico.Add(HM2);
                db.SaveChanges();
                //Debug.WriteLine("¿Has sido ingresado alguna vez en el hospital?");
                //Debug.WriteLine(collection["pregunta_B"]);
            }
            /*Pregunta C*/
            if (!string.IsNullOrEmpty(collection["pregunta_C"]))
            {
                Historial_Medico HM3 = new Historial_Medico();
                HM3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM3.Preguntas = "¿Has tenido cirugia alguna vez?";
                HM3.Respuestas = collection["pregunta_C"];
                HM3.Detalles = "";
                db.Historial_Medico.Add(HM3);
                db.SaveChanges();
                //Debug.WriteLine("¿Has tenido cirugia alguna vez?");
                //Debug.WriteLine(collection["pregunta_C"]);
            }
            else
            {

            }
            /*Pregunta D*/
            if (!string.IsNullOrEmpty(collection["pregunta_D"]))
            {
                Historial_Medico HM4 = new Historial_Medico();
                HM4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM4.Preguntas = "¿Usas lentes o lentes de contacto?";
                HM4.Respuestas = collection["pregunta_D"];
                HM4.Detalles = "";
                db.Historial_Medico.Add(HM4);
                db.SaveChanges();
                //Debug.WriteLine("¿Usas lentes o lentes de contacto?");
                //Debug.WriteLine(collection["pregunta_D"]);
            }
            else
            {

            }
            /*Pregunta E*/
            if (!string.IsNullOrEmpty(collection["pregunta_E"]))
            {
                Historial_Medico HM5 = new Historial_Medico();
                HM5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM5.Preguntas = "¿Naciste o te falta un riñon,un ojo,un testiculo u algun otro órgano?";
                HM5.Respuestas = collection["pregunta_E"];
                HM5.Detalles = "";
                db.Historial_Medico.Add(HM5);
                db.SaveChanges();
                //Debug.WriteLine("¿Naciste o te falta un riñon,un ojo,untesticulo u algun otro órgano?");
                //Debug.WriteLine(collection["pregunta_E"]);
            }
            else
            {

            }
            /*Pregunta F*/
            if (!string.IsNullOrEmpty(collection["pregunta_F"]))
            {
                Historial_Medico HM6 = new Historial_Medico();
                HM6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM6.Preguntas = "¿Te has desmayado durante o despues de hacer ejercicios?";
                HM6.Respuestas = collection["pregunta_F"];
                HM6.Detalles = "";
                db.Historial_Medico.Add(HM6);
                db.SaveChanges();
                //Debug.WriteLine("¿Te has desmayado durante o despues de hacer ejercicios?");
                //Debug.WriteLine(collection["pregunta_F"]);
            }
            else
            {

            }
            /*Pregunta G*/
            if (!string.IsNullOrEmpty(collection["pregunta_G"]))
            {
                Historial_Medico HM7 = new Historial_Medico();
                HM7.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM7.Preguntas = "¿Has tenido alguna vez molestias dolor o presion en el pecho cuando haces ejercicios?";
                HM7.Respuestas = collection["pregunta_G"];
                HM7.Detalles = "";
                db.Historial_Medico.Add(HM7);
                db.SaveChanges();
                //Debug.WriteLine("¿Has tenido alguna vez molestias dolor o presion en el pecho cuando haces ejercicios?");
                //Debug.WriteLine(collection["pregunta_G"]);
            }
            else
            {

            }
            /*Pregunta H*/
            if (!string.IsNullOrEmpty(collection["pregunta_H"]))
            {
                Historial_Medico HM8 = new Historial_Medico();
                HM8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM8.Preguntas = "¿Alguna vez has tenido palpitaciones o latidos irregulares cuando haces ejercicios?";
                HM8.Respuestas = collection["pregunta_H"];
                HM8.Detalles = "";
                db.Historial_Medico.Add(HM8);
                db.SaveChanges();
                //Debug.WriteLine("¿Alguna vez has tenido palpitaciones o latidos irregulares cuando haces ejercicios?");
                //Debug.WriteLine(collection["pregunta_H"]);
            }
            else
            {

            }
            /*Pregunta I*/
            if (!string.IsNullOrEmpty(collection["pregunta_I"]))
            {
                Historial_Medico HM9 = new Historial_Medico();
                HM9.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM9.Preguntas = "¿Te ha dicho un doctor que tienes un problema del Corazón?";
                HM9.Respuestas = collection["pregunta_I"];
                HM9.Detalles = "";
                db.Historial_Medico.Add(HM9);
                db.SaveChanges();
                //Debug.WriteLine("¿Te ha dicho un doctor que tienes un problema del corazon?");
                //Debug.WriteLine(collection["pregunta_I"]);
                //Pregunta I Anexo A
                if (!string.IsNullOrEmpty(collection["presion_alta"]))
                {
                    Historial_Medico HM10 = new Historial_Medico();
                    HM10.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM10.Preguntas = "I.A Presion Alta";
                    HM10.Respuestas = collection["presion_alta"];
                    HM10.Detalles = "";
                    db.Historial_Medico.Add(HM10);
                    db.SaveChanges();
                    //Debug.WriteLine("Presion Alta");
                    //Debug.WriteLine(collection["presion_alta"]);
                }
                else
                {

                }
                //Pregunta I Anexo B
                if (!string.IsNullOrEmpty(collection["Soplo"]))
                {
                    Historial_Medico HM11 = new Historial_Medico();
                    HM11.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM11.Preguntas = "I.B Soplo en el Corazón";
                    HM11.Respuestas = collection["Soplo"];
                    HM11.Detalles = "";
                    db.Historial_Medico.Add(HM11);
                    db.SaveChanges();
                    //Debug.WriteLine("Soplo en el Corazón");
                    //Debug.WriteLine(collection["Soplo"]);
                }
                else
                {

                }
                //Pregunta I Anexo C
                if (!string.IsNullOrEmpty(collection["colesterol"]))
                {
                    Historial_Medico HM12 = new Historial_Medico();
                    HM12.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM12.Preguntas = "I.C Nivel alto de Colesterol";
                    HM12.Respuestas = collection["colesterol"];
                    HM12.Detalles = "";
                    db.Historial_Medico.Add(HM12);
                    db.SaveChanges();
                    //Debug.WriteLine("Nivel alto de Colesterol");
                    //Debug.WriteLine(collection["colesterol"]);
                }
                else
                {

                }
                //Pregunta I Anexo D
                if (!string.IsNullOrEmpty(collection["otroenfer"]))
                {
                    Historial_Medico HM13 = new Historial_Medico();
                    HM13.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM13.Preguntas = "I.D Otro";
                    HM13.Respuestas = collection["otroenfer"];
                    HM13.Detalles = collection["txt_especificacion_otros"];
                    db.Historial_Medico.Add(HM13);
                    db.SaveChanges();
                    //Debug.WriteLine("otro");
                    //Debug.WriteLine(collection["otroenfer"]);
                    //Debug.WriteLine(collection["txt_especificacion_otros"]);
                }
                else
                {

                }
            }
            else
            {

            }
            /*Pregunta J*/
            if (!string.IsNullOrEmpty(collection["pregunta_J"]))
            {
                Historial_Medico HM14 = new Historial_Medico();
                HM14.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM14.Preguntas = "¿Alguna vez un doctor te ha pedido que te hagas una prueba del corazon¿Ej:Electrocardiograma?";
                HM14.Respuestas = collection["pregunta_J"];
                HM14.Detalles = "";
                db.Historial_Medico.Add(HM14);
                db.SaveChanges();
                //Debug.WriteLine("¿Alguna vez un doctor te ha pedido que te hagas una prueba del corazon¿Ej:Electrocardiograma?");
                //Debug.WriteLine(collection["pregunta_J"]);
            }
            else
            {

            }
            /*Pregunta K*/
            if (!string.IsNullOrEmpty(collection["pregunta_K"]))
            {
                Historial_Medico HM15 = new Historial_Medico();
                HM15.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM15.Preguntas = "¿Te sientes mareado o te falta el aire mas de lo esperado cuando haces ejercicios?";
                HM15.Respuestas = collection["pregunta_K"];
                HM15.Detalles = "";
                db.Historial_Medico.Add(HM15);
                db.SaveChanges();
                //Debug.WriteLine("¿Te sientes mareado o te falta el aire mas de lo esperado cuando haces ejercicios?");
                //Debug.WriteLine(collection["pregunta_K"]);
            }
            else
            {

            }
            /*Pregunta L*/
            if (!string.IsNullOrEmpty(collection["pregunta_L"]))
            {
                Historial_Medico HM16 = new Historial_Medico();
                HM16.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HM16.Preguntas = "¿Has tenido una convulsion inexplicable?";
                HM16.Respuestas = collection["pregunta_L"];
                HM16.Detalles = "";
                db.Historial_Medico.Add(HM16);
                db.SaveChanges();
                //Debug.WriteLine("¿Has tenido una convulsion inexplicable?");
                //Debug.WriteLine(collection["pregunta_L"]);
            }
            else
            {

            }
            //Historial Familiar
            /*Pregunta M*/
            if (!string.IsNullOrEmpty(collection["pregunta_fam_1"]))
            {
                Historia_Familiar HF1 = new Historia_Familiar();
                HF1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HF1.Preguntas = "¿Has tenido algun familiar que haya fallecido a causa de problemas de corazon, o bien que haya fallecido de forma inexplicable antes de los 50 años?";
                HF1.Respuestas = collection["pregunta_fam_1"];
                db.Historia_Familiar.Add(HF1);
                db.SaveChanges();
                //Debug.WriteLine("¿Has tenido algun familiar que haya fallecido a causa de problemas de corazon, o bien que haya fallecido de forma inexplicable antes de los 50 años?");
                //Debug.WriteLine(collection["pregunta_fam_1"]);
            }
            else
            {

            }
            /*Pregunta N*/
            if (!string.IsNullOrEmpty(collection["pregunta_fam_2"]))
            {
                Historia_Familiar HF2 = new Historia_Familiar();
                HF2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HF2.Preguntas = "¿Alguien de tu familia tiene problemas del corazon, un marcapaso o un desfibrilador en su corazon?";
                HF2.Respuestas = collection["pregunta_fam_2"];
                db.Historia_Familiar.Add(HF2);
                db.SaveChanges();
                //Debug.WriteLine("¿Alguien de tu familia tiene problemas del corazon, un marcapaso o un desfibrilador en su corazon?");
                //Debug.WriteLine(collection["pregunta_fam_2"]);
            }
            else
            {

            }
            /*Pregunta Ñ*/
            if (!string.IsNullOrEmpty(collection["pregunta_fam_3"]))
            {
                Historia_Familiar HF3 = new Historia_Familiar();
                HF3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HF3.Preguntas = "¿Ha sufrido algun familiar un desmayo inexplicable o convulsiones?";
                HF3.Respuestas = collection["pregunta_fam_3"];
                db.Historia_Familiar.Add(HF3);
                db.SaveChanges();
                //Debug.WriteLine("¿Ha sufrido algun familiar un desmayo inexplicable o convulsiones ? ");
                //Debug.WriteLine(collection["pregunta_fam_3"]);
            }
            else
            {

            }
            /*Pregunta O*/
            if (!string.IsNullOrEmpty(collection["pregunta_fam_4"]))
            {
                Historia_Familiar HF4 = new Historia_Familiar();
                HF4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HF4.Preguntas = "¿Alguien de su familia padece de Diabetes?";
                HF4.Respuestas = collection["pregunta_fam_4"];
                db.Historia_Familiar.Add(HF4);
                db.SaveChanges();
                //Debug.WriteLine("¿Alguien de su familia padece de Diabetes?");
                //Debug.WriteLine(collection["pregunta_fam_4"]);
            }
            else
            {

            }
            /*Pregunta P*/
            if (!string.IsNullOrEmpty(collection["pregunta_fam_5"]))
            {
                Historia_Familiar HF5 = new Historia_Familiar();
                HF5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                HF5.Preguntas = "¿Alguien de su familia padece de asma?";
                HF5.Respuestas = collection["pregunta_fam_5"];
                db.Historia_Familiar.Add(HF5);
                db.SaveChanges();
                //Debug.WriteLine("¿Alguien de su familia padece de asma?");
                //Debug.WriteLine(collection["pregunta_fam_5"]);
            }
            else
            {

            }
            //Aparato Locomotor
            /*Pregunta Q*/
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_1"]))
            {
                Aparato_Locomotor AL1 = new Aparato_Locomotor();
                AL1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AL1.Preguntas = "¿Alguna vez ha perdido un entrenamiento o evento por haber sufrido lesion en el hueso, tendon o musculo?";
                AL1.Respuestas = collection["pregunta_locomotor_1"];
                db.Aparato_Locomotor.Add(AL1);
                db.SaveChanges();
                //Debug.WriteLine("¿Alguna vez ha perdido un entrenamiento o evento por haber sufrido lesion en el hueso, tendon o musculo?");
                //Debug.WriteLine(collection["pregunta_locomotor_1"]);
            }
            else
            {

            }
            /*Pregunta R*/
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_2"]))
            {
                Aparato_Locomotor AL2 = new Aparato_Locomotor();
                AL2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AL2.Preguntas = "¿Te has fracturado alguna vez un hueso o dislocado una articulacion?";
                AL2.Respuestas = collection["pregunta_locomotor_2"];
                db.Aparato_Locomotor.Add(AL2);
                db.SaveChanges();
                //Debug.WriteLine("¿Te has fracturado alguna vez un hueso o dislocado una articulacion?");
                //Debug.WriteLine(collection["pregunta_locomotor_2"]);
            }
            else
            {

            }
            /*Pregunta S*/
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_3"]))
            {
                Aparato_Locomotor AL3 = new Aparato_Locomotor();
                AL3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AL3.Preguntas = "¿Has sufrido alguna lesion que haya requerido radiografias,tomografias, o resonancia magnetica, soporte ortopedico,como yeso o tablilla?";
                AL3.Respuestas = collection["pregunta_locomotor_3"];
                db.Aparato_Locomotor.Add(AL3);
                db.SaveChanges();
                //Debug.WriteLine("¿Has sufrido alguna lesion que haya requerido radiografias,tomografias, o resonancia magnetica, soporte ortopedico,como yeso o tablilla?");
                //Debug.WriteLine(collection["pregunta_locomotor_3"]);
            }
            else
            {

            }
            /*Pregunta T*/
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_4"]))
            {
                Aparato_Locomotor AL4 = new Aparato_Locomotor();
                AL4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AL4.Preguntas = "¿Usas regularmente una tablilla/soporte ortopedico u otro dispositivo de asistencia?";
                AL4.Respuestas = collection["pregunta_locomotor_4"];
                db.Aparato_Locomotor.Add(AL4);
                db.SaveChanges();
                //Debug.WriteLine("¿Usas regularmente una tablilla/soporte ortopedico u otro dispositivo de asistencia?");
                //Debug.WriteLine(collection["pregunta_locomotor_4"]);
            }
            else
            {

            }
            /*Pregunta U*/
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_5"]))
            {
                Aparato_Locomotor AL5 = new Aparato_Locomotor();
                AL5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AL5.Preguntas = "¿Tienes calambres frecuentes en los musculos cuando haces ejercicios?";
                AL5.Respuestas = collection["pregunta_locomotor_5"];
                db.Aparato_Locomotor.Add(AL5);
                db.SaveChanges();
                //Debug.WriteLine("¿Tienes calambres frecuentes en los musculos cuando haces ejercicios?");
                //Debug.WriteLine(collection["pregunta_locomotor_5"]);
            }
            else
            {

            }
            /*Pregunta V*/
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_6"]))
            {
                Aparato_Locomotor AL6 = new Aparato_Locomotor();
                AL6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AL6.Preguntas = "¿Has tenido Hinchazon en alguna de tus articulaciones?";
                AL6.Respuestas = collection["pregunta_locomotor_6"];
                db.Aparato_Locomotor.Add(AL6);
                db.SaveChanges();
                //Debug.WriteLine("¿Has tenido Hinchazon en alguna de tus articulaciones?");
                //Debug.WriteLine(collection["pregunta_locomotor_6"]);
            }
            else
            {

            }
            if (!string.IsNullOrEmpty(collection["cirugias"]))
            {
                Aparato_Locomotor AL7 = new Aparato_Locomotor();
                AL7.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AL7.Preguntas = "Cirugias(especifique que tipo de cirugias y cuando fue realizada)";
                AL7.Respuestas = collection["cirugias"];
                db.Aparato_Locomotor.Add(AL7);
                db.SaveChanges();
                //Debug.WriteLine("Cirugias(especifique que tipo de cirugias y cuando fue realizada)");
                //Debug.WriteLine(collection["cirugias"]);
            }
            else
            {

            }
            if (!string.IsNullOrEmpty(collection["hospitalizaciones"]))
            {
                Aparato_Locomotor AL8 = new Aparato_Locomotor();
                AL8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AL8.Preguntas = "Hospitalizaciones(Especifique si ha sido hospitalizado,las fechas y las causas)";
                AL8.Respuestas = collection["hospitalizaciones"];
                db.Aparato_Locomotor.Add(AL8);
                db.SaveChanges();
                //Debug.WriteLine("Hospitalizaciones(Especifique si ha sido hospitalizado,las fechas y las causas)");
                //Debug.WriteLine(collection["hospitalizaciones"]);
            }
            else
            {

            }
            //CARRERA DEPORTIVA
            //Cuanto Tiempo lleva Compitiendo
            if (!string.IsNullOrEmpty(collection["compitiendo"]))
            {
                Carrera_Deportiva CD1 = new Carrera_Deportiva();
                CD1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CD1.Preguntas = "Cuanto Tiempo lleva Compitiendo";
                CD1.Respuestas = collection["compitiendo"];
                db.Carrera_Deportiva.Add(CD1);
                db.SaveChanges();
                //Debug.WriteLine("Cuanto Tiempo lleva Compitiendo");
                //Debug.WriteLine(collection["compitiendo"]);
            }
            //Antecedentes Deportivos. Carrera deportiva
            if (!string.IsNullOrEmpty(collection["prueba[]"]) || !string.IsNullOrEmpty(collection["resultado[]"]) || !string.IsNullOrEmpty(collection["fechaYlugar[]"]) || !string.IsNullOrEmpty(collection["evento[]"]))
            {
                var prueba = collection["prueba[]"];
                var resul = collection["resultado[]"];
                var fyl = collection["fechaYlugar[]"];
                var eve = collection["evento[]"];
                for (var i = 0; i < prueba.Count(); i++)
                {
                    if (prueba[i].ToString() != "," || resul[i].ToString() != "," || fyl[i].ToString() != "," || eve[i].ToString() != ",")
                    {
                        Carrera_Deportiva_Evento CDE1 = new Carrera_Deportiva_Evento();
                        CDE1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                        CDE1.Prueba = prueba[i].ToString();
                        CDE1.Resultado = resul[i].ToString();
                        CDE1.Fecha_Y_Lugar = fyl[i].ToString();
                        CDE1.Evento = eve[i].ToString();
                        db.Carrera_Deportiva_Evento.Add(CDE1);
                        db.SaveChanges();
                    }
                }

                //Debug.WriteLine("Antecedentes Deportivos: a continuacion, mencione sus logros y medallas mas importantes en competencias como seleccionado (a) o en eventos olimpicos");
                //Debug.WriteLine(collection["prueba[]"]);
                //Debug.WriteLine(collection["resultado[]"]);
                //Debug.WriteLine(collection["fechaYlugar[]"]);
                //Debug.WriteLine(collection["evento[]"]);
            }
            //Antecedentes Deportivos. Carrera deportiva Familiar
            if (!string.IsNullOrEmpty(collection["evento_fam[]"]) || !string.IsNullOrEmpty(collection["resultado_fam[]"]) || !string.IsNullOrEmpty(collection["fechaYlugarfam[]"]))
            {
                var pruebafam = collection["evento_fam[]"];
                var fylfam = collection["fechaYlugarfam[]"];
                var resulfam = collection["resultado_fam[]"];
                for (var i = 0; i < pruebafam.Count(); i++)
                {
                    if (pruebafam[i].ToString() != "," || fylfam[i].ToString() != "," || resulfam[i].ToString() != ",")
                    {
                        Carrera_Deportiva_Familiar CDF1 = new Carrera_Deportiva_Familiar();
                        CDF1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                        CDF1.Evento = pruebafam[i].ToString();
                        CDF1.FechayLugar = fylfam[i].ToString();
                        CDF1.Resultado = resulfam[i].ToString();
                        db.Carrera_Deportiva_Familiar.Add(CDF1);
                        db.SaveChanges();
                    }
                }
                //Debug.WriteLine("Espeifique si algun familiar ha participado en eventos deportivos de alto rendimiento o de seleccion nacional.");
                //Debug.WriteLine(collection["evento_fam[]"]);
                //Debug.WriteLine(collection["resultado_fam[]"]);
                //Debug.WriteLine(collection["fechaYlugarfam[]"]);
            }
            //Entrenamientos
            if (!string.IsNullOrEmpty(collection["entrenamiento"]))
            {
                Carrera_Deportiva CD2 = new Carrera_Deportiva();
                CD2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CD2.Preguntas = "Entreno(dias por semana)";
                CD2.Respuestas = collection["entrenamiento"];
                CD2.Detalles = collection["sesiones"];
                db.Carrera_Deportiva.Add(CD2);
                db.SaveChanges();
                //Debug.WriteLine("Entreno(dias por semana)");
                //Debug.WriteLine(collection["entrenamiento"]);
                //Debug.WriteLine(collection["sesiones"]);
            }
            //Horas de entrenamiento por sesion
            if (!string.IsNullOrEmpty(collection["por_sesion"]))
            {
                Carrera_Deportiva CD3 = new Carrera_Deportiva();
                CD3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CD3.Preguntas = "Horas de entrenamiento por sesion";
                CD3.Respuestas = collection["por_sesion"];
                CD3.Detalles = "";
                db.Carrera_Deportiva.Add(CD3);
                db.SaveChanges();
                //Debug.WriteLine("Horas de entrenamiento por sesion");
                //Debug.WriteLine(collection["por_sesion"]);
            }
            //Modalidad de entrenamiento
            if (!string.IsNullOrEmpty(collection["modalidad_entrenamiento"]))
            {
                Carrera_Deportiva CD4 = new Carrera_Deportiva();
                CD4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CD4.Preguntas = "Modalidad de entrenamiento";
                CD4.Respuestas = collection["modalidad_entrenamiento"];
                CD4.Detalles = "";
                db.Carrera_Deportiva.Add(CD4);
                db.SaveChanges();
                //Debug.WriteLine("Modalidad de entrenamiento");
                //Debug.WriteLine(collection["modalidad_entrenamiento"]);
            }
            //Cuento con un plan de entrenamiento que:
            if (!string.IsNullOrEmpty(collection["plan"]))
            {
                Carrera_Deportiva CD5 = new Carrera_Deportiva();
                CD5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CD5.Preguntas = "Cuento con un plan de entrenamiento que:";
                CD5.Respuestas = collection["plan"];
                CD5.Detalles = "";
                db.Carrera_Deportiva.Add(CD5);
                db.SaveChanges();
                //Debug.WriteLine("Cuento con un plan de entrenamiento que:");
                //Debug.WriteLine(collection["plan"]);
            }
            //Sus actividades se adaptan a sus horararios y sesiones de entrenamiento
            if (!string.IsNullOrEmpty(collection["acti"]))
            {
                Carrera_Deportiva CD6 = new Carrera_Deportiva();
                CD6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CD6.Preguntas = "Sus actividades se adaptan a sus horararios y sesiones de entrenamiento";
                CD6.Respuestas = collection["acti"];
                if (!string.IsNullOrEmpty(collection["mediporque"]) && collection["acti"] == "Medianamente")
                {
                    var vocal = collection["mediporque"];
                    CD6.Detalles = Convert.ToString(vocal);
                }
                else if (!string.IsNullOrEmpty(collection["no_porque"]) && collection["acti"] == "No")
                {
                    CD6.Detalles = collection["no_porque"];
                }
                else
                {
                    CD6.Detalles = "";
                }
                db.Carrera_Deportiva.Add(CD6);
                db.SaveChanges();
                //Debug.WriteLine("Sus actividades se adaptan a sus horararios y sesiones de entrenamiento");
                //Debug.WriteLine(collection["acti"]);
                //Debug.WriteLine(collection["mediporque"]);
                //Debug.WriteLine(collection["no_porque"]);
            }
            //Su sitio de entrenamiento es:            
            if (!string.IsNullOrEmpty(collection["sitio"]))
            {
                Carrera_Deportiva CD7 = new Carrera_Deportiva();
                CD7.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CD7.Preguntas = "Su sitio de entrenamiento es:";
                CD7.Respuestas = collection["sitio"];
                if (!string.IsNullOrEmpty(collection["inad"]))
                {
                    CD7.Detalles = collection["inadec"];
                    //Debug.WriteLine("Su sitio de entrenamiento es:");
                    //Debug.WriteLine(collection["inad"]);
                    //Debug.WriteLine(collection["inadec"]);
                }
                else
                {
                    CD7.Detalles = "";
                }
                //Debug.WriteLine("Su sitio de entrenamiento es:");
                //Debug.WriteLine(collection["sitio"]);
                db.Carrera_Deportiva.Add(CD7);
                db.SaveChanges();
            }
            //INFORMACION LABORAL/ECONMICA
            //Trabaja Actualmente
            //Tabla Situacion laboral
            if (!string.IsNullOrEmpty(collection["trabaja"]))
            {
                Situacion_Laboral SL1 = new Situacion_Laboral();
                SL1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                SL1.Preguntas = "Trabaja Actualmente";
                SL1.Respuestas = collection["trabaja"];
                db.Situacion_Laboral.Add(SL1);
                db.SaveChanges();
                //Debug.WriteLine("Trabaja Actualmente");
                //Debug.WriteLine(collection["trabaja"]);
            }
            //Tiene personas a cargo
            if (!string.IsNullOrEmpty(collection["personas"]))
            {
                Situacion_Laboral SL2 = new Situacion_Laboral();
                SL2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                SL2.Preguntas = "Tiene personas a cargo";
                SL2.Respuestas = collection["personas"];
                db.Situacion_Laboral.Add(SL2);
                db.SaveChanges();
                //Debug.WriteLine("Tiene personas a cargo");
                //Debug.WriteLine(collection["personas"]);
            }
            //Tabla Apoyo Economico
            //Las necesidades economicas del atleta para su practica deportiva son asumidas por:
            //Atleta
            if (!string.IsNullOrEmpty(collection["NEA"]))
            {
                Apoyo_Economico AE1 = new Apoyo_Economico();
                AE1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE1.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE1.Respuestas = collection["NEA"];
                AE1.Detalles = "";
                db.Apoyo_Economico.Add(AE1);
                db.SaveChanges();
            }
            else
            {

            }
            //Padre
            if (!string.IsNullOrEmpty(collection["NEP"]))
            {
                Apoyo_Economico AE2 = new Apoyo_Economico();
                AE2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE2.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE2.Respuestas = collection["NEP"];
                AE2.Detalles = "";
                db.Apoyo_Economico.Add(AE2);
                db.SaveChanges();
            }
            else
            {

            }
            //Madre
            if (!string.IsNullOrEmpty(collection["NEM"]))
            {
                Apoyo_Economico AE3 = new Apoyo_Economico();
                AE3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE3.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE3.Respuestas = collection["NEM"];
                AE3.Detalles = "";
                db.Apoyo_Economico.Add(AE3);
                db.SaveChanges();
            }
            else
            {

            }
            //Pareja
            if (!string.IsNullOrEmpty(collection["NEPA"]))
            {
                Apoyo_Economico AE4 = new Apoyo_Economico();
                AE4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE4.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE4.Respuestas = collection["NEPA"];
                AE4.Detalles = "";
                db.Apoyo_Economico.Add(AE4);
                db.SaveChanges();
            }
            else
            {

            }
            //Otros Miembros de la Familia
            if (!string.IsNullOrEmpty(collection["NEOMF"]))
            {
                Apoyo_Economico AE5 = new Apoyo_Economico();
                AE5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE5.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE5.Respuestas = collection["NEOMF"];
                AE5.Detalles = collection["txt_otrosmiembros"];
                db.Apoyo_Economico.Add(AE5);
                db.SaveChanges();
            }
            else
            {

            }
            //Otros Miembros Cuales
            if (!string.IsNullOrEmpty(collection["NEOMC"]))
            {
                Apoyo_Economico AE6 = new Apoyo_Economico();
                AE6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE6.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE6.Respuestas = collection["NEOMC"];
                AE6.Detalles = collection["txt_otrospersonas"];
                db.Apoyo_Economico.Add(AE6);
                db.SaveChanges();
            }
            else
            {

            }
            //No Recibe apoyo Monetario
            if (!string.IsNullOrEmpty(collection["NENRAM"]))
            {
                Apoyo_Economico AE7 = new Apoyo_Economico();
                AE7.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE7.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE7.Respuestas = collection["NENRAM"];
                AE7.Detalles = "";
                db.Apoyo_Economico.Add(AE7);
                db.SaveChanges();
            }
            else
            {

            }
            //Apoyo Monetario de Programa Deportivo
            if (!string.IsNullOrEmpty(collection["NEAMPD"]))
            {
                Apoyo_Economico AE8 = new Apoyo_Economico();
                AE8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE8.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE8.Respuestas = collection["NEAMPD"];
                AE8.Detalles = "";
                db.Apoyo_Economico.Add(AE8);
                db.SaveChanges();
            }
            else
            {

            }
            //Federacion
            if (!string.IsNullOrEmpty(collection["NEF"]))
            {
                Apoyo_Economico AE9 = new Apoyo_Economico();
                AE9.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE9.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE9.Respuestas = collection["NEF"];
                AE9.Detalles = "";
                db.Apoyo_Economico.Add(AE9);
                db.SaveChanges();
            }
            else
            {

            }
            //Otros Apoyos
            if (!string.IsNullOrEmpty(collection["NEOA"]))
            {
                Apoyo_Economico AE10 = new Apoyo_Economico();
                AE10.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE10.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE10.Respuestas = collection["NEOA"];
                AE10.Detalles = collection["txt_otrosapoyos1"];
                db.Apoyo_Economico.Add(AE10);
                db.SaveChanges();
            }
            else
            {

            }
            //Tabla Consiste apoyo
            //En que consiste el apoyo que recibe:
            //Monetario
            if (!string.IsNullOrEmpty(collection["CAM"]))
            {
                Consiste_Apoyo CA1 = new Consiste_Apoyo();
                CA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CA1.Preguntas = "En que consiste el apoyo que recibe:";
                CA1.Respuestas = collection["CAM"];
                db.Consiste_Apoyo.Add(CA1);
                db.SaveChanges();
                //Debug.WriteLine("En que consiste el apoyo que recibe:");
                //Debug.WriteLine(collection["consiste[]"]);
            }
            else
            {

            }
            //Equipo Ciencias del Deporte
            if (!string.IsNullOrEmpty(collection["CAECD"]))
            {
                Consiste_Apoyo CA2 = new Consiste_Apoyo();
                CA2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CA2.Preguntas = "En que consiste el apoyo que recibe:";
                CA2.Respuestas = collection["CAECD"];
                db.Consiste_Apoyo.Add(CA2);
                db.SaveChanges();
                //Debug.WriteLine("En que consiste el apoyo que recibe:");
                //Debug.WriteLine(collection["consiste[]"]);
            }
            else
            {

            }
            //Educativo
            if (!string.IsNullOrEmpty(collection["CAE"]))
            {
                Consiste_Apoyo CA3 = new Consiste_Apoyo();
                CA3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CA3.Preguntas = "En que consiste el apoyo que recibe:";
                CA3.Respuestas = collection["CAE"];
                db.Consiste_Apoyo.Add(CA3);
                db.SaveChanges();
                //Debug.WriteLine("En que consiste el apoyo que recibe:");
                //Debug.WriteLine(collection["consiste[]"]);
            }
            else
            {

            }
            //Alojamiento
            if (!string.IsNullOrEmpty(collection["CAA"]))
            {
                Consiste_Apoyo CA4 = new Consiste_Apoyo();
                CA4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CA4.Preguntas = "En que consiste el apoyo que recibe:";
                CA4.Respuestas = collection["CAA"];
                db.Consiste_Apoyo.Add(CA4);
                db.SaveChanges();
                //Debug.WriteLine("En que consiste el apoyo que recibe:");
                //Debug.WriteLine(collection["consiste[]"]);
            }
            else
            {

            }
            //Transporte
            if (!string.IsNullOrEmpty(collection["CAT"]))
            {
                Consiste_Apoyo CA5 = new Consiste_Apoyo();
                CA5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CA5.Preguntas = "En que consiste el apoyo que recibe:";
                CA5.Respuestas = collection["CAT"];
                db.Consiste_Apoyo.Add(CA5);
                db.SaveChanges();
                //Debug.WriteLine("En que consiste el apoyo que recibe:");
                //Debug.WriteLine(collection["consiste[]"]);
            }
            else
            {

            }
            //Alimentacion
            if (!string.IsNullOrEmpty(collection["CAAL"]))
            {
                Consiste_Apoyo CA6 = new Consiste_Apoyo();
                CA6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                CA6.Preguntas = "En que consiste el apoyo que recibe:";
                CA6.Respuestas = collection["CAAL"];
                db.Consiste_Apoyo.Add(CA6);
                db.SaveChanges();
                //Debug.WriteLine("En que consiste el apoyo que recibe:");
                //Debug.WriteLine(collection["consiste[]"]);
            }
            else
            {

            }
            //En que invierte su apoyo monetario
            //Practica Deportiva
            if (!string.IsNullOrEmpty(collection["IAMPD"]))
            {
                Apoyo_Economico AE17 = new Apoyo_Economico();
                AE17.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE17.Preguntas = "En que invierte su apoyo monetario";
                AE17.Respuestas = collection["IAMPD"];
                AE17.Detalles = "";
                db.Apoyo_Economico.Add(AE17);
                db.SaveChanges();
                //Debug.WriteLine("En que invierte su apoyo monetario");
                //Debug.WriteLine(collection["invierte[]"]);
            }
            else
            {

            }
            //Economia Familiar
            if (!string.IsNullOrEmpty(collection["IAMEF"]))
            {
                Apoyo_Economico AE18 = new Apoyo_Economico();
                AE18.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE18.Preguntas = "En que invierte su apoyo monetario";
                AE18.Respuestas = collection["IAMEF"];
                AE18.Detalles = "";
                db.Apoyo_Economico.Add(AE18);
                db.SaveChanges();
                //Debug.WriteLine("En que invierte su apoyo monetario");
                //Debug.WriteLine(collection["invierte[]"]);
            }
            else
            {

            }
            //Educacion
            if (!string.IsNullOrEmpty(collection["IAME"]))
            {
                Apoyo_Economico AE19 = new Apoyo_Economico();
                AE19.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE19.Preguntas = "En que invierte su apoyo monetario";
                AE19.Respuestas = collection["IAME"];
                AE19.Detalles = "";
                db.Apoyo_Economico.Add(AE19);
                db.SaveChanges();
                //Debug.WriteLine("En que invierte su apoyo monetario");
                //Debug.WriteLine(collection["invierte[]"]);
            }
            else
            {

            }
            //INFORMACION EXTRA
            //Informacion Familiar
            //Tabla Informacion Familiar
            //Con quien vive
            //Soltero
            if (!string.IsNullOrEmpty(collection["CQVS"]))
            {
                Informacion_Familiar IF1 = new Informacion_Familiar();
                IF1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF1.Preguntas = "Con quien vive";
                IF1.Respuestas = collection["CQVS"];
                IF1.Detalles = "";
                db.Informacion_Familiar.Add(IF1);
                db.SaveChanges();
                //Debug.WriteLine("Con quien vive");
                //Debug.WriteLine(collection["vive[]"]);
            }
            //Acompañado
            if (!string.IsNullOrEmpty(collection["CQVA"]))
            {
                Informacion_Familiar IF2 = new Informacion_Familiar();
                IF2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF2.Preguntas = "Con quien vive";
                IF2.Respuestas = collection["CQVA"];
                IF2.Detalles = "";
                db.Informacion_Familiar.Add(IF2);
                db.SaveChanges();
                //Debug.WriteLine("Con quien vive");
                //Debug.WriteLine(collection["vive[]"]);
            }
            //Padre
            if (!string.IsNullOrEmpty(collection["CQVPA"]))
            {
                Informacion_Familiar IF3 = new Informacion_Familiar();
                IF3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF3.Preguntas = "Con quien vive";
                IF3.Respuestas = collection["CQVPA"];
                IF3.Detalles = "";
                db.Informacion_Familiar.Add(IF3);
                db.SaveChanges();
                //Debug.WriteLine("Con quien vive");
                //Debug.WriteLine(collection["vive[]"]);
            }
            //Madre
            if (!string.IsNullOrEmpty(collection["CQVMA"]))
            {
                Informacion_Familiar IF4 = new Informacion_Familiar();
                IF4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF4.Preguntas = "Con quien vive";
                IF4.Respuestas = collection["CQVMA"];
                IF4.Detalles = "";
                db.Informacion_Familiar.Add(IF4);
                db.SaveChanges();
                //Debug.WriteLine("Con quien vive");
                //Debug.WriteLine(collection["vive[]"]);
            }
            //Hermanos
            if (!string.IsNullOrEmpty(collection["CQVHE"]))
            {
                Informacion_Familiar IF5 = new Informacion_Familiar();
                IF5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF5.Preguntas = "Con quien vive";
                IF5.Respuestas = collection["CQVHE"];
                if (!string.IsNullOrEmpty(collection["txt_Chermanos"]))
                {
                    IF5.Detalles = collection["txt_Chermanos"];
                }
                else
                {
                    IF5.Detalles = "";
                }
                db.Informacion_Familiar.Add(IF5);
                db.SaveChanges();
                //Debug.WriteLine("Con quien vive");
                //Debug.WriteLine(collection["vive[]"]);
            }
            //Hijos
            if (!string.IsNullOrEmpty(collection["CQVHI"]))
            {
                Informacion_Familiar IF6 = new Informacion_Familiar();
                IF6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF6.Preguntas = "Con quien vive";
                IF6.Respuestas = collection["CQVHI"];
                if (!string.IsNullOrEmpty(collection["txt_cHijos"]))
                {
                    IF6.Detalles = collection["txt_cHijos"];
                }
                else
                {
                    IF6.Detalles = "";
                }
                db.Informacion_Familiar.Add(IF6);
                db.SaveChanges();
                //Debug.WriteLine("Con quien vive");
                //Debug.WriteLine(collection["vive[]"]);
            }
            //Otros Familiares
            if (!string.IsNullOrEmpty(collection["CQVOF"]))
            {
                Informacion_Familiar IF7 = new Informacion_Familiar();
                IF7.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF7.Preguntas = "Con quien vive";
                IF7.Respuestas = collection["CQVOF"];
                if (!string.IsNullOrEmpty(collection["txt_Qfamiliar"]))
                {
                    IF7.Detalles = collection["txt_Qfamiliar"];
                }
                else
                {
                    IF7.Detalles = "";
                }
                db.Informacion_Familiar.Add(IF7);
                db.SaveChanges();
                //Debug.WriteLine("Con quien vive");
                //Debug.WriteLine(collection["vive[]"]);
            }
            //Otro
            if (!string.IsNullOrEmpty(collection["CQVO"]))
            {
                Informacion_Familiar IF8 = new Informacion_Familiar();
                IF8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF8.Preguntas = "Con quien vive";
                IF8.Respuestas = collection["CQVO"];
                if (!string.IsNullOrEmpty(collection["txt_Qotros"]))
                {
                    IF8.Detalles = collection["txt_Qotros"];
                }
                else
                {
                    IF8.Detalles = "";
                }
                db.Informacion_Familiar.Add(IF8);
                db.SaveChanges();
                //Debug.WriteLine("Con quien vive");
                //Debug.WriteLine(collection["vive[]"]);
            }
            //Alojamiento Deportivo
            if (!string.IsNullOrEmpty(collection["CQVAD"]))
            {
                Informacion_Familiar IF9 = new Informacion_Familiar();
                IF9.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF9.Preguntas = "Con quien vive";
                IF9.Respuestas = collection["CQVAD"];
                IF9.Detalles = "";
                db.Informacion_Familiar.Add(IF9);
                db.SaveChanges();
                //Debug.WriteLine("Con quien vive");
                //Debug.WriteLine(collection["vive[]"]);
            }
            //¿Tiene Hijos?
            if (!string.IsNullOrEmpty(collection["btnhijos"]))
            {
                Informacion_Familiar IF10 = new Informacion_Familiar();
                IF10.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF10.Preguntas = "¿Tiene Hijos?";
                IF10.Respuestas = collection["btnhijos"];
                IF10.Detalles = "";
                db.Informacion_Familiar.Add(IF10);
                db.SaveChanges();
                //Debug.WriteLine("¿Tiene Hijos?");
                //Debug.WriteLine(collection["btnhijos"]);
            }
            //¿Proyecta Tener Hijos?
            if (!string.IsNullOrEmpty(collection["pmhijos"]))
            {
                Informacion_Familiar IF11 = new Informacion_Familiar();
                IF11.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF11.Preguntas = "¿Proyecta Tener Hijos?";
                IF11.Respuestas = collection["pmhijos"];
                IF11.Detalles = "";
                db.Informacion_Familiar.Add(IF11);
                db.SaveChanges();
                //Debug.WriteLine("¿Proyecta Tener Hijos?");
                //Debug.WriteLine(collection["pmhijos"]);
            }
            //Números de personas con las que Vive
            if (!string.IsNullOrEmpty(collection["numvive"]))
            {
                Informacion_Familiar IF12 = new Informacion_Familiar();
                IF12.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                IF12.Preguntas = "Números de personas con las que Vive";
                IF12.Respuestas = collection["numvive"];
                if (!string.IsNullOrEmpty(collection["txt_menosde4"]))
                {
                    //Debug.WriteLine(collection["txt_menosde4"]);
                    IF12.Detalles = collection["txt_menosde4"];
                }
                else
                {
                    IF12.Detalles = "";
                }
                db.Informacion_Familiar.Add(IF12);
                db.SaveChanges();
                //Debug.WriteLine("Números de personas con las que Vive");
                //Debug.WriteLine(collection["numvive"]);                
            }
            //EDUCACION Y FORMACION
            //Situacion Academica
            if (!string.IsNullOrEmpty(collection["Est"]))
            {
                Educacion E1 = new Educacion();
                E1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                E1.Preguntas = "Estudia Actualmente";
                E1.Respuestas = collection["Est"];
                E1.Detalles = "";
                db.Educacion.Add(E1);
                db.SaveChanges();
                //Debug.WriteLine("Estudia Actualmente");
                //Debug.WriteLine(collection["Est"]);
            }
            //Ultimo nivel academico terminado
            if (!string.IsNullOrEmpty(collection["nivelaca"]))
            {
                Educacion E2 = new Educacion();
                E2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                E2.Preguntas = "Ultimo nivel academico terminado";
                E2.Respuestas = collection["nivelaca"];
                if (!string.IsNullOrEmpty(collection["especializacion_maestria"]))
                {
                    //    Debug.WriteLine(collection["especializacion_maestria"]);
                    E2.Detalles = collection["especializacion_maestria"];
                }
                else
                {
                    E2.Detalles = "";
                }
                db.Educacion.Add(E2);
                db.SaveChanges();
                //Debug.WriteLine("Ultimo nivel academico terminado");
                //Debug.WriteLine(collection["nivelaca"]);
                //if (!string.IsNullOrEmpty(collection["especializacion_maestria"]))
                //{
                //    Debug.WriteLine(collection["especializacion_maestria"]);
                //}
                //else if (!string.IsNullOrEmpty(collection["txt_donde_Estudia"]))
                //{
                //    Debug.WriteLine(collection["txt_donde_Estudia"]);
                //}
                //else
                //{
                //    Debug.WriteLine("No posee");
                //    Debug.WriteLine("No posee");
                //}
            }
            // Donde Estudia
            if (!string.IsNullOrEmpty(collection["txt_donde_Estudia"]))
            {
                Educacion E3 = new Educacion();
                E3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                E3.Preguntas = "¿Donde Estudia?";
                E3.Respuestas = collection["txt_donde_Estudia"];
                E3.Detalles = "";
                db.Educacion.Add(E3);
                db.SaveChanges();
            }
            //Lugar de Habitacion
            if (!string.IsNullOrEmpty(collection["barrio"]))
            {
                Habitacion habitacion1 = new Habitacion();
                habitacion1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                habitacion1.Preguntas = "Cómo calificaría su barrio";
                habitacion1.Respuestas = collection["barrio"];
                if (!string.IsNullOrEmpty(collection["txtotrosbarrios"]))
                {
                    //    Debug.WriteLine(collection["especializacion_maestria"]);
                    habitacion1.Detalles = collection["txtotrosbarrios"];
                }
                else
                {
                    habitacion1.Detalles = "";
                }
                db.Habitacion.Add(habitacion1);
                db.SaveChanges();
                //Debug.WriteLine("Cómo calificaría su barrio");
                //Debug.WriteLine(collection["barrio"]);
                //if (!string.IsNullOrEmpty(collection["txtotrosbarrios"]))
                //{
                //    Debug.WriteLine(collection["txtotrosbarrios"]);
                //}
            }
            //Como describiria el estado de la vivienda en que reside actualmente
            if (!string.IsNullOrEmpty(collection["vivienda"]))
            {
                Habitacion habitacion2 = new Habitacion();
                habitacion2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                habitacion2.Preguntas = "Como describiria el estado de la vivienda en que reside actualmente";
                habitacion2.Respuestas = collection["vivienda"];
                habitacion2.Detalles = "";
                db.Habitacion.Add(habitacion2);
                db.SaveChanges();
                //Debug.WriteLine("Como describiria el estado de la vivienda en que reside actualmente");
                //Debug.WriteLine(collection["vivienda"]);
            }
            //Habitos
            //¿Usted Fuma?
            if (!string.IsNullOrEmpty(collection["fuma"]))
            {
                Habitos habitos1 = new Habitos();
                habitos1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                habitos1.Preguntas = "¿Usted Fuma?";
                habitos1.Respuestas = collection["fuma"];
                if (!string.IsNullOrEmpty(collection["si_fuma"]))
                {
                    habitos1.Detalles = collection["si_fuma"];
                }
                else
                {
                    habitos1.Detalles = "";
                }
                db.Habitos.Add(habitos1);
                db.SaveChanges();
                //Debug.WriteLine("¿Usted Fuma?");
                //Debug.WriteLine(collection["fuma"]);
                //if (!string.IsNullOrEmpty(collection["si_fuma"]))
                //{
                //    Debug.WriteLine(collection["si_fuma"]);
                //}
            }
            //¿Usted toma?
            if (!string.IsNullOrEmpty(collection["toma"]))
            {
                Habitos habitos2 = new Habitos();
                habitos2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                habitos2.Preguntas = "¿Usted Toma?";
                habitos2.Respuestas = collection["toma"];
                if (!string.IsNullOrEmpty(collection["cerveza"]))
                {
                    habitos2.Detalles = collection["cerveza"];
                }
                else
                {
                    habitos2.Detalles = "";
                }
                if (!string.IsNullOrEmpty(collection["licor"]))
                {
                    habitos2.Detalles = collection["licor"];
                }
                else
                {
                    habitos2.Detalles = "";
                }
                db.Habitos.Add(habitos2);
                db.SaveChanges();
                //Debug.WriteLine("¿Usted toma?");
                //Debug.WriteLine(collection["toma"]);
                //if (!string.IsNullOrEmpty(collection["cerveza"]))
                //{
                //    Debug.WriteLine(collection["cerveza"]);
                //}
                //if (!string.IsNullOrEmpty(collection["licor"]))
                //{
                //    Debug.WriteLine(collection["licor"]);
                //}
            }
            return Redirect("~/HomeAdmin/");
        }
        [HttpPost]
        public ActionResult Actualizar(int ID, FormCollection collection)
        {
            //MEDICAMENTOS
            //Relajantes Musculares
            if (!string.IsNullOrEmpty(collection["btnrelajantes"]))
            {
                Medicamentos M = db.Medicamentos.FirstOrDefault(s => s.ID_Atleta == ID && s.Medicamentos1 == "Relajante Musculares");
                if (M == null)
                {
                    Medicamentos Medica1 = new Medicamentos();
                    Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Medica1.Medicamentos1 = "Relajante Musculares";
                    Medica1.Descripcion = collection["txt_medicamentos"];
                    db.Medicamentos.Add(Medica1);
                    db.SaveChanges();
                }
                else
                {
                    //M.ID = M.ID;
                    M.ID_Atleta = ID;
                    M.Medicamentos1 = collection["btnrelajantes"];
                    M.Descripcion = collection["txt_medicamentos"];
                    db.Entry(M).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Medicamentos M = db.Medicamentos.FirstOrDefault(s => s.ID_Atleta == ID && s.Medicamentos1 == "Relajante Musculares");
                if (M == null)
                {

                }
                else
                {
                    M.ID_Atleta = ID;
                    M.Medicamentos1 = collection["btnrelajantes"];
                    M.Descripcion = collection["txt_medicamentos"];
                    db.Medicamentos.Remove(M);                    
                    db.SaveChanges();
                }
            }
            //Antiinflamatorios
            if (!string.IsNullOrEmpty(collection["antiflamatorio"]))
            {
                Medicamentos M = db.Medicamentos.FirstOrDefault(s => s.ID_Atleta == ID && s.Medicamentos1 == "Antiinflamatorios");
                if (M == null)
                {
                    Medicamentos Medica2 = new Medicamentos();
                    Medica2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Medica2.Medicamentos1 = "Antiinflamatorios";
                    Medica2.Descripcion = collection["txt_antiinflamatorios"];
                    db.Medicamentos.Add(Medica2);
                    db.SaveChanges();
                }
                else
                {
                    M.ID_Atleta = ID;
                    M.Medicamentos1 = collection["antiflamatorio"];
                    M.Descripcion = collection["txt_antiinflamatorios"];
                    db.Entry(M).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Medicamentos M = db.Medicamentos.FirstOrDefault(s => s.ID_Atleta == ID && s.Medicamentos1 == "Antiinflamatorios");
                if (M == null)
                {

                }
                else
                {
                    M.ID_Atleta = ID;
                    M.Medicamentos1 = collection["antiflamatorio"];
                    M.Descripcion = collection["txt_antiinflamatorios"];
                    db.Medicamentos.Remove(M);
                    db.SaveChanges();
                }
            }
            //Analgesico
            if (!string.IsNullOrEmpty(collection["analgesico"]))
            {
                Medicamentos M = db.Medicamentos.FirstOrDefault(s => s.ID_Atleta == ID && s.Medicamentos1 == "Analgesicos");
                if (M == null)
                {
                    Medicamentos Medica3 = new Medicamentos();
                    Medica3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Medica3.Medicamentos1 = "Analgesicos";
                    Medica3.Descripcion = collection["txt_analgesicos"];
                    db.Medicamentos.Add(Medica3);
                    db.SaveChanges();
                }
                else
                {
                    M.ID_Atleta = ID;
                    M.Medicamentos1 = collection["analgesico"];
                    M.Descripcion = collection["txt_analgesicos"];
                    db.Entry(M).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Medicamentos M = db.Medicamentos.FirstOrDefault(s => s.ID_Atleta == ID && s.Medicamentos1 == "Analgesicos");
                if (M == null)
                {

                }
                else
                {
                    M.ID_Atleta = ID;
                    M.Medicamentos1 = collection["analgesico"];
                    M.Descripcion = collection["txt_analgesicos"];
                    db.Medicamentos.Remove(M);
                    db.SaveChanges();
                }
            }
            //Otros
            if (!string.IsNullOrEmpty(collection["btn_otros"]))
            {
                Medicamentos M = db.Medicamentos.FirstOrDefault(s => s.ID_Atleta == ID && s.Medicamentos1 == "Otros Medicamentos");
                if (M == null)
                {
                    Medicamentos Medica3 = new Medicamentos();
                    Medica3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Medica3.Medicamentos1 = "Otros Medicamentos";
                    Medica3.Descripcion = collection["txt_medicamentos_otros"];
                    db.Medicamentos.Add(Medica3);
                    db.SaveChanges();
                }
                else
                {
                    M.ID_Atleta = ID;
                    M.Medicamentos1 = collection["btn_otros"];
                    M.Descripcion = collection["txt_medicamentos_otros"];
                    db.Entry(M).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Medicamentos M = db.Medicamentos.FirstOrDefault(s => s.ID_Atleta == ID && s.Medicamentos1 == "Otros Medicamentos");
                if (M == null)
                {

                }
                else
                {
                    M.ID_Atleta = ID;
                    M.Medicamentos1 = collection["btn_otros"];
                    M.Descripcion = collection["txt_medicamentos_otros"];
                    db.Medicamentos.Remove(M);
                    db.SaveChanges();
                }
            }
            //ALERGIAS
            //Medicamentos
            if (!string.IsNullOrEmpty(collection["medicamento_alergia"]))
            {
                Alergias A = db.Alergias.FirstOrDefault(s => s.ID_Atleta == ID && s.Alergia == "Medicamentos");
                if (A == null)
                {
                    Alergias Alergia1 = new Alergias();
                    Alergia1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Alergia1.Alergia = "Medicamentos";
                    Alergia1.Descripcion = collection["txt_medicamentos_alergicos"];
                    db.Alergias.Add(Alergia1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Alergia = collection["medicamento_alergia"];
                    A.Descripcion = collection["txt_medicamentos_alergicos"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Alergias A = db.Alergias.FirstOrDefault(s => s.ID_Atleta == ID && s.Alergia == "Medicamentos");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Alergia = collection["medicamento_alergia"];
                    A.Descripcion = collection["txt_medicamentos_alergicos"];
                    db.Alergias.Remove(A);
                    db.SaveChanges();
                }
            }
            //Polen
            if (!string.IsNullOrEmpty(collection["polen"]))
            {
                Alergias A = db.Alergias.FirstOrDefault(s => s.ID_Atleta == ID && s.Alergia == "Polen");
                if (A == null)
                {
                    Alergias Alergia2 = new Alergias();
                    Alergia2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Alergia2.Alergia = "Polen";
                    Alergia2.Descripcion = collection["txt_alergia_polen"];
                    db.Alergias.Add(Alergia2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Alergia = collection["polen"];
                    A.Descripcion = collection["txt_alergia_polen"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Alergias A = db.Alergias.FirstOrDefault(s => s.ID_Atleta == ID && s.Alergia == "Polen");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Alergia = collection["polen"];
                    A.Descripcion = collection["txt_alergia_polen"];
                    db.Alergias.Remove(A);
                    db.SaveChanges();
                }
            }
            //Comida
            if (!string.IsNullOrEmpty(collection["comida"]))
            {
                Alergias A = db.Alergias.FirstOrDefault(s => s.ID_Atleta == ID && s.Alergia == "Comida");
                if (A == null)
                {
                    Alergias Alergia3 = new Alergias();
                    Alergia3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Alergia3.Alergia = "Comida";
                    Alergia3.Descripcion = collection["txtalergiacomida"];
                    db.Alergias.Add(Alergia3);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Alergia = collection["comida"];
                    A.Descripcion = collection["txtalergiacomida"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Alergias A = db.Alergias.FirstOrDefault(s => s.ID_Atleta == ID && s.Alergia == "Comida");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Alergia = collection["comida"];
                    A.Descripcion = collection["txtalergiacomida"];
                    db.Alergias.Remove(A);
                    db.SaveChanges();
                }
            }
            //Piquetes de Insectos
            if (!string.IsNullOrEmpty(collection["piquetesdeinsectos"]))
            {
                Alergias A = db.Alergias.FirstOrDefault(s => s.ID_Atleta == ID && s.Alergia == "Piquetes de insectos");
                if (A == null)
                {
                    Alergias Alergia4 = new Alergias();
                    Alergia4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Alergia4.Alergia = "Piquetes de insectos";
                    Alergia4.Descripcion = collection["txtpiquete"];
                    db.Alergias.Add(Alergia4);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Alergia = collection["piquetesdeinsectos"];
                    A.Descripcion = collection["txtpiquete"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Alergias A = db.Alergias.FirstOrDefault(s => s.ID_Atleta == ID && s.Alergia == "Piquetes de insectos");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Alergia = collection["piquetesdeinsectos"];
                    A.Descripcion = collection["txtpiquete"];
                    db.Alergias.Remove(A);
                    db.SaveChanges();
                }
            }
            //Otros
            if (!string.IsNullOrEmpty(collection["otrosalergias"]))
            {
                Alergias A = db.Alergias.FirstOrDefault(s => s.ID_Atleta == ID && s.Alergia == "Otros");
                if (A == null)
                {
                    Alergias Alergia5 = new Alergias();
                    Alergia5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    Alergia5.Alergia = "Otros";
                    Alergia5.Descripcion = collection["txtotra_alergia"];
                    db.Alergias.Add(Alergia5);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Alergia = collection["otrosalergias"];
                    A.Descripcion = collection["txtotra_alergia"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Alergias A = db.Alergias.FirstOrDefault(s => s.ID_Atleta == ID && s.Alergia == "Otros");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Alergia = collection["otrosalergias"];
                    A.Descripcion = collection["txtotra_alergia"];
                    db.Alergias.Remove(A);
                    db.SaveChanges();
                }
            }
            //PREGUNTAS
            //Historial Medico
            //Pregunta A
            if (!string.IsNullOrEmpty(collection["pregunta_A"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguna vez un doctor te ha prohibido limitado tu participacion en deportes por alguna razon?");
                if (A == null)
                {
                    Historial_Medico HM1 = new Historial_Medico();
                    HM1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM1.Preguntas = "¿Alguna vez un doctor te ha prohibido limitado tu participacion en deportes por alguna razon?";
                    HM1.Respuestas = collection["pregunta_A"];
                    HM1.Detalles = "";
                    db.Historial_Medico.Add(HM1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguna vez un doctor te ha prohibido limitado tu participacion en deportes por alguna razon?";
                    A.Respuestas = collection["pregunta_A"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguna vez un doctor te ha prohibido limitado tu participacion en deportes por alguna razon?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguna vez un doctor te ha prohibido limitado tu participacion en deportes por alguna razon?";
                    A.Respuestas = collection["pregunta_A"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pregunta B
            if (!string.IsNullOrEmpty(collection["pregunta_B"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has sido ingresado alguna vez en el hospital?");
                if (A == null)
                {
                    Historial_Medico HM2 = new Historial_Medico();
                    HM2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM2.Preguntas = "¿Has sido ingresado alguna vez en el hospital?";
                    HM2.Respuestas = collection["pregunta_B"];
                    HM2.Detalles = "";
                    db.Historial_Medico.Add(HM2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has sido ingresado alguna vez en el hospital?";
                    A.Respuestas = collection["pregunta_B"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has sido ingresado alguna vez en el hospital?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has sido ingresado alguna vez en el hospital?";
                    A.Respuestas = collection["pregunta_B"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pregunta C
            if (!string.IsNullOrEmpty(collection["pregunta_C"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has tenido cirugia alguna vez?");
                if (A == null)
                {
                    Historial_Medico HM3 = new Historial_Medico();
                    HM3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM3.Preguntas = "¿Has tenido cirugia alguna vez?";
                    HM3.Respuestas = collection["pregunta_C"];
                    HM3.Detalles = "";
                    db.Historial_Medico.Add(HM3);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has tenido cirugia alguna vez?";
                    A.Respuestas = collection["pregunta_C"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has tenido cirugia alguna vez?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has tenido cirugia alguna vez?";
                    A.Respuestas = collection["pregunta_C"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pregunta D
            if (!string.IsNullOrEmpty(collection["pregunta_D"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Usas lentes o lentes de contacto?");
                if (A == null)
                {
                    Historial_Medico HM4 = new Historial_Medico();
                    HM4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM4.Preguntas = "¿Usas lentes o lentes de contacto?";
                    HM4.Respuestas = collection["pregunta_D"];
                    HM4.Detalles = "";
                    db.Historial_Medico.Add(HM4);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Usas lentes o lentes de contacto?";
                    A.Respuestas = collection["pregunta_D"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Usas lentes o lentes de contacto?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Usas lentes o lentes de contacto?";
                    A.Respuestas = collection["pregunta_D"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pregunta E
            if (!string.IsNullOrEmpty(collection["pregunta_E"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Naciste o te falta un riñon,un ojo,un testiculo u algun otro órgano?");
                if (A == null)
                {
                    Historial_Medico HM5 = new Historial_Medico();
                    HM5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM5.Preguntas = "¿Naciste o te falta un riñon,un ojo,un testiculo u algun otro órgano?";
                    HM5.Respuestas = collection["pregunta_E"];
                    HM5.Detalles = "";
                    db.Historial_Medico.Add(HM5);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Naciste o te falta un riñon,un ojo,un testiculo u algun otro órgano?";
                    A.Respuestas = collection["pregunta_E"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Naciste o te falta un riñon,un ojo,un testiculo u algun otro órgano?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Naciste o te falta un riñon,un ojo,un testiculo u algun otro órgano?";
                    A.Respuestas = collection["pregunta_E"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pregunta F
            if (!string.IsNullOrEmpty(collection["pregunta_F"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Te has desmayado durante o despues de hacer ejercicios?");
                if (A == null)
                {
                    Historial_Medico HM6 = new Historial_Medico();
                    HM6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM6.Preguntas = "¿Te has desmayado durante o despues de hacer ejercicios?";
                    HM6.Respuestas = collection["pregunta_F"];
                    HM6.Detalles = "";
                    db.Historial_Medico.Add(HM6);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Te has desmayado durante o despues de hacer ejercicios?";
                    A.Respuestas = collection["pregunta_F"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Te has desmayado durante o despues de hacer ejercicios?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Te has desmayado durante o despues de hacer ejercicios?";
                    A.Respuestas = collection["pregunta_F"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pregunta G
            if (!string.IsNullOrEmpty(collection["pregunta_G"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has tenido alguna vez molestias dolor o presion en el pecho cuando haces ejercicios?");
                if (A == null)
                {
                    Historial_Medico HM7 = new Historial_Medico();
                    HM7.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM7.Preguntas = "¿Has tenido alguna vez molestias dolor o presion en el pecho cuando haces ejercicios?";
                    HM7.Respuestas = collection["pregunta_G"];
                    HM7.Detalles = "";
                    db.Historial_Medico.Add(HM7);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has tenido alguna vez molestias dolor o presion en el pecho cuando haces ejercicios?";
                    A.Respuestas = collection["pregunta_G"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has tenido alguna vez molestias dolor o presion en el pecho cuando haces ejercicios?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has tenido alguna vez molestias dolor o presion en el pecho cuando haces ejercicios?";
                    A.Respuestas = collection["pregunta_G"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pregunta H
            if (!string.IsNullOrEmpty(collection["pregunta_H"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguna vez has tenido palpitaciones o latidos irregulares cuando haces ejercicios?");
                if (A == null)
                {
                    Historial_Medico HM8 = new Historial_Medico();
                    HM8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM8.Preguntas = "¿Alguna vez has tenido palpitaciones o latidos irregulares cuando haces ejercicios?";
                    HM8.Respuestas = collection["pregunta_H"];
                    HM8.Detalles = "";
                    db.Historial_Medico.Add(HM8);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguna vez has tenido palpitaciones o latidos irregulares cuando haces ejercicios?";
                    A.Respuestas = collection["pregunta_H"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguna vez has tenido palpitaciones o latidos irregulares cuando haces ejercicios?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguna vez has tenido palpitaciones o latidos irregulares cuando haces ejercicios?";
                    A.Respuestas = collection["pregunta_H"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pregunta I
            if (!string.IsNullOrEmpty(collection["pregunta_I"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Te ha dicho un doctor que tienes un problema del Corazón?");
                Historial_Medico B = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "I.A Presion Alta");
                Historial_Medico C = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "I.B Soplo en el Corazón");
                Historial_Medico D = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "I.C Nivel alto de Colesterol");
                Historial_Medico E = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "I.D Otro");
                if (A == null)
                {
                    Historial_Medico HM9 = new Historial_Medico();
                    HM9.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM9.Preguntas = "¿Te ha dicho un doctor que tienes un problema del Corazón?";
                    HM9.Respuestas = collection["pregunta_I"];
                    HM9.Detalles = "";
                    db.Historial_Medico.Add(HM9);
                    db.SaveChanges();
                    //Pregunta I Anexo A
                    if (!string.IsNullOrEmpty(collection["presion_alta"]))
                    {
                        Historial_Medico HM10 = new Historial_Medico();
                        HM10.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                        HM10.Preguntas = "I.A Presion Alta";
                        HM10.Respuestas = collection["presion_alta"];
                        HM10.Detalles = "";
                        db.Historial_Medico.Add(HM10);
                        db.SaveChanges();
                    }
                    else
                    {

                    }
                    //Pregunta I Anexo B
                    if (!string.IsNullOrEmpty(collection["Soplo"]))
                    {
                        Historial_Medico HM11 = new Historial_Medico();
                        HM11.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                        HM11.Preguntas = "I.B Soplo en el Corazón";
                        HM11.Respuestas = collection["Soplo"];
                        HM11.Detalles = "";
                        db.Historial_Medico.Add(HM11);
                        db.SaveChanges();
                    }
                    else
                    {

                    }
                    //Pregunta I Anexo C
                    if (!string.IsNullOrEmpty(collection["colesterol"]))
                    {
                        Historial_Medico HM12 = new Historial_Medico();
                        HM12.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                        HM12.Preguntas = "I.C Nivel alto de Colesterol";
                        HM12.Respuestas = collection["colesterol"];
                        HM12.Detalles = "";
                        db.Historial_Medico.Add(HM12);
                        db.SaveChanges();
                    }
                    else
                    {

                    }
                    //Pregunta I Anexo D
                    if (!string.IsNullOrEmpty(collection["otroenfer"]))
                    {
                        Historial_Medico HM13 = new Historial_Medico();
                        HM13.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                        HM13.Preguntas = "I.D Otro";
                        HM13.Respuestas = collection["otroenfer"];
                        HM13.Detalles = collection["txt_especificacion_otros"];
                        db.Historial_Medico.Add(HM13);
                        db.SaveChanges();
                    }
                    else
                    {

                    }
                }
                else
                {
                    //I
                    if (collection["pregunta_I"] == "No")
                    {
                        if (A != null)
                        {
                            A.ID_Atleta = ID;
                            A.Preguntas = "¿Te ha dicho un doctor que tienes un problema del Corazón?";
                            A.Respuestas = collection["pregunta_I"];
                            db.Historial_Medico.Remove(A);
                            db.SaveChanges();
                        }
                        else
                        {

                        }
                        //1 I.A Presion Alta                
                        if (B != null)
                        {
                            B.ID_Atleta = ID;
                            B.Preguntas = "I.A Presion Alta";
                            B.Respuestas = collection["presion_alta"];
                            db.Historial_Medico.Remove(B);
                            db.SaveChanges();
                        }
                        else
                        {

                        }
                        //2 I.B Soplo en el Corazón                
                        if (C != null)
                        {
                            C.ID_Atleta = ID;
                            C.Preguntas = "I.B Soplo en el Corazón";
                            C.Respuestas = collection["Soplo"];
                            db.Historial_Medico.Remove(C);
                            db.SaveChanges();
                        }
                        else
                        {

                        }
                        //3 I.C Nivel alto de Colesterol                
                        if (D != null)
                        {
                            D.ID_Atleta = ID;
                            D.Preguntas = "I.C Nivel alto de Colesterol";
                            D.Respuestas = collection["colesterol"];
                            db.Historial_Medico.Remove(D);
                            db.SaveChanges();
                        }
                        else
                        {

                        }
                        //4 I.D Otro                
                        if (E != null)
                        {
                            E.ID_Atleta = ID;
                            E.Preguntas = "I.D Otro";
                            E.Respuestas = collection["otroenfer"];
                            E.Detalles = collection["txt_especificacion_otros"];
                            db.Historial_Medico.Remove(E);
                            db.SaveChanges();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (A == null)
                        {
                            Historial_Medico HM9 = new Historial_Medico();
                            HM9.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                            HM9.Preguntas = "¿Te ha dicho un doctor que tienes un problema del Corazón?";
                            HM9.Respuestas = collection["pregunta_I"];
                            HM9.Detalles = "";
                            db.Historial_Medico.Add(HM9);
                            db.SaveChanges();
                        }
                        else
                        {
                            A.ID_Atleta = ID;
                            A.Preguntas = "¿Te ha dicho un doctor que tienes un problema del Corazón?";
                            A.Respuestas = collection["pregunta_I"];
                            db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        //1
                        if (B == null)
                        {
                            Historial_Medico HM10 = new Historial_Medico();
                            HM10.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                            HM10.Preguntas = "I.A Presion Alta";
                            HM10.Respuestas = collection["presion_alta"];
                            HM10.Detalles = "";
                            db.Historial_Medico.Add(HM10);
                            db.SaveChanges();
                        }
                        else
                        {
                            B.ID_Atleta = ID;
                            B.Preguntas = "I.A Presion Alta";
                            B.Respuestas = collection["presion_alta"];
                            db.Entry(B).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        //2
                        if (C == null)
                        {
                            Historial_Medico HM11 = new Historial_Medico();
                            HM11.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                            HM11.Preguntas = "I.B Soplo en el Corazón";
                            HM11.Respuestas = collection["Soplo"];
                            HM11.Detalles = "";
                            db.Historial_Medico.Add(HM11);
                            db.SaveChanges();
                        }
                        else
                        {
                            C.ID_Atleta = ID;
                            C.Preguntas = "I.B Soplo en el Corazón";
                            C.Respuestas = collection["Soplo"];
                            db.Entry(C).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        //3
                        if (D == null)
                        {
                            Historial_Medico HM12 = new Historial_Medico();
                            HM12.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                            HM12.Preguntas = "I.C Nivel alto de Colesterol";
                            HM12.Respuestas = collection["colesterol"];
                            HM12.Detalles = "";
                            db.Historial_Medico.Add(HM12);
                            db.SaveChanges();
                        }
                        else
                        {
                            D.ID_Atleta = ID;
                            D.Preguntas = "I.C Nivel alto de Colesterol";
                            D.Respuestas = collection["colesterol"];
                            db.Entry(D).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        //4 
                        if (E == null)
                        {
                            Historial_Medico HM13 = new Historial_Medico();
                            HM13.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                            HM13.Preguntas = "I.D Otro";
                            HM13.Respuestas = collection["otroenfer"];
                            HM13.Detalles = collection["txt_especificacion_otros"];
                            db.Historial_Medico.Add(HM13);
                            db.SaveChanges();
                        }
                        else
                        {
                            if (collection["otroenfer"] == "No")
                            {
                                E.ID_Atleta = ID;
                                E.Preguntas = "I.D Otro";
                                E.Respuestas = collection["otroenfer"];
                                E.Detalles = "";
                                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                            else
                            {
                                E.ID_Atleta = ID;
                                E.Preguntas = "I.D Otro";
                                E.Respuestas = collection["otroenfer"];
                                E.Detalles = collection["txt_especificacion_otros"];
                                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
            else
            {
            }
            //Pregunta J
            if (!string.IsNullOrEmpty(collection["pregunta_J"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguna vez un doctor te ha pedido que te hagas una prueba del corazon¿Ej:Electrocardiograma?");
                if (A == null)
                {
                    Historial_Medico HM8 = new Historial_Medico();
                    HM8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM8.Preguntas = "¿Alguna vez un doctor te ha pedido que te hagas una prueba del corazon¿Ej:Electrocardiograma?";
                    HM8.Respuestas = collection["pregunta_J"];
                    HM8.Detalles = "";
                    db.Historial_Medico.Add(HM8);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguna vez un doctor te ha pedido que te hagas una prueba del corazon¿Ej:Electrocardiograma?";
                    A.Respuestas = collection["pregunta_J"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguna vez un doctor te ha pedido que te hagas una prueba del corazon¿Ej:Electrocardiograma?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguna vez has tenido palpitaciones o latidos irregulares cuando haces ejercicios?";
                    A.Respuestas = collection["pregunta_J"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pregunta K
            if (!string.IsNullOrEmpty(collection["pregunta_K"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Te sientes mareado o te falta el aire mas de lo esperado cuando haces ejercicios?");
                if (A == null)
                {
                    Historial_Medico HM8 = new Historial_Medico();
                    HM8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM8.Preguntas = "¿Te sientes mareado o te falta el aire mas de lo esperado cuando haces ejercicios?";
                    HM8.Respuestas = collection["pregunta_K"];
                    HM8.Detalles = "";
                    db.Historial_Medico.Add(HM8);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Te sientes mareado o te falta el aire mas de lo esperado cuando haces ejercicios?";
                    A.Respuestas = collection["pregunta_K"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Te sientes mareado o te falta el aire mas de lo esperado cuando haces ejercicios?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Te sientes mareado o te falta el aire mas de lo esperado cuando haces ejercicios?";
                    A.Respuestas = collection["pregunta_K"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pregunta L
            if (!string.IsNullOrEmpty(collection["pregunta_L"]))
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has tenido una convulsion inexplicable?");
                if (A == null)
                {
                    Historial_Medico HM8 = new Historial_Medico();
                    HM8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HM8.Preguntas = "¿Has tenido una convulsion inexplicable?";
                    HM8.Respuestas = collection["pregunta_L"];
                    HM8.Detalles = "";
                    db.Historial_Medico.Add(HM8);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has tenido una convulsion inexplicable?";
                    A.Respuestas = collection["pregunta_L"];
                    A.Detalles = "";
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historial_Medico A = db.Historial_Medico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has tenido una convulsion inexplicable?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has tenido una convulsion inexplicable?";
                    A.Respuestas = collection["pregunta_L"];
                    db.Historial_Medico.Remove(A);
                    db.SaveChanges();
                }
            }
            //M
            if (!string.IsNullOrEmpty(collection["pregunta_fam_1"]))
            {
                Historia_Familiar A = db.Historia_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has tenido algun familiar que haya fallecido a causa de problemas de corazon, o bien que haya fallecido de forma inexplicable antes de los 50 años?");
                if (A == null)
                {
                    Historia_Familiar HF1 = new Historia_Familiar();
                    HF1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HF1.Preguntas = "¿Has tenido algun familiar que haya fallecido a causa de problemas de corazon, o bien que haya fallecido de forma inexplicable antes de los 50 años?";
                    HF1.Respuestas = collection["pregunta_fam_1"];
                    db.Historia_Familiar.Add(HF1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has tenido algun familiar que haya fallecido a causa de problemas de corazon, o bien que haya fallecido de forma inexplicable antes de los 50 años?";
                    A.Respuestas = collection["pregunta_fam_1"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historia_Familiar A = db.Historia_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has tenido algun familiar que haya fallecido a causa de problemas de corazon, o bien que haya fallecido de forma inexplicable antes de los 50 años?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has tenido algun familiar que haya fallecido a causa de problemas de corazon, o bien que haya fallecido de forma inexplicable antes de los 50 años?";
                    A.Respuestas = collection["pregunta_fam_1"];
                    db.Historia_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //N
            if (!string.IsNullOrEmpty(collection["pregunta_fam_2"]))
            {
                Historia_Familiar A = db.Historia_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguien de tu familia tiene problemas del corazon, un marcapaso o un desfibrilador en su corazon?");
                if (A == null)
                {
                    Historia_Familiar HF2 = new Historia_Familiar();
                    HF2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HF2.Preguntas = "¿Alguien de tu familia tiene problemas del corazon, un marcapaso o un desfibrilador en su corazon?";
                    HF2.Respuestas = collection["pregunta_fam_2"];
                    db.Historia_Familiar.Add(HF2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguien de tu familia tiene problemas del corazon, un marcapaso o un desfibrilador en su corazon?";
                    A.Respuestas = collection["pregunta_fam_2"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historia_Familiar A = db.Historia_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguien de tu familia tiene problemas del corazon, un marcapaso o un desfibrilador en su corazon?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguien de tu familia tiene problemas del corazon, un marcapaso o un desfibrilador en su corazon?";
                    A.Respuestas = collection["pregunta_fam_2"];
                    db.Historia_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Ñ
            if (!string.IsNullOrEmpty(collection["pregunta_fam_3"]))
            {
                Historia_Familiar A = db.Historia_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Ha sufrido algun familiar un desmayo inexplicable o convulsiones?");
                if (A == null)
                {
                    Historia_Familiar HF3 = new Historia_Familiar();
                    HF3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HF3.Preguntas = "¿Ha sufrido algun familiar un desmayo inexplicable o convulsiones?";
                    HF3.Respuestas = collection["pregunta_fam_3"];
                    db.Historia_Familiar.Add(HF3);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Ha sufrido algun familiar un desmayo inexplicable o convulsiones?";
                    A.Respuestas = collection["pregunta_fam_3"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historia_Familiar A = db.Historia_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Ha sufrido algun familiar un desmayo inexplicable o convulsiones?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Ha sufrido algun familiar un desmayo inexplicable o convulsiones?";
                    A.Respuestas = collection["pregunta_fam_3"];
                    db.Historia_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //O
            if (!string.IsNullOrEmpty(collection["pregunta_fam_4"]))
            {
                Historia_Familiar A = db.Historia_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguien de su familia padece de Diabetes?");
                if (A == null)
                {
                    Historia_Familiar HF4 = new Historia_Familiar();
                    HF4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HF4.Preguntas = "¿Alguien de su familia padece de Diabetes?";
                    HF4.Respuestas = collection["pregunta_fam_4"];
                    db.Historia_Familiar.Add(HF4);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguien de su familia padece de Diabetes?";
                    A.Respuestas = collection["pregunta_fam_4"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historia_Familiar A = db.Historia_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguien de su familia padece de Diabetes?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguien de su familia padece de Diabetes?";
                    A.Respuestas = collection["pregunta_fam_4"];
                    db.Historia_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //P
            if (!string.IsNullOrEmpty(collection["pregunta_fam_5"]))
            {
                Historia_Familiar A = db.Historia_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguien de su familia padece de asma?");
                if (A == null)
                {
                    Historia_Familiar HF5 = new Historia_Familiar();
                    HF5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    HF5.Preguntas = "¿Alguien de su familia padece de asma?";
                    HF5.Respuestas = collection["pregunta_fam_5"];
                    db.Historia_Familiar.Add(HF5);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguien de su familia padece de asma?";
                    A.Respuestas = collection["pregunta_fam_5"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Historia_Familiar A = db.Historia_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguien de su familia padece de asma?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguien de su familia padece de asma?";
                    A.Respuestas = collection["pregunta_fam_5"];
                    db.Historia_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Q
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_1"]))
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguna vez ha perdido un entrenamiento o evento por haber sufrido lesion en el hueso, tendon o musculo?");
                if (A == null)
                {
                    Aparato_Locomotor AL1 = new Aparato_Locomotor();
                    AL1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AL1.Preguntas = "¿Alguna vez ha perdido un entrenamiento o evento por haber sufrido lesion en el hueso, tendon o musculo?";
                    AL1.Respuestas = collection["pregunta_locomotor_1"];
                    db.Aparato_Locomotor.Add(AL1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguna vez ha perdido un entrenamiento o evento por haber sufrido lesion en el hueso, tendon o musculo?";
                    A.Respuestas = collection["pregunta_locomotor_1"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Alguna vez ha perdido un entrenamiento o evento por haber sufrido lesion en el hueso, tendon o musculo?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Alguna vez ha perdido un entrenamiento o evento por haber sufrido lesion en el hueso, tendon o musculo?";
                    A.Respuestas = collection["pregunta_locomotor_1"];
                    db.Aparato_Locomotor.Remove(A);
                    db.SaveChanges();
                }
            }
            //R
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_2"]))
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Te has fracturado alguna vez un hueso o dislocado una articulacion?");
                if (A == null)
                {
                    Aparato_Locomotor AL2 = new Aparato_Locomotor();
                    AL2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AL2.Preguntas = "¿Te has fracturado alguna vez un hueso o dislocado una articulacion?";
                    AL2.Respuestas = collection["pregunta_locomotor_2"];
                    db.Aparato_Locomotor.Add(AL2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Te has fracturado alguna vez un hueso o dislocado una articulacion?";
                    A.Respuestas = collection["pregunta_locomotor_2"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Te has fracturado alguna vez un hueso o dislocado una articulacion?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Te has fracturado alguna vez un hueso o dislocado una articulacion?";
                    A.Respuestas = collection["pregunta_locomotor_2"];
                    db.Aparato_Locomotor.Remove(A);
                    db.SaveChanges();
                }
            }
            //S
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_3"]))
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has sufrido alguna lesion que haya requerido radiografias,tomografias, o resonancia magnetica, soporte ortopedico,como yeso o tablilla?");
                if (A == null)
                {
                    Aparato_Locomotor AL3 = new Aparato_Locomotor();
                    AL3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AL3.Preguntas = "¿Has sufrido alguna lesion que haya requerido radiografias,tomografias, o resonancia magnetica, soporte ortopedico,como yeso o tablilla?";
                    AL3.Respuestas = collection["pregunta_locomotor_3"];
                    db.Aparato_Locomotor.Add(AL3);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has sufrido alguna lesion que haya requerido radiografias,tomografias, o resonancia magnetica, soporte ortopedico,como yeso o tablilla?";
                    A.Respuestas = collection["pregunta_locomotor_3"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has sufrido alguna lesion que haya requerido radiografias,tomografias, o resonancia magnetica, soporte ortopedico,como yeso o tablilla?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has sufrido alguna lesion que haya requerido radiografias,tomografias, o resonancia magnetica, soporte ortopedico,como yeso o tablilla?";
                    A.Respuestas = collection["pregunta_locomotor_3"];
                    db.Aparato_Locomotor.Remove(A);
                    db.SaveChanges();
                }
            }
            //T
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_4"]))
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Usas regularmente una tablilla/soporte ortopedico u otro dispositivo de asistencia?");
                if (A == null)
                {
                    Aparato_Locomotor AL4 = new Aparato_Locomotor();
                    AL4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AL4.Preguntas = "¿Usas regularmente una tablilla/soporte ortopedico u otro dispositivo de asistencia?";
                    AL4.Respuestas = collection["pregunta_locomotor_4"];
                    db.Aparato_Locomotor.Add(AL4);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Usas regularmente una tablilla/soporte ortopedico u otro dispositivo de asistencia?";
                    A.Respuestas = collection["pregunta_locomotor_4"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Usas regularmente una tablilla/soporte ortopedico u otro dispositivo de asistencia?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Usas regularmente una tablilla/soporte ortopedico u otro dispositivo de asistencia?";
                    A.Respuestas = collection["pregunta_locomotor_4"];
                    db.Aparato_Locomotor.Remove(A);
                    db.SaveChanges();
                }
            }
            //U
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_5"]))
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Tienes calambres frecuentes en los musculos cuando haces ejercicios?");
                if (A == null)
                {
                    Aparato_Locomotor AL5 = new Aparato_Locomotor();
                    AL5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AL5.Preguntas = "¿Tienes calambres frecuentes en los musculos cuando haces ejercicios?";
                    AL5.Respuestas = collection["pregunta_locomotor_5"];
                    db.Aparato_Locomotor.Add(AL5);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Tienes calambres frecuentes en los musculos cuando haces ejercicios?";
                    A.Respuestas = collection["pregunta_locomotor_5"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Tienes calambres frecuentes en los musculos cuando haces ejercicios?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Tienes calambres frecuentes en los musculos cuando haces ejercicios?";
                    A.Respuestas = collection["pregunta_locomotor_5"];
                    db.Aparato_Locomotor.Remove(A);
                    db.SaveChanges();
                }
            }
            //V
            if (!string.IsNullOrEmpty(collection["pregunta_locomotor_6"]))
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has tenido Hinchazon en alguna de tus articulaciones?");
                if (A == null)
                {
                    Aparato_Locomotor AL6 = new Aparato_Locomotor();
                    AL6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AL6.Preguntas = "¿Has tenido Hinchazon en alguna de tus articulaciones?";
                    AL6.Respuestas = collection["pregunta_locomotor_6"];
                    db.Aparato_Locomotor.Add(AL6);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has tenido Hinchazon en alguna de tus articulaciones?";
                    A.Respuestas = collection["pregunta_locomotor_6"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Has tenido Hinchazon en alguna de tus articulaciones?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Has tenido Hinchazon en alguna de tus articulaciones?";
                    A.Respuestas = collection["pregunta_locomotor_6"];
                    db.Aparato_Locomotor.Remove(A);
                    db.SaveChanges();
                }
            }
            //CIRUGIAS
            if (!string.IsNullOrEmpty(collection["cirugias"]))
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Cirugias(especifique que tipo de cirugias y cuando fue realizada)");
                if (A == null)
                {
                    Aparato_Locomotor AL7 = new Aparato_Locomotor();
                    AL7.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AL7.Preguntas = "Cirugias(especifique que tipo de cirugias y cuando fue realizada)";
                    AL7.Respuestas = collection["cirugias"];
                    db.Aparato_Locomotor.Add(AL7);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Cirugias(especifique que tipo de cirugias y cuando fue realizada)";
                    A.Respuestas = collection["cirugias"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Cirugias(especifique que tipo de cirugias y cuando fue realizada)");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Cirugias(especifique que tipo de cirugias y cuando fue realizada)";
                    A.Respuestas = collection["cirugias"];
                    db.Aparato_Locomotor.Remove(A);
                    db.SaveChanges();
                }
            }
            //HOSPITALIZACIONES
            if (!string.IsNullOrEmpty(collection["hospitalizaciones"]))
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Hospitalizaciones(Especifique si ha sido hospitalizado,las fechas y las causas)");
                if (A == null)
                {
                    Aparato_Locomotor AL8 = new Aparato_Locomotor();
                    AL8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AL8.Preguntas = "Hospitalizaciones(Especifique si ha sido hospitalizado,las fechas y las causas)";
                    AL8.Respuestas = collection["hospitalizaciones"];
                    db.Aparato_Locomotor.Add(AL8);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Hospitalizaciones(Especifique si ha sido hospitalizado,las fechas y las causas)";
                    A.Respuestas = collection["hospitalizaciones"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Aparato_Locomotor A = db.Aparato_Locomotor.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Hospitalizaciones(Especifique si ha sido hospitalizado,las fechas y las causas)");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Hospitalizaciones(Especifique si ha sido hospitalizado,las fechas y las causas)";
                    A.Respuestas = collection["hospitalizaciones"];
                    db.Aparato_Locomotor.Remove(A);
                    db.SaveChanges();
                }
            }
            //CARRERA DEPORTIVA
            //Cuanto Tiempo lleva Compitiendo
            if (!string.IsNullOrEmpty(collection["compitiendo"]))
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Cuanto Tiempo lleva Compitiendo");
                if (A == null)
                {
                    Carrera_Deportiva CD1 = new Carrera_Deportiva();
                    CD1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CD1.Preguntas = "Cuanto Tiempo lleva Compitiendo";
                    CD1.Respuestas = collection["compitiendo"];
                    CD1.Detalles = "";
                    db.Carrera_Deportiva.Add(CD1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Cuanto Tiempo lleva Compitiendo";
                    A.Respuestas = collection["compitiendo"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Cuanto Tiempo lleva Compitiendo");
                if (A == null)
                {

                }
            }
            //Antecedentes Deportivos. Carrera deportiva
            //Antecedentes Deportivos. Carrera deportiva Familiar
            //Entrenamientos
            if (!string.IsNullOrEmpty(collection["entrenamiento"]))
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Entreno(dias por semana)");
                if (A == null)
                {
                    Carrera_Deportiva CD2 = new Carrera_Deportiva();
                    CD2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CD2.Preguntas = "Entreno(dias por semana)";
                    CD2.Respuestas = collection["entrenamiento"];
                    CD2.Detalles = collection["sesiones"];
                    db.Carrera_Deportiva.Add(CD2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Entreno(dias por semana)";
                    A.Respuestas = collection["entrenamiento"];
                    A.Detalles = collection["sesiones"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Entreno(dias por semana)");
                if (A == null)
                {

                }
            }
            //Horas de entrenamiento por sesion
            if (!string.IsNullOrEmpty(collection["por_sesion"]))
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Horas de entrenamiento por sesion");
                if (A == null)
                {
                    Carrera_Deportiva CD3 = new Carrera_Deportiva();
                    CD3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CD3.Preguntas = "Horas de entrenamiento por sesion";
                    CD3.Respuestas = collection["por_sesion"];
                    CD3.Detalles = "";
                    db.Carrera_Deportiva.Add(CD3);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Horas de entrenamiento por sesion";
                    A.Respuestas = collection["por_sesion"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Horas de entrenamiento por sesion");
                if (A == null)
                {

                }
            }
            //Modalidad de entrenamiento
            if (!string.IsNullOrEmpty(collection["modalidad_entrenamiento"]))
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Modalidad de entrenamiento");
                if (A == null)
                {
                    Carrera_Deportiva CD4 = new Carrera_Deportiva();
                    CD4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CD4.Preguntas = "Modalidad de entrenamiento";
                    CD4.Respuestas = collection["modalidad_entrenamiento"];
                    CD4.Detalles = "";
                    db.Carrera_Deportiva.Add(CD4);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Modalidad de entrenamiento";
                    A.Respuestas = collection["modalidad_entrenamiento"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Modalidad de entrenamiento");
                if (A == null)
                {

                }
            }
            //Cuento con un plan de entrenamiento que:
            if (!string.IsNullOrEmpty(collection["plan"]))
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Cuento con un plan de entrenamiento que:");
                if (A == null)
                {
                    Carrera_Deportiva CD5 = new Carrera_Deportiva();
                    CD5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CD5.Preguntas = "Cuento con un plan de entrenamiento que:";
                    CD5.Respuestas = collection["plan"];
                    CD5.Detalles = "";
                    db.Carrera_Deportiva.Add(CD5);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Cuento con un plan de entrenamiento que:";
                    A.Respuestas = collection["plan"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Cuento con un plan de entrenamiento que:");
                if (A == null)
                {

                }
            }
            //Sus actividades se adaptan a sus horararios y sesiones de entrenamiento
            if (!string.IsNullOrEmpty(collection["acti"]))
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Sus actividades se adaptan a sus horararios y sesiones de entrenamiento");
                if (A == null)
                {
                    Carrera_Deportiva CD6 = new Carrera_Deportiva();
                    CD6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CD6.Preguntas = "Sus actividades se adaptan a sus horararios y sesiones de entrenamiento";
                    CD6.Respuestas = collection["acti"];
                    if (!string.IsNullOrEmpty(collection["medianamente"]) && collection["acti"] == "Medianamente")
                    {
                        var vocal = collection["medianamente"];
                        CD6.Detalles = Convert.ToString(vocal);
                    }
                    else if (!string.IsNullOrEmpty(collection["no_porque"]) && collection["acti"] == "No")
                    {
                        CD6.Detalles = collection["no_porque"];
                    }
                    else
                    {
                        CD6.Detalles = "";
                    }
                    db.Carrera_Deportiva.Add(CD6);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Sus actividades se adaptan a sus horararios y sesiones de entrenamiento";
                    A.Respuestas = collection["acti"];
                    if (!string.IsNullOrEmpty(collection["medianamente"]) && collection["acti"] == "Medianamente")
                    {
                        var vocal = collection["medianamente"];
                        A.Detalles = Convert.ToString(vocal);
                    }
                    else if (!string.IsNullOrEmpty(collection["no_porque"]) && collection["acti"] == "No")
                    {
                        A.Detalles = collection["no_porque"];
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Sus actividades se adaptan a sus horararios y sesiones de entrenamiento");
                if (A == null)
                {

                }
            }
            //Su sitio de entrenamiento es:            
            if (!string.IsNullOrEmpty(collection["sitio"]))
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Su sitio de entrenamiento es:");
                if (A == null)
                {
                    Carrera_Deportiva CD7 = new Carrera_Deportiva();
                    CD7.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CD7.Preguntas = "Su sitio de entrenamiento es:";
                    CD7.Respuestas = collection["sitio"];
                    if (!string.IsNullOrEmpty(collection["inad"]))
                    {
                        CD7.Detalles = collection["inadec"]; ;
                    }
                    else
                    {
                        CD7.Detalles = "";
                    }
                    db.Carrera_Deportiva.Add(CD7);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Su sitio de entrenamiento es:";
                    A.Respuestas = collection["sitio"];
                    if (!string.IsNullOrEmpty(collection["inad"]))
                    {
                        A.Detalles = collection["inadec"]; ;
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Carrera_Deportiva A = db.Carrera_Deportiva.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Su sitio de entrenamiento es:");
                if (A == null)
                {

                }
            }
            //INFORMACION LABORAL/ECONMICA
            //Trabaja Actualmente            
            if (!string.IsNullOrEmpty(collection["trabaja"]))
            {
                Situacion_Laboral A = db.Situacion_Laboral.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Trabaja Actualmente");
                if (A == null)
                {
                    Situacion_Laboral SL1 = new Situacion_Laboral();
                    SL1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    SL1.Preguntas = "Trabaja Actualmente";
                    SL1.Respuestas = collection["trabaja"];
                    db.Situacion_Laboral.Add(SL1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Trabaja Actualmente";
                    A.Respuestas = collection["trabaja"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Situacion_Laboral A = db.Situacion_Laboral.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Trabaja Actualmente");
                if (A == null)
                {

                }
            }
            //Tiene personas a cargo
            if (!string.IsNullOrEmpty(collection["personas"]))
            {
                Situacion_Laboral A = db.Situacion_Laboral.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Tiene personas a cargo");
                if (A == null)
                {
                    Situacion_Laboral SL2 = new Situacion_Laboral();
                    SL2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    SL2.Preguntas = "Tiene personas a cargo";
                    SL2.Respuestas = collection["personas"];
                    db.Situacion_Laboral.Add(SL2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Tiene personas a cargo";
                    A.Respuestas = collection["personas"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Situacion_Laboral A = db.Situacion_Laboral.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Tiene personas a cargo");
                if (A == null)
                {

                }
            }
            //Tabla Apoyo Economico
            //Las necesidades economicas del atleta para su practica deportiva son asumidas por:
            //Atleta
            if (!string.IsNullOrEmpty(collection["NEA"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Atleta");
                if (A == null)
                {
                    Apoyo_Economico AE1 = new Apoyo_Economico();
                    AE1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE1.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    AE1.Respuestas = collection["NEA"];
                    AE1.Detalles = "";
                    db.Apoyo_Economico.Add(AE1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEA"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Atleta");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEA"];
                    A.Detalles = "";
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Padre
            if (!string.IsNullOrEmpty(collection["NEP"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Padre");
                if (A == null)
                {
                    Apoyo_Economico AE2 = new Apoyo_Economico();
                    AE2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE2.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    AE2.Respuestas = collection["NEP"];
                    AE2.Detalles = "";
                    db.Apoyo_Economico.Add(AE2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEP"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Padre");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEP"];
                    A.Detalles = "";
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Madre            
            if (!string.IsNullOrEmpty(collection["NEM"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Madre");
                if (A == null)
                {
                    Apoyo_Economico AE3 = new Apoyo_Economico();
                    AE3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE3.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    AE3.Respuestas = collection["NEM"];
                    AE3.Detalles = "";
                    db.Apoyo_Economico.Add(AE3);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEM"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Madre");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEM"];
                    A.Detalles = "";
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Pareja
            if (!string.IsNullOrEmpty(collection["NEPA"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Pareja");
                if (A == null)
                {
                    Apoyo_Economico AE4 = new Apoyo_Economico();
                    AE4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE4.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    AE4.Respuestas = collection["NEPA"];
                    AE4.Detalles = "";
                    db.Apoyo_Economico.Add(AE4);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEPA"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Pareja");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEPA"];
                    A.Detalles = "";
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Otros Miembros de la Familia        
            if (!string.IsNullOrEmpty(collection["NEOMF"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Otros Familiares");
                if (A == null)
                {
                    Apoyo_Economico AE5 = new Apoyo_Economico();
                    AE5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE5.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    AE5.Respuestas = collection["NEOMF"];
                    AE5.Detalles = collection["txt_otrosmiembros"];
                    db.Apoyo_Economico.Add(AE5);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEOMF"];
                    A.Detalles = collection["txt_otrosmiembros"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Otros Familiares");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEOMF"];
                    A.Detalles = collection["txt_otrosmiembros"];
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Otros Miembros Cuales        
            if (!string.IsNullOrEmpty(collection["NEOMC"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Otros");
                if (A == null)
                {
                    Apoyo_Economico AE6 = new Apoyo_Economico();
                    AE6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE6.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    AE6.Respuestas = collection["NEOMC"];
                    AE6.Detalles = collection["txt_otrospersonas"];
                    db.Apoyo_Economico.Add(AE6);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEOMC"];
                    A.Detalles = collection["txt_otrospersonas"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Otros");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEOMC"];
                    A.Detalles = collection["txt_otrospersonas"];
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //No Recibe apoyo Monetario        
            if (!string.IsNullOrEmpty(collection["NENRAM"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "No recibe apoyo Monetario");
                if (A == null)
                {
                    Apoyo_Economico AE7 = new Apoyo_Economico();
                    AE7.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE7.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    AE7.Respuestas = collection["NENRAM"];
                    AE7.Detalles = "";
                    db.Apoyo_Economico.Add(AE7);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NENRAM"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "No recibe apoyo Monetario");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NENRAM"];
                    A.Detalles = "";
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Apoyo Monetario de Programa Deportivo        
            if (!string.IsNullOrEmpty(collection["NEAMPD"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Apoyo monetario de programa deportivo");
                if (A == null)
                {
                    Apoyo_Economico AE8 = new Apoyo_Economico();
                    AE8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE8.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    AE8.Respuestas = collection["NEAMPD"];
                    AE8.Detalles = "";
                    db.Apoyo_Economico.Add(AE8);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEAMPD"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Apoyo monetario de programa deportivo");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEAMPD"];
                    A.Detalles = "";
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Federacion        
            if (!string.IsNullOrEmpty(collection["NEF"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Federación");
                if (A == null)
                {
                    Apoyo_Economico AE9 = new Apoyo_Economico();
                    AE9.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE9.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    AE9.Respuestas = collection["NEF"];
                    AE9.Detalles = "";
                    db.Apoyo_Economico.Add(AE9);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEF"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Federación");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEF"];
                    A.Detalles = "";
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Otros Apoyos        
            if (!string.IsNullOrEmpty(collection["NEOA"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Otros apoyos");
                if (A == null)
                {
                    Apoyo_Economico AE10 = new Apoyo_Economico();
                    AE10.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE10.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    AE10.Respuestas = collection["NEOA"];
                    AE10.Detalles = collection["txt_otrosapoyos1"];
                    db.Apoyo_Economico.Add(AE10);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEOA"];
                    A.Detalles = collection["txt_otrosapoyos1"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Las necesidades economicas del atleta para su practica deportiva son asumidas por:" && s.Respuestas == "Otros apoyos");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                    A.Respuestas = collection["NEOA"];
                    A.Detalles = collection["txt_otrosapoyos1"];
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Tabla Consiste apoyo
            //En que consiste el apoyo que recibe:
            //Monetario
            if (!string.IsNullOrEmpty(collection["CAM"]))
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Monetario");
                if (A == null)
                {
                    Consiste_Apoyo CA1 = new Consiste_Apoyo();
                    CA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CA1.Preguntas = "En que consiste el apoyo que recibe:";
                    CA1.Respuestas = collection["CAM"];
                    db.Consiste_Apoyo.Add(CA1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAM"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Monetario");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAM"];
                    db.Consiste_Apoyo.Remove(A);
                    db.SaveChanges();
                }
            }
            //Equipo Ciencias del Deporte
            if (!string.IsNullOrEmpty(collection["CAECD"]))
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Equipo ciencias del deporte");
                if (A == null)
                {
                    Consiste_Apoyo CA2 = new Consiste_Apoyo();
                    CA2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CA2.Preguntas = "En que consiste el apoyo que recibe:";
                    CA2.Respuestas = collection["CAECD"];
                    db.Consiste_Apoyo.Add(CA2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAECD"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Equipo ciencias del deporte");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAECD"];
                    db.Consiste_Apoyo.Remove(A);
                    db.SaveChanges();
                }
            }
            //Educativo
            if (!string.IsNullOrEmpty(collection["CAE"]))
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Educativo");
                if (A == null)
                {
                    Consiste_Apoyo CA3 = new Consiste_Apoyo();
                    CA3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CA3.Preguntas = "En que consiste el apoyo que recibe:";
                    CA3.Respuestas = collection["CAE"];
                    db.Consiste_Apoyo.Add(CA3);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAE"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Educativo");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAE"];
                    db.Consiste_Apoyo.Remove(A);
                    db.SaveChanges();
                }
            }
            //Alojamiento
            if (!string.IsNullOrEmpty(collection["CAA"]))
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Alojamiento");
                if (A == null)
                {
                    Consiste_Apoyo CA4 = new Consiste_Apoyo();
                    CA4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CA4.Preguntas = "En que consiste el apoyo que recibe:";
                    CA4.Respuestas = collection["CAA"];
                    db.Consiste_Apoyo.Add(CA4);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAA"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Alojamiento");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAA"];
                    db.Consiste_Apoyo.Remove(A);
                    db.SaveChanges();
                }
            }
            //Transporte
            if (!string.IsNullOrEmpty(collection["CAT"]))
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Transporte");
                if (A == null)
                {
                    Consiste_Apoyo CA5 = new Consiste_Apoyo();
                    CA5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CA5.Preguntas = "En que consiste el apoyo que recibe:";
                    CA5.Respuestas = collection["CAT"];
                    db.Consiste_Apoyo.Add(CA5);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAT"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Transporte");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAT"];
                    db.Consiste_Apoyo.Remove(A);
                    db.SaveChanges();
                }
            }
            //Alimentacion
            if (!string.IsNullOrEmpty(collection["CAAL"]))
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Alimentacion");
                if (A == null)
                {
                    Consiste_Apoyo CA6 = new Consiste_Apoyo();
                    CA6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    CA6.Preguntas = "En que consiste el apoyo que recibe:";
                    CA6.Respuestas = collection["CAAL"];
                    db.Consiste_Apoyo.Add(CA6);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAAL"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Consiste_Apoyo A = db.Consiste_Apoyo.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que consiste el apoyo que recibe:" && s.Respuestas == "Alimentacion");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que consiste el apoyo que recibe:";
                    A.Respuestas = collection["CAAL"];
                    db.Consiste_Apoyo.Remove(A);
                    db.SaveChanges();
                }
            }
            //En que invierte su apoyo monetario
            //Practica Deportiva
            if (!string.IsNullOrEmpty(collection["IAMPD"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que invierte su apoyo monetario" && s.Respuestas == "Practica deportiva");
                if (A == null)
                {
                    Apoyo_Economico AE17 = new Apoyo_Economico();
                    AE17.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE17.Preguntas = "En que invierte su apoyo monetario";
                    AE17.Respuestas = collection["IAMPD"];
                    AE17.Detalles = "";
                    db.Apoyo_Economico.Add(AE17);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que invierte su apoyo monetario";
                    A.Respuestas = collection["IAMPD"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que invierte su apoyo monetario" && s.Respuestas == "Practica deportiva");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que invierte su apoyo monetario";
                    A.Respuestas = collection["IAMPD"];
                    A.Detalles = "";
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Economia Familiar
            if (!string.IsNullOrEmpty(collection["IAMEF"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que invierte su apoyo monetario" && s.Respuestas == "Economia Familiar");
                if (A == null)
                {
                    Apoyo_Economico AE18 = new Apoyo_Economico();
                    AE18.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE18.Preguntas = "En que invierte su apoyo monetario";
                    AE18.Respuestas = collection["IAMEF"];
                    AE18.Detalles = "";
                    db.Apoyo_Economico.Add(AE18);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que invierte su apoyo monetario";
                    A.Respuestas = collection["IAMEF"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que invierte su apoyo monetario" && s.Respuestas == "Economia Familiar");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que invierte su apoyo monetario";
                    A.Respuestas = collection["IAMEF"];
                    A.Detalles = "";
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //Educacion
            if (!string.IsNullOrEmpty(collection["IAME"]))
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que invierte su apoyo monetario" && s.Respuestas == "Educacion");
                if (A == null)
                {
                    Apoyo_Economico AE19 = new Apoyo_Economico();
                    AE19.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    AE19.Preguntas = "En que invierte su apoyo monetario";
                    AE19.Respuestas = collection["IAME"];
                    AE19.Detalles = "";
                    db.Apoyo_Economico.Add(AE19);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que invierte su apoyo monetario";
                    A.Respuestas = collection["IAME"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Apoyo_Economico A = db.Apoyo_Economico.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "En que invierte su apoyo monetario" && s.Respuestas == "Educacion");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "En que invierte su apoyo monetario";
                    A.Respuestas = collection["IAME"];
                    A.Detalles = "";
                    db.Apoyo_Economico.Remove(A);
                    db.SaveChanges();
                }
            }
            //INFORMACION EXTRA
            //Informacion Familiar
            //Tabla Informacion Familiar
            //Con quien vive
            //Soltero
            if (!string.IsNullOrEmpty(collection["CQVS"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Soltero(a)");
                if (A == null)
                {
                    Informacion_Familiar IF1 = new Informacion_Familiar();
                    IF1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF1.Preguntas = "Con quien vive";
                    IF1.Respuestas = collection["CQVS"];
                    IF1.Detalles = "";
                    db.Informacion_Familiar.Add(IF1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVS"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Soltero(a)");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVS"];
                    A.Detalles = "";
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Acompañado
            if (!string.IsNullOrEmpty(collection["CQVA"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Acompañado");
                if (A == null)
                {
                    Informacion_Familiar IF2 = new Informacion_Familiar();
                    IF2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF2.Preguntas = "Con quien vive";
                    IF2.Respuestas = collection["CQVA"];
                    IF2.Detalles = "";
                    db.Informacion_Familiar.Add(IF2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVA"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Acompañado");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVA"];
                    A.Detalles = "";
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Padre
            if (!string.IsNullOrEmpty(collection["CQVPA"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Padre");
                if (A == null)
                {
                    Informacion_Familiar IF3 = new Informacion_Familiar();
                    IF3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF3.Preguntas = "Con quien vive";
                    IF3.Respuestas = collection["CQVPA"];
                    IF3.Detalles = "";
                    db.Informacion_Familiar.Add(IF3);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVPA"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Padre");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVPA"];
                    A.Detalles = "";
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Madre
            if (!string.IsNullOrEmpty(collection["CQVMA"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Madre");
                if (A == null)
                {
                    Informacion_Familiar IF4 = new Informacion_Familiar();
                    IF4.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF4.Preguntas = "Con quien vive";
                    IF4.Respuestas = collection["CQVMA"];
                    IF4.Detalles = "";
                    db.Informacion_Familiar.Add(IF4);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVMA"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Madre");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVMA"];
                    A.Detalles = "";
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Hermanos
            if (!string.IsNullOrEmpty(collection["CQVHE"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Hermanos");
                if (A == null)
                {
                    Informacion_Familiar IF5 = new Informacion_Familiar();
                    IF5.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF5.Preguntas = "Con quien vive";
                    IF5.Respuestas = collection["CQVHE"];
                    if (!string.IsNullOrEmpty(collection["txt_Chermanos"]))
                    {
                        IF5.Detalles = collection["txt_Chermanos"];
                    }
                    else
                    {
                        IF5.Detalles = "";
                    }
                    db.Informacion_Familiar.Add(IF5);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVHE"];
                    if (!string.IsNullOrEmpty(collection["txt_Chermanos"]))
                    {
                        A.Detalles = collection["txt_Chermanos"];
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Hermanos");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVHE"];
                    A.Detalles = collection["txt_Chermanos"];
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Hijos
            if (!string.IsNullOrEmpty(collection["CQVHI"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Hijos");
                if (A == null)
                {
                    Informacion_Familiar IF6 = new Informacion_Familiar();
                    IF6.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF6.Preguntas = "Con quien vive";
                    IF6.Respuestas = collection["CQVHI"];
                    if (!string.IsNullOrEmpty(collection["txt_cHijos"]))
                    {
                        IF6.Detalles = collection["txt_cHijos"];
                    }
                    else
                    {
                        IF6.Detalles = "";
                    }
                    db.Informacion_Familiar.Add(IF6);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVHI"];
                    if (!string.IsNullOrEmpty(collection["txt_cHijos"]))
                    {
                        A.Detalles = collection["txt_cHijos"];
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Hijos");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVHI"];
                    A.Detalles = collection["txt_cHijos"];
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Otros Familiares
            if (!string.IsNullOrEmpty(collection["CQVOF"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Otros Familiares");
                if (A == null)
                {
                    Informacion_Familiar IF7 = new Informacion_Familiar();
                    IF7.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF7.Preguntas = "Con quien vive";
                    IF7.Respuestas = collection["CQVOF"];
                    if (!string.IsNullOrEmpty(collection["txt_Qfamiliar"]))
                    {
                        IF7.Detalles = collection["txt_Qfamiliar"];
                    }
                    else
                    {
                        IF7.Detalles = "";
                    }
                    db.Informacion_Familiar.Add(IF7);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVOF"];
                    if (!string.IsNullOrEmpty(collection["txt_Qfamiliar"]))
                    {
                        A.Detalles = collection["txt_Qfamiliar"];
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Otros Familiares");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVOF"];
                    A.Detalles = collection["txt_Qfamiliar"];
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Otro
            if (!string.IsNullOrEmpty(collection["CQVO"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Otros");
                if (A == null)
                {
                    Informacion_Familiar IF8 = new Informacion_Familiar();
                    IF8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF8.Preguntas = "Con quien vive";
                    IF8.Respuestas = collection["CQVO"];
                    if (!string.IsNullOrEmpty(collection["txt_Qotros"]))
                    {
                        IF8.Detalles = collection["txt_Qotros"];
                    }
                    else
                    {
                        IF8.Detalles = "";
                    }
                    db.Informacion_Familiar.Add(IF8);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVO"];
                    if (!string.IsNullOrEmpty(collection["txt_Qotros"]))
                    {
                        A.Detalles = collection["txt_Qotros"];
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Otros");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVO"];
                    A.Detalles = collection["txt_Qotros"];
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Alojamiento Deportivo
            if (!string.IsNullOrEmpty(collection["CQVAD"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Alojamiento Deportivo");
                if (A == null)
                {
                    Informacion_Familiar IF9 = new Informacion_Familiar();
                    IF9.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF9.Preguntas = "Con quien vive";
                    IF9.Respuestas = collection["CQVAD"];
                    IF9.Detalles = "";
                    db.Informacion_Familiar.Add(IF9);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVAD"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Con quien vive" && s.Respuestas == "Alojamiento Deportivo");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Con quien vive";
                    A.Respuestas = collection["CQVAD"];
                    A.Detalles = ""
;
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //¿Tiene Hijos?
            if (!string.IsNullOrEmpty(collection["btnhijos"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Tiene Hijos?");
                if (A == null)
                {
                    Informacion_Familiar IF10 = new Informacion_Familiar();
                    IF10.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF10.Preguntas = "¿Tiene Hijos?";
                    IF10.Respuestas = collection["btnhijos"];
                    IF10.Detalles = "";
                    db.Informacion_Familiar.Add(IF10);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Tiene Hijos?";
                    A.Respuestas = collection["btnhijos"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Tiene Hijos?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Tiene Hijos?";
                    A.Respuestas = collection["btnhijos"];
                    A.Detalles = ""
;
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //¿Proyecta Tener Hijos?
            if (!string.IsNullOrEmpty(collection["pmhijos"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Proyecta Tener Hijos?");
                if (A == null)
                {
                    Informacion_Familiar IF11 = new Informacion_Familiar();
                    IF11.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF11.Preguntas = "¿Proyecta Tener Hijos?";
                    IF11.Respuestas = collection["pmhijos"];
                    IF11.Detalles = "";
                    db.Informacion_Familiar.Add(IF11);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Proyecta Tener Hijos?";
                    A.Respuestas = collection["pmhijos"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Proyecta Tener Hijos?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Proyecta Tener Hijos?";
                    A.Respuestas = collection["pmhijos"];
                    A.Detalles = "";
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //Números de personas con las que Vive
            if (!string.IsNullOrEmpty(collection["numvive"]))
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Números de personas con las que Vive");
                if (A == null)
                {
                    Informacion_Familiar IF12 = new Informacion_Familiar();
                    IF12.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    IF12.Preguntas = "Números de personas con las que Vive";
                    IF12.Respuestas = collection["numvive"];
                    if (!string.IsNullOrEmpty(collection["txt_menosde4"]))
                    {
                        IF12.Detalles = collection["txt_menosde4"];
                    }
                    else
                    {
                        IF12.Detalles = "";
                    }
                    db.Informacion_Familiar.Add(IF12);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Números de personas con las que Vive";
                    A.Respuestas = collection["numvive"];
                    if (!string.IsNullOrEmpty(collection["txt_menosde4"]))
                    {
                        A.Detalles = collection["txt_menosde4"];
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Informacion_Familiar A = db.Informacion_Familiar.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Números de personas con las que Vive");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Números de personas con las que Vive";
                    A.Respuestas = collection["numvive"];
                    A.Detalles = collection["txt_menosde4"];
                    db.Informacion_Familiar.Remove(A);
                    db.SaveChanges();
                }
            }
            //EDUCACION Y FORMACION
            //Situacion Academica
            if (!string.IsNullOrEmpty(collection["Est"]))
            {
                Educacion A = db.Educacion.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Estudia Actualmente");
                if (A == null)
                {
                    Educacion E1 = new Educacion();
                    E1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    E1.Preguntas = "Estudia Actualmente";
                    E1.Respuestas = collection["Est"];
                    E1.Detalles = "";
                    db.Educacion.Add(E1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Estudia Actualmente";
                    A.Respuestas = collection["Est"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Educacion A = db.Educacion.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Estudia Actualmente");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Estudia Actualmente";
                    A.Respuestas = collection["Est"];
                    A.Detalles = "";
                    db.Educacion.Remove(A);
                    db.SaveChanges();
                }
            }
            //Ultimo nivel academico terminado
            if (!string.IsNullOrEmpty(collection["nivelaca"]))
            {
                Educacion A = db.Educacion.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Ultimo nivel academico terminado");
                if (A == null)
                {
                    Educacion E2 = new Educacion();
                    E2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    E2.Preguntas = "Ultimo nivel academico terminado";
                    E2.Respuestas = collection["nivelaca"];
                    if (!string.IsNullOrEmpty(collection["especializacion_maestria"]))
                    {
                        E2.Detalles = collection["especializacion_maestria"];
                    }
                    else
                    {
                        E2.Detalles = "";
                    }
                    db.Educacion.Add(E2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Ultimo nivel academico terminado";
                    A.Respuestas = collection["nivelaca"];
                    if (!string.IsNullOrEmpty(collection["especializacion_maestria"]))
                    {
                        A.Detalles = collection["especializacion_maestria"];
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Educacion A = db.Educacion.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Ultimo nivel academico terminado");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Ultimo nivel academico terminado";
                    A.Respuestas = collection["Est"];
                    A.Detalles = collection["especializacion_maestria"];
                    db.Educacion.Remove(A);
                    db.SaveChanges();
                }
            }
            // Donde Estudia
            if (!string.IsNullOrEmpty(collection["txt_donde_Estudia"]))
            {
                Educacion A = db.Educacion.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Donde Estudia?");
                if (A == null)
                {
                    Educacion E3 = new Educacion();
                    E3.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    E3.Preguntas = "¿Donde Estudia?";
                    E3.Respuestas = collection["txt_donde_Estudia"];
                    E3.Detalles = "";
                    db.Educacion.Add(E3);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Donde Estudia?";
                    A.Respuestas = collection["txt_donde_Estudia"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Educacion A = db.Educacion.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Donde Estudia?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Donde Estudia?";
                    A.Respuestas = collection["txt_donde_Estudia"];
                    A.Detalles = "";
                    db.Educacion.Remove(A);
                    db.SaveChanges();
                }
            }
            //Lugar de Habitacion
            if (!string.IsNullOrEmpty(collection["barrio"]))
            {
                Habitacion A = db.Habitacion.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Cómo calificaría su barrio");
                if (A == null)
                {
                    Habitacion habitacion1 = new Habitacion();
                    habitacion1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    habitacion1.Preguntas = "Cómo calificaría su barrio";
                    habitacion1.Respuestas = collection["barrio"];
                    if (!string.IsNullOrEmpty(collection["txtotrosbarrios"]))
                    {
                        habitacion1.Detalles = collection["txtotrosbarrios"];
                    }
                    else
                    {
                        habitacion1.Detalles = "";
                    }
                    db.Habitacion.Add(habitacion1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Cómo calificaría su barrio";
                    A.Respuestas = collection["barrio"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Habitacion A = db.Habitacion.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Cómo calificaría su barrio");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Cómo calificaría su barrio";
                    A.Respuestas = collection["barrio"];
                    A.Detalles = collection["txtotrosbarrios"];
                    db.Habitacion.Remove(A);
                    db.SaveChanges();
                }
            }
            //Como describiria el estado de la vivienda en que reside actualmente
            if (!string.IsNullOrEmpty(collection["vivienda"]))
            {
                Habitacion A = db.Habitacion.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Como describiria el estado de la vivienda en que reside actualmente");
                if (A == null)
                {
                    Habitacion habitacion2 = new Habitacion();
                    habitacion2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    habitacion2.Preguntas = "Como describiria el estado de la vivienda en que reside actualmente";
                    habitacion2.Respuestas = collection["vivienda"];
                    habitacion2.Detalles = "";
                    db.Habitacion.Add(habitacion2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Como describiria el estado de la vivienda en que reside actualmente";
                    A.Respuestas = collection["vivienda"];
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Habitacion A = db.Habitacion.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "Como describiria el estado de la vivienda en que reside actualmente");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "Como describiria el estado de la vivienda en que reside actualmente";
                    A.Respuestas = collection["vivienda"];
                    A.Detalles = "";
                    db.Habitacion.Remove(A);
                    db.SaveChanges();
                }
            }
            //Habitos
            //¿Usted Fuma?
            if (!string.IsNullOrEmpty(collection["fuma"]))
            {
                Habitos A = db.Habitos.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Usted Fuma?");
                if (A == null)
                {
                    Habitos habitos1 = new Habitos();
                    habitos1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    habitos1.Preguntas = "¿Usted Fuma?";
                    habitos1.Respuestas = collection["fuma"];
                    if (!string.IsNullOrEmpty(collection["si_fuma"]))
                    {
                        habitos1.Detalles = collection["si_fuma"];
                    }
                    else
                    {
                        habitos1.Detalles = "";
                    }
                    db.Habitos.Add(habitos1);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Usted Fuma?";
                    A.Respuestas = collection["fuma"];
                    if (!string.IsNullOrEmpty(collection["si_fuma"]))
                    {
                        A.Detalles = collection["si_fuma"];
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Habitos A = db.Habitos.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Usted Fuma?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Usted Fuma?";
                    A.Respuestas = collection["fuma"];
                    A.Detalles = collection["si_fuma"];
                    db.Habitos.Remove(A);
                    db.SaveChanges();
                }
            }
            //¿Usted toma?
            if (!string.IsNullOrEmpty(collection["toma"]))
            {
                Habitos A = db.Habitos.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Usted Toma?");
                if (A == null)
                {
                    Habitos habitos2 = new Habitos();
                    habitos2.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    habitos2.Preguntas = "¿Usted Toma?";
                    habitos2.Respuestas = collection["toma"];
                    if (!string.IsNullOrEmpty(collection["cerveza"]))
                    {
                        habitos2.Detalles = collection["cerveza"];
                    }
                    else
                    if (!string.IsNullOrEmpty(collection["licor"]))
                    {
                        habitos2.Detalles = collection["licor"];
                    }
                    else
                    if (!string.IsNullOrEmpty(collection["cerveza"]) && !string.IsNullOrEmpty(collection["licor"]))
                    {
                        habitos2.Detalles = collection["cerveza"] + "," + collection["licor"];
                    }
                    else
                    {
                        habitos2.Detalles = "";
                    }
                    db.Habitos.Add(habitos2);
                    db.SaveChanges();
                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Usted Toma?";
                    A.Respuestas = collection["toma"];
                    if (!string.IsNullOrEmpty(collection["cerveza"]))
                    {
                        A.Detalles = collection["cerveza"];
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    if (!string.IsNullOrEmpty(collection["licor"]))
                    {
                        A.Detalles = collection["licor"];
                    }
                    else
                    {
                        A.Detalles = "";
                    }
                    db.Entry(A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                Habitos A = db.Habitos.FirstOrDefault(s => s.ID_Atleta == ID && s.Preguntas == "¿Usted Toma?");
                if (A == null)
                {

                }
                else
                {
                    A.ID_Atleta = ID;
                    A.Preguntas = "¿Usted Toma?";
                    A.Respuestas = collection["toma"];
                    A.Detalles = "";
                    db.Habitos.Remove(A);
                    db.SaveChanges();
                }
            }
            return Redirect("~/HomeAdmin");
        }
    }
}