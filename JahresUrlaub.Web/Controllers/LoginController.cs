using JahresUrlaub.Web;
using JahresUrlaub.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UserReg.Controllers
{
    public class LoginController : Controller
    {
        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users Login)
        {
            string message = "";
            using (UserEntities db = new UserEntities())
            {
                var v = db.Users.Where(a => a.Email == Login.Email && a.Password==Login.Password).FirstOrDefault();
                if (v != null)
                {
                  Session["UserID"] = v.user_id;
                  Session["Lastname"] = v.Lastname.ToString(); 
                  return View("~/Views/FirstPage/Index.cshtml", Login);
                }
                else
                {
                   // v.LoginErrorMessage = "Überprüfen Sie mal Ihre Daten nach !";
                    return View("Login", Login);
                }
            }      
        }
        
        //LOgout
        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        // Part3- Forgot Password 
        public ActionResult ForgotPassword()
        {
            return View(); 
        }
        [NonAction]
        public void SendVerificationLinkEmail(string email, string activiationCode)
        {
            var verifyUrl = "/Login/ResetPassword/" + activiationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("azlouknour@gmail.com", "Urlaubsverwaltung");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "98438145A"; // Replace with actual password
            string subject = "Rest Password ";
            string body = "<br/><br/>Link für ändern Ihr Password" +
                " Klicken einach auf den Link Danke " +
                " <br/><br/><a href="+link+" >Rest Password Link </a> ";
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

        [HttpPost]
        public ActionResult ForgotPassword(string Email)
        {
            //Überprüfen Email 
            // Gererate Reset Password link
            // send Email 
            string message = "";
            bool status = false;
            using(UserEntities db= new UserEntities())
            {
                var account = db.Users.Where(a => a.Email == Email).FirstOrDefault();
                if(account!=null)
                {
                    // senden Email für Reset Password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.Email, resetCode);
                    account.ResetPasswordCode = resetCode;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    message = " Die link für neues Password wurde an Ihre Email gesendet";
                }
                else
                {
                    message = "Konto wurde nicht gefunden !"; 
                }
            }
            return View();
        }
        public ActionResult ResetPassword(string id)
        {
            //überprüfen die link von Reset Password 
            // inden konto mit Link 
            using (UserEntities dc = new UserEntities())
            {
                var user = dc.Users.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if(user!=null)
                {
                    ResetPassword model = new ResetPassword();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound(); 
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword( ResetPassword model)
        {
            var message = "";
            if(ModelState.IsValid)
            {
                using(UserEntities dc = new UserEntities())
                {
                    var user = dc.Users.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if(user!=null)
                    {
                        user.Password = model.NewPassword;
                        user.ResetPasswordCode = "";
                        dc.Configuration.ValidateOnSaveEnabled = false;
                        dc.SaveChanges();
                        message = "Password wurde geändert ";
                    }
                }
            }
            else
            {
                message = "Etwas fehlt noch !";
            }
            ViewBag.message = message;
            return View(model);
        }
    }
}
