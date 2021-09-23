
using JahresUrlaub.Web.Models;
using Limilabs.Client.SMTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace JahresUrlaub.Web.Controllers
{
    public class UrlaubController : Controller
    {
        // GET: Home
        /// <summary>
        ///   <para>GET : Home DataEvent für Kalender</para>
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
        public JsonResult GetUrlaubs()
        {
            using (EventsEntities dc = new EventsEntities())
            {   
                        var urlaubs = dc.Events.ToList();
                        return new JsonResult { Data = urlaubs, JsonRequestBehavior = JsonRequestBehavior.AllowGet };          
             }
           
        }
        [HttpPost]
        public JsonResult SaveUrlaub(Events e)
        {
            var status = false;
            using (EventsEntities dc = new EventsEntities())
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
                SendVerificationLinkEmail();

                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
        [NonAction]
        public void SendVerificationLinkEmail()
        {
            string email = "azlouknourddin@gmail.com"; // Email_Chef
            
            var fromEmail = new MailAddress("azlouknour@gmail.com", "Urlaubsverwaltung");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "testpassword";
            string subject = "Neuer Antrag ist eingegangen!";
            string body = "<br/><br/> In Ihrem Urlaubsverwaltungskonto ist ein neuer Urlaubsantrag Ihres Mitarbeiters eingegangen." +
                "<br/><br/>"+
                "Mit freundlichen Grüßen";
                
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
        /// <summary>Deletes the event.</summary>
        /// <param name="EventID">The event identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteUrlaub(int EventID)
        {
            /// <summary>
            /// Implements the DeleteEvent method.
            /// </summary>
            /// <returns>Memeful Comments</returns>
            /// <image url="https://media.giphy.com/media/Ca7gy6EZqdH32/giphy.gif" scale="0.3" />

            var status = false;
            using (EventsEntities dc = new EventsEntities())
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
