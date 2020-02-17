using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notepad.Models.Entity;
namespace Notepad.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        DBNOTEPADEntities1 db = new DBNOTEPADEntities1();
        public ActionResult Index()
        {
            var values = db.TBLCONTENT.ToList();
            return View(values);
        }

        //Add Notes 
        [HttpGet]
        public ActionResult AddNotes()
        {
            List<SelectListItem> valueAuthors = (from i in db.TBLPERSONAL.ToList()
                    select new SelectListItem
                    {
                        Text = i.Name + ' ' + i.Surname,

                        Value = i.Id.ToString()
                    }).ToList();
            ViewBag.val2 = valueAuthors;
            return View();
        }

        [HttpPost]
        public ActionResult AddNotes(TBLCONTENT notes)
        {
          
            var prs = db.TBLPERSONAL.Where(c => c.Id == notes.TBLPERSONAL.Id).FirstOrDefault();
            notes.TBLPERSONAL = prs;
            db.TBLCONTENT.Add(notes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete Notes
        public ActionResult DeleteNotes(int id)
        {
            var values = db.TBLCONTENT.Find(id);
            db.TBLCONTENT.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET & UPDATE
        public ActionResult GetNotes(int id)
        {
            var values = db.TBLPERSONAL.Find(id);
            return View("GetPersonal", values);
        }
        public ActionResult UpdateNotes(TBLCONTENT p)
        {
            var values = db.TBLCONTENT.Find(p.Id);
            values.Theme = p.Theme;
            values.Details = p.Details;
            values.Personal = p.Personal;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}