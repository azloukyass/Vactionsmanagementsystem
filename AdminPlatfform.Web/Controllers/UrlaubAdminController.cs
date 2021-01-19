using AdminPlatfform.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdminPlatfform.Web.Controllers
{
    /// <summary>
    /// Controller indem wirde die Geschäftslogik der Bearbeitung einen Antrag implementiert 
    /// </summary>
    public class UrlaubAdminController : Controller
    {
        AdminEntities _db; 
        // GET: UrlaubAdmin
        public UrlaubAdminController()
        {
            _db = new AdminEntities(); 
        }
        /// <summary>
        /// Suche Option in Index List bei Admin , um nach bestimmt Antrag zu suchen
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index(String searchString)
        {
            ViewData["Getdetails"] = searchString;
            var modelquery = from x in _db.Events select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                modelquery = modelquery.Where(x => x.Subject.Contains(searchString)|| x.Subject.Contains(searchString));
            }
            return View(await modelquery.AsNoTracking().ToListAsync());
        }
        /// <summary>
        /// Einfach Action gibt List als View zurück
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var list= _db.Events.ToList();
            return View(list);
        }
        /// <summary>
        /// Edit der Anträge  
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }
        /// <summary>
        /// Methode gibt alle Urlaubs (Events) als JSON zurück
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEvents()
        {
            using (AdminEntities dc = new AdminEntities())
            {
                var events = dc.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        /// <summary>
        /// POST Methode um die Urlaub abzuspeichern 
        /// Urlaub wird als Event abgelegt 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;
            using (AdminEntities dc = new AdminEntities())
            {
                if (e.EventID > 0)
                {
                    ///Update Urlaub
                    var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Events.Add(e);
                }

                dc.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        /// <summary>Löschen der Urlaub </summary>
        /// <param name="EventID">Primary Key jeder Urlaub .</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteEvent(int EventID)
        {
            /// <summary>
            /// Implementierung der DeleteEvent Methode
            /// </summary>
            /// <returns></returns>
            

            var status = false;
            using (AdminEntities dc = new AdminEntities())
            {
                var v = dc.Events.Where(a => a.EventID == EventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}

    
