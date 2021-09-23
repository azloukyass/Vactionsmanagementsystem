using DocumentFormat.OpenXml.Wordprocessing;
using JahresUrlaub.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JahresUrlaub.Web.Controllers
{
    /// <summary>
    /// Registrieren Logik für neue Mitarbeiter 
    /// </summary>
    public class RegistierenController : Controller
    {
        UserEntities _db;
        public RegistierenController()
        {
            _db = new UserEntities();
        }
        // Registrion Action 
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        // Registration POST Action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Exclude = "IsEmailVerified,ActivationCode")] Users users)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {

                #region //Email is alerdy Exist 
                var isExist = IsEmailExist(users.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email bereit raus");
                    return View(users);
                }
                #endregion
                #region Generate Activation Code
                users.ActivationCode = Guid.NewGuid();
                #endregion

                #region Password Hashing 
                users.Password = Crypto.Hash(users.Password);
                users.ConfirmPassword = Crypto.Hash(users.ConfirmPassword); 
                #endregion
                users.IsEmailVerified = false;
                #region Save to Database 
                using (UserEntities _db = new UserEntities())
                {
                     
                    _db.Users.Add(users);
                    _db.SaveChanges();

                    //send Email to user 
                    SendVerificationLinkEmail(users.Email, users.ActivationCode.ToString());
                    message = "Registration erfolgreich Konto Aktiviation Link" +
                        " Email wurd an Ihre Email breits gesendet  " + users.Email;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Fehermeldung";
            }
            // Email is Bereits RAUS 

            // Generate Actiovation Code 
            // Password Hashing 

            // Save data to Database

            // Send Email to User 
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(users);
        }
        //Verif Account
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {   
            bool Status = false;
            using(UserEntities db = new UserEntities())
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var v = db.Users.Where(x => x.ActivationCode == new Guid(id)).FirstOrDefault();
                if(v!=null)
                {
                    v.IsEmailVerified = true;
                    db.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Fehlermeldung";
                }
            }
            ViewBag.Status = Status;
            return View();
        }
        // Verfiy Email LINK
        [NonAction]
        public bool IsEmailExist(string email)
        {
            using (UserEntities user = new UserEntities())
            {
                var v = user.Users.Where(a => a.Email == email).FirstOrDefault();
                return v != null;
            }
        }
        [NonAction]
        public void SendVerificationLinkEmail(string email, string activiationCode)
        {
            var verifyUrl = "/Registieren/VerifyAccount/" + activiationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("azlouknour@gmail.com", "Urlaubsverwaltung");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "testpassword"; 
            string subject = "Your account is successfully created!";
            string body = "<br/><br/>Wir freuen uns, Ihnen mitteilen zu können, dass Ihr Urlaubsverwaltung-Konto erfolgreich erstellt wurde." +
                " Bitte klicken Sie auf den folgenden Link, um Ihr Konto zu bestätigen" +
                " <br/><br/><a href='" + link + "'>" + link + "</a> ";
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
    }
}
