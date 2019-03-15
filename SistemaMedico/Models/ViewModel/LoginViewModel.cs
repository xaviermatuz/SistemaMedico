using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaMedico.Models.ViewModel
{
    public class LoginViewModel
    {
        public int ID { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Contraseña { get; set; }
        [Required]
        public string Correo { get; set; }
        public Nullable<int> ID_Rol { get; set; }
        public Nullable<bool> Activo { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}