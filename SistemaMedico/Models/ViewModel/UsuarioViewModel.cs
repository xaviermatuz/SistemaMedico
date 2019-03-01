using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaMedico.Models.ViewModel
{
    public class UsuarioViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Contraseña { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        public Nullable<int> ID_Rol { get; set; }
        public bool Activo { get; set; }
    }

}