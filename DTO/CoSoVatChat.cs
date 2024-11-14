namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoSoVatChat")]
    public partial class CoSoVatChat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CoSoVatChat()
        {
            LichBaoTris = new HashSet<LichBaoTri>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCSVC { get; set; }

        [StringLength(100)]
        public string TenCoSo { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        [StringLength(100)]
        public string LoaiCoSo { get; set; }

        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichBaoTri> LichBaoTris { get; set; }
    }
}
