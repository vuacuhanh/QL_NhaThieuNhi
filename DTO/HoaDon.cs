namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHoaDon { get; set; }

        public decimal? SoTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        [StringLength(50)]
        public string HinhThucThanhToan { get; set; }

        [StringLength(50)]
        public string TrangThaiThanhToan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianBatDauDongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianKetThucDongTien { get; set; }

        public int? MaHocVien { get; set; }

        public int? MaLop { get; set; }

        public virtual HocVien HocVien { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
