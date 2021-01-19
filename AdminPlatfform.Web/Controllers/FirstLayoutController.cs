using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPlatfform.Web.Controllers
{
    /// <summary>
    /// Controller für Erste Page nach einloggen . hat nur eine einfach Action 
    /// </summary>
    public class FirstLayoutController : Controller
    {
        // GET: FirstLayout
        public ActionResult Index()
        {
            return View();
        }
    }
}