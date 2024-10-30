using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanAccess tkAccess = new TaiKhoanAccess();

        public string CheckLogicLogin(TaiKhoan taikhoan)
        {
            // Kiểm tra nghiệp vụ
            if (string.IsNullOrEmpty(taikhoan.TenDangNhap))
            {
                return "Tên đăng nhập không được để trống";
            }

            if (string.IsNullOrEmpty(taikhoan.MatKhau))
            {
                return "Mật khẩu không được để trống";
            }

            // Gọi tầng DAL để kiểm tra thông tin đăng nhập
            string info = tkAccess.CheckLogin(taikhoan); // Sửa phương thức gọi từ tkAccess

            // Trả về kết quả từ DAL
            return info; // Kết quả có thể là tên người dùng hoặc thông báo lỗi
        }

        public List<TaiKhoan> LoadTaiKhoan()
        {
            return tkAccess.LoadTaiKhoan();
        }
    }
}
