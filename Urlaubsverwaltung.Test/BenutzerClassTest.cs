using AdminPlatfform.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Urlaubsverwaltung.Test
{
    /// <summary>
    /// UnitTest um die Benutzer Models zu testen 
    /// </summary>
    [TestClass]
    public class BenutzerClassTest
    {
        [TestMethod]
        public void Test()
        {
            Benutzer benutzer = new Benutzer();
            Assert.AreEqual("Yassine", benutzer.Username);
            Assert.AreEqual("Azlouk", benutzer.Vorname);
        }
    }
}
