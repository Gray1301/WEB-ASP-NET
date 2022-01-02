namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGioHang-SanPham")]
    public partial class ChiTietGioHang_SanPham
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaGH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống!")]
        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }
        [Required(ErrorMessage = "Giá tiền không được để trống!")]
        [DisplayName("Giá tiền")]
        public double Gia { get; set; }

        public virtual GioHang GioHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
