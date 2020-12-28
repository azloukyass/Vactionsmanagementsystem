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
                var userDetails = db.Benutzer.Where(x => x.Username == AdminModel.Username && x.passwordUser == AdminModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    AdminModel.LoginErrorMessage = " Falsch Username oder Password";
                    return View("Index", AdminModel);
                }
                else
                    return View("~/Views/FirstPage/Index.cshtml", AdminModel);
            }
        }
    }
}