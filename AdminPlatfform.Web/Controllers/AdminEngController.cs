﻿using AdminPlatfform.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPlatfform.Web.Controllers
{
    public class AdminEngController : Controller
    {
        // GET: AdminEng
        AdminEntities _db;
        public AdminEngController()
        {
            _db = new AdminEntities();
        }
        public ActionResult List()
        {
            var test = _db.Benutzer.ToList();
            return View(test);
        }
        // GET: AdminEng
        public ActionResult Index()
        {
            return View();
        }
        // GET: AdminEng
        public ActionResult AddOrEdit(int id = 0)
        {
            Admin_Geschäftfuehrer userModel = new Admin_Geschäftfuehrer();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Admin_Geschäftfuehrer userModel)
        {
            using (AdminEntities model = new AdminEntities())
            {
                model.Admin_Geschäftfuehrer.Add(userModel);
                model.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful ";
            return View("AddOrEdit", new Admin_Geschäftfuehrer());
        }
    }
}