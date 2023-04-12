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
    public class ABOUTsController : Controller
    {
        private coza_storeEntities7 db = new coza_storeEntities7();

        // GET: Admin/ABOUTs
        public ActionResult Index()
        {
            return View(db.ABOUTs.ToList());
        }

        // GET: Admin/ABOUTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABOUT aBOUT = db.ABOUTs.Find(id);
            if (aBOUT == null)
            {
                return HttpNotFound();
            }
            return View(aBOUT);
        }

        // GET: Admin/ABOUTs/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,TITLE,DESCRIPTION,IMG,META,HIDE,ORDER,DATE_BEGIN")] ABOUT aBOUT, HttpPostedFileBase img)
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
                    aBOUT.IMG = filename;
                }
                else
                {
                    aBOUT.IMG = "about-01.jpg";
                }
                db.ABOUTs.Add(aBOUT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aBOUT);
        }

        // GET: Admin/ABOUTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABOUT aBOUT = db.ABOUTs.Find(id);
            if (aBOUT == null)
            {
                return HttpNotFound();
            }
            return View(aBOUT);
        }

        // POST: Admin/ABOUTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,TITLE,DESCRIPTION,IMG,META,HIDE,ORDER,DATE_BEGIN")] ABOUT aBOUT, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            ABOUT temp = getById(aBOUT.ID);
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
                    temp.IMG = aBOUT.IMG;
                }
                temp.TITLE = aBOUT.TITLE;
                temp.DESCRIPTION = aBOUT.DESCRIPTION;
                temp.META = aBOUT.META;
                temp.HIDE = aBOUT.HIDE;
                temp.ORDER = aBOUT.ORDER;
                temp.DATE_BEGIN = aBOUT.DATE_BEGIN;
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aBOUT);
        }

        // GET: Admin/ABOUTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABOUT aBOUT = db.ABOUTs.Find(id);
            if (aBOUT == null)
            {
                return HttpNotFound();
            }
            return View(aBOUT);
        }

        // POST: Admin/ABOUTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ABOUT aBOUT = db.ABOUTs.Find(id);
            db.ABOUTs.Remove(aBOUT);
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

        public ABOUT getById(long id)
        {
            return db.ABOUTs.Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
