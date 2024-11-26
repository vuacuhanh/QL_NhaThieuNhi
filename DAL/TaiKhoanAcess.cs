using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public class TaiKhoanAccess
    {
        public string CheckLogin(TaiKhoan taikhoan)
        {
            return DataBaseAccess.CheckLogin(taikhoan);
        }

        public List<TaiKhoan> LoadTaiKhoan()
        {
            return DataBaseAccess.LoadTaiKhoan();
        }

        public bool AddTaiKhoan(TaiKhoan taikhoan)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_AddTaiKhoan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenDangNhap", taikhoan.TenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", taikhoan.MatKhau);
                        cmd.Parameters.AddWithValue("@MaQuyen", taikhoan.MaQuyen);

                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi thêm tài khoản: " + ex.Message);
                    return false;
                }
            }
        }

        // Phương thức xóa tài khoản
        public bool DeleteTaiKhoan(int maTaiKhoan)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteTaiKhoan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);

                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi xóa tài khoản: " + ex.Message);
                    return false;
                }
            }
        }

        // Phương thức sửa tài khoản
        public bool EditTaiKhoan(TaiKhoan taikhoan)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_EditTaiKhoan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaTaiKhoan", taikhoan.MaTaiKhoan);
                        cmd.Parameters.AddWithValue("@TenDangNhap", taikhoan.TenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", taikhoan.MatKhau);
                        cmd.Parameters.AddWithValue("@MaQuyen", taikhoan.MaQuyen);

                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi sửa tài khoản: " + ex.Message);
                    return false;
                }
            }
        }
        // Phương thức đếm số lượng tài khoản
        public int CountTaiKhoan()
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TaiKhoan", conn))
                    {
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi đếm tài khoản: " + ex.Message);
                    return 0;
                }
            }
        }
    }
}
