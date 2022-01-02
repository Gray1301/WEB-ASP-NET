namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucSP")]
    public partial class DanhMucSP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucSP()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Required(ErrorMessage = "Mã danh mục không được để trống!")]
        [DisplayName("Mã danh mục")]
        public int MaDM { get; set; }

        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống!")]
        [StringLength(30)]
        public string TenDM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
