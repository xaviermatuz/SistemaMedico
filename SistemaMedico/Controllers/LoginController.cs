using SistemaMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaMedico.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Auth(Usuarios usermodel)
        {
            if (ModelState.IsValid)
            {
                using (MeSysEntities db = new MeSysEntities())
                {
                    string Pwd = SHA256(usermodel.Contraseña);
                    var obj = db.Usuarios.Where(a => a.Correo.Equals(usermodel.Correo) && a.Contraseña.Equals(Pwd)).FirstOrDefault();
                    if (usermodel.Correo == null && usermodel.Contraseña == null)
                    {
                        //usermodel.LoginErrorMessage = "Correo y Contraseña no pueden estar vacios";
                        return View("Index", usermodel);
                    }
                    else
                    {
                        if (usermodel.Correo == null)
                        {
                            //usermodel.LoginErrorMessage = "Campo Correo No puede estar vacio";
                            return View("Index", usermodel);
                        }
                        else if (usermodel.Contraseña == null)
                        {
                            //usermodel.LoginErrorMessage = "Campo Contraseña No puede estar vacio";
                            return View("Index", usermodel);
                        }
                        else
                        {
                            if (obj != null)
                            {
                                if (obj.ID_Rol.ToString() == Convert.ToString("1"))
                                {
                                    Session["ID"] = obj.ID.ToString();
                                    Session["Nombre"] = obj.Nombre.ToString();
                                    Session["ID_Rol"] = obj.ID_Rol.ToString();
                                    Session["Correo"] = obj.Correo.ToString();                                    
                                    //FormsAuthentication.SetAuthCookie(obj.ID_Rol.ToString(), false);
                                    return Redirect("~/HomeAdmin/");
                                }
                                else if (obj.ID_Rol.ToString() == Convert.ToString("2"))
                                {
                                    Session["ID"] = obj.ID.ToString();
                                    Session["Nombre"] = obj.Nombre.ToString();
                                    Session["ID_Rol"] = obj.ID_Rol.ToString();
                                    Session["Correo"] = obj.Correo.ToString();
                                    return View("~/Views/HomeAdmin/Vista.cshtml");
                                }
                            }
                        }
                    }

                }
            }
            return View(usermodel);
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

        public ActionResult LogOut()
        {           
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
