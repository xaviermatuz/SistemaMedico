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
            //tab1
            //pregunta 1
            Examen_Fisico_Principal Examen1 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            Examen1.ID_Examen_Fisico = 1;
            Examen1.Estado = true;
            Examen1.Fecha_de_Registro = DateTime.Today;
            if (!string.IsNullOrEmpty(collection["Si_Cuello"]))
            {
                Examen1.Normal = "Si";
                Examen1.Hallazgos_Anormales = "";
            }
            else
            {
                Examen1.Normal = "No";
                Examen1.Hallazgos_Anormales = collection["HA_Cuello"];
            }

            db.Examen_Fisico_Principal.Add(Examen1);
            db.SaveChanges();
            //pregunta 2
            //Examen_Fisico_Principal Examen2 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            Examen1.ID_Examen_Fisico = 2;
            if (!string.IsNullOrEmpty(collection["Si_Espalda"]))
            {
                Examen1.Normal = "Si";
                Examen1.Hallazgos_Anormales = "";
            }
            else
            {
                Examen1.Normal = "No";
                Examen1.Hallazgos_Anormales = collection["HA_Espalda"];
            }

            db.Examen_Fisico_Principal.Add(Examen1);
            db.SaveChanges();
            //pregunta 3
            //Examen_Fisico_Principal Examen3 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            Examen1.ID_Examen_Fisico = 3;
            if (!string.IsNullOrEmpty(collection["Si_Hombro"]))
            {
                Examen1.Normal = "Si";
                Examen1.Hallazgos_Anormales = "";
            }
            else
            {
                Examen1.Normal = "No";
                Examen1.Hallazgos_Anormales = collection["HA_hombro"];
            }

            db.Examen_Fisico_Principal.Add(Examen1);
            db.SaveChanges();
            //pregunta 4
            //Examen_Fisico_Principal Examen4 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            Examen1.ID_Examen_Fisico = 4;
            if (!string.IsNullOrEmpty(collection["Si_Codo"]))
            {
                Examen1.Normal = "Si";
                Examen1.Hallazgos_Anormales = "";
            }
            else
            {
                Examen1.Normal = "No";
                Examen1.Hallazgos_Anormales = collection["HA_codo"];
            }

            db.Examen_Fisico_Principal.Add(Examen1);
            db.SaveChanges();
            //pregunta 5
            //Examen_Fisico_Principal Examen5 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            Examen1.ID_Examen_Fisico = 5;
            if (!string.IsNullOrEmpty(collection["Si_Muñeca"]))
            {
                Examen1.Normal = "Si";
                Examen1.Hallazgos_Anormales = "";
            }
            else
            {
                Examen1.Normal = "No";
                Examen1.Hallazgos_Anormales = collection["HA_muñeca"];
            }
            db.Examen_Fisico_Principal.Add(Examen1);
            db.SaveChanges();
            //pregunta 6
            //Examen_Fisico_Principal Examen6 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            Examen1.ID_Examen_Fisico = 6;
            if (!string.IsNullOrEmpty(collection["Si_Cadera"]))
            {
                Examen1.Normal = "Si";
                Examen1.Hallazgos_Anormales = "";
            }
            else
            {
                Examen1.Normal = "No";
                Examen1.Hallazgos_Anormales = collection["HA_cadera"];
            }
            db.Examen_Fisico_Principal.Add(Examen1);
            db.SaveChanges();
            //pregunta 7
            //Examen_Fisico_Principal Examen7 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            Examen1.ID_Examen_Fisico = 7;
            if (!string.IsNullOrEmpty(collection["Si_Rodilla"]))
            {
                Examen1.Normal = "Si";
                Examen1.Hallazgos_Anormales = "";
            }
            else
            {
                Examen1.Normal = "No";
                Examen1.Hallazgos_Anormales = collection["HA_rodilla"];
            }
            db.Examen_Fisico_Principal.Add(Examen1);
            db.SaveChanges();
            //pregunta 8
            //Examen_Fisico_Principal Examen8 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            Examen1.ID_Examen_Fisico = 8;
            if (!string.IsNullOrEmpty(collection["Si_Pierna"]))
            {
                Examen1.Normal = "Si";
                Examen1.Hallazgos_Anormales = "";
            }
            else
            {
                Examen1.Normal = "No";
                Examen1.Hallazgos_Anormales = collection["HA_pierna"];
            }
            db.Examen_Fisico_Principal.Add(Examen1);
            db.SaveChanges();
            //pregunta 9
            //Examen_Fisico_Principal Examen9 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            Examen1.ID_Examen_Fisico = 9;
            if (!string.IsNullOrEmpty(collection["Si_dedos"]))
            {
                Examen1.Normal = "Si";
                Examen1.Hallazgos_Anormales = "";
            }
            else
            {
                Examen1.Normal = "No";
                Examen1.Hallazgos_Anormales = collection["HA_dedos"];
            }
            db.Examen_Fisico_Principal.Add(Examen1);
            db.SaveChanges();
            //otros Hallazgos
            if (collection["otroshallazgos"] != "" || collection["Recomendaciones"] != "")
            {
                Anexos anex1 = new Anexos();
                anex1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                anex1.Fecha_de_Registro = DateTime.Now;
                anex1.Estado = true;
                if (collection["otroshallazgos"] != "")
                {
                    anex1.Otros_Hallazgos = collection["otroshallazgos"];

                }
                else
                {
                    anex1.Otros_Hallazgos = "";
                }
                if (collection["Recomendaciones"] != "")
                {
                    anex1.Recomendaciones = collection["Recomendaciones"];
                }
                else
                {
                    anex1.Recomendaciones = "";
                }
                anex1.Observaciones = "";
                db.Anexos.Add(anex1);
                db.SaveChanges();
            }
            //cindiciones clinicas actuales 
            //Practicas Deportivas
            Condiciones_Clinicas_Actuales_Principal CCA1 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.Estado = true;
            CCA1.Fecha_de_Registro = DateTime.Now;
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["PD"]))
            {
                CCA1.Nombre = "Practica Deportiva";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Economia Familiar
            //Condiciones_Clinicas_Actuales_Principal CCA2 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["EF"]))
            {
                CCA1.Nombre = "Economia Familiar";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Educacion
            //Condiciones_Clinicas_Actuales_Principal CCA3 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["educa"]))
            {
                CCA1.Nombre = "Educación";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Dolor Articular 
            //Condiciones_Clinicas_Actuales_Principal CCA4 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["Da"]))
            {
                CCA1.Nombre = "Dolor Articular";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Rigidez en articulaciones
            //Condiciones_Clinicas_Actuales_Principal CCA5 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["Ra"]))
            {
                CCA1.Nombre = "Rigidez en Articulaciones";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Fracturas
            //Condiciones_Clinicas_Actuales_Principal CCA6 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["Fracturas"]))
            {
                CCA1.Nombre = "Fracturas";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Debilidad Muscular
            //Condiciones_Clinicas_Actuales_Principal CCA7 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["DM"]))
            {
                CCA1.Nombre = "Debilidad Muscular";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Hinchazon articular
            //Condiciones_Clinicas_Actuales_Principal CCA8 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["HA"]))
            {
                CCA1.Nombre = "Hinchazon articular";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Paralisis
            //Condiciones_Clinicas_Actuales_Principal CCA9 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 2;
            if (!string.IsNullOrEmpty(collection["Paralisis"]))
            {
                CCA1.Nombre = "Paralisis";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Temblores
            //Condiciones_Clinicas_Actuales_Principal CCA10 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 2;
            if (!string.IsNullOrEmpty(collection["Temblores"]))
            {
                CCA1.Nombre = "Temblores";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Alteraciones de la conciencia
            //Condiciones_Clinicas_Actuales_Principal CCA1 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 2;
            if (!string.IsNullOrEmpty(collection["Ac"]))
            {
                CCA1.Nombre = "Alteraciones de la conciencia";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 3;
            if (!string.IsNullOrEmpty(collection["pp"]))
            {
                CCA1.Nombre = "Perdida de peso";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Aumento de peso
            //Condiciones_Clinicas_Actuales_Principal CCA14 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 3;
            if (!string.IsNullOrEmpty(collection["AP"]))
            {
                CCA1.Nombre = "Aumento de peso";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Fiebre
            //Condiciones_Clinicas_Actuales_Principal CCA16 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 3;
            if (!string.IsNullOrEmpty(collection["Fiebre"]))
            {
                CCA1.Nombre = "Fiebre";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Escalofrios
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 3;
            if (!string.IsNullOrEmpty(collection["Escalofrios"]))
            {
                CCA1.Nombre = "Escalofrios";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Sibilancia
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 4;
            if (!string.IsNullOrEmpty(collection["Sibilancia"]))
            {
                CCA1.Nombre = "Sibilancia";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Tos
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 4;
            if (!string.IsNullOrEmpty(collection["Tos"]))
            {
                CCA1.Nombre = "Tos";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Dolor al respirar
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 4;
            if (!string.IsNullOrEmpty(collection["DAR"]))
            {
                CCA1.Nombre = "Dolor al respirar";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Toser coagulos de sangre
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 4;
            if (!string.IsNullOrEmpty(collection["TCS"]))
            {
                CCA1.Nombre = "Toser coagulos de sangre";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Erupciones/Purito
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 5;
            if (!string.IsNullOrEmpty(collection["EP"]))
            {
                CCA1.Nombre = "Erupciones/Purito";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Ulceras/Llagas
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 5;
            if (!string.IsNullOrEmpty(collection["Ulceras"]))
            {
                CCA1.Nombre = "Ulceras/Llagas";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Hongos en los pies
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 5;
            if (!string.IsNullOrEmpty(collection["hongos"]))
            {
                CCA1.Nombre = "Hongos en los pies";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }
            //Dolores de Cabeza
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 6;
            if (!string.IsNullOrEmpty(collection["Dc"]))
            {
                CCA1.Nombre = "Dolores de Cabeza";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Convulsiones
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 6;
            if (!string.IsNullOrEmpty(collection["Convulsiones"]))
            {
                CCA1.Nombre = "Convulsiones";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Perdida de la conciencia
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 6;
            if (!string.IsNullOrEmpty(collection["PConciencia"]))
            {
                CCA1.Nombre = "Perdida de la conciencia";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Cambios en la vision
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 7;
            if (!string.IsNullOrEmpty(collection["cambiosVision"]))
            {
                CCA1.Nombre = "Cambios en la vision";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //fotofobia
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 7;
            if (!string.IsNullOrEmpty(collection["fotofobia"]))
            {
                CCA1.Nombre = "Fotofobia";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Dolor/enrojecimiento
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 7;
            if (!string.IsNullOrEmpty(collection["DE"]))
            {
                CCA1.Nombre = "Dolor/enrojecimiento";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Lagrimeo excesivo
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 7;
            if (!string.IsNullOrEmpty(collection["lagrimeoe"]))
            {
                CCA1.Nombre = "Lagrimeo excesivo";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Perdida audicion
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 8;
            if (!string.IsNullOrEmpty(collection["PA"]))
            {
                CCA1.Nombre = "Perdida audicion";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Vertigo
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 8;
            if (!string.IsNullOrEmpty(collection["Vertigo"]))
            {
                CCA1.Nombre = "Vertigo";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Sangrado de nariz
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 8;
            if (!string.IsNullOrEmpty(collection["sangradoN"]))
            {
                CCA1.Nombre = "Sangrado de nariz";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Ronquidos
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 8;
            if (!string.IsNullOrEmpty(collection["Ronquidos"]))
            {
                CCA1.Nombre = "Ronquidos";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }


            //Perdida control de vejiga
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 9;
            if (!string.IsNullOrEmpty(collection["PCVe"]))
            {
                CCA1.Nombre = "Perdida control de vejiga";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Miccion frecuente
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 9;
            if (!string.IsNullOrEmpty(collection["MiccionF"]))
            {
                CCA1.Nombre = "Miccion frecuente";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Dolor en el pecho
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 10;
            if (!string.IsNullOrEmpty(collection["DolorP"]))
            {
                CCA1.Nombre = "Dolor en el pecho";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Palpitaciones
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 10;
            if (!string.IsNullOrEmpty(collection["Palpitaciones"]))
            {
                CCA1.Nombre = "Palpitaciones";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Falta Aliento
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 10;
            if (!string.IsNullOrEmpty(collection["FaltaAliento"]))
            {
                CCA1.Nombre = "Falta de Aliento";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Dificultad para deglutir
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 11;
            if (!string.IsNullOrEmpty(collection["Dificultaddeglutir"]))
            {
                CCA1.Nombre = "Dificultad para deglutir";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Ardor estomacal
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 11;
            if (!string.IsNullOrEmpty(collection["ardorEstomacal"]))
            {
                CCA1.Nombre = "Ardor estomacal";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Nauseas/Vomito
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 11;
            if (!string.IsNullOrEmpty(collection["NV"]))
            {
                CCA1.Nombre = "Nauseas/Vomito";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Sangrado intestinal
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 11;
            if (!string.IsNullOrEmpty(collection["Sangradointestinal"]))
            {
                CCA1.Nombre = "Sangrado intestinal";
                CCA1.Valor = "Si";
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //Otros
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 12;
            if (!string.IsNullOrEmpty(collection["otrosCCA"]))
            {
                CCA1.Nombre = "Otros";
                CCA1.Valor = collection["otrosCCA"];
                db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
                db.SaveChanges();
            }
            else
            {

            }

            //observaciones
            if (collection["observacioneCCA"] != "")
            {
                Anexos anex1 = new Anexos();
                anex1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                anex1.Observaciones = collection["observacioneCCA"];
                anex1.Estado = true;
                anex1.Fecha_de_Registro = DateTime.Now;
                anex1.Otros_Hallazgos = "";
                anex1.Recomendaciones = "";
                db.Anexos.Add(anex1);
                db.SaveChanges();
            }
            //ficha antroprometrica
            //peso corporal
            //Ficha_Antropometrica ficha = new Ficha_Antropometrica();
            //ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            //ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            //ficha.Sexo = collection["genero"];
            //ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            //ficha.Antropometrista = collection["Antropometrista"];
            //ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            //ficha.Anotador = collection["Anotador"];
            //ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            //if (collection["genero"] == "Masculino")
            //{
            //    ficha.Menstruacion = "No";
            //}
            //else
            //{
            //    ficha.Menstruacion = collection["menstruacion"];
            //}
            //ficha.Estado = true;
            //ficha.Fecha_de_Registro = DateTime.Now;
            //ficha.Txt_Ficha_Antropometrica = "01-Peso corporal (kg)";
            //ficha.Toma1 = Convert.ToDecimal(collection["PCtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["PCtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["PCtoma3"]);
            ////1ficha.Promedio_Mediana = Convert.ToDecimal(collection["PCpromed"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["PCpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Talla(cm)
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "02-Talla (cm)";
            //ficha.Toma1 = Convert.ToDecimal(collection["Ttoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["Ttoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["Ttoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["Tpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Talla sentado (cm)
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "03-Talla sentado (cm)";
            //ficha.Toma1 = Convert.ToDecimal(collection["Tstoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["Tstoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["Tstoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["Tspromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Envergadura
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "04-Envergadura (mm)";
            //ficha.Toma1 = Convert.ToDecimal(collection["Etoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["Etoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["Etoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["Epromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Subescapular
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "05-Subescapular";
            //ficha.Toma1 = Convert.ToDecimal(collection["SCtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["SCtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["SCtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["SCpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Tricipital
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "06-Tricipital";
            //ficha.Toma1 = Convert.ToDecimal(collection["TTtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["TTtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["TTtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["TTpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Bicipital
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "07-Bicipital";
            //ficha.Toma1 = Convert.ToDecimal(collection["BCtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["BCtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["BCtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["BCpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Supracrestal o cresta iliaca
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "08-Supracrestal o cresta iliaca";
            //ficha.Toma1 = Convert.ToDecimal(collection["CItoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["CItoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["CItoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["CIpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Supracrestal o suprailiaco
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "09-Supracrestal o suprailiaco";
            //ficha.Toma1 = Convert.ToDecimal(collection["SCotoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["SCotoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["SCotoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["SCopromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Abdominal
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "10-Abdominal";
            //ficha.Toma1 = Convert.ToDecimal(collection["ABtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["ABtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["ABtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["ABpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Muslo anterior
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "11-Muslo anterior";
            //ficha.Toma1 = Convert.ToDecimal(collection["MAtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["MAtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["MAtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["MApromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Pierna medial
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "12-Pierna medial";
            //ficha.Toma1 = Convert.ToDecimal(collection["PMtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["PMtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["PMtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["PMpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Otros1
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //string vari = collection["otros1"];
            //ficha.Txt_Ficha_Antropometrica = "12.5" + vari;
            //ficha.Toma1 = Convert.ToDecimal(collection["otros1toma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["otros1toma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["otros1toma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["otros1promed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Brazo relajado
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "13-Brazo relajado";
            //ficha.Toma1 = Convert.ToDecimal(collection["BRtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["BRtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["BRtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["BRpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Brazo flexionado y contaido
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "14-Brazo flexionado y contraido";
            //ficha.Toma1 = Convert.ToDecimal(collection["BFCtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["BFCtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["BFCtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["BFCpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Muslo medial
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "15-Muslo medial";
            //ficha.Toma1 = Convert.ToDecimal(collection["MMtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["MMtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["MMtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["MMpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Pantorilla
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "16-Pantorilla";
            //ficha.Toma1 = Convert.ToDecimal(collection["PANtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["PANtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["PANtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["PANpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Cintura
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "17-Cintura";
            //ficha.Toma1 = Convert.ToDecimal(collection["CINtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["CINtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["CINtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["CINpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Cadera
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "18-Cadera";
            //ficha.Toma1 = Convert.ToDecimal(collection["CADtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["CADtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["CADtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["CADpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////otros 2
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //string var9 = collection["otros2"];
            //ficha.Txt_Ficha_Antropometrica = "19" + var9;
            //ficha.Toma1 = Convert.ToDecimal(collection["otros2toma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["otros2toma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["otros2toma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["otros2promed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Humero
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "20-Humero";
            //ficha.Toma1 = Convert.ToDecimal(collection["Humerotoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["Humerotoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["Humerotoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["Humeropromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Muñeca
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "21-Muñeca";
            //ficha.Toma1 = Convert.ToDecimal(collection["Muñecatoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["Muñecatoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["Muñecatoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["Muñecapromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////Femur
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //ficha.Txt_Ficha_Antropometrica = "22-Femur";
            //ficha.Toma1 = Convert.ToDecimal(collection["femurtoma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["femurtoma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["femurtoma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["femurpromed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            ////otros3
            ////ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            ////ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
            ////ficha.Sexo = collection["genero"];
            ////ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
            ////ficha.Antropometrista = collection["Antropometrista"];
            ////ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
            ////ficha.Anotador = collection["Anotador"];
            ////ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
            ////if (collection["genero"] == "Masculino")
            ////{
            ////    ficha.Menstruacion = "No";
            ////}
            ////else
            ////{
            ////    ficha.Menstruacion = collection["menstruacion"];
            ////}
            //string var8 = collection["otros3"];
            //ficha.Txt_Ficha_Antropometrica = "23" + var8;
            //ficha.Toma1 = Convert.ToDecimal(collection["otros3toma1"]);
            //ficha.Toma2 = Convert.ToDecimal(collection["otros3toma2"]);
            //ficha.Toma3 = Convert.ToDecimal(collection["otros3toma3"]);
            //ficha.Promedio_Mediana = Convert.ToDecimal(collection["otros3promed"]);
            //db.Ficha_Antropometrica.Add(ficha);
            //db.SaveChanges();
            if (!string.IsNullOrEmpty(collection["numEvaluacion"]) && !string.IsNullOrEmpty(collection["Antropometrista"]) && !string.IsNullOrEmpty(collection["Anotador"]) && !string.IsNullOrEmpty(collection["fechaNac"]))
            {



                Ficha_Antropometrica ficha = new Ficha_Antropometrica();
                ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
                ficha.Sexo = collection["genero"];
                ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                ficha.Antropometrista = collection["Antropometrista"];
                ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                ficha.Anotador = collection["Anotador"];
                ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
                if (collection["genero"] == "Masculino")
                {
                    ficha.Menstruacion = "No";
                }
                else
                {
                    ficha.Menstruacion = collection["menstruacion"];
                }
                ficha.Estado = true;
                ficha.Fecha_de_Registro = DateTime.Today;
                //peso corporal
                ficha.Txt_Ficha_Antropometrica = "01-Peso corporal (kg)";
                if (string.IsNullOrEmpty(collection["PCtoma1"]) && string.IsNullOrEmpty(collection["PCtoma2"]) && string.IsNullOrEmpty(collection["PCtoma3"]) && string.IsNullOrEmpty(collection["PCpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["PCtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["PCtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["PCtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["PCpromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();

                //Talla(cm)

                ficha.Txt_Ficha_Antropometrica = "02-Talla (cm)";
                if (string.IsNullOrEmpty(collection["Ttoma1"]) && string.IsNullOrEmpty(collection["Ttoma2"]) && string.IsNullOrEmpty(collection["Ttoma3"]) && string.IsNullOrEmpty(collection["Tpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["Ttoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["Ttoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["Ttoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["Tpromed"]);
                }
                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Talla sentado (cm)

                ficha.Txt_Ficha_Antropometrica = "03-Talla sentado (cm)";
                if (string.IsNullOrEmpty(collection["Tstoma1"]) && string.IsNullOrEmpty(collection["Tsoma2"]) && string.IsNullOrEmpty(collection["Tsoma3"]) && string.IsNullOrEmpty(collection["Tspromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["Tstoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["Tstoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["Tstoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["Tspromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Envergadura

                ficha.Txt_Ficha_Antropometrica = "04-Envergadura (mm)";
                if (string.IsNullOrEmpty(collection["Etoma1"]) && string.IsNullOrEmpty(collection["Etoma2"]) && string.IsNullOrEmpty(collection["Etoma3"]) && string.IsNullOrEmpty(collection["Epromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["Etoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["Etoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["Etoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["Epromed"]);
                }
                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Subescapular

                ficha.Txt_Ficha_Antropometrica = "05-Subescapular";
                if (string.IsNullOrEmpty(collection["SCtoma1"]) && string.IsNullOrEmpty(collection["SCtoma2"]) && string.IsNullOrEmpty(collection["SCtomatoma3"]) && string.IsNullOrEmpty(collection["SCpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["SCtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["SCtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["SCtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["SCpromed"]);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["SCtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["SCtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["SCtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["SCpromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Tricipital

                ficha.Txt_Ficha_Antropometrica = "06-Tricipital";
                if (string.IsNullOrEmpty(collection["TTtoma1"]) && string.IsNullOrEmpty(collection["TTtoma2"]) && string.IsNullOrEmpty(collection["TTtoma3"]) && string.IsNullOrEmpty(collection["TTpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["TTtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["TTtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["TTtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["TTpromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Bicipital

                ficha.Txt_Ficha_Antropometrica = "07-Bicipital";
                if (string.IsNullOrEmpty(collection["BCtoma1"]) && string.IsNullOrEmpty(collection["BCtoma2"]) && string.IsNullOrEmpty(collection["BCtoma3"]) && string.IsNullOrEmpty(collection["BCpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["BCtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["BCtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["BCtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["BCpromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Supracrestal o cresta iliaca

                ficha.Txt_Ficha_Antropometrica = "08-Supracrestal o cresta iliaca";
                if (string.IsNullOrEmpty(collection["CItoma1"]) && string.IsNullOrEmpty(collection["CItoma2"]) && string.IsNullOrEmpty(collection["CItoma3"]) && string.IsNullOrEmpty(collection["CIpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["CItoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["CItoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["CItoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["CIpromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Supracrestal o suprailiaco

                ficha.Txt_Ficha_Antropometrica = "09-Supracrestal o suprailiaco";
                if (string.IsNullOrEmpty(collection["SCotoma1"]) && string.IsNullOrEmpty(collection["SCotoma2"]) && string.IsNullOrEmpty(collection["SCotoma3"]) && string.IsNullOrEmpty(collection["CIpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["SCotoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["SCotoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["SCotoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["SCopromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Abdominal
                ficha.Txt_Ficha_Antropometrica = "10-Abdominal";
                if (string.IsNullOrEmpty(collection["ABtoma1"]) && string.IsNullOrEmpty(collection["ABtoma2"]) && string.IsNullOrEmpty(collection["ABtoma3"]) && string.IsNullOrEmpty(collection["ABpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["ABtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["ABtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["ABtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["ABpromed"]);
                }
                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Muslo anterior

                ficha.Txt_Ficha_Antropometrica = "11-Muslo anterior";
                if (string.IsNullOrEmpty(collection["MAtoma1"]) && string.IsNullOrEmpty(collection["MAtoma2"]) && string.IsNullOrEmpty(collection["MAtoma3"]) && string.IsNullOrEmpty(collection["MApromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["MAtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["MAtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["MAtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["MApromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Pierna medial
                ficha.Txt_Ficha_Antropometrica = "12-Pierna medial";
                if (string.IsNullOrEmpty(collection["PMtoma1"]) && string.IsNullOrEmpty(collection["PMtoma2"]) && string.IsNullOrEmpty(collection["PMtoma3"]) && string.IsNullOrEmpty(collection["PMpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["PMtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["PMtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["PMtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["PMpromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Otros1

                string vari = collection["otros1"]; ficha.Txt_Ficha_Antropometrica = "12.5" + vari;

                if (string.IsNullOrEmpty(collection["otros1toma1"]) && string.IsNullOrEmpty(collection["otros1toma2"]) && string.IsNullOrEmpty(collection["otros1toma3"]) && string.IsNullOrEmpty(collection["otros1promed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["otros1toma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["otros1toma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["otros1toma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["otros1promed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Brazo relajado

                ficha.Txt_Ficha_Antropometrica = "13-Brazo relajado";
                if (string.IsNullOrEmpty(collection["BRtoma1"]) && string.IsNullOrEmpty(collection["BRtoma2"]) && string.IsNullOrEmpty(collection["BRtoma3"]) && string.IsNullOrEmpty(collection["BRpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["BRtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["BRtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["BRtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["BRpromed"]);
                }


                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Brazo flexionado y contaido

                ficha.Txt_Ficha_Antropometrica = "14-Brazo flexionado y contraido";
                if (string.IsNullOrEmpty(collection["BFCtoma1"]) && string.IsNullOrEmpty(collection["BFCtoma2"]) && string.IsNullOrEmpty(collection["BFCtoma3"]) && string.IsNullOrEmpty(collection["BFCpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["BFCtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["BFCtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["BFCtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["BFCpromed"]);

                }
                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Muslo medial


                ficha.Txt_Ficha_Antropometrica = "15-Muslo medial";
                if (string.IsNullOrEmpty(collection["MMtoma1"]) && string.IsNullOrEmpty(collection["MMtoma2"]) && string.IsNullOrEmpty(collection["MMtoma3"]) && string.IsNullOrEmpty(collection["MMpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["MMtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["MMtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["MMtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["MMpromed"]);

                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Pantorilla

                ficha.Txt_Ficha_Antropometrica = "16-Pantorilla";
                if (string.IsNullOrEmpty(collection["PANtoma1"]) && string.IsNullOrEmpty(collection["PANtoma2"]) && string.IsNullOrEmpty(collection["PANtoma3"]) && string.IsNullOrEmpty(collection["PANpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["PANtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["PANtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["PANtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["PANpromed"]);

                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Cintura

                ficha.Txt_Ficha_Antropometrica = "17-Cintura";
                if (string.IsNullOrEmpty(collection["CINtoma1"]) && string.IsNullOrEmpty(collection["CINtoma2"]) && string.IsNullOrEmpty(collection["CINtoma3"]) && string.IsNullOrEmpty(collection["CINpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["CINtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["CINtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["CINtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["CINpromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Cadera

                ficha.Txt_Ficha_Antropometrica = "18-Cadera";

                ficha.Toma1 = Convert.ToDecimal(collection["CADtoma1"]);
                ficha.Toma2 = Convert.ToDecimal(collection["CADtoma2"]);
                ficha.Toma3 = Convert.ToDecimal(collection["CADtoma3"]);
                ficha.Promedio_Mediana = Convert.ToDecimal(collection["CADpromed"]);
                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //otros 2
                string var9 = collection["otros2"];
                ficha.Txt_Ficha_Antropometrica = "19" + var9;
                if (string.IsNullOrEmpty(collection["otros2toma1"]) && string.IsNullOrEmpty(collection["otros2toma2"]) && string.IsNullOrEmpty(collection["otros2toma3"]) && string.IsNullOrEmpty(collection["otros2promed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {


                    ficha.Toma1 = Convert.ToDecimal(collection["otros2toma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["otros2toma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["otros2toma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["otros2promed"]);
                }
                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Humero

                ficha.Txt_Ficha_Antropometrica = "20-Humero";
                if (string.IsNullOrEmpty(collection["Humerotoma1"]) && string.IsNullOrEmpty(collection["Humerotoma2"]) && string.IsNullOrEmpty(collection["Humerotoma3"]) && string.IsNullOrEmpty(collection["Humeropromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["Humerotoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["Humerotoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["Humerotoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["Humeropromed"]);
                }

                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Muñeca

                ficha.Txt_Ficha_Antropometrica = "21-Muñeca";
                if (string.IsNullOrEmpty(collection["Muñecatoma1"]) && string.IsNullOrEmpty(collection["Muñecatoma2"]) && string.IsNullOrEmpty(collection["Muñecatoma3"]) && string.IsNullOrEmpty(collection["Muñecapromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["Muñecatoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["Muñecatoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["Muñecatoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["Muñecapromed"]);
                }


                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //Femur

                ficha.Txt_Ficha_Antropometrica = "22-Femur";
                if (string.IsNullOrEmpty(collection["femurtoma1"]) && string.IsNullOrEmpty(collection["femurtoma2"]) && string.IsNullOrEmpty(collection["femurtoma3"]) && string.IsNullOrEmpty(collection["femurpromed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["femurtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["femurtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["femurtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["femurpromed"]);
                }
                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();
                //otros3
                string var8 = collection["otros3"];
                ficha.Txt_Ficha_Antropometrica = "23" + var8;
                if (string.IsNullOrEmpty(collection["otros3toma1"]) && string.IsNullOrEmpty(collection["otros3toma2"]) && string.IsNullOrEmpty(collection["otros3toma3"]) && string.IsNullOrEmpty(collection["otros3promed"]))
                {
                    ficha.Toma1 = Convert.ToDecimal(0);
                    ficha.Toma2 = Convert.ToDecimal(0);
                    ficha.Toma3 = Convert.ToDecimal(0);
                    ficha.Promedio_Mediana = Convert.ToDecimal(0);
                }
                else
                {
                    ficha.Toma1 = Convert.ToDecimal(collection["otros3toma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["otros3toma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["otros3toma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["otros3promed"]);
                }
                db.Ficha_Antropometrica.Add(ficha);
                db.SaveChanges();

            }
            return Redirect("~/HomeAdmin/");
           
        }
        public ActionResult Actualizar(int id)
        {
            var nom = db.Datos_Atleta.Find(id);
            ViewBag.id = id;
            ViewBag.nombre = nom.Nombre_Completo;
            ViewBag.genero = nom.Genero;

            var cca = db.Condiciones_Clinicas_Actuales_Principal.Where(s => s.ID_Atleta == id).ToList(); ;
            foreach (var i in cca)
            {
                //Musculo Esqueletico
                if (i.Nombre == "Practica Deportiva")
                {
                    ViewBag.pd = i.Nombre;                    
                }
                if (i.Nombre == "Economia Familiar")
                {
                    ViewBag.ef = i.Nombre;                    
                }
                if (i.Nombre == "Educacion")
                {
                    ViewBag.educa = i.Nombre;                    
                }
                if (i.Nombre == "Dolor Articular")
                {
                    ViewBag.da = i.Nombre;                    
                }
                if (i.Nombre == "Rigidez en Articulaciones")
                {
                    ViewBag.Ra = i.Nombre;
                }
                if (i.Nombre == "Fracturas" )
                {
                    ViewBag.fractura=i.Nombre;
                }
                if (i.Nombre == "Debilidad Muscular")
                {
                    ViewBag.dm = i.Nombre;
                }
                if (i.Nombre == "Hinchazon articular")
                {
                    ViewBag.ha = i.Nombre;
                }
                //Neurologico
                if (i.Nombre == "Paralisis")
                {
                    ViewBag.paralisis = i.Nombre;
                }
                if (i.Nombre == "Temblores")
                {
                    ViewBag.temblores = i.Nombre;
                }
                if (i.Nombre == "Alteraciones de la conciencia")
                {
                    ViewBag.ac = i.Nombre;
                }
                //General

                if (i.Nombre == "Perdida de peso")
                {
                    ViewBag.pp = i.Nombre;
                }
                if (i.Nombre == "Aumento de peso")
                {
                    ViewBag.ap = i.Nombre;
                }
                if (i.Nombre == "Fiebre")
                {
                    ViewBag.fiebre = i.Nombre;
                }
                if (i.Nombre == "Escalofrios")
                {
                    ViewBag.esc = i.Nombre;
                }
                //Respiratorio
                if (i.Nombre == "Sibilancia")
                {
                    ViewBag.silb = i.Nombre;
                }
                if (i.Nombre == "Tos")
                {
                    ViewBag.tos = i.Nombre;
                }
                if (i.Nombre == "Dolor al respirar")
                {
                    ViewBag.dar = i.Nombre;
                }
                if (i.Nombre == "Toser coagulos de sangre")
                {
                    ViewBag.tcs = i.Nombre;
                }
                //Dermatologico
                if (i.Nombre == "Erupciones/Purito")
                {
                    ViewBag.e_p = i.Nombre;
                }
                if (i.Nombre == "Ulceras/Llagas")
                {
                    ViewBag.U_LL = i.Nombre;
                }
                if (i.Nombre == "Hongos en los pies")
                {
                    ViewBag.hp = i.Nombre;
                }
                //cabeza
                if (i.Nombre == "Dolores de Cabeza")
                {
                    ViewBag.DC = i.Nombre;
                }
                if (i.Nombre == "Convulsiones")
                {
                    ViewBag.convul = i.Nombre;
                }
                if (i.Nombre == "Perdida de la conciencia")
                {
                    ViewBag.pc = i.Nombre;
                }
                //ojos 
                if (i.Nombre == "Cambios en la vision")
                {
                    ViewBag.cv = i.Nombre;
                }
                if (i.Nombre == "Fotofobia")
                {
                    ViewBag.foto = i.Nombre;
                }
                if (i.Nombre == "Dolor/enrojecimiento")
                {
                    ViewBag.de = i.Nombre;
                }
                if (i.Nombre == "Lagrimeo excesivo")
                {
                    ViewBag.le = i.Nombre;
                }
                //oidos,nariz,garganta
                if (i.Nombre == "Perdida audicion")
                {
                    ViewBag.pa = i.Nombre;
                }
                if (i.Nombre == "Vertigo")
                {
                    ViewBag.ver = i.Nombre;
                }
                if (i.Nombre == "Sangrado de nariz")
                {
                    ViewBag.sn = i.Nombre;
                }
                if (i.Nombre == "Ronquidos")
                {
                    ViewBag.ron = i.Nombre;
                }
                //Genitourinario
                if (i.Nombre == "Perdida control de vejiga")
                {
                    ViewBag.pcv = i.Nombre;
                }
                if (i.Nombre == "Miccion frecuente")
                {
                    ViewBag.mf = i.Nombre;
                }
                //Cardiovascular
                if (i.Nombre == "Dolor en el pecho")
                {
                    ViewBag.dp = i.Nombre;
                }
                if (i.Nombre == "Palpitaciones")
                {
                    ViewBag.palpita = i.Nombre;
                }
                if (i.Nombre == "Falta de aliento")
                {
                    ViewBag.fa = i.Nombre;
                }
                //Gastrointestinal
                if (i.Nombre == "Dificultad para deglutir")
                {
                    ViewBag.dd = i.Nombre;
                }
                if (i.Nombre == "Ardor estomacal")
                {
                    ViewBag.ae = i.Nombre;
                }
                if (i.Nombre == "Nauseas/Vomito")
                {
                    ViewBag.nv = i.Nombre;
                }
                if (i.Nombre == "Sangrado intestinal")
                {
                    ViewBag.si = i.Nombre;
                }
                //otros
                if (i.Nombre == "Otros")
                {
                    ViewBag.otros = i.Valor;
                }
            }//end foreach

            IEnumerable<Examen_Fisico_Principal> EFP = db.Examen_Fisico_Principal.Where(s => s.ID_Atleta == id).ToList();
            ViewBag.efp = EFP;
            IEnumerable<Anexos> anexos = db.Anexos.Where(s => s.ID_Atleta == id).ToList();
            ViewBag.anex = anexos;
            //IEnumerable<Condiciones_Clinicas_Actuales_Principal> cca = db.Condiciones_Clinicas_Actuales_Principal.Where(s => s.ID_Atleta == id).ToList();
            //ViewBag.CCA = cca;
            IEnumerable<Ficha_Antropometrica> ficha_Antropometricas = db.Ficha_Antropometrica.Where(s => s.ID_Atleta == id).ToList();
            ViewBag.ficha = ficha_Antropometricas;
            return View();
        }
        [HttpPost]
        public ActionResult Actualizar(int ID, FormCollection collection)
        {
            //tab1
            //pregunta 1
            if (!string.IsNullOrEmpty(collection["Si_Cuello"]))
            {

                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 1);
                if (E == null)
                {
                    //Medicamentos Medica1 = new Medicamentos();
                    //Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    //Medica1.Medicamentos1 = "Relajante Musculares";
                    //Medica1.Descripcion = collection["txt_medicamentos"];
                    //db.Medicamentos.Add(Medica1);
                    //db.SaveChanges();
                    Debug.WriteLine("1");
                }
                else
                {

                    
                    E.ID_Atleta = ID;
                    E.Hallazgos_Anormales = "";
                    E.Normal = "Si";
                    db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ////}
                    //Debug.WriteLine(collection["HA_Cuello"]);
                }
                //Debug.WriteLine("cambio de checked");
            }
            else if (collection["HA_Cuello"] != "")
            {
                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 1);
                
                E.ID_Atleta = ID;
                E.Hallazgos_Anormales = collection["HA_Cuello"];
                E.Normal = "No";
                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Debug.WriteLine("cambio de texto");
            }
            //pregunta 2
            if (!string.IsNullOrEmpty(collection["Si_Espalda"]))
            {

                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 2);
                if (E == null)
                {
                    //Medicamentos Medica1 = new Medicamentos();
                    //Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    //Medica1.Medicamentos1 = "Relajante Musculares";
                    //Medica1.Descripcion = collection["txt_medicamentos"];
                    //db.Medicamentos.Add(Medica1);
                    //db.SaveChanges();
                    Debug.WriteLine("1");
                }
                else 
                {
                   
                    
                    E.ID_Atleta = ID;
                    E.Hallazgos_Anormales = "";
                    E.Normal = "Si";
                    db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ////}
                    //Debug.WriteLine(collection["HA_Cuello"]);
                }
                //Debug.WriteLine("cambio de checked");
            }
            else if (collection["HA_espalda"] != "")
            {
                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 2);
                
                E.ID_Atleta = ID;
                E.Hallazgos_Anormales = collection["HA_espalda"];
                E.Normal = "No";
                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Debug.WriteLine("HA_espalda");
            }
            ////pregunta 3
            if (!string.IsNullOrEmpty(collection["Si_Hombro"]))
            {

                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 3);
                if (E == null)
                {
                    //Medicamentos Medica1 = new Medicamentos();
                    //Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    //Medica1.Medicamentos1 = "Relajante Musculares";
                    //Medica1.Descripcion = collection["txt_medicamentos"];
                    //db.Medicamentos.Add(Medica1);
                    //db.SaveChanges();
                    Debug.WriteLine("1");
                }
                else
                {

                    
                    E.ID_Atleta = ID;
                    E.Hallazgos_Anormales = "";
                    E.Normal = "Si";
                    db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ////}
                    //Debug.WriteLine(collection["HA_Cuello"]);
                }
                //Debug.WriteLine("cambio de checked");
            }
            else if (collection["HA_hombro"] != "")
            {
                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 3);
                
                E.ID_Atleta = ID;
                E.Hallazgos_Anormales = collection["HA_hombro"];
                E.Normal = "No";
                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Debug.WriteLine("cambio de texto");
            }
            ////pregunta 4
            if (!string.IsNullOrEmpty(collection["Si_Codo"]))
            {

                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 4);
                if (E == null)
                {
                    //Medicamentos Medica1 = new Medicamentos();
                    //Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    //Medica1.Medicamentos1 = "Relajante Musculares";
                    //Medica1.Descripcion = collection["txt_medicamentos"];
                    //db.Medicamentos.Add(Medica1);
                    //db.SaveChanges();
                    Debug.WriteLine("1");
                }
                else
                {

                    
                    E.ID_Atleta = ID;
                    E.Hallazgos_Anormales = "";
                    E.Normal = "Si";
                    db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ////}
                    //Debug.WriteLine(collection["HA_Cuello"]);
                }
                //Debug.WriteLine("cambio de checked");
            }
            else if (collection["HA_codo"] != "")
            {
                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 4);
                
                E.ID_Atleta = ID;
                E.Hallazgos_Anormales = collection["HA_codo"];
                E.Normal = "No";
                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Debug.WriteLine("cambio de texto");
            }
            ////pregunta 5
            if (!string.IsNullOrEmpty(collection["Si_Muñeca"]))
            {

                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 5);
                if (E == null)
                {
                    //Medicamentos Medica1 = new Medicamentos();
                    //Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    //Medica1.Medicamentos1 = "Relajante Musculares";
                    //Medica1.Descripcion = collection["txt_medicamentos"];
                    //db.Medicamentos.Add(Medica1);
                    //db.SaveChanges();
                    Debug.WriteLine("1");
                }
                else
                {

                    
                    E.ID_Atleta = ID;
                    E.Hallazgos_Anormales = "";
                    E.Normal = "Si";
                    db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ////}
                    //Debug.WriteLine(collection["HA_Cuello"]);
                }
                //Debug.WriteLine("cambio de checked");
            }
            else if (collection["HA_muñeca"] != "")
            {
                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 5);
                
                E.ID_Atleta = ID;
                E.Hallazgos_Anormales = collection["HA_muñeca"];
                E.Normal = "No";
                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Debug.WriteLine("cambio de texto");
            }
            ////pregunta 6
            if (!string.IsNullOrEmpty(collection["Si_Cadera"]))
            {

                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 6);
                if (E == null)
                {
                    //Medicamentos Medica1 = new Medicamentos();
                    //Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    //Medica1.Medicamentos1 = "Relajante Musculares";
                    //Medica1.Descripcion = collection["txt_medicamentos"];
                    //db.Medicamentos.Add(Medica1);
                    //db.SaveChanges();
                    Debug.WriteLine("1");
                }
                else
                {

                    
                    E.ID_Atleta = ID;
                    E.Hallazgos_Anormales = "";
                    E.Normal = "Si";
                    db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ////}
                    //Debug.WriteLine(collection["HA_Cuello"]);
                }
                //Debug.WriteLine("cambio de checked");
            }
            else if (collection["HA_cadera"] != "")
            {
                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 6);
                
                E.ID_Atleta = ID;
                E.Hallazgos_Anormales = collection["HA_cadera"];
                E.Normal = "No";
                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Debug.WriteLine("cambio de texto");
            }
            ////pregunta 7
            if (!string.IsNullOrEmpty(collection["Si_Rodilla"]))
            {

                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 7);
                if (E == null)
                {
                    //Medicamentos Medica1 = new Medicamentos();
                    //Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    //Medica1.Medicamentos1 = "Relajante Musculares";
                    //Medica1.Descripcion = collection["txt_medicamentos"];
                    //db.Medicamentos.Add(Medica1);
                    //db.SaveChanges();
                    Debug.WriteLine("1");
                }
                else
                {

                    
                    E.ID_Atleta = ID;
                    E.Hallazgos_Anormales = "";
                    E.Normal = "Si";
                    db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ////}
                    //Debug.WriteLine(collection["HA_Cuello"]);
                }
                //Debug.WriteLine("cambio de checked");
            }
            else if (collection["HA_rodilla"] != "")
            {
                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 7);
                
                E.ID_Atleta = ID;
                E.Hallazgos_Anormales = collection["HA_rodilla"];
                E.Normal = "No";
                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Debug.WriteLine("cambio de texto");
            }
            //pregunta 8
            if (!string.IsNullOrEmpty(collection["Si_Pierna"]))
            {

                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 8);
                if (E == null)
                {
                    //Medicamentos Medica1 = new Medicamentos();
                    //Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    //Medica1.Medicamentos1 = "Relajante Musculares";
                    //Medica1.Descripcion = collection["txt_medicamentos"];
                    //db.Medicamentos.Add(Medica1);
                    //db.SaveChanges();
                    Debug.WriteLine("1");
                }
                else
                {

                    
                    E.ID_Atleta = ID;
                    E.Hallazgos_Anormales = "";
                    E.Normal = "Si";
                    db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ////}
                    //Debug.WriteLine(collection["HA_Cuello"]);
                }
                //Debug.WriteLine("cambio de checked");
            }
            else if (collection["HA_pierna"] != "")
            {
                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 8);
                
                E.ID_Atleta = ID;
                E.Hallazgos_Anormales = collection["HA_pierna"];
                E.Normal = "No";
                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Debug.WriteLine("cambio de texto");
            }
            //pregunta 9
            if (!string.IsNullOrEmpty(collection["Si_dedos"]))
            {

                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 9);
                if (E == null)
                {
                    //Medicamentos Medica1 = new Medicamentos();
                    //Medica1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    //Medica1.Medicamentos1 = "Relajante Musculares";
                    //Medica1.Descripcion = collection["txt_medicamentos"];
                    //db.Medicamentos.Add(Medica1);
                    //db.SaveChanges();
                    Debug.WriteLine("1");
                }
                else
                {

                    //
                    E.ID_Atleta = ID;
                    E.Hallazgos_Anormales = "";
                    E.Normal = "Si";
                    db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ////}
                    //Debug.WriteLine(collection["HA_Cuello"]);
                }
                //Debug.WriteLine("cambio de checked");
            }
            else if (collection["HA_dedos"] != "")
            {
                Examen_Fisico_Principal E = db.Examen_Fisico_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.ID_Examen_Fisico == 9);
                //
                E.ID_Atleta = ID;
                E.Hallazgos_Anormales = collection["HA_dedos"];
                E.Normal = "No";
                db.Entry(E).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Debug.WriteLine("cambio de texto");
            }

            if (!string.IsNullOrEmpty(collection["otroshallazgos"]) && !string.IsNullOrEmpty(collection["Recomendaciones"]))
            {
                Anexos anexo = db.Anexos.FirstOrDefault(s=>s.ID_Atleta==ID && s.Observaciones=="");
                anexo.Otros_Hallazgos = collection["otroshallazgos"];
                anexo.Recomendaciones= collection["Recomendaciones"];
                db.Entry(anexo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //tab 2
            //cindiciones clinicas actuales 
            //Musculo esqueletico
            //Practicas Deportivas
            if (string.IsNullOrEmpty(collection["PD"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Practica Deportiva");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Practica Deportiva";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }
               
            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Practica Deportiva");
                if (CCA1==null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 1;
                    cca.Nombre = "Practica Deportiva";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }
                
                
            }
            //economia Familiar
            if (string.IsNullOrEmpty(collection["EF"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Economia Familiar");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Economia Familiar";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {

                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Economia Familiar");
                if (CCA1==null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 1;
                    cca.Nombre = "Economia Familiar";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }
               
            }
            //educacion
            if (string.IsNullOrEmpty(collection["Educa"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Educacion");
                if (CCA1 != null)
                {

                    CCA1.Nombre = "Educacion";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Educacion");
                if (CCA1==null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 1;
                    cca.Nombre = "Educacion";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }
                
            }
            //Dolor Articular
            if (string.IsNullOrEmpty(collection["Da"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dolor Articular");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Dolor Articular";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dolor Articular");
                if (CCA1==null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 1;
                    cca.Nombre = "Dolor Articular";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }
                
            }
            //rigidez en articulaciones
            if (string.IsNullOrEmpty(collection["Ra"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Rigidez en Articulaciones");
                if (CCA1 != null)
                {

                    CCA1.Nombre = "Rigidez en Articulaciones";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Rigidez en Articulaciones");
                if (CCA1==null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 1;
                    cca.Nombre = "Rigidez en Articulaciones";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }
               
            }
            //fracturas
            if (string.IsNullOrEmpty(collection["Fracturas"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Fracturas");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Fracturas";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Fracturas");
                if (CCA1==null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 1;
                    cca.Nombre = "Fracturas";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }
                
            }
            //debilidad muscular
            if (string.IsNullOrEmpty(collection["DM"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Debilidad Muscular");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Debilidad Muscular";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Debilidad Muscular");
                if (CCA1==null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 1;
                    cca.Nombre = "Debilidad Muscular";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }
               
            }
            //hinchazon articular
            if (string.IsNullOrEmpty(collection["HA"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Hinchazon articular");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Hinchazon articular";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Hinchazon articular");
                if (CCA1==null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 1;
                    cca.Nombre = "Hinchazon articular";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }
              
            }
            //Neurologico
            //paralisis
            if (string.IsNullOrEmpty(collection["Paralisis"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Paralisis");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Paralisis";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Paralisis");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 2;
                    cca.Nombre = "Paralisis";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //temblores
            if (string.IsNullOrEmpty(collection["Temblores"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Temblores");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Temblores";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Temblores");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 2;
                    cca.Nombre = "Temblores";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //Alteraciones de la conciencia
            if (string.IsNullOrEmpty(collection["Ac"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Alteraciones de la conciencia");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Alteraciones de la conciencia";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Alteraciones de la conciencia");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 2;
                    cca.Nombre = "Alteraciones de la conciencia";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //General
            //perdida de peso
            if (string.IsNullOrEmpty(collection["PP"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Perdida de peso");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Perdida de peso";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Perdida de peso");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 3;
                    cca.Nombre = "Perdida de peso";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //aumento de peso
            if (string.IsNullOrEmpty(collection["AP"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Aumento de peso");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Aumento de peso";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Aumento de peso");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 3;
                    cca.Nombre = "Aumento de peso";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //Fiebre
            if (string.IsNullOrEmpty(collection["Fiebre"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Fiebre");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Fiebre";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Fiebre");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 3;
                    cca.Nombre = "Fiebre";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //Escalofrio
            if (string.IsNullOrEmpty(collection["Escalofrios"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Escalofrios");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Escalofrios";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Escalofrios");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 3;
                    cca.Nombre = "Escalofrios";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //Respiratorio
            //Sibilancia
            if (string.IsNullOrEmpty(collection["Sibilancia"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Sibilancia");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Sibilancia";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Sibilancia");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 4;
                    cca.Nombre = "Sibilancia";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //Tos
            if (string.IsNullOrEmpty(collection["Tos"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Tos");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Tos";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Tos");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 4;
                    cca.Nombre = "Tos";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //Dolor al respirar 
            if (string.IsNullOrEmpty(collection["DAR"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dolor al respirar");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Dolor al respirar";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dolor al respirar");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 4;
                    cca.Nombre = "Dolor al respirar";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //toser coaulo de sangre 
            if (string.IsNullOrEmpty(collection["TCS"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Toser coagulos de sangre");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Toser coagulos de sangre";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Toser coagulos de sangre");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 4;
                    cca.Nombre = "Toser coagulos de sangre";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //dermatologico
            //erupciones/purito
            if (string.IsNullOrEmpty(collection["EP"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Erupciones/Purito");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Erupciones/Purito";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Erupciones/Purito");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 5;
                    cca.Nombre = "Erupciones/Purito";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //Ulceras/Llagas
            if (string.IsNullOrEmpty(collection["Ulceras"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Ulceras/Llagas");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Ulceras/Llagas";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Ulceras/Llagas");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 5;
                    cca.Nombre = "Ulceras/Llagas";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //Hongos en los pies
            if (string.IsNullOrEmpty(collection["hongos"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Hongos en los pies");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Hongos en los pies";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Hongos en los pies");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 5;
                    cca.Nombre = "Hongos en los pies";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //cabeza
            //dolores de cabeza 
            if (string.IsNullOrEmpty(collection["Dc"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dolores de Cabeza");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Dolores de Cabeza";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dolores de Cabeza");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 6;
                    cca.Nombre = "Dolores de Cabeza";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //convulsiones
            if (string.IsNullOrEmpty(collection["Convulsiones"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Convulsiones");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Convulsiones";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Convulsiones");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 6;
                    cca.Nombre = "Convulsiones";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //perdida de conciencia
            if (string.IsNullOrEmpty(collection["PConciencia"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Perdida de la conciencia");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Perdida de la conciencia";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Perdida de la conciencia");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 6;
                    cca.Nombre = "Perdida de la conciencia";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //ojos
            //cambios en la vision
            if (string.IsNullOrEmpty(collection["cambiosVision"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Cambios en la vision");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Cambios en la vision";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Cambios en la vision");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 7;
                    cca.Nombre = "Cambios en la vision";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //fotofobia
            if (string.IsNullOrEmpty(collection["fotofobia"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Fotofobia");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Fotofobia";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Fotofobia");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 7;
                    cca.Nombre = "Fotofobia";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //dolor/enroecimiento
            if (string.IsNullOrEmpty(collection["DE"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dolor/enrojecimiento");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Dolor/enrojecimiento";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dolor/enrojecimiento");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 7;
                    cca.Nombre = "Dolor/enrojecimiento";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //lagrimeo excesivo
            if (string.IsNullOrEmpty(collection["lagrimeoe"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Lagrimeo excesivo");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Lagrimeo excesivo";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Lagrimeo excesivo");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 7;
                    cca.Nombre = "Lagrimeo excesivo";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //oidos nariz garganta 
            //perdidas de audicion
            if (string.IsNullOrEmpty(collection["PA"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Perdida audicion");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Perdida audicion";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Perdida audicion");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 8;
                    cca.Nombre = "Perdida audicion";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //vertigo
            if (string.IsNullOrEmpty(collection["Vertigo"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Vertigo");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Vertigo";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Vertigo");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 8;
                    cca.Nombre = "Vertigo";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //sangrado de nariz
            if (string.IsNullOrEmpty(collection["sangradoN"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Sangrado de nariz");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Sangrado de nariz";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Sangrado de nariz");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 8;
                    cca.Nombre = "Sangrado de nariz";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //ronquidos
            if (string.IsNullOrEmpty(collection["Ronquidos"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Ronquidos");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Ronquidos";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Ronquidos");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 8;
                    cca.Nombre = "Ronquidos";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //genitounitario
            //perdida de control de vejiga
            if (string.IsNullOrEmpty(collection["PCVe"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Perdida control de vejiga");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Perdida control de vejiga";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Perdida control de vejiga");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 9;
                    cca.Nombre = "Perdida control de vejiga";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //Miccion frecuente
            if (string.IsNullOrEmpty(collection["MiccionF"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Miccion frecuente");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Miccion frecuente";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Miccion frecuente");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 9;
                    cca.Nombre = "Miccion frecuente";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //cardiovascular
            //Dolor en el pecho
            if (string.IsNullOrEmpty(collection["DolorP"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dolor en el pecho");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Dolor en el pecho";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dolor en el pecho");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 10   ;
                    cca.Nombre = "Dolor en el pecho";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //palpitaciones
            if (string.IsNullOrEmpty(collection["Palpitaciones"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Palpitaciones");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Palpitaciones";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Palpitaciones");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 10;
                    cca.Nombre = "Palpitaciones";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //Falta de aliento
            if (string.IsNullOrEmpty(collection["FaltaAliento"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Falta de aliento");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Falta de aliento";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Falta de aliento");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 10;
                    cca.Nombre = "Falta de aliento";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //gastrointestinal
            //dificultad para deglutir
            if (string.IsNullOrEmpty(collection["Dificultaddeglutir"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dificultad para deglutir");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Dificultad para deglutir";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Dificultad para deglutir");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 11;
                    cca.Nombre = "Dificultad para deglutir";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //ardor estomacal
            if (string.IsNullOrEmpty(collection["ardorEstomacal"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Ardor estomacal");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Ardor estomacal";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Ardor estomacal");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 11;
                    cca.Nombre = "Ardor estomacal";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //nauseas/vomito
            if (string.IsNullOrEmpty(collection["NV"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Nauseas/Vomito");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Nauseas/Vomito";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Nauseas/Vomito");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 11;
                    cca.Nombre = "Nauseas/Vomito";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //sangado intestinal
            if (string.IsNullOrEmpty(collection["Sangradointestinal"]))
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Sangrado intestinal");
                if (CCA1 != null)
                {
                    CCA1.Nombre = "Sangrado intestinal";
                    CCA1.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Remove(CCA1);
                    db.SaveChanges();
                }

            }
            else
            {
                Condiciones_Clinicas_Actuales_Principal CCA1 = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Sangrado intestinal");
                if (CCA1 == null)
                {
                    Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                    cca.ID_Atleta = ID;
                    cca.Estado = true;
                    cca.Fecha_de_Registro = DateTime.Now;
                    cca.ID_Condiciones_Clinicas_Actuales = 11;
                    cca.Nombre = "Sangrado intestinal";
                    cca.Valor = "Si";
                    db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                    db.SaveChanges();
                }

            }
            //otros
            Condiciones_Clinicas_Actuales_Principal cotros = db.Condiciones_Clinicas_Actuales_Principal.FirstOrDefault(s => s.ID_Atleta == ID && s.Nombre == "Otros");
            if (cotros == null)
            {
                Condiciones_Clinicas_Actuales_Principal cca = new Condiciones_Clinicas_Actuales_Principal();
                cca.ID_Atleta = ID;
                cca.Estado = true;
                cca.Fecha_de_Registro = DateTime.Now;
                cca.ID_Condiciones_Clinicas_Actuales = 12;
                cca.Nombre = "Otros";
                cca.Valor = collection["otrosCCA"];
                db.Condiciones_Clinicas_Actuales_Principal.Add(cca);
                db.SaveChanges();
            }
            else
            {
                cotros.ID_Atleta = ID;
                cotros.Nombre = "Otros";
                cotros.ID_Condiciones_Clinicas_Actuales = 12;
                cotros.Estado = true;
                cotros.Valor = collection["otrosCCA"];
                db.Entry(cotros).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
               
            }
            //observaciones
            if (!string.IsNullOrEmpty(collection["observacioneCCA"]))
            {
                Anexos anexo = db.Anexos.FirstOrDefault(s => s.ID_Atleta == ID && s.Otros_Hallazgos == "" || s.Recomendaciones =="");
                anexo.Observaciones = collection["observacioneCCA"];
                db.Entry(anexo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //ficha antropometrica
            Ficha_Antropometrica fa = db.Ficha_Antropometrica.FirstOrDefault(s=> s.ID_Atleta.Equals(ID));
            if (fa == null)
            {
                // Debug.WriteLine("mis huevos");
               
                if (!string.IsNullOrEmpty(collection["numEvaluacion"]) && !string.IsNullOrEmpty(collection["Antropometrista"]) && !string.IsNullOrEmpty(collection["Anotador"]) && !string.IsNullOrEmpty(collection["fechaNac"]))
                {



                    Ficha_Antropometrica ficha = new Ficha_Antropometrica();
                    ficha.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
                    ficha.Nombre_Y_Apellidos = collection["nombreAtleta"];
                    ficha.Sexo = collection["genero"];
                    ficha.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    ficha.Antropometrista = collection["Antropometrista"];
                    ficha.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    ficha.Anotador = collection["Anotador"];
                    ficha.Fecha_De_Nacimiento = Convert.ToDateTime(collection["fechaNac"]);
                    if (collection["genero"] == "Masculino")
                    {
                        ficha.Menstruacion = "No";
                    }
                    else
                    {
                        ficha.Menstruacion = collection["menstruacion"];
                    }
                    ficha.Estado = true;
                    ficha.Fecha_de_Registro = DateTime.Today;
                    //peso corporal
                    ficha.Txt_Ficha_Antropometrica = "01-Peso corporal (kg)";
                    if (string.IsNullOrEmpty(collection["PCtoma1"]) && string.IsNullOrEmpty(collection["PCtoma2"]) && string.IsNullOrEmpty(collection["PCtoma3"]) && string.IsNullOrEmpty(collection["PCpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["PCtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["PCtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["PCtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["PCpromed"]);
                    }
                   
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();

                    //Talla(cm)

                    ficha.Txt_Ficha_Antropometrica = "02-Talla (cm)";
                    if (string.IsNullOrEmpty(collection["Ttoma1"]) && string.IsNullOrEmpty(collection["Ttoma2"]) && string.IsNullOrEmpty(collection["Ttoma3"]) && string.IsNullOrEmpty(collection["Tpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["Ttoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["Ttoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["Ttoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["Tpromed"]);
                    }
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Talla sentado (cm)

                    ficha.Txt_Ficha_Antropometrica = "03-Talla sentado (cm)";
                    if (string.IsNullOrEmpty(collection["Tstoma1"]) && string.IsNullOrEmpty(collection["Tsoma2"]) && string.IsNullOrEmpty(collection["Tsoma3"]) && string.IsNullOrEmpty(collection["Tspromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["Tstoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["Tstoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["Tstoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["Tspromed"]);
                    }
                    
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Envergadura

                    ficha.Txt_Ficha_Antropometrica = "04-Envergadura (mm)";
                    if (string.IsNullOrEmpty(collection["Etoma1"]) && string.IsNullOrEmpty(collection["Etoma2"]) && string.IsNullOrEmpty(collection["Etoma3"]) && string.IsNullOrEmpty(collection["Epromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["Etoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["Etoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["Etoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["Epromed"]);
                    }
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Subescapular

                    ficha.Txt_Ficha_Antropometrica = "05-Subescapular";
                    if (string.IsNullOrEmpty(collection["SCtoma1"]) && string.IsNullOrEmpty(collection["SCtoma2"]) && string.IsNullOrEmpty(collection["SCtomatoma3"]) && string.IsNullOrEmpty(collection["SCpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["SCtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["SCtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["SCtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["SCpromed"]);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["SCtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["SCtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["SCtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["SCpromed"]);
                    }
                   
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Tricipital

                    ficha.Txt_Ficha_Antropometrica = "06-Tricipital";
                    if (string.IsNullOrEmpty(collection["TTtoma1"]) && string.IsNullOrEmpty(collection["TTtoma2"]) && string.IsNullOrEmpty(collection["TTtoma3"]) && string.IsNullOrEmpty(collection["TTpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0); 
                    }
                    else
                    {
                       ficha.Toma1 = Convert.ToDecimal(collection["TTtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["TTtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["TTtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["TTpromed"]);
                    }
                   
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Bicipital

                    ficha.Txt_Ficha_Antropometrica = "07-Bicipital";
                    if (string.IsNullOrEmpty(collection["BCtoma1"]) && string.IsNullOrEmpty(collection["BCtoma2"]) && string.IsNullOrEmpty(collection["BCtoma3"]) && string.IsNullOrEmpty(collection["BCpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["BCtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["BCtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["BCtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["BCpromed"]);
                    }
                    
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Supracrestal o cresta iliaca

                    ficha.Txt_Ficha_Antropometrica = "08-Supracrestal o cresta iliaca";
                    if (string.IsNullOrEmpty(collection["CItoma1"]) && string.IsNullOrEmpty(collection["CItoma2"]) && string.IsNullOrEmpty(collection["CItoma3"]) && string.IsNullOrEmpty(collection["CIpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["CItoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["CItoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["CItoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["CIpromed"]);
                    }
                   
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Supracrestal o suprailiaco

                    ficha.Txt_Ficha_Antropometrica = "09-Supracrestal o suprailiaco";
                    if (string.IsNullOrEmpty(collection["SCotoma1"]) && string.IsNullOrEmpty(collection["SCotoma2"]) && string.IsNullOrEmpty(collection["SCotoma3"]) && string.IsNullOrEmpty(collection["CIpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["SCotoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["SCotoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["SCotoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["SCopromed"]);
                    }
                    
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Abdominal
                    ficha.Txt_Ficha_Antropometrica = "10-Abdominal";
                    if (string.IsNullOrEmpty(collection["ABtoma1"]) && string.IsNullOrEmpty(collection["ABtoma2"]) && string.IsNullOrEmpty(collection["ABtoma3"]) && string.IsNullOrEmpty(collection["ABpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["ABtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["ABtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["ABtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["ABpromed"]);
                    }
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Muslo anterior

                    ficha.Txt_Ficha_Antropometrica = "11-Muslo anterior";
                    if (string.IsNullOrEmpty(collection["MAtoma1"]) && string.IsNullOrEmpty(collection["MAtoma2"]) && string.IsNullOrEmpty(collection["MAtoma3"]) && string.IsNullOrEmpty(collection["MApromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["MAtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["MAtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["MAtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["MApromed"]);
                    }
                   
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Pierna medial
                    ficha.Txt_Ficha_Antropometrica = "12-Pierna medial";
                    if (string.IsNullOrEmpty(collection["PMtoma1"]) && string.IsNullOrEmpty(collection["PMtoma2"]) && string.IsNullOrEmpty(collection["PMtoma3"]) && string.IsNullOrEmpty(collection["PMpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["PMtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["PMtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["PMtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["PMpromed"]);
                    }
                    
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Otros1

                    string vari = collection["otros1"]; ficha.Txt_Ficha_Antropometrica = "12.5" + vari;
                   
                    if (string.IsNullOrEmpty(collection["otros1toma1"]) && string.IsNullOrEmpty(collection["otros1toma2"]) && string.IsNullOrEmpty(collection["otros1toma3"]) && string.IsNullOrEmpty(collection["otros1promed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["otros1toma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["otros1toma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["otros1toma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["otros1promed"]);
                    }
                   
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Brazo relajado

                    ficha.Txt_Ficha_Antropometrica = "13-Brazo relajado";
                    if (string.IsNullOrEmpty(collection["BRtoma1"]) && string.IsNullOrEmpty(collection["BRtoma2"]) && string.IsNullOrEmpty(collection["BRtoma3"]) && string.IsNullOrEmpty(collection["BRpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["BRtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["BRtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["BRtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["BRpromed"]);
                    }

                  
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Brazo flexionado y contaido

                    ficha.Txt_Ficha_Antropometrica = "14-Brazo flexionado y contraido";
                    if (string.IsNullOrEmpty(collection["BFCtoma1"]) && string.IsNullOrEmpty(collection["BFCtoma2"]) && string.IsNullOrEmpty(collection["BFCtoma3"]) && string.IsNullOrEmpty(collection["BFCpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["BFCtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["BFCtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["BFCtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["BFCpromed"]);
                        
                    }
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Muslo medial


                    ficha.Txt_Ficha_Antropometrica = "15-Muslo medial";
                    if (string.IsNullOrEmpty(collection["MMtoma1"]) && string.IsNullOrEmpty(collection["MMtoma2"]) && string.IsNullOrEmpty(collection["MMtoma3"]) && string.IsNullOrEmpty(collection["MMpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["MMtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["MMtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["MMtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["MMpromed"]);

                    }
                   
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Pantorilla

                    ficha.Txt_Ficha_Antropometrica = "16-Pantorilla";
                    if (string.IsNullOrEmpty(collection["PANtoma1"]) && string.IsNullOrEmpty(collection["PANtoma2"]) && string.IsNullOrEmpty(collection["PANtoma3"]) && string.IsNullOrEmpty(collection["PANpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["PANtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["PANtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["PANtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["PANpromed"]);

                    }
                    
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Cintura

                    ficha.Txt_Ficha_Antropometrica = "17-Cintura";
                    if (string.IsNullOrEmpty(collection["CINtoma1"]) && string.IsNullOrEmpty(collection["CINtoma2"]) && string.IsNullOrEmpty(collection["CINtoma3"]) && string.IsNullOrEmpty(collection["CINpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["CINtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["CINtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["CINtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["CINpromed"]);
                    }
                    
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Cadera

                    ficha.Txt_Ficha_Antropometrica = "18-Cadera";
                    
                    ficha.Toma1 = Convert.ToDecimal(collection["CADtoma1"]);
                    ficha.Toma2 = Convert.ToDecimal(collection["CADtoma2"]);
                    ficha.Toma3 = Convert.ToDecimal(collection["CADtoma3"]);
                    ficha.Promedio_Mediana = Convert.ToDecimal(collection["CADpromed"]);
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //otros 2
                    string var9 = collection["otros2"];
                    ficha.Txt_Ficha_Antropometrica = "19" + var9;
                    if (string.IsNullOrEmpty(collection["otros2toma1"]) && string.IsNullOrEmpty(collection["otros2toma2"]) && string.IsNullOrEmpty(collection["otros2toma3"]) && string.IsNullOrEmpty(collection["otros2promed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        
                        
                        ficha.Toma1 = Convert.ToDecimal(collection["otros2toma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["otros2toma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["otros2toma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["otros2promed"]);
                    }
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Humero

                    ficha.Txt_Ficha_Antropometrica = "20-Humero";
                    if (string.IsNullOrEmpty(collection["Humerotoma1"]) && string.IsNullOrEmpty(collection["Humerotoma2"]) && string.IsNullOrEmpty(collection["Humerotoma3"]) && string.IsNullOrEmpty(collection["Humeropromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["Humerotoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["Humerotoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["Humerotoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["Humeropromed"]);
                    }
                   
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Muñeca

                    ficha.Txt_Ficha_Antropometrica = "21-Muñeca";
                    if (string.IsNullOrEmpty(collection["Muñecatoma1"]) && string.IsNullOrEmpty(collection["Muñecatoma2"]) && string.IsNullOrEmpty(collection["Muñecatoma3"]) && string.IsNullOrEmpty(collection["Muñecapromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["Muñecatoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["Muñecatoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["Muñecatoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["Muñecapromed"]);
                    }

                    
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //Femur

                    ficha.Txt_Ficha_Antropometrica = "22-Femur";
                    if (string.IsNullOrEmpty(collection["femurtoma1"]) && string.IsNullOrEmpty(collection["femurtoma2"]) && string.IsNullOrEmpty(collection["femurtoma3"]) && string.IsNullOrEmpty(collection["femurpromed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["femurtoma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["femurtoma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["femurtoma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["femurpromed"]);
                    }
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();
                    //otros3
                    string var8 = collection["otros3"];
                    ficha.Txt_Ficha_Antropometrica = "23" + var8;
                    if (string.IsNullOrEmpty(collection["otros3toma1"]) && string.IsNullOrEmpty(collection["otros3toma2"]) && string.IsNullOrEmpty(collection["otros3toma3"]) && string.IsNullOrEmpty(collection["otros3promed"]))
                    {
                        ficha.Toma1 = Convert.ToDecimal(0);
                        ficha.Toma2 = Convert.ToDecimal(0);
                        ficha.Toma3 = Convert.ToDecimal(0);
                        ficha.Promedio_Mediana = Convert.ToDecimal(0);
                    }
                    else
                    {
                        ficha.Toma1 = Convert.ToDecimal(collection["otros3toma1"]);
                        ficha.Toma2 = Convert.ToDecimal(collection["otros3toma2"]);
                        ficha.Toma3 = Convert.ToDecimal(collection["otros3toma3"]);
                        ficha.Promedio_Mediana = Convert.ToDecimal(collection["otros3promed"]);
                    }
                    db.Ficha_Antropometrica.Add(ficha);
                    db.SaveChanges();

                }
            }
            //si esta lleno
            else
            {
                //peso corporal
                if (!string.IsNullOrEmpty(collection["PCtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "01-Peso corporal (kg)");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["PCtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["PCtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["PCtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["PCpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //talla
                if (!string.IsNullOrEmpty(collection["Ttoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "02-Talla (cm)");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["Ttoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["Ttoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["Ttoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["Tpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //talla sentado
                if (!string.IsNullOrEmpty(collection["Tstoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "03-Talla sentado (cm)");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["Tstoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["Tstoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["Tstoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["Tspromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //envergadura
                if (!string.IsNullOrEmpty(collection["Etoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "04-Envergadura (mm)");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["Etoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["Etoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["Etoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["Epromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //subescapular
                if (!string.IsNullOrEmpty(collection["SCtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "05-Subescapular");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["SCtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["SCtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["SCtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["SCpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //tricipital
                if (!string.IsNullOrEmpty(collection["TTtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "06-Tricipital");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["TTtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["TTtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["TTtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["TTpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //bicipital
                if (!string.IsNullOrEmpty(collection["BCtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "07-Bicipital");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["BCtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["BCtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["BCtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["BCpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //08-Supracrestal o cresta iliaca
                if (!string.IsNullOrEmpty(collection["CItoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "08-Supracrestal o cresta iliaca");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["CItoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["CItoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["CItoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["CIpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //09-Supracrestal o suprailiaco
                if (!string.IsNullOrEmpty(collection["SCotoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "09-Supracrestal o suprailiaco");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["SCotoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["SCotoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["SCotoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["SCopromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //Abdominal
                if (!string.IsNullOrEmpty(collection["ABtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "10-Abdominal");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["ABtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["ABtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["ABtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["ABpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //muslo anterior
                if (!string.IsNullOrEmpty(collection["MAtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "11-Muslo anterior");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["MAtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["MAtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["MAtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["MApromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //12-Pierna medial
                if (!string.IsNullOrEmpty(collection["PMtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "12-Pierna medial");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["PMtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["PMtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["PMtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["PMpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //otros 1
                if (!string.IsNullOrEmpty(collection["otros1toma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica.IndexOf("12.5").Equals(0));
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    string vari = collection["otros1"];
                    F_A.Txt_Ficha_Antropometrica = "12.5" + vari;
                    F_A.Toma1 = Convert.ToDecimal(collection["otros1toma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["otros1toma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["otros1toma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["otros1promed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //brazo relajado
                if (!string.IsNullOrEmpty(collection["BRtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "13-Brazo relajado");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["BRtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["BRtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["BRtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["BRpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //brazo flexionado y contraido
                if (!string.IsNullOrEmpty(collection["BFCtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "14-Brazo flexionado y contraido");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["BFCtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["BFCtoma1"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["BFCtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["BFCpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //muslo medial
                if (!string.IsNullOrEmpty(collection["MMtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "15-Muslo medial");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["MMtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["MMtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["MMtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["MMpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //pantorrilla
                if (!string.IsNullOrEmpty(collection["PANtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "16-Pantorilla");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["PANtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["PANtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["PANtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["PANpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //cintura
                if (!string.IsNullOrEmpty(collection["CINtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "17-Cintura");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["CINtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["CINtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["CINtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["CINpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //cadera
                if (!string.IsNullOrEmpty(collection["CADtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "18-Cadera");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["CADtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["CADtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["CADtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["CADpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //otro 2
                if (!string.IsNullOrEmpty(collection["otros2toma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica.IndexOf("19").Equals(0));
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    string vari = collection["otros2"];
                    F_A.Txt_Ficha_Antropometrica = "19" + vari;
                    F_A.Toma1 = Convert.ToDecimal(collection["otros2toma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["otros2toma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["otros2toma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["otros2promed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //humero
                if (!string.IsNullOrEmpty(collection["Humerotoma1"]))
                {
                    
                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "20-Humero");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["Humerotoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["Humerotoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["Humerotoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["Humeropromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //muñeca
                if (!string.IsNullOrEmpty(collection["Muñecatoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "21-Muñeca");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["Muñecatoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["Muñecatoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["Muñecatoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["Muñecapromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //femur
                if (!string.IsNullOrEmpty(collection["femurtoma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica == "22-Femur");
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    F_A.Toma1 = Convert.ToInt32(collection["femurtoma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["femurtoma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["femurtoma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["femurpromed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //otros 3
                if (!string.IsNullOrEmpty(collection["otros3toma1"]))
                {

                    Ficha_Antropometrica F_A = db.Ficha_Antropometrica.FirstOrDefault(s => s.ID_Atleta.Equals(ID) && s.Txt_Ficha_Antropometrica.IndexOf("23").Equals(0));
                    F_A.Evaluacion = Convert.ToInt32(collection["numEvaluacion"]);
                    F_A.Antropometrista = collection["Antropometrista"];
                    F_A.Fecha_De_Evaluacion = Convert.ToDateTime(collection["fechaEv"]);
                    F_A.Anotador = collection["Anotador"];
                    F_A.Fecha_de_Actualizacion = DateTime.Today;
                    string vari = collection["otros3"];
                    F_A.Txt_Ficha_Antropometrica = "23" + vari;
                    F_A.Toma1 = Convert.ToDecimal(collection["otros3toma1"]);
                    F_A.Toma2 = Convert.ToDecimal(collection["otros3toma2"]);
                    F_A.Toma3 = Convert.ToDecimal(collection["otros3toma3"]);
                    F_A.Promedio_Mediana = Convert.ToDecimal(collection["otros3promed"]);
                    db.Entry(F_A).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Redirect("~/HomeAdmin/");
        }
    }
}