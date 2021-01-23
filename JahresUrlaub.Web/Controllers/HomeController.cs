
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JahresUrlaub.Web.Controllers
{ 
    /// <summary>
    /// Home Page für Ganz Anwendung
    /// </summary>
    public class HomeController : Controller
    {
       // GET:HOME
        public ActionResult Index()
        {
           return View();
        }
    }
}
