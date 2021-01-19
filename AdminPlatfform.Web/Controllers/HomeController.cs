using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPlatfform.Web.Controllers
{
    /// <summary>
    ///  Controller indem wirde die View von HomePage zurückgegeben 
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}