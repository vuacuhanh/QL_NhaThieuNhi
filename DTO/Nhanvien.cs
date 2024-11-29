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


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNhanVien { get; set; }

        [StringLength(100)]
        public string TenNhanVien { get; set; }

        public byte[] HinhAnh { get; set; }

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

    }
}
