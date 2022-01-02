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
    public class DanhMucSPsController : Controller
    {
        private QLDDT db = new QLDDT();

        // GET: Admin/DanhMucSPs
        public ActionResult Index(int? page)
        {
            var danhmucs = db.DanhMucSPs.Select(u=>u);
            danhmucs = danhmucs.OrderBy(u => u.MaDM);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(danhmucs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/DanhMucSPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSP danhMucSP = db.DanhMucSPs.Find(id);
            if (danhMucSP == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSP);
        }

        // GET: Admin/DanhMucSPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucSPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDM,TenDM")] DanhMucSP danhMucSP)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.DanhMucSPs.Where(s => s.TenDM.ToLower().Equals(danhMucSP.TenDM.ToLower())).ToList().Count == 0)
                    {
                        db.DanhMucSPs.Add(danhMucSP);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Error = "Tên danh mục đã tồn tại";
                        
                        return View(danhMucSP);
                    }
                    
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(danhMucSP);
            }
        }

        // GET: Admin/DanhMucSPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSP danhMucSP = db.DanhMucSPs.Find(id);
            if (danhMucSP == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSP);
        }

        // POST: Admin/DanhMucSPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDM,TenDM")] DanhMucSP danhMucSP)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(danhMucSP).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(danhMucSP);
            }
        }

        // GET: Admin/DanhMucSPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSP danhMucSP = db.DanhMucSPs.Find(id);
            if (danhMucSP == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSP);
        }

        // POST: Admin/DanhMucSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMucSP danhMucSP = db.DanhMucSPs.Find(id);
            try
            {
                db.DanhMucSPs.Remove(danhMucSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Không xóa được bản ghi này " + ex.Message;
                return ViewBag("Delete", danhMucSP);
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
