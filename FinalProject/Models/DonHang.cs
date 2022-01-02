namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        [Required(ErrorMessage = "Mã đơn hàng không được để trống!")]
        [DisplayName("Mã đơn hàng")]
        public int MaDH { get; set; }
        [Required(ErrorMessage = "Mã giỏ hàng không được để trống!")]
        [DisplayName("Mã giỏ hàng")]
        public int MaGH { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Ngày đặt không được để trống!")]
        [DisplayName("Ngày đặt"), DataType(DataType.DateTime)]
        public DateTime? NgayDat { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Địa chỉ nhận không được để trống!")]
        [DisplayName("Địa chỉ nhận")]
        public string DiaChiNhan { get; set; }

        [Required(ErrorMessage = "Tình trạng đơn hàng không được để trống!")]
        [DisplayName("Tình trạng")]
        [StringLength(30)]
        public string TinhTrang { get; set; }

        public virtual GioHang GioHang { get; set; }
    }
}
