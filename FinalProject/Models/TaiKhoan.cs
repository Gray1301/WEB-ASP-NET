namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            GioHangs = new HashSet<GioHang>();
        }

        [Key]
        [StringLength(60)]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        [DisplayName("Tên tài khoản")]
        [MaxLength(20, ErrorMessage = "Tên đăng nhập phải có tối đa 20 ký tự")]
        [MinLength(3, ErrorMessage = "Tên đăng nhập phải có tối thiểu 3 ký tự")]
        public string TenTK { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [DisplayName("Mật khẩu"), DataType(DataType.Password)]
        [StringLength(60)]
        [MaxLength(20, ErrorMessage = "Mật khẩu phải có tối đa 20 ký tự")]
        [MinLength(3, ErrorMessage = "Mật khẩu nhập phải có tối thiểu 3 ký tự")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống!")]
        [DisplayName("Họ tên")]
        [StringLength(60)]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Email không được để trống!")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email cần nhập đúng định dạng. VD: example@gmail.com")]
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(12)]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        //[Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Tỉnh/Thành phố không được để trống!")]
        [DisplayName("Tỉnh/Thành phố")]
        public string Tinh_ThanhPho { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [DisplayName("Phân quyền")]
        [StringLength(25)]
        public string PhanQuyen { get; set; }
        [DisplayName("Tình trạng")]
        public bool TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}


