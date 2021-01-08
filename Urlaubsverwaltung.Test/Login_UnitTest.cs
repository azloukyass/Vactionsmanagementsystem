using AdminPlatfform.Web.Models;
using JahresUrlaub.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using UserReg.Controllers;

namespace Urlaubsverwaltung.Test
{
    public class Tests
    {
        [TestMethod]
        public void LogOnTest1()
        {
            LoginController Controller = new LoginController();

            BenutzerEntities benutzerEntities = new BenutzerEntities();
            AdminPlatfform.Web.Models.Benutzer benutzer = new AdminPlatfform.Web.Models.Benutzer();
            benutzer.Username = "testuser"; 
            benutzer.passwordUser = "test1234";

            if (Controller. == null)
            {
                controller.MembershipService = new AccountMembershipService();
            }

            if (controller.FormsService == null)
            {
                controller.FormsService = new FormsAuthenticationService();
            }

            var result = controller.LogOn(logonModel, "") as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }
    }
}