using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private QLDDT db = new QLDDT();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["checktentk"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: nguoidungs/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string tentk, string matkhau)
        {        
            if (ModelState.IsValid)
            {
                if (tentk == "")
                {
                    ViewBag.error = "Bạn chưa nhập tên tài khoản";
                }
                else
                if (matkhau == "")
                {
                    ViewBag.error = "Bạn chưa nhập mật khẩu";
                }
                else
                {
                    var user = db.TaiKhoans.Where(u => u.TenTK.Equals(tentk) && u.MatKhau.Equals(matkhau)).ToList();
                    if (user.Count() > 0)
                    {
                        Session["checktentk"] = user.FirstOrDefault().TenTK;
                        if (user.FirstOrDefault().PhanQuyen.ToString() == "Người quản trị")
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.error = "Bạn không phải người quản trị";
                        }
                    }
                    else
                    {
                        ViewBag.error = "Tên tài khoản hoặc mật khẩu không chính xác!";
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}