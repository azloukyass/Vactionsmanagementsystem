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
            if (Session["username"] != null)
            {
                return RedirectToAction("Index", "Home", new { username = Session["username"].ToString() });
            }
            else return View();

        }

        [HttpPost]
        public ActionResult Autherize(Benutzer userModel)
        {
            using (BenutzerEntities db = new BenutzerEntities())
            {
                var userDetails = db.Benutzer.Where(x => x.Username == userModel.Username && x.passwordUser == userModel.passwordUser).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = " Bitte überprüfen Sie Ihre Daten nochmal";
                    return View("Index", userModel);
                }
                else
                    Session["username"] = userModel.Username;
                return View("~/Views/FirstPage/Index.cshtml", userModel);
            }
        }
        public ActionResult LogOut()
        {
            Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }
    }
}