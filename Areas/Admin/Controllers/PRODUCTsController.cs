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
    public class PRODUCTsController : Controller
    {
        private coza_storeEntities7 db = new coza_storeEntities7();

        // GET: Admin/PRODUCTs
        public ActionResult Index(long? id = null)
        {
            getCategory(id);
            return View();
        }


        public void getCategory(long? selectedID = null)
        {
            ViewBag.Category = new SelectList(db.CATEGORies.Where(x => x.HIDE == true).OrderBy(x => x.ORDER), "id", "name", selectedID);
        }

        public void getNameCategory(long? id)
        {
            
            var t = from c in db.CATEGORies
                    from p in db.PRODUCTs
                    where p.ID == id && p.CATE_ID == c.ID
                    select c;
                    
         
            ViewBag.NameCategory = t.FirstOrDefault().NAME;


           
        }

        public ActionResult getProduct(long? id)
        {
            if (id == null)
            {
                var v = db.PRODUCTs.OrderBy(x => x.ORDER).ToList();
                return PartialView(v);
            }
            var m = db.PRODUCTs.Where(x => x.CATE_ID == id).OrderBy(x => x.ORDER).ToList();
            return PartialView(m);
        }

        // GET: Admin/PRODUCTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: Admin/PRODUCTs/Create
        public ActionResult Create()
        {
            //ViewBag.CATE_ID = new SelectList(db.CATEGORies, "ID", "NAME");
            getCategory();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,NAME,PRICE,IMG,DESCRIPTION,COLOR,META,HIDE,ORDER,DATE_BEGIN,CATE_ID")] PRODUCT pRODUCT, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    filename = DateTime.Now.ToString("dd-MM-yyyy-") + img.FileName;
                    path = Path.Combine(Server.MapPath("~/images"), filename);
                    img.SaveAs(path);
                    pRODUCT.IMG = filename;

                }
                else
                {  
                    pRODUCT.IMG = "product-01.jpg";
                }
                db.PRODUCTs.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index","PRODUCTs", new { id = pRODUCT.CATEGORY});
            }

            ViewBag.CATE_ID = new SelectList(db.CATEGORies, "ID", "NAME", pRODUCT.CATE_ID);
            return View(pRODUCT);
        }

        // GET: Admin/PRODUCTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.CATE_ID = new SelectList(db.CATEGORies, "ID", "NAME", pRODUCT.CATE_ID);
            return View(pRODUCT);
        }

        // POST: Admin/PRODUCTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,NAME,PRICE,IMG,DESCRIPTION,COLOR,META,HIDE,ORDER,DATE_BEGIN,CATE_ID")] PRODUCT pRODUCT, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                PRODUCT temp = getByid(pRODUCT.ID);

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
                        temp.IMG = "product-01.jpg";

                    }
                    temp.NAME = pRODUCT.NAME;
                    temp.PRICE = pRODUCT.PRICE;
                    temp.DESCRIPTION = pRODUCT.DESCRIPTION;
                    temp.COLOR = pRODUCT.COLOR;
                    temp.META = pRODUCT.META;
                    temp.HIDE = pRODUCT.HIDE;
                    temp.ORDER = pRODUCT.ORDER;
                    temp.DATE_BEGIN = pRODUCT.DATE_BEGIN;
                    temp.CATE_ID = pRODUCT.CATE_ID;
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "PRODUCTs", new { id = pRODUCT.CATEGORY });
                }
            }
            catch(Exception e)
            {
                throw e;
            }
          
            //ViewBag.CATE_ID = new SelectList(db.CATEGORies, "ID", "NAME", pRODUCT.CATE_ID);
            return View(pRODUCT);
        }

        // GET: Admin/PRODUCTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            getNameCategory(pRODUCT.ID);
            return View(pRODUCT);
        }

        // POST: Admin/PRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            db.PRODUCTs.Remove(pRODUCT);
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

        public PRODUCT getByid(long id)
        {
            return db.PRODUCTs.Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
