using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdminPlatfform.Web.Controllers
{
    public class UrlaubAdminController : Controller
    {
        AdminEntities _db; 
        // GET: UrlaubAdmin
        public UrlaubAdminController()
        {
            _db = new AdminEntities(); 
        }

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
        public ActionResult Index()
        {
            var list= _db.Events.ToList();
            return View(list);
        }
        public ActionResult Edit()
        {
            return View();
        }

       

        /// <summary>GetEvents : Buscar informação do evento</summary>
        public JsonResult GetEvents(Benutzer e, Events x)
        {
            using (AdminEntities dc = new AdminEntities())
            {
                var test = dc.Events.Where(x1 => x1.Subject == e.Personalnummer).ToList();
                if (e.Personalnummer == x.Subject)
                {
                    return new JsonResult { Data = test, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else return null;
            }
        }
        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;
            using (AdminEntities dc = new AdminEntities())
            {
                if (e.EventID > 0)
                {
                    ///Update the event
                    var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.EndDatum = e.EndDatum;
                        v.Description = e.Description;
                        v.Personalnummer = e.Personalnummer;
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

        /// <summary>Deletes the event.</summary>
        /// <param name="EventID">The event identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteEvent(int EventID)
        {
            /// <summary>
            /// Implements the DeleteEvent method.
            /// </summary>
            /// <returns>Memeful Comments</returns>
            /// <image url="https://media.giphy.com/media/Ca7gy6EZqdH32/giphy.gif" scale="0.3" />

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

    
