using AdminPlatfform.Web.Models;
using JahresUrlaub.Web;
using NUnit.Framework;

namespace Urlaubsverwaltung.Test
{
    public class Tests
    {
        [Test]
        public void ShouldAuthenticateValidUser()
        {
            BenutzerEntities db = new BenutzerEntities();
            var service = new AuthenticationService(db);

            db("Name", "Password");

            Assert.IsTrue(service.DoLogin("Name", "Password"));

            //Ensure data access layer was used
            Assert.IsTrue(mockDa.GetUserFromDBWasCalled);
        }

        [Test]
        public void ShouldNotAuthenticateUserWithInvalidPassword()
        {
            IMyMockDa mockDa = new MockDataAccess();
            var service = new AuthenticationService(mockDa);

            mockDa.AddUser("Name", "Password");

            Assert.IsFalse(service.DoLogin("Name", "BadPassword"));

            //Ensure data access layer was used
            Assert.IsTrue(mockDa.GetUserFromDBWasCalled);
        }
    }
}