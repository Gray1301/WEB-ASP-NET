using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using System.Net;
using PagedList;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private QLDDT db = new QLDDT();
        public ActionResult Index(string searchString)
        {
            List<SanPham> hangs = new List<SanPham>();
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;

                hangs = db.SanPhams.Where(h => h.TenSP.Contains(searchString)).Select(h => h).ToList();
                Session["soluongtimkiem"] = hangs.Count.ToString();
                return View("TimKiem", hangs);
            }
            var sanphams = db.SanPhams.Where(u => u.MaDM.Equals(2)).Take(4).ToList();
            return View(sanphams);
        }

        [HttpGet]
        public ActionResult Register(string searchString)
        {
            List<SanPham> hangs = new List<SanPham>();
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;

                hangs = db.SanPhams.Where(h => h.TenSP.Contains(searchString)).Select(h => h).ToList();
                Session["soluongtimkiem"] = hangs.Count.ToString();
                return View("TimKiem", hangs);
            }
            List<string> tinhs = new List<string>
                {
                "An Giang","Bà Rịa - Vũng Tàu","Bạc Liêu","Bắc Giang" , "Bắc Kạn","Bắc Ninh","Bến Tre","Bình Dương","Bình Định","Bình Phước ","Bình Định","Cà Mau","Cao Bằng","Cần Thơ",
                "Đà Nẵng ","Đắk Lắk","Dắk Nông","Điện Biên","Đồng Nai","Đồng Tháp","Gia Lai","Hà Giang","Hà Nam","Hà Nội","Hà Tĩnh","Hải Dương","Hải Phòng","Hậu Giang","Hòa Bình","Thành phố Hồ Chí Minh",
                "Hưng Yên","Khánh Hòa","Kiên Giang","Kon Tum","Lai Châu","Lạng Sơn","Lào Cai","Lâm Đồng","Long An","Nam Định","Nghệ An","Ninh Bình ","Ninh Thuận","Phú Thọ","Phú Yên","Quảng Bình",
                "Quảng Nam","Quảng Ngãi ","Quảng Ninh","Quảng Trị","Sóc Trăng","Sơn La","Tây Ninh","Thái Bình","Thái Nguyên","Thanh Hóa","Thùa Thiên Huế","Tiền Giang","Trà Vinh","Tuyên Quang","Vĩnh Long","Vĩnh Phúc","Yên Bái"
                };
            ViewBag.tinhs = tinhs;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "TenTK,MatKhau,Email,HoTen,SDT,NgaySinh,Tinh_ThanhPho,DiaChi")] TaiKhoan taikhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    taikhoan.PhanQuyen = "Khách hàng";
                    taikhoan.TinhTrang = true;
                    db.TaiKhoans.Add(taikhoan);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Error = "Đăng ký không thành công!";
                    return View(taikhoan);
                }
            }catch(Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
                return View("Register");
            }
        }

        [HttpGet]
        public ActionResult Login( string searchString)
        {
            List<SanPham> hangs = new List<SanPham>();
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;
                hangs = db.SanPhams.Where(h => h.TenSP.Contains(searchString)).Select(h => h).ToList();
                Session["soluongtimkiem"] = hangs.Count.ToString();
                return View("TimKiem", hangs);
            }
            
                return View();
        }

        // POST: nguoidungs/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string tentk, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var user = db.TaiKhoans.Where(u => u.TenTK.Equals(tentk) && u.MatKhau.Equals(matkhau)).ToList();
                if (user.Count() > 0)
                {
                    // Sử dụng Session: add Session
                    Session["HoTen"] = user.FirstOrDefault().HoTen;
                    Session["idUser"] = user.FirstOrDefault().TenTK;
                    Session["SDT"] = user.FirstOrDefault().SDT;
                    string id = user.FirstOrDefault().TenTK.ToString();
                    if (Session["trave"].Equals("giohang"))
                    {
                        return RedirectToAction("GioHang");
                    }
                    else
                    if (Session["trave"].Equals("taikhoan"))
                    {
                        return RedirectToAction("TaiKhoan",new {id = id });
                    }
                    else
                    if (Session["trave"].Equals("chitietsp"))
                    {
                        string ma = Session["machitiet"].ToString();
                        return RedirectToAction("ChiTietSP", new {id = ma });
                    }
                    else
                        return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Đăng nhập không thành công!";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        public PartialViewResult _Search()
        {
            return PartialView();
        }
        public ActionResult Timkiem(List<SanPham> hangs,int? page)
        {
            if (hangs.Count != 0)
            {
               
                return View(hangs);
            }
            return View();
        }

        public ActionResult GioHang( string searchString)
        {
            List<SanPham> hangs = new List<SanPham>();
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;

                hangs = db.SanPhams.Where(h => h.TenSP.Contains(searchString)).Select(h => h).ToList();
                Session["soluongtimkiem"] = hangs.Count.ToString();
                return View("TimKiem", hangs);
            }
            if (Session["idUser"] == null)
            {
                Session["trave"] = "giohang";
                return RedirectToAction("Login");
            }
            else
            {

                string tentkgh = Session["idUser"].ToString();
                var magh = db.GioHangs.Where(u => u.TenTK.Equals(tentkgh)).ToList();
                int key = (int)magh.FirstOrDefault().MaGH;
                var chitietgiohangs = db.ChiTietGioHang_SanPham.Where(u => u.MaGH.Equals(key)).ToList();
                if (chitietgiohangs.Count == 0)
                {
                    return View("KhongGioHang");

                }
                return View(chitietgiohangs);
            }
        }
        public ActionResult DonHang(string searchString)
        {
            List<SanPham> hangs = new List<SanPham>();
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;

                hangs = db.SanPhams.Where(h => h.TenSP.Contains(searchString)).Select(h => h).ToList();
                Session["soluongtimkiem"] = hangs.Count.ToString();
                return View("TimKiem", hangs);
            }
            if (Session["idUser"] == null)
                return RedirectToAction("Login");
            else
            {
                string tentkgh = Session["idUser"].ToString();
                var magh = db.GioHangs.Where(u => u.TenTK.Equals(tentkgh)).ToList();
                int key = (int)magh.FirstOrDefault().MaGH;
                var chitietgiohangs = db.ChiTietGioHang_SanPham.Where(u => u.MaGH.Equals(key)).ToList();
                return View(chitietgiohangs);
            }
        }

        public ActionResult TaiKhoan(string id, string searchString)
        {
            List<SanPham> hangs = new List<SanPham>();
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;

                hangs = db.SanPhams.Where(h => h.TenSP.Contains(searchString)).Select(h => h).ToList();
                Session["soluongtimkiem"] = hangs.Count.ToString();
                return View("TimKiem", hangs);
            }
            if (Session["idUser"] == null)
            {
                Session["trave"] = "taikhoan";
                return RedirectToAction("Login");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
                if (taiKhoan == null)
                {
                    return HttpNotFound();
                }
                List<string> tinhs = new List<string>
                {
                "An Giang","Bà Rịa - Vũng Tàu","Bạc Liêu","Bắc Giang" , "Bắc Kạn","Bắc Ninh","Bến Tre","Bình Dương","Bình Định","Bình Phước ","Bình Định","Cà Mau","Cao Bằng","Cần Thơ",
                "Đà Nẵng ","Đắk Lắk","Dắk Nông","Điện Biên","Đồng Nai","Đồng Tháp","Gia Lai","Hà Giang","Hà Nam","Hà Nội","Hà Tĩnh","Hải Dương","Hải Phòng","Hậu Giang","Hòa Bình","Thành phố Hồ Chí Minh",
                "Hưng Yên","Khánh Hòa","Kiên Giang","Kon Tum","Lai Châu","Lạng Sơn","Lào Cai","Lâm Đồng","Long An","Nam Định","Nghệ An","Ninh Bình ","Ninh Thuận","Phú Thọ","Phú Yên","Quảng Bình",
                "Quảng Nam","Quảng Ngãi ","Quảng Ninh","Quảng Trị","Sóc Trăng","Sơn La","Tây Ninh","Thái Bình","Thái Nguyên","Thanh Hóa","Thùa Thiên Huế","Tiền Giang","Trà Vinh","Tuyên Quang","Vĩnh Long","Vĩnh Phúc","Yên Bái"
                };
                ViewBag.tinhs = tinhs;
                return View(taiKhoan);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaiKhoan([Bind(Include = "TenTK,MatKhau,HoTen,Email,SDT,NgaySinh,Tinh_ThanhPho,DiaChi,PhanQuyen,TinhTrang")] TaiKhoan taiKhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(taiKhoan).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
                return View(taiKhoan);
            }
        }
        public ActionResult DoiMatKhau(string id, string searchString)
        {
            List<SanPham> hangs = new List<SanPham>();
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;

                hangs = db.SanPhams.Where(h => h.TenSP.Contains(searchString)).Select(h => h).ToList();
                Session["soluongtimkiem"] = hangs.Count.ToString();
                return View("TimKiem", hangs);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhau([Bind(Include = "TenTK,MatKhau,HoTen,Email,SDT,NgaySinh,Tinh_ThanhPho,DiaChi,PhanQuyen,TinhTrang")] TaiKhoan taiKhoan, string OldPassword)
        {
            string old_pass = db.TaiKhoans.AsNoTracking().Where(t => t.Email.Equals(taiKhoan.Email)).FirstOrDefault().MatKhau;
            if (old_pass.Equals(OldPassword))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(taiKhoan).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Lỗi nhập dữ liệu";
                }
            }
            else
            {
                ViewBag.error = "Mật khẩu cũ sai";
            }


            return View(taiKhoan);
        }
        public ActionResult Loa()
        {
            var sanphams = db.SanPhams.OrderByDescending(h => h.MaDM).Select(h => h).Take(4);
            return PartialView(sanphams);

        }

        public ActionResult SanPhamTheoDM(int id,int? page, string searchString)
        {
            List<SanPham> hangs = new List<SanPham>();
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;

                hangs = db.SanPhams.Where(h => h.TenSP.Contains(searchString)).Select(h => h).ToList();
                Session["soluongtimkiem"] = hangs.Count.ToString();
                return View("TimKiem", hangs);
            }

            var sanphams = db.SanPhams.Where(u => u.MaDM.Equals(id));
            sanphams = sanphams.OrderBy(u => u.MaSP);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(sanphams.ToPagedList( pageNumber, pageSize));
        }
        public PartialViewResult _Nav()
        {
            var danhmuc = db.DanhMucSPs.Select(n => n);
            return PartialView(danhmuc);
        }
        public ActionResult ChiTietSP(string id,string searchString)
        {
            List<SanPham> hangs = new List<SanPham>();
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;

                hangs = db.SanPhams.Where(h => h.TenSP.Contains(searchString)).Select(h => h).ToList();
                Session["soluongtimkiem"] = hangs.Count.ToString();
                return View("TimKiem", hangs);
            }
          
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SanPham sp = db.SanPhams.Find(int.Parse(id));
                if (sp == null)
                {
                    return HttpNotFound();
                }

                return View(sp);
        }

    }
}