using JahresUrlaub.Web.Models;
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
        EventsEntities _db; 
        public FirstPageController()
        {
            _db = new EventsEntities(); 
        }
     
        // GET: FirstPage
        public ActionResult Index()
        {
            
            return View(); 
        }
        public JsonResult GetEvents()
        {
            using (EventsEntities dc = new EventsEntities())
            {

                var events = dc.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}