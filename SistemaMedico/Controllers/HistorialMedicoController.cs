using SistemaMedico.Models;
using SistemaMedico.Models.ViewModel;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [HttpPost]
        public ActionResult Crear(FormCollection collection)
        {
            //MEDICAMENTOS
            //Relajantes Musculares
            if (!string.IsNullOrEmpty(collection["btnrelajantes"]))
            {
                Medicamentos Medica1 = new Medicamentos();
                Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                Medica1.Medicamentos1 = "Relajante Muscular";
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
                Medica4.Medicamentos1 = "Otros";
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
                HM5.Preguntas = "¿Naciste o te falta un riñon,un ojo,untesticulo u algun otro órgano?";
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
                HM7.Preguntas = "¿¿Has tenido alguna vez molestias dolor o presion en el pecho cuando haces ejercicios?";
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
                CD1.Detalles = "";
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
                    if (pruebafam[i].ToString() != "," || fylfam[i].ToString() != "," || resulfam[i].ToString() != "," )
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
                if (!string.IsNullOrEmpty(collection["mediporque"]))
                {
                    CD6.Detalles = collection["mediporque"];
                }
                else
                {
                    CD6.Detalles = "";
                }
                if (!string.IsNullOrEmpty(collection["no_porque"]))
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
                    CD7.Detalles = collection["inad"] + " " + collection["inadec"]; ;
                    //Carrera_Deportiva CD8 = new Carrera_Deportiva();
                    //CD8.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    //CD8.Preguntas = "Su sitio de entrenamiento es:";
                    //CD8.Respuestas = collection["inad"];
                    //CD8.Detalles = collection["inadec"];
                    //db.Carrera_Deportiva.Add(CD8);
                    //db.SaveChanges();
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
                Apoyo_Economico AE11 = new Apoyo_Economico();
                AE11.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE11.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE11.Respuestas = collection["CAM"];
                AE11.Detalles = "";
                db.Apoyo_Economico.Add(AE11);
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
                Apoyo_Economico AE12 = new Apoyo_Economico();
                AE12.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE12.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE12.Respuestas = collection["CAECD"];
                AE12.Detalles = "";
                db.Apoyo_Economico.Add(AE12);
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
                Apoyo_Economico AE13 = new Apoyo_Economico();
                AE13.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE13.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE13.Respuestas = collection["CAE"];
                AE13.Detalles = "";
                db.Apoyo_Economico.Add(AE13);
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
                Apoyo_Economico AE14 = new Apoyo_Economico();
                AE14.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE14.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE14.Respuestas = collection["CAA"];
                AE14.Detalles = "";
                db.Apoyo_Economico.Add(AE14);
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
                Apoyo_Economico AE15 = new Apoyo_Economico();
                AE15.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE15.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE15.Respuestas = collection["CAT"];
                AE15.Detalles = "";
                db.Apoyo_Economico.Add(AE15);
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
                Apoyo_Economico AE16 = new Apoyo_Economico();
                AE16.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                AE16.Preguntas = "Las necesidades economicas del atleta para su practica deportiva son asumidas por:";
                AE16.Respuestas = collection["CAAL"];
                AE16.Detalles = "";
                db.Apoyo_Economico.Add(AE16);
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
        public ActionResult Actualizar()
        {
            return View();
        }
    }
}