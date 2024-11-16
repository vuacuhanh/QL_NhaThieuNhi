namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopHoc")]
    public partial class LopHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public  LopHoc()
        {
            HoaDons = new HashSet<HoaDon>();
            HocViens = new HashSet<HocVien>();
            LichDays = new HashSet<LichDay>();
            LichHocs = new HashSet<LichHoc>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLop { get; set; }

        public int? MaNhanVien { get; set; }

        [StringLength(100)]
        public string TenLop { get; set; }

        [StringLength(100)]
        public string ChuyenMon { get; set; }

        public int? SiSo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianKetThuc { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocVien> HocViens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichDay> LichDays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichHoc> LichHocs { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
