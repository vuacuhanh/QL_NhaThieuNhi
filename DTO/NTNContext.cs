using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DTO
{
    public partial class NTNContext : DbContext
    {
        public NTNContext()
            : base("name=NTNContext")
        {
        }

        public virtual DbSet<CaHoc> CaHocs { get; set; }
        public virtual DbSet<ChuongTrinhNangKhieu> ChuongTrinhNangKhieux { get; set; }
        public virtual DbSet<CoSoVatChat> CoSoVatChats { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoatDongNgoaiKhoa> HoatDongNgoaiKhoas { get; set; }
        public virtual DbSet<HocBong> HocBongs { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<LichBaoTri> LichBaoTris { get; set; }
        public virtual DbSet<LichDay> LichDays { get; set; }
        public virtual DbSet<LichHoc> LichHocs { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<PhuHuynh> PhuHuynhs { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThamGiaHoatDong> ThamGiaHoatDongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaHoc>()
                .HasMany(e => e.LichDays)
                .WithRequired(e => e.CaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CaHoc>()
                .HasMany(e => e.LichHocs)
                .WithRequired(e => e.CaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.LichDays)
                .WithRequired(e => e.LopHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.LichHocs)
                .WithRequired(e => e.LopHoc)
                .WillCascadeOnDelete(false);

          
        }
    }
}
