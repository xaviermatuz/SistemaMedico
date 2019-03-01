using SistemaMedico.Models;
using SistemaMedico.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaMedico.Controllers
{
    public class HomeAdminController : Controller
    {
        DAL objdal = new DAL();
        public MeSysEntities db = new MeSysEntities();
        // GET: Home
        // [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Usuario> User = db.Usuarios.ToList();
            ViewBag.Usuario = User;
            return View();
        }
        public ActionResult Editar(int id)
        {
            Usuario model = new Usuario();
            var otabla = db.Usuarios.Find(id);
            model.ID = otabla.ID;
            model.Nombre = otabla.Nombre;
            model.Correo = otabla.Correo;
            model.Contraseña = otabla.Contraseña;
            model.ID_Rol = otabla.ID_Rol;
            ViewBag.Nombre = model.Nombre;

            // string Rolesstring = "select * from Roles";
            // DataSet ds = new DataSet();
            // List<string> li = new List<string>();
            // DataTable dt = new DataTable();
            // dt = objdal.MyMethod(Rolesstring);
            // List<SelectListItem> Roles = new List<SelectListItem>();
            //// Roles.Add(new SelectListItem { Text = "--Seleccionar Rol--", Value = "0" });
            // foreach (DataRow row in dt.Rows)
            // {
            //     Roles.Add(new SelectListItem { Text = Convert.ToString(row.ItemArray[1]), Value = Convert.ToString(row.ItemArray[1]) });
            // }
            // ViewBag.Roles = Roles;
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(Usuario model)
        {
            var ousuario = db.Usuarios.Find(model.ID);
            ousuario.Nombre = model.Nombre;
            ousuario.Correo = model.Correo;
            ousuario.Contraseña = SHA256(model.Contraseña.ToString());
            ousuario.ID_Rol = model.ID_Rol;
            db.Entry(ousuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Redirect("~/HomeAdmin/");
        }
        public ActionResult Nuevo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(UsuarioViewModel model)
        {
            Usuario ousuario = new Usuario();
            ousuario.Nombre = model.Nombre;
            ousuario.Correo = model.Correo;
            ousuario.Contraseña = SHA256(model.Contraseña.ToString());
            ousuario.ID_Rol = model.ID_Rol;
            ousuario.Activo = true;
            db.Usuarios.Add(ousuario);
            db.SaveChanges();
            return Redirect("~/HomeAdmin/");
        }
        public static List<SelectListItem> GetDropDown()
        {
            MeSysEntities db1 = new MeSysEntities();
            List<SelectListItem> ls = new List<SelectListItem>();
            var lm = db1.Roles.ToList();
            foreach (var temp in lm)
            {
                ls.Add(new SelectListItem() { Text = temp.Rol, Value = temp.ID.ToString() });
            }
            return ls;
        }
        public static string SHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}