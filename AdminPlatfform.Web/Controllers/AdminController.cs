using AdminPlatfform;
using AdminPlatfform.Web;
using AdminPlatfform.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserReg.Controllers
{
    public class AdminController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Admin_Geschäftfuehrer AdminModel)
        {
            using (AdminEntities db = new AdminEntities())
            {
                var userDetails = db.Admin_Geschäftfuehrer.Where(x => x.Username == AdminModel.Username && x.Password== AdminModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    AdminModel.LoginErrorMessage = "Überprüfen Sie Ihre Daten nach bitte ! ";
                    return View("Index", AdminModel);
                }
                else
                    return View("~/Views/FirstLayout/Index.cshtml", AdminModel);
            }
        }
    }
}