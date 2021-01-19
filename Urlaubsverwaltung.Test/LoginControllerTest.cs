using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using UserReg.Controllers;

namespace Urlaubsverwaltung.Test
{
    /// <summary>
    /// UnitTest für Login-Geschäftslogik 
    /// </summary>
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange 
            LoginController controller = new LoginController();
            // Act 
            ViewResult result = controller.Index() as ViewResult;
            // Assert 
            Assert.IsNotNull(result);
        }
    }
}
