using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final.Models;

namespace Final.Areas.Admin.Controllers
{
    public class FOOTERsController : Controller
    {
        private coza_storeEntities7 db = new coza_storeEntities7();

        // GET: Admin/FOOTERs
        public ActionResult Index()
        {
            ViewBag.categor = "áo";
            return View(db.FOOTERs.ToList());
        }

        // GET: Admin/FOOTERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOTER fOOTER = db.FOOTERs.Find(id);
            if (fOOTER == null)
            {
                return HttpNotFound();
            }
            return View(fOOTER);
        }

        // GET: Admin/FOOTERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FOOTERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,DETAIL,META,HIDE,ORDER,DATE_BEGIN")] FOOTER fOOTER)
        {
            if (ModelState.IsValid)
            {
                db.FOOTERs.Add(fOOTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fOOTER);
        }

        // GET: Admin/FOOTERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOTER fOOTER = db.FOOTERs.Find(id);
            if (fOOTER == null)
            {
                return HttpNotFound();
            }
            return View(fOOTER);
        }

        // POST: Admin/FOOTERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,DETAIL,META,HIDE,ORDER,DATE_BEGIN")] FOOTER fOOTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fOOTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fOOTER);
        }

        // GET: Admin/FOOTERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOTER fOOTER = db.FOOTERs.Find(id);
            if (fOOTER == null)
            {
                return HttpNotFound();
            }
            return View(fOOTER);
        }

        // POST: Admin/FOOTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FOOTER fOOTER = db.FOOTERs.Find(id);
            db.FOOTERs.Remove(fOOTER);
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
