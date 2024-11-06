using System;
using System.Data.SqlClient;
using DTO;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DAL
{
    public class ConnectionData
    {
        private static readonly string connectionString = @"Data Source=DESKTOP-FGIC7BA\SQLEXPRESSQUAN;Initial Catalog=QL_NhaThieuNhi;Integrated Security=True";

        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }


    }

    public class DataBaseAccess
    {
        public static string CheckLogin(TaiKhoan taikhoan)
        {
            string user = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_CheckDangNhap", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TenDangNhap", taikhoan.TenDangNhap);
                        command.Parameters.AddWithValue("@MatKhau", taikhoan.MatKhau);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    user = reader.GetString(0); // Lấy thông tin người dùng
                                }
                            }
                            else
                            {
                                return "Tài khoản hoặc mật khẩu không chính xác";
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi kết nối hoặc thực thi câu lệnh SQL
                    return "Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message;
                }
                finally
                {
                    conn.Close(); // Đóng kết nối
                }
            }

            return user; // Trả về tên người dùng nếu đăng nhập thành công
        }

        public static List<TaiKhoan> LoadTaiKhoan()
        {
            List<TaiKhoan> danhSachTaiKhoan = new List<TaiKhoan>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_LoadTaiKhoan", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaiKhoan tk = new TaiKhoan
                            {
                                MaTaiKhoan = reader.GetInt32(0),
                                TenDangNhap = reader.GetString(1),
                                MatKhau = reader.GetString(2),
                                MaQuyen = reader.GetInt32(3)
                            };
                            danhSachTaiKhoan.Add(tk);
                        }
                    }
                }
            }
            return danhSachTaiKhoan;
        }
        public static List<NhanViens> LoadNhanVien()
        {
            List<NhanViens> danhSachNhanVien = new List<NhanViens>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();         
                    string query = "SELECT * FROM NhanVien"; 

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NhanViens nv = new NhanViens
                                {
                                    MaNhanVien = reader.GetInt32(0),        // Cột 0 là MaNhanVien
                                    TenNhanVien = reader.GetString(1),
                                    HinhAnh = reader.IsDBNull(2) ? null : reader.GetString(2),  
                                    NgaySinh = reader.GetDateTime(3),       
                                    GioiTinh = reader.GetString(4),         
                                    SoDienThoai = reader.GetString(5),      
                                    ChuyenMon = reader.GetString(6),        
                                    TrangThai = reader.GetString(7),        
                                    Email = reader.GetString(8),            
                                    Luong = reader.GetDecimal(9),           
                                    ChucVu = reader.GetString(10)
                                };
                                danhSachNhanVien.Add(nv);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi kết nối hoặc truy vấn SQL
                    MessageBox.Show("Lỗi kết nối hoặc truy vấn: " + ex.Message);
                }
            }

            return danhSachNhanVien;
        }

    }
}
