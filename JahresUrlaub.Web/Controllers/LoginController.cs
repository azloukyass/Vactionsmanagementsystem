using JahresUrlaub.Web;
using JahresUrlaub.Web.Models;
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
        public ActionResult Autherize(Users userModel)
        {
            using (UserEntities db = new UserEntities())
            {
                var userDetails = db.Users.Where(x => x.Email== userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = " Bitte überprüfen Sie Ihre Daten nochmal";
                    return View("Index", userModel);
                }
                else
                   
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