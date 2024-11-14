namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocBong")]
    public partial class HocBong
    {
        [Key]
        public int MaHocBong { get; set; }

        public int? MaHocVien { get; set; }

        [StringLength(255)]
        public string LoaiHocBong { get; set; }

        public decimal? SoTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCap { get; set; }

        public virtual HocVien HocVien { get; set; }
    }
}
