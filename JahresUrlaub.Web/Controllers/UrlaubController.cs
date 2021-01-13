
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JahresUrlaub.Web.Controllers
{
    public class UrlaubController : Controller
    {
        // GET: Home
        /// <summary>
        ///   <para>GET : Home DataEvent for Calendar</para>
        ///   <para>return View(); </para>
        /// </summary>
        

        
        public UrlaubController()
        {
       
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

      
        public JsonResult GetEvents()
        {
            using (JahreUrlaubDBEntitiess dc = new JahreUrlaubDBEntitiess())
            {
                
                        var events = dc.Events.ToList();
                        return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                  
             }
           
        }
        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;
            using (JahreUrlaubDBEntitiess dc = new JahreUrlaubDBEntitiess())
            {
                if (e.EventID > 0)
                {
                    ///Update the event
                    var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End= e.End;
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
            using (JahreUrlaubDBEntitiess dc = new JahreUrlaubDBEntitiess())
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
