using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final.Models;

namespace Final.Areas.Admin.Controllers
{
    public class SLIDERsController : Controller
    {
        private coza_storeEntities7 db = new coza_storeEntities7();

        // GET: Admin/SLIDERs
        public ActionResult Index()
        {
            return View(db.SLIDERs.ToList());
        }

        // GET: Admin/SLIDERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDER sLIDER = db.SLIDERs.Find(id);
            if (sLIDER == null)
            {
                return HttpNotFound();
            }
            return View(sLIDER);
        }

        // GET: Admin/SLIDERs/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,IMG,DESCRIPTION,META,HIDE,ORDER,DATE_BEGIN,TITLE")] SLIDER sLIDER, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    filename = DateTime.Now.ToString("dd-MM-yy-") + img.FileName;
                    path = Path.Combine(Server.MapPath("~/images"), filename);
                    img.SaveAs(path);
                    sLIDER.IMG = filename;
                }
                else
                {
                    sLIDER.IMG = "slide-03.jpg";
                }

                db.SLIDERs.Add(sLIDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sLIDER);
        }

        // GET: Admin/SLIDERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDER sLIDER = db.SLIDERs.Find(id);
            if (sLIDER == null)
            {
                return HttpNotFound();
            }
            return View(sLIDER);
        }

        // POST: Admin/SLIDERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,IMG,DESCRIPTION,META,HIDE,ORDER,DATE_BEGIN,TITLE")] SLIDER sLIDER, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            SLIDER temp = getByid(sLIDER.ID);
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    filename = DateTime.Now.ToString("dd-MM-yy-") + img.FileName;
                    path = Path.Combine(Server.MapPath("~/images"), filename);
                    img.SaveAs(path);
                    temp.IMG = filename;
                }
                else
                {
                    temp.IMG = sLIDER.IMG;
                }
                temp.DESCRIPTION = sLIDER.DESCRIPTION;
                temp.META = sLIDER.META;
                temp.HIDE = sLIDER.HIDE;
                temp.ORDER = sLIDER.ORDER;
                temp.DATE_BEGIN = sLIDER.DATE_BEGIN;
                temp.TITLE = sLIDER.TITLE;
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sLIDER);
        }

        // GET: Admin/SLIDERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDER sLIDER = db.SLIDERs.Find(id);
            if (sLIDER == null)
            {
                return HttpNotFound();
            }
            return View(sLIDER);
        }

        // POST: Admin/SLIDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SLIDER sLIDER = db.SLIDERs.Find(id);
            db.SLIDERs.Remove(sLIDER);
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

        public SLIDER getByid(long id)
        {
            return db.SLIDERs.Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
