using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final.Models;
using System.Web.Helpers;

namespace Final.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            // sẽ sửa sau
            if (Session["user"] == null)
            {
                return RedirectToAction("loginAdmin");
            }
            return View();  
        }

        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(string firstName, string lastName, string address, string email, string password, string confirm)
        {

            coza_storeEntities7 db = new coza_storeEntities7();
            int count = db.NhanViens.Count(m => m.email == email);
            if (count >= 1)
            {
                TempData["errorUser"] = "Username đã tồn tại";
                return View();
            }
            NhanVien nhanvien = new NhanVien();
            if (password == confirm)
            {
                nhanvien.firstName = firstName;
                nhanvien.email = email;
                nhanvien.address = address;
                nhanvien.lastName = lastName;
                nhanvien.password = password;
                db.NhanViens.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("loginAdmin");
            }
            else
            {
                TempData["error"] = "Mật khẩu confirm không đúng";
                return View();
            }
        }

        public ActionResult loginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult loginAdmin(string email, string password)
        {
            coza_storeEntities7 db = new coza_storeEntities7();
            var nhanVien = db.NhanViens.SingleOrDefault(m => m.email == email && m.password == password);
            if (nhanVien != null)
            {
                Session["user"] = nhanVien;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Tên đăng nhập hoặc mật khẩu không đúng";
                return View();
            }
        }

        [HttpPost]
        public ActionResult sendEmail(string useremail)
        {
            string subject = "this is your password";
            string body = "password code";

            WebMail.Send(useremail, subject, body, null, null, null, true, null, null, null, null, null, null);

            return View();
        }

        public ActionResult logOut()
        {
            // xóa Session
            Session.Remove("user");

            return RedirectToAction("loginAdmin");
        }

        public ActionResult fogotPassword()
        {
            return View();
        }



    }
}