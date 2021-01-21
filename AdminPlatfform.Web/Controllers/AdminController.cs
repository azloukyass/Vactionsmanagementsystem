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
    /// <summary>
    /// Die Controller wird die Logik von Login einem Admin in Anwnendung implementiert
    /// </summary>

    public class AdminController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Hier wurde die Daten bei Login wie Username und Password überprüft, ob es stimmt ist oder nicht 
        //  Hier wurde die Datenbank abgeruft um die Index zu holen.
        /// </summary>
        /// <param name="AdminModel"></param>
        /// <returns></returns>
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
                  Session["UserID"] = userDetails.Admin_id;
                return View("~/Views/FirstLayout/Index.cshtml", AdminModel);
            }
        }
    }
}