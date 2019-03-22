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
            return View();
        }
        [HttpPost]
        public ActionResult Crear(ExamenFisicoViewModel model, FormCollection collection)
        {
            //pregunta 1 
            Examen_Fisico_Principal Examen1 = new Examen_Fisico_Principal();
            Examen1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            Examen1.ID_Examen_Fisico = 1;
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
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["PD"]))
            {
                CCA1.Nombre = "Practica Deportiva";
                CCA1.Valor = "Si";
            }
            else
            {

            }

            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Economia Familiar
            //Condiciones_Clinicas_Actuales_Principal CCA2 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["EF"]))
            {
                CCA1.Nombre = "Economia Familiar";
                CCA1.Valor = "Si";
            }
            else
            {

            }

            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Educacion
            //Condiciones_Clinicas_Actuales_Principal CCA3 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["educa"]))
            {
                CCA1.Nombre = "Educación";
                CCA1.Valor = "Si";
            }
            else
            {

            }

            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Dolor Articular 
            //Condiciones_Clinicas_Actuales_Principal CCA4 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["Da"]))
            {
                CCA1.Nombre = "Dolor articular";
                CCA1.Valor = "Si";
            }
            else
            {

            }

            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Rigidez en articulaciones
            //Condiciones_Clinicas_Actuales_Principal CCA5 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["Ra"]))
            {
                CCA1.Nombre = "Rigidez en articulaciones";
                CCA1.Valor = "Si";
            }
            else
            {

            }

            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Fracturas
            //Condiciones_Clinicas_Actuales_Principal CCA6 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["Fracturas"]))
            {
                CCA1.Nombre = "Fracturas";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();

            //Debilidad Muscular
            //Condiciones_Clinicas_Actuales_Principal CCA7 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["DM"]))
            {
                CCA1.Nombre = "Debilidad Muscular";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Hinchazon articular
            //Condiciones_Clinicas_Actuales_Principal CCA8 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 1;
            if (!string.IsNullOrEmpty(collection["HA"]))
            {
                CCA1.Nombre = "Hinchazon articular";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Paralisis
            //Condiciones_Clinicas_Actuales_Principal CCA9 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 2;
            if (!string.IsNullOrEmpty(collection["Paralisis"]))
            {
                CCA1.Nombre = "Paralisis";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Temblores
            //Condiciones_Clinicas_Actuales_Principal CCA10 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 2;
            if (!string.IsNullOrEmpty(collection["Temblores"]))
            {
                CCA1.Nombre = "Temblores";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Alteraciones de la conciencia
            //Condiciones_Clinicas_Actuales_Principal CCA1 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 2;
            if (!string.IsNullOrEmpty(collection["Ac"]))
            {
                CCA1.Nombre = "Alteraciones de la conciencia";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();

            //Perdida de peso
            //Condiciones_Clinicas_Actuales_Principal CCA12 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 3;
            if (!string.IsNullOrEmpty(collection["pp"]))
            {
                CCA1.Nombre = "Perdida de peso";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Perdida de peso
            //Condiciones_Clinicas_Actuales_Principal CCA13 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 3;
            if (!string.IsNullOrEmpty(collection["pp"]))
            {
                CCA1.Nombre = "Perdida de peso";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Aumento de peso
            //Condiciones_Clinicas_Actuales_Principal CCA14 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 3;
            if (!string.IsNullOrEmpty(collection["AP"]))
            {
                CCA1.Nombre = "Aumento de peso";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Fiebre
            //Condiciones_Clinicas_Actuales_Principal CCA16 = new Condiciones_Clinicas_Actuales_Principal();
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 3;
            if (!string.IsNullOrEmpty(collection["Fiebre"]))
            {
                CCA1.Nombre = "Fiebre";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Escalofrios
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 3;
            if (!string.IsNullOrEmpty(collection["Escalofrios"]))
            {
                CCA1.Nombre = "Escalofrios";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Sibilancia
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 4;
            if (!string.IsNullOrEmpty(collection["Sibilancia"]))
            {
                CCA1.Nombre = "Sibilancia";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();

            //Tos
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 4;
            if (!string.IsNullOrEmpty(collection["Tos"]))
            {
                CCA1.Nombre = "Tos";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Dolor al respirar
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 4;
            if (!string.IsNullOrEmpty(collection["DAR"]))
            {
                CCA1.Nombre = "Dolor al respirar";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Toser coagulos de sangre
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 4;
            if (!string.IsNullOrEmpty(collection["TCS"]))
            {
                CCA1.Nombre = "Toser coagulos de sangre";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Erupciones/Purito
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 5;
            if (!string.IsNullOrEmpty(collection["EP"]))
            {
                CCA1.Nombre = "Erupciones/Purito";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Ulceras/Llagas
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 5;
            if (!string.IsNullOrEmpty(collection["Ulceras"]))
            {
                CCA1.Nombre = "Ulceras/Llagas";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Hongos en los pies
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 5;
            if (!string.IsNullOrEmpty(collection["hongos"]))
            {
                CCA1.Nombre = "Hongos en los pies";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Dolores de Cabeza
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 6;
            if (!string.IsNullOrEmpty(collection["Dc"]))
            {
                CCA1.Nombre = "Dolores de Cabeza";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Dolores de Cabeza
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 6;
            if (!string.IsNullOrEmpty(collection["Dc"]))
            {
                CCA1.Nombre = "Dolores de Cabeza";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Convulsiones
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 6;
            if (!string.IsNullOrEmpty(collection["Convulsiones"]))
            {
                CCA1.Nombre = "Convulsiones";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Perdida de la conciencia
            CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 6;
            if (!string.IsNullOrEmpty(collection["PConciencia"]))
            {
                CCA1.Nombre = "Perdida de la conciencia";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Cambios en la vision
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 7;
            if (!string.IsNullOrEmpty(collection["cambiosVision"]))
            {
                CCA1.Nombre = "Cambios en la vision";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();

            //fotofobia
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 7;
            if (!string.IsNullOrEmpty(collection["fotofobia"]))
            {
                CCA1.Nombre = "Fotofobia";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();

            //Dolor/enrojecimiento
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 7;
            if (!string.IsNullOrEmpty(collection["DE"]))
            {
                CCA1.Nombre = "Dolor/enrojecimiento";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();

            //Lagrimeo excesivo
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 7;
            if (!string.IsNullOrEmpty(collection["lagrimeoe"]))
            {
                CCA1.Nombre = "Lagrimeo excesivo";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();

            //Perdida audicion
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 8;
            if (!string.IsNullOrEmpty(collection["PA"]))
            {
                CCA1.Nombre = "Perdida audicion";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Vertigo
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 8;
            if (!string.IsNullOrEmpty(collection["Vertigo"]))
            {
                CCA1.Nombre = "Vertigo";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();

            //Sangrado de nariz
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 8;
            if (!string.IsNullOrEmpty(collection["sangradoN"]))
            {
                CCA1.Nombre = "Sangrado de nariz";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();
            //Ronquidos
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 8;
            if (!string.IsNullOrEmpty(collection["Ronquidos"]))
            {
                CCA1.Nombre = "Ronquidos";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();

            //Perdida control de vejiga
            //CCA1.ID_Atleta = Convert.ToInt32(collection["txt_atleta"]);
            CCA1.ID_Condiciones_Clinicas_Actuales = 9;
            if (!string.IsNullOrEmpty(collection["PCVe"]))
            {
                CCA1.Nombre = "Perdida control de vejiga";
                CCA1.Valor = "Si";
            }
            else
            {

            }
            db.Condiciones_Clinicas_Actuales_Principal.Add(CCA1);
            db.SaveChanges();


            return Redirect("~/HomeAdmin/");
           
        }
        public ActionResult Actualizar()
        {
            return View();
        }
    }
}