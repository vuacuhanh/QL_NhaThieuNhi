namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            ChuongTrinhNangKhieux = new HashSet<ChuongTrinhNangKhieu>();
            HoatDongNgoaiKhoas = new HashSet<HoatDongNgoaiKhoa>();
            LichBaoTris = new HashSet<LichBaoTri>();
            LichBaoTris1 = new HashSet<LichBaoTri>();
            LichDays = new HashSet<LichDay>();
            LopHocs = new HashSet<LopHoc>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNhanVien { get; set; }

        [StringLength(100)]
        public string TenNhanVien { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string ChucVu { get; set; }

        [StringLength(100)]
        public string ChuyenMon { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public decimal? Luong { get; set; }

        public int? MaTaiKhoan { get; set; }

        public int? MaPhongBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuongTrinhNangKhieu> ChuongTrinhNangKhieux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoatDongNgoaiKhoa> HoatDongNgoaiKhoas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichBaoTri> LichBaoTris { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichBaoTri> LichBaoTris1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichDay> LichDays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }

        public virtual PhongBan PhongBan { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
