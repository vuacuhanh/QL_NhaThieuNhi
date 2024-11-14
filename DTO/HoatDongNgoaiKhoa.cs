namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoatDongNgoaiKhoa")]
    public partial class HoatDongNgoaiKhoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoatDongNgoaiKhoa()
        {
            ThamGiaHoatDongs = new HashSet<ThamGiaHoatDong>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHDNK { get; set; }

        [StringLength(100)]
        public string TenHoatDong { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianToChuc { get; set; }

        [StringLength(255)]
        public string DiaDiem { get; set; }

        public int? MaGiaoVien { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamGiaHoatDong> ThamGiaHoatDongs { get; set; }
    }
}
