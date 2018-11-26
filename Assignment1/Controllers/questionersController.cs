using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    [Authorize]
    public class questionersController : Controller
    {
        //disable db connection
        //private QuestionModel db = new QuestionModel();

        private IquestionersMock db;
        //default constructor
        public questionersController()
        {
            this.db = new EFAquestioners();
        }
        //mock constructor
        public questionersController(IquestionersMock mock)
        {
            this.db = mock;
        }

        // GET: questioners
        [AllowAnonymous]
        public ActionResult Index()
        {
            //return View(db.questioners.ToList());
            return View("Index", db.questioners.ToList());
        }
        [AllowAnonymous]
        // GET: questioners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //questioner questioner = db.questioner.Find(id);
            questioner questioner = db.questioners.SingleOrDefault(a => a.questioner_id == id);
            if (questioner == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View("Details", questioner);
        }

        // GET: questioners/Create
        public ActionResult Create()
        {
            //scaffold code

            ViewBag.first_name = new SelectList(db.questioners, "first_name", "first_name");
            ViewBag.last_name = new SelectList(db.questioners, "last_name", "last_name");

            return View("Create");
        }

        // POST: questioners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "questioner_id,first_name,last_name,phone_number,email_address")] questioner questioner)
        {
            if (ModelState.IsValid)
            {

                //db.questioner.Add(questioner);
                //db.SaveChanges();
                db.Save(questioner);
                return RedirectToAction("Index");
            }
            ViewBag.first_name = new SelectList(db.questioners, "first_name", "first_name", questioner.first_name);
            ViewBag.last_name = new SelectList(db.questioners, "last_name", "last_name", questioner.last_name);
            return View("Create", questioner);
        }

        // GET: questioners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //questioner questioner = db.questioner.Find(id);
            questioner questioner = db.questioners.SingleOrDefault(a => a.questioner_id == id);
            if (questioner == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            ViewBag.first_name = new SelectList(db.questioners.OrderBy(a => a.first_name), "first_name", "first_name", questioner.first_name);
            ViewBag.last_name = new SelectList(db.questioners.OrderBy(a => a.last_name), "last_name", "last_name", questioner.last_name);
            return View("Edit", questioner);
        }

        // POST: questioners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "questioner_id,first_name,last_name,phone_number,email_address")] questioner questioner)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(questioner).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(questioner);
                return RedirectToAction("Index");
            }
            ViewBag.first_name = new SelectList(db.questioners.OrderBy(a => a.first_name), "first_name", "first_name", questioner.first_name);
            ViewBag.last_name = new SelectList(db.questioners.OrderBy(a => a.last_name), "last_name", "last_name", questioner.last_name);
            return View("Edit", questioner);
        }

        // GET: questioners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //questioner questioner = db.questioner.Find(id);
            questioner questioner = db.questioners.SingleOrDefault(a => a.questioner_id == id);
            if (questioner == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View("Delete", questioner);
        }

        // POST: questioners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int? id)
        public ActionResult DeleteConfirmed(int? id)
        {
            //questioner questioner = db.questioner.Find(id);
            //db.questioner.Remove(questioner);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            questioner questioner = db.questioners.SingleOrDefault(a => a.questioner_id == id);

            if (questioner == null)
            {
                return View("Error");
            }
            else
            {

                db.Delete(questioner);

                return RedirectToAction("Index");
            }
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
