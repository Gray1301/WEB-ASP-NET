using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class GioHangsController : Controller
    {
        private QLDDT db = new QLDDT();

        // GET: Admin/GioHangs
        public ActionResult Index()
        {
            var gioHangs = db.GioHangs.Include(g => g.TaiKhoan);
            return View(gioHangs.ToList());
        }

        // GET: Admin/GioHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // GET: Admin/GioHangs/Create
        public ActionResult Create()
        {
            ViewBag.TenTK = new SelectList(db.TaiKhoans, "TenTK", "MatKhau");
            return View();
        }

        // POST: Admin/GioHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGH,TenTK")] GioHang gioHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.GioHangs.Add(gioHang);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                ViewBag.TenTK = new SelectList(db.TaiKhoans, "TenTK", "MatKhau", gioHang.TenTK);
                return View(gioHang);
            }
        }

        // GET: Admin/GioHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenTK = new SelectList(db.TaiKhoans, "TenTK", "MatKhau", gioHang.TenTK);
            return View(gioHang);
        }

        // POST: Admin/GioHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGH,TenTK")] GioHang gioHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(gioHang).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                ViewBag.TenTK = new SelectList(db.TaiKhoans, "TenTK", "MatKhau", gioHang.TenTK);
                return View(gioHang);
            }
        }

        // GET: Admin/GioHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // POST: Admin/GioHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GioHang gioHang = db.GioHangs.Find(id);
            try
            {
                db.GioHangs.Remove(gioHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View("Delete", gioHang);
            }
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
