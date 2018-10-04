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
    public class questionersController : Controller
    {
        private QuestionModel db = new QuestionModel();

        // GET: questioners
        public ActionResult Index()
        {
            return View(db.questioner.ToList());
        }

        // GET: questioners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            questioner questioner = db.questioner.Find(id);
            if (questioner == null)
            {
                return HttpNotFound();
            }
            return View(questioner);
        }

        // GET: questioners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: questioners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "questioner_id,first_name,last_name,phone_number,email_addres")] questioner questioner)
        {
            if (ModelState.IsValid)
            {
                db.questioner.Add(questioner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questioner);
        }

        // GET: questioners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            questioner questioner = db.questioner.Find(id);
            if (questioner == null)
            {
                return HttpNotFound();
            }
            return View(questioner);
        }

        // POST: questioners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "questioner_id,first_name,last_name,phone_number,email_addres")] questioner questioner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questioner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questioner);
        }

        // GET: questioners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            questioner questioner = db.questioner.Find(id);
            if (questioner == null)
            {
                return HttpNotFound();
            }
            return View(questioner);
        }

        // POST: questioners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            questioner questioner = db.questioner.Find(id);
            db.questioner.Remove(questioner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
