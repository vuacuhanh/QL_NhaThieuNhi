namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichHoc")]
    public partial class LichHoc
    {
        [Key]
        public int MaLichHoc { get; set; }

        public DateTime ThoiGianHoc { get; set; }

        public int MaCaHoc { get; set; }

        [StringLength(100)]
        public string PhongHoc { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public int MaLop { get; set; }

        public virtual CaHoc CaHoc { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
