namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LichDay")]
    public partial class LichDay
    {
        [Key]
        public int MaLichDay { get; set; }

        public int MaNhanVien { get; set; }

        public int MaLop { get; set; }

        public int MaCaHoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDay { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKetThuc { get; set; }

        [StringLength(50)]
        public string PhongHoc { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        public virtual CaHoc CaHoc { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
