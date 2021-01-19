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
        JahreUrlaubDBEntitiess _db;
        public StatusController()
        {
            _db = new JahreUrlaubDBEntitiess();
        }
        public ActionResult Index()
        {
            var list = _db.Events.ToList();
            return View(list);
        }
    }
}