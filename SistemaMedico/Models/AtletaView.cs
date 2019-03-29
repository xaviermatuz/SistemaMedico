using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SistemaMedico.Models
{
    [DataContract(IsReference = true)]
    public class AtletaView
    {


        public int ID { get; set; }
        public string Foto { get; set; }
        [Display(Name = "Foto Atleta")]
        public HttpPostedFileBase ImageFile { get; set; }
        public string Primer_Nombre { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Nombre_Completo { get; set; }
        public Nullable<int> Edad { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha_De_Registro { get; set; }
        public string Genero { get; set; }
        public string Numero_De_Cedula { get; set; }
        public string Correo_Electronico { get; set; }
        [StringLength(14, ErrorMessage = "Tamaño maximo 14 caracteres")]
        public string Telefono_Convencional { get; set; }
        [StringLength(14, ErrorMessage = "Tamaño maximo 14 caracteres")]
        public string Telefono_Celular { get; set; }
        [Required]
        public string Tiene_Seguro { get; set; }
        public int Hospital { get; set; }
        public string Dirreccion { get; set; }
        public int Municipio { get; set; }
        public string Nombre_Madre { get; set; }
        public string Telefono_Madre { get; set; }
        public string Nombre_Padre { get; set; }
        public string Telefono_Padre { get; set; }
        public string Emergencia { get; set; }
        public string Dirreccion_Emergencia { get; set; }
        [StringLength(7, ErrorMessage = "Tamaño maximo 7 caracteres")]
        public string Embarazo { get; set; }

        public List<Atleta_Categoria> categorias { get; set; }

    }
}