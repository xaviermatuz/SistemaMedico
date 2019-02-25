using SistemaMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

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
        //public ActionResult Auth(SistemaMedico.Models.Usuario usermodel)
        //{
        //    using (MeSysEntities db = new MeSysEntities())
        //    {
        //        string Pwd = SHA256(usermodel.Contraseña);
        //        var obj = db.Usuarios.Where(a => a.Correo.Equals(usermodel.Correo) && a.Contraseña.Equals(Pwd)).FirstOrDefault();
        //        if (usermodel.Correo == null && usermodel.Contraseña == null)
        //        {
        //            usermodel.LoginErrorMessage = "Correo y Contraseña no pueden estar vacios";
        //            return View("Index", usermodel);
        //        }
        //        else
        //        {
        //            if (usermodel.Correo == null)
        //            {
        //                //usermodel.LoginErrorMessage += "Campo Correo No puede estar vacio";
        //                //mensajes += "Campo Correo No puede estar vacio";
        //                usermodel.LoginErrorMessage = "Campo Correo No puede estar vacio";
        //                return View("Index", usermodel);
        //            }
        //            else if (usermodel.Contraseña == null)
        //            {
        //                //usermodel.LoginErrorMessage += "Campo Contraseña No puede estar vacio"; 
        //                usermodel.LoginErrorMessage = "Campo Contraseña No puede estar vacio";
        //                return View("Index", usermodel);
        //            }
        //            else
        //            {
        //                //Session["ID"] = obj.ID;
        //                //Session["Nombre"] = obj.Nombre;
        //                //Session["Correo"] = obj.Correo;
        //                //return RedirectToAction("Index", "Home");
        //                if (obj != null)
        //                {
        //                    if (obj.ID_Rol.ToString() == Convert.ToString("1"))
        //                    {
        //                        Session["UserID"] = obj.ID.ToString();
        //                        Session["UserName"] = obj.Nombre.ToString();
        //                        Session["Rol"] = obj.ID_Rol.ToString();
        //                        return RedirectToAction("Index", "Home");
        //                    }
        //                    else if (obj.ID_Rol.ToString() == Convert.ToString("2"))
        //                    {
        //                        Session["UserID"] = obj.ID.ToString();
        //                        Session["UserName"] = obj.Nombre.ToString();
        //                        return RedirectToAction("View", "Home");
        //                    }
        //                    //Session["UserID"] = obj.UserId.ToString();
        //                    //Session["UserName"] = obj.UserName.ToString();
        //                    //return RedirectToAction("UserDashBoard");
        //                }
        //            }
        //        }
        //        //var userDetails = db.Usuarios.Where(x => x.Correo == usermodel.Correo && x.Contraseña == usermodel.Contraseña).FirstOrDefault();
        //        //if (usermodel.Correo == null && usermodel.Contraseña == null)
        //        //{
        //        //    usermodel.LoginErrorMessage = "Correo y Contraseña no pueden estar vacios";
        //        //    return View("Index", usermodel);
        //        //}
        //        //else
        //        //{
        //        //    if (usermodel.Correo == null)
        //        //    {
        //        //        //usermodel.LoginErrorMessage += "Campo Correo No puede estar vacio";
        //        //        //mensajes += "Campo Correo No puede estar vacio";
        //        //        usermodel.LoginErrorMessage = "Campo Correo No puede estar vacio";
        //        //        return View("Index", usermodel);
        //        //    }
        //        //    else if (usermodel.Contraseña == null)
        //        //    {
        //        //        //usermodel.LoginErrorMessage += "Campo Contraseña No puede estar vacio"; 
        //        //        usermodel.LoginErrorMessage = "Campo Contraseña No puede estar vacio";
        //        //        return View("Index", usermodel);
        //        //    }
        //        //    else
        //        //    {
        //        //        Session["ID"] = userDetails.ID;
        //        //        Session["Nombre"] = userDetails.Nombre;
        //        //        Session["Correo"] = userDetails.Correo;
        //        //        return RedirectToAction("Index", "Home");
        //        //    }
        //        //}

        //    }
        //    return View(usermodel);
        //}
        //public static string SHA256(string str)
        //{
        //    SHA256 sha256 = SHA256Managed.Create();
        //    ASCIIEncoding encoding = new ASCIIEncoding();
        //    byte[] stream = null;
        //    StringBuilder sb = new StringBuilder();
        //    stream = sha256.ComputeHash(encoding.GetBytes(str));
        //    for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
        //    return sb.ToString();
        //}
        [ValidateAntiForgeryToken]
        public ActionResult Auth(Usuario usermodel)
        {
            if (ModelState.IsValid)
            {
                using (MeSysEntities db = new MeSysEntities())
                {
                    string Pwd = SHA256(usermodel.Contraseña);
                    var obj = db.Usuarios.Where(a => a.Correo.Equals(usermodel.Correo) && a.Contraseña.Equals(Pwd)).FirstOrDefault();
                    if (usermodel.Correo == null && usermodel.Contraseña == null)
                    {
                        usermodel.LoginErrorMessage = "Correo y Contraseña no pueden estar vacios";
                        return View("Index", usermodel);
                    }
                    else
                    {
                        if (usermodel.Correo == null)
                        {
                            //usermodel.LoginErrorMessage += "Campo Correo No puede estar vacio";
                            //mensajes += "Campo Correo No puede estar vacio";
                            usermodel.LoginErrorMessage = "Campo Correo No puede estar vacio";
                            return View("Index", usermodel);
                        }
                        else if (usermodel.Contraseña == null)
                        {
                            //usermodel.LoginErrorMessage += "Campo Contraseña No puede estar vacio"; 
                            usermodel.LoginErrorMessage = "Campo Contraseña No puede estar vacio";
                            return View("Index", usermodel);
                        }
                        else
                        {
                            //Session["ID"] = obj.ID;
                            //Session["Nombre"] = obj.Nombre;
                            //Session["Correo"] = obj.Correo;
                            //return RedirectToAction("Index", "Home");
                            if (obj != null)
                            {
                                if (obj.ID_Rol.ToString() == Convert.ToString("1"))
                                {
                                    Session["ID"] = obj.ID.ToString();
                                    Session["Nombre"] = obj.Nombre.ToString();
                                    Session["ID_Rol"] = obj.ID_Rol.ToString();
                                    Session["Correo"] = obj.Correo.ToString();
                                    return View("~/Views/Home/Index.cshtml");
                                }
                                else if (obj.ID_Rol.ToString() == Convert.ToString("2"))
                                {
                                    Session["ID"] = obj.ID.ToString();
                                    Session["Nombre"] = obj.Nombre.ToString();
                                    Session["ID_Rol"] = obj.ID_Rol.ToString();
                                    Session["Correo"] = obj.Correo.ToString();
                                    return View("~/Views/Home/View.cshtml");
                                }
                                //Session["UserID"] = obj.UserId.ToString();
                                //Session["UserName"] = obj.UserName.ToString();
                                //return RedirectToAction("UserDashBoard");
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
            //int userId = (int)Session["ID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
