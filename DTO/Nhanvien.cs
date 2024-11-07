using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Nhanvien
    {
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string HinhAnh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
        public string ChuyenMon { get; set; }
        public string TrangThai { get; set; }
        public string Email { get; set; }
        public decimal Luong { get; set; }
        public int MaTaiKhoan { get; set; }
        public int MaPhongBan { get; set; }

        public Nhanvien()
        {
        }

        // Hàm khởi tạo có tham số
        public Nhanvien(int maNhanVien, string tenNhanVien, string hinhAnh, DateTime ngaySinh, string gioiTinh,
                        string soDienThoai, string chucVu, string chuyenMon, string trangThai, string email, decimal luong, int maTaiKhoan, int maPhongBan)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            HinhAnh = hinhAnh;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            SoDienThoai = soDienThoai;
            ChucVu = chucVu;
            ChuyenMon = chuyenMon;
            TrangThai = trangThai;
            Email = email;
            Luong = luong;
            MaTaiKhoan = maTaiKhoan;
            MaPhongBan = maPhongBan;
        }

        // Phương thức tính tuổi của nhân viên
        public int TinhTuoi()
        {
            int tuoi = DateTime.Now.Year - NgaySinh.Year;
            if (DateTime.Now.DayOfYear < NgaySinh.DayOfYear)
                tuoi--;
            return tuoi;
        }
    }
}
