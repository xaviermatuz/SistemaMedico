using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SistemaMedico.Models
{
    [DataContract(IsReference = true)]
    public class AtletaView
    {
        public Datos_Atleta Model { get; set; }

        [Display(Name = "Foto Atleta")]
        public HttpPostedFileBase ImageFile { get; set; }
    
       

       // public List<Atleta_Categoria> categorias { get; set; }
        public virtual Equipo_Deportivo equip { get; set; }
    }
}