using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaMedico.Models.ViewModel
{
    public class Actualizar
    {       
        public Datos_Atleta DA { get; set; }
        public Historial_Medico HM { get; set; }
        public Historia_Familiar HF { get; set; }
        public Aparato_Locomotor AL { get; set; }
        public Carrera_Deportiva CD { get; set; }
        public Carrera_Deportiva_Evento CDE { get; set; }
        public Carrera_Deportiva_Familiar CDF { get; set; }
        public Situacion_Laboral SL { get; set; }
        public Apoyo_Economico AE { get; set; }
        public Informacion_Familiar IF { get; set; }
        public Educacion ED { get; set; }
        public Medicamentos ME { get; set; }
        public Habitos HATOS { get; set; }
        public Habitacion HACION { get; set; }
        public Alergias ALAS { get; set; }
        //public List<Element> Elements { get; set; }
    }

}