using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien
        public ActionResult DanhSach()
        {
            return View();
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        public ActionResult Sua()
        {
            return View();
        }

        public ActionResult Xoa()
        {
            return View();
        }
    }
}