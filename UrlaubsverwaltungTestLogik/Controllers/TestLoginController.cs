using JahresUrlaub.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlaubsverwaltungTestLogik.Controllers
{
    public class TestLoginController : Controller
    {
        // Registrion Action 
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        // Registration POST Action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] Users users)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {
                //Email is alerdy Exist
                #region Generate Actiovation Code 
                var isExist = IsEmailExist(users.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email bereit raus");
                    return View(users);
                }

                users.ActivationCode = Guid.NewGuid();
                #endregion 
                #region Password Hashing 
                users.Password = Crypto.Hash(users.Password);
                users.ConfirmPassword = Crypto.Hash(users.ConfirmPassword); // 
                #endregion
                users.IsEmailVerified = false;
                #region Save to Database 
                using (UserEntities dc = new UserEntities())
                {
                    dc.Users.Add(users);
                    dc.SaveChanges();

                    //send Email to user 
                    SendVerificationLinkEmail(users.Email, users.ActivationCode.ToString());
                    message = "Registration erfolgreich Konto Aktiviation Link" +
                        " Email wurd an Ihre Email breits gesendet" + users.Email;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid Request";
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
        //Verif Email 

        // Verfiy Email LINK

        //Login 

        //Login POST

        //LOgout

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
            var verifyUrl = "/Users/VerifyAccount/" + activiationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("azlouknour@gmail.com", "Urlaubsverwaltung");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "ronldocaaz1920AZ";
            string subject = "Ihr Konto breits erfolgreich gestellt Danke Ihnen";
            string body = "<br/><br/> freuen wir uns auf Ihre Registieren bitte Link Sie auf Link" +
                "um das Konto erfolgreich zu aktivieren " +
                "<br/><br/><a href='" + link + "'>" + link + "</a>";
            var smtp = new SmtpClient
            {
                Host = "smpt.gmail.com",
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