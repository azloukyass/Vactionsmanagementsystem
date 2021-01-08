
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JahresUrlaub.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string username)
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else return View();
           
        }
    }
        
}
