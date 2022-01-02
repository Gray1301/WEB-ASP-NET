using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using PagedList;

namespace FinalProject.Areas.Admin.Controllers
{
    public class DonHangsController : Controller
    {
        private QLDDT db = new QLDDT();

        // GET: Admin/DonHangs
        public ActionResult Index(int? page)
        {
            var donHangs = db.DonHangs.Include(d => d.GioHang);
            donHangs = donHangs.OrderBy(u => u.MaDH);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(donHangs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/DonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // GET: Admin/DonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaGH = new SelectList(db.GioHangs, "MaGH", "TenTK");
            return View();
        }

        // POST: Admin/DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,MaGH,NgayDat,DiaChiNhan,TinhTrang")] DonHang donHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DonHangs.Add(donHang);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                ViewBag.MaGH = new SelectList(db.GioHangs, "MaGH", "TenTK", donHang.MaGH);
                return View(donHang);
            }
        }

        // GET: Admin/DonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            List<string> TinhTrang = new List<string>
            {
                "Chờ xác nhận","Đang chuẩn bị","Đang giao","Đã giao","Đã hủy"
            };
            ViewBag.TinhTrang = TinhTrang;
            ViewBag.MaGH = new SelectList(db.GioHangs, "MaGH", "TenTK", donHang.MaGH);
            return View(donHang);
        }

        // POST: Admin/DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,MaGH,NgayDat,DiaChiNhan,TinhTrang")] DonHang donHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(donHang).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.MaGH = new SelectList(db.GioHangs, "MaGH", "TenTK", donHang.MaGH);
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                return View(donHang);
            }
        }

        // GET: Admin/DonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: Admin/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            try
            {
                db.DonHangs.Remove(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Không xóa được bản ghi này " + ex.Message;
                return View("Delete", donHang);
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
