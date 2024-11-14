namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThamGiaHoatDong")]
    public partial class ThamGiaHoatDong
    {
        [Key]
        public int MaThamGia { get; set; }

        public int? MaHocVien { get; set; }

        public int? MaHDNK { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThamGia { get; set; }

        public int? MaCTNK { get; set; }

        public virtual ChuongTrinhNangKhieu ChuongTrinhNangKhieu { get; set; }

        public virtual HoatDongNgoaiKhoa HoatDongNgoaiKhoa { get; set; }

        public virtual HocVien HocVien { get; set; }
    }
}
