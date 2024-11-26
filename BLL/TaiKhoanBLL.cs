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

        public (bool isSuccess, string message, string tenQuyen) CheckLogin(TaiKhoan taikhoan)
        {
            if (string.IsNullOrEmpty(taikhoan.TenDangNhap))
                return (false, "Tên đăng nhập không được để trống", null);

            if (string.IsNullOrEmpty(taikhoan.MatKhau))
                return (false, "Mật khẩu không được để trống", null);

            // Gọi tầng DAL để kiểm tra thông tin đăng nhập
            string result = tkAccess.CheckLogin(taikhoan);

            if (result == "Tài khoản hoặc mật khẩu không chính xác")
            {
                return (false, result, null);
            }

            return (true, "Đăng nhập thành công", result); 
        }

        public List<TaiKhoan> LoadTaiKhoan()
        {
            return tkAccess.LoadTaiKhoan();
        }

        public bool AddTaiKhoan(TaiKhoan t)
        {
            try
            {
                // Gọi phương thức AddTaiKhoan từ tkAccess
                return tkAccess.AddTaiKhoan(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm tài khoản: " + ex.Message);
                return false;
            }
        }

        public bool DeleteTaiKhoan(int maTaiKhoan)
        {
            try
            {
                return tkAccess.DeleteTaiKhoan(maTaiKhoan);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa tài khoản: " + ex.Message);
                return false;
            }
        }

        public bool EditTaiKhoan(TaiKhoan t)
        {
            try
            {
                return tkAccess.EditTaiKhoan(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi sửa tài khoản: " + ex.Message);
                return false;
            }
        }
        public int CountTaiKhoan()
        {
            try
            {
                return tkAccess.CountTaiKhoan(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đếm tài khoản: " + ex.Message);
                return 0;
            }
        }

    }
}
