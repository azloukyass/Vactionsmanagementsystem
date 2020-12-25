using JahresUrlaub.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UserReg.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Benutzer userModel)
        {
            using (BenutzerEntities db = new BenutzerEntities())
            {
                var userDetails = db.Benutzer.Where(x => x.Username == userModel.Username && x.passwordUser == userModel.passwordUser).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = " Falsch Username oder Password";
                    return View("Index", userModel);
                }
                else
                    return View("~/Views/FirstPage/Index.cshtml", userModel);
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}