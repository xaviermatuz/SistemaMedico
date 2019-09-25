using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaMedico.Models.ViewModel
{
    public class MostrarViewModel
    {
        //public Datos_Atleta DA { get; set; }
        //public Alergias alergia { get; set; }
        public int ID { get; set; }
        public string Foto { get; set; }
        public string Primer_Nombre { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Nombre_Completo { get; set; }
        public Nullable<int> Edad { get; set; }
        public Nullable<System.DateTime> Fecha_De_Registro { get; set; }
        public string Genero { get; set; }
        public string Numero_De_Cedula { get; set; }
        public string Correo_Electronico { get; set; }
        public string Telefono_Convencional { get; set; }
        public string Telefono_Celular { get; set; }
        public string Tiene_Seguro { get; set; }
        public string Hospital { get; set; }
        public string Dirreccion { get; set; }
        public int Municipio { get; set; }
        public string Nombre_Madre { get; set; }
        public string Telefono_Madre { get; set; }
        public string Nombre_Padre { get; set; }
        public string Telefono_Padre { get; set; }
        public string Emergencia { get; set; }
        public string Dirreccion_Emergencia { get; set; }
        public string Embarazo { get; set; }
        public Nullable<bool> Activo { get; set; }

    }
}