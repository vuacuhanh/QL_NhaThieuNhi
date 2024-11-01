using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int MaQuyen { get; set; }

        // Constructor không tham số
        public TaiKhoan() { }

        // Constructor đầy đủ tham số
        public TaiKhoan(int maTaiKhoan, string tenDangNhap, string matKhau, int maQuyen)
        {
            MaTaiKhoan = maTaiKhoan;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            MaQuyen = maQuyen;
        }
    }
}
