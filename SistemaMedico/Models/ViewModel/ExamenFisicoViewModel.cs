using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaMedico.Models.ViewModel
{
    public class ExamenFisicoViewModel
    {
       
        public int ID_Atleta { get; set; }
        public int ID_Examen_Fisico { get; set; }
        public bool Normal { get; set; }
        public string Hallazgos_Anormales { get; set; }
    }
}