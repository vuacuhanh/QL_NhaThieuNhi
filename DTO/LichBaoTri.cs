namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichBaoTri")]
    public partial class LichBaoTri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLichBaoTri { get; set; }

        public int? MaNhanVienLapLich { get; set; }

        public DateTime? ThoiGianBD { get; set; }

        public DateTime? ThoiGianKT { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public int? MaCSVC { get; set; }

        public int? MaNhanVienBaoTri { get; set; }

        public virtual CoSoVatChat CoSoVatChat { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual NhanVien NhanVien1 { get; set; }
    }
}
