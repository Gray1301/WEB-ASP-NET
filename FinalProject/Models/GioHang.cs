namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioHang()
        {
            ChiTietGioHang_SanPham = new HashSet<ChiTietGioHang_SanPham>();
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [Required(ErrorMessage = "Mã giỏ hàng nhận không được để trống!")]
        [DisplayName("Mã giỏ hàng")]
        public int MaGH { get; set; }

        [Required(ErrorMessage = "Tên tài khoản không được để trống!")]
        [DisplayName("Tên tài khoản")]
        [StringLength(60)]
        public string TenTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang_SanPham> ChiTietGioHang_SanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
