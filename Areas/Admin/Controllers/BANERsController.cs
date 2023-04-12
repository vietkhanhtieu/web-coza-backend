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
    public class BANERsController : Controller
    {
        private coza_storeEntities7 db = new coza_storeEntities7();

        // GET: Admin/BANERs
        public ActionResult Index()
        {
            return View(db.BANERs.ToList());
        }

        // GET: Admin/BANERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANER bANER = db.BANERs.Find(id);
            if (bANER == null)
            {
                return HttpNotFound();
            }
            return View(bANER);
        }

        // GET: Admin/BANERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BANERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,IMG,TITLE,DESCRIPTION,META,HIDE,ORDER,DATE_BEGIN")] BANER bANER, HttpPostedFileBase img)
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
                    bANER.IMG = filename;
                }
                else
                {
                    bANER.IMG = "banner-09.jpg";
                }
                db.BANERs.Add(bANER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bANER);
        }

        // GET: Admin/BANERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANER bANER = db.BANERs.Find(id);
            if (bANER == null)
            {
                return HttpNotFound();
            }
            return View(bANER);
        }

        // POST: Admin/BANERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,IMG,TITLE,DESCRIPTION,META,HIDE,ORDER,DATE_BEGIN")] BANER bANER, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            BANER temp = getByid(bANER.ID);
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
                    temp.IMG = bANER.IMG;
                }
                temp.DESCRIPTION = bANER.DESCRIPTION;
                temp.META = bANER.META;
                temp.HIDE = bANER.HIDE;
                temp.ORDER = bANER.ORDER;
                temp.DATE_BEGIN = bANER.DATE_BEGIN;
                temp.TITLE = bANER.TITLE;
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bANER);
        }

        // GET: Admin/BANERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANER bANER = db.BANERs.Find(id);
            if (bANER == null)
            {
                return HttpNotFound();
            }
            return View(bANER);
        }

        // POST: Admin/BANERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BANER bANER = db.BANERs.Find(id);
            db.BANERs.Remove(bANER);
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
        public BANER getByid(long id)
        {
            return db.BANERs.Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
