using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JahresUrlaub.Web.Controllers
{
    public class RegistierenController : Controller
    {
        BenutzerEntities _db;
        public RegistierenController()
        {
            _db = new BenutzerEntities();
        }
        public ActionResult List()
        {
            var test = _db.Benutzer.ToList();
            return View(test);
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        // GET: User
        public ActionResult AddOrEdit(int id = 0)
        {
            Benutzer userModel = new Benutzer();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Benutzer userModel)
        {
            using (BenutzerEntities model = new BenutzerEntities ())
            {
                model.Benutzer.Add(userModel);
                model.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful ";
            return View("AddOrEdit", new Benutzer());
        }
    }
}