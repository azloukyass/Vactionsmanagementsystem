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
    public class StatusController : Controller
    {
        // GET: Status

        EventsEntities _db;
        public StatusController()
        {
            _db = new EventsEntities();
        }
        // GET:Status 
        [HttpGet]
        public async Task<ActionResult> Index(String searchString)
        {
            ViewData["Getdetails"] = searchString;
            var modelquery = from x in _db.Events select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                modelquery = modelquery.Where(x => x.Subject.Contains(searchString));
            }
            return View(await modelquery.AsNoTracking().ToListAsync());
        }
        /// <summary>
        /// Einfach Action gibt List als View zurück
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string para)
        {

            var test = _db.Events.Where(x => x.Subject == para).ToList();
            if (test != null)
            {
                return View("Index",test);
            }
            return View("Index");
        }
        // GET: Status 
        public ActionResult Status()
        {
            return View();
        }
    }
}