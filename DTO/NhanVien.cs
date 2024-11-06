using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime? NgaySinh { get; set; } // Đổi thành nullable DateTime
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
        public string ChuyenMon { get; set; }
        public string TrangThai { get; set; }
        public string Email { get; set; }
        public decimal Luong { get; set; }
        public int? MaTaiKhoan { get; set; }
        public int? MaPhongBan { get; set; }

        // Phương thức kiểm tra số điện thoại hợp lệ
        public bool IsValidSoDienThoai()
        {
            return SoDienThoai.Length == 10; // Giả sử số điện thoại hợp lệ là 10 ký tự
        }

        // Phương thức kiểm tra email hợp lệ
        public bool IsValidEmail()
        {
            return Email.Contains("@"); // Kiểm tra cơ bản email có dấu "@" hay không
        }
    }

}
