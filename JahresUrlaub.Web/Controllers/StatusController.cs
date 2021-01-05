using JahresUrlaub.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace JahresUrlaub.Web.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
       
        JahreUrlaubDBEntitiess _db; 
        public StatusController()
        {
            _db = new JahreUrlaubDBEntitiess(); 
        }
      

        // GET:Status 
        public ActionResult Index()
        {
            var list = _db.Events.ToList();
            return View(list);
        }
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
    }
}