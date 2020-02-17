using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notepad.Models.Entity;

namespace Notepad.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal

        DBNOTEPADEntities db = new DBNOTEPADEntities();
        public ActionResult Index()
        {
            var values = db.TBLPERSONAL.ToList();
            return View(values);
        }

        //Add Personal 
        [HttpGet]
        public ActionResult AddPersonal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPersonal(TBLPERSONAL prs)
        {
            db.TBLPERSONAL.Add(prs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete Personal
        public ActionResult DeletePersonal(int id)
        {
            var values = db.TBLPERSONAL.Find(id);
            db.TBLPERSONAL.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET & UPDATE
        public ActionResult GetPersonal(int id)
        {
            var values = db.TBLPERSONAL.Find(id);
            return View("GetPersonal", values);
        }
        public ActionResult UpdatePersonal(TBLPERSONAL p)
        {
            var values = db.TBLPERSONAL.Find(p.Id);
            values.Name = p.Name;
            values.Surname = p.Surname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}