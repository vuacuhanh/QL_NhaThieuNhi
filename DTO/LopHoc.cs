using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopHoc
    {
        public int MaLop { get; set; }
        public int MaNhanVien { get; set; }
        public string TenLop { get; set; }
        public string ChuyenMon { get; set; }
        public int SiSo { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string TrangThai { get; set; }
    }
}
