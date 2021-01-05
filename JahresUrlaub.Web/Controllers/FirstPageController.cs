using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JahresUrlaub.Web.Controllers
{
    public class FirstPageController : Controller
    {


     
        // GET: FirstPage
        public ActionResult Index()
        {
            return View();
        }
    }
}