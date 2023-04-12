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
    public class BLOGsController : Controller
    {
        private coza_storeEntities7 db = new coza_storeEntities7();

        // GET: Admin/BLOGs
        public ActionResult Index()
        {
            return View(db.BLOGs.ToList());
        }

        // GET: Admin/BLOGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // GET: Admin/BLOGs/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Create([Bind(Include = "ID,NAME,IMG,DESCRIPTION,LINK,DETAIL,META,HIDE,ORDER,DATE_BEGIN")] BLOG bLOG, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if(img!= null)
                {
                    filename = DateTime.Now.ToString("dd-MM-yyyy-") + img.FileName;
                    path = Path.Combine(Server.MapPath("~/images"), filename);
                    img.SaveAs(path);
                    bLOG.IMG = filename;

                }
                else
                {
                    bLOG.IMG = "blog-01.jpg";
                }
                db.BLOGs.Add(bLOG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bLOG);
        }

        // GET: Admin/BLOGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // POST: Admin/BLOGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,NAME,IMG,DESCRIPTION,LINK,DETAIL,META,HIDE,ORDER,DATE_BEGIN")] BLOG bLOG, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            BLOG temp = getById(bLOG.ID);
            
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
                    temp.IMG = "blog-01.jpg";
                }
                temp.NAME = bLOG.NAME;
                temp.DESCRIPTION = bLOG.DESCRIPTION;
                temp.LINK = bLOG.LINK;
                temp.DETAIL = bLOG.DETAIL;
                temp.META = bLOG.META;
                temp.HIDE = bLOG.HIDE;
                temp.ORDER = bLOG.ORDER;
                temp.DATE_BEGIN = bLOG.DATE_BEGIN;
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bLOG);
        }

        // GET: Admin/BLOGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLOG bLOG = db.BLOGs.Find(id);
            if (bLOG == null)
            {
                return HttpNotFound();
            }
            return View(bLOG);
        }

        // POST: Admin/BLOGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLOG bLOG = db.BLOGs.Find(id);
            db.BLOGs.Remove(bLOG);
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
        public BLOG getById(long id)
        {
            return db.BLOGs.Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
