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
    public class SanPhamsController : Controller
    {
        private QLDDT db = new QLDDT();

        // GET: Admin/SanPhams
        public ActionResult Index(int? page)
        {
            var sanPhams = db.SanPhams.Include(s => s.DanhMucSP);
            sanPhams = sanPhams.OrderBy(u => u.MaSP);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(sanPhams.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DanhMucSPs, "MaDM", "TenDM");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,Anh,ThuongHieu,GiaHang,Gia,MoTa,SoLuongCon,MaDM")] SanPham sanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sanPham.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/Areas/Admin/assets/imgnew/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.Anh = FileName;
                    }
                    if (db.SanPhams.Where(s => s.TenSP.ToLower().Equals(sanPham.TenSP.ToLower())).ToList().Count == 0)
                    {
                        db.SanPhams.Add(sanPham);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Error = "Tên sản phẩm đã tồn tại";
                        ViewBag.MaDM = new SelectList(db.DanhMucSPs, "MaDM", "TenDM", sanPham.MaDM);
                        return View(sanPham);
                    }
                }
                return RedirectToAction("Index");
            }catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
                ViewBag.MaDM = new SelectList(db.DanhMucSPs, "MaDM", "TenDM", sanPham.MaDM);
                return View(sanPham);
            }
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DanhMucSPs, "MaDM", "TenDM", sanPham.MaDM);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,Anh,ThuongHieu,GiaHang,Gia,MoTa,SoLuongCon,MaDM")] SanPham sanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/Areas/Admin/assets/imgnew/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.Anh = FileName;
                    }
                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
                ViewBag.MaDM = new SelectList(db.DanhMucSPs, "MaDM", "TenDM", sanPham.MaDM);
                return View(sanPham);
            }
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            try
            {
                db.SanPhams.Remove(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View("Delete", sanPham);
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
