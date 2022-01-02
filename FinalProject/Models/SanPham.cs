namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietGioHang_SanPham = new HashSet<ChiTietGioHang_SanPham>();
        }

        [Key]
        [Required(ErrorMessage = "Mã sản phẩm không được để trống!")]
        [DisplayName("Mã sản phẩm")]
        public int MaSP { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống!")]
        [DisplayName("Tên sản phẩm")]
        [StringLength(80)]
        public string TenSP { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Thương hiệu sản phẩm không được để trống!")]
        [DisplayName("Thương hiệu")]
        public string ThuongHieu { get; set; }
        [DisplayName("Giá hãng")]
        [RegularExpression("^[0-9]*\\.?[0-9]*$", ErrorMessage = "Giá hãng phải là một số.")]
        public double? GiaHang { get; set; }
        [Required(ErrorMessage = "Giá bán không được để trống!")]
        [DisplayName("Giá bán")]
        [RegularExpression("^[0-9]*\\.?[0-9]*$", ErrorMessage = "Giá bán phải là một số.")]
        public double Gia { get; set; }
        [DisplayName("Mô tả")]
        [StringLength(80)]
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }
        [Required(ErrorMessage = "Số lượng còn không được để trống!")]
        
        [DisplayName("Số lượng còn")]
        public int SoLuongCon { get; set; }
        [Required(ErrorMessage = "Mã danh mục hàng không được để trống!")]
        [DisplayName("Mã danh mục")]
        public int MaDM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang_SanPham> ChiTietGioHang_SanPham { get; set; }

        public virtual DanhMucSP DanhMucSP { get; set; }
    }
}
