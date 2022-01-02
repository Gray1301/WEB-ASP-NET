using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FinalProject.Models
{
    public partial class QLDDT : DbContext
    {
        public QLDDT()
            : base("name=QLDDT")
        {
        }

        public virtual DbSet<ChiTietGioHang_SanPham> ChiTietGioHang_SanPham { get; set; }
        public virtual DbSet<DanhMucSP> DanhMucSPs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucSP>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.DanhMucSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.ChiTietGioHang_SanPham)
                .WithRequired(e => e.GioHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.GioHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.ThuongHieu)
                .IsFixedLength();

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietGioHang_SanPham)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.GioHangs)
                .WithRequired(e => e.TaiKhoan)
                .WillCascadeOnDelete(false);
        }
    }
}
