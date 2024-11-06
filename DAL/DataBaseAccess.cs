using System;
using System.Data.SqlClient;
using DTO;
using System.Data;
using System.Collections.Generic;

namespace DAL
{
    public class ConnectionData
    {
<<<<<<< HEAD
        private static readonly string connectionString = @"Data Source=LAPTOP-0GJ5N2UI\SQLEXPRESS;Initial Catalog=QL_NhaThieuNhi;Integrated Security=True";

        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }


=======
        public static SqlConnection Connect()
        {
            string Strcon = @"Data Source=LAPTOP-0GJ5N2UI\SQLEXPRESS;Initial Catalog=QL_NhaThieuNhi;Integrated Security=True";
            return new SqlConnection(Strcon); // Tạo kết nối
        }
>>>>>>> 7ca0bcebd288371c20329ac3812f1025c6559255
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
<<<<<<< HEAD

        public static List<LopHoc> LoadLopHoc()
        {
            List<LopHoc> danhSachLopHoc = new List<LopHoc>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_LoadLopHoc", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LopHoc lop = new LopHoc
                            {
                                MaLop = reader.GetInt32(0),
                                MaNhanVien = reader.GetInt32(1),  // Thêm trường MaNhanVien
                                TenLop = reader.GetString(2),
                                ChuyenMon = reader.GetString(3),  // Thêm trường ChuyenMon
                                SiSo = reader.GetInt32(4),
                                ThoiGianBatDau = reader.GetDateTime(5),  // Thêm trường ThoiGianBatDau
                                ThoiGianKetThuc = reader.GetDateTime(6),  // Thêm trường ThoiGianKetThuc
                                TrangThai = reader.GetString(7)  // Thêm trường TrangThai
                            };
                            danhSachLopHoc.Add(lop);
                        }
                    }
                }
            }

            return danhSachLopHoc;
        }

        public static string AddLopHoc(LopHoc lopHoc)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_ThemLopHoc", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaNhanVien", lopHoc.MaNhanVien); // Thêm MaNhanVien
                    command.Parameters.AddWithValue("@TenLop", lopHoc.TenLop);
                    command.Parameters.AddWithValue("@ChuyenMon", lopHoc.ChuyenMon); // Thêm ChuyenMon
                    command.Parameters.AddWithValue("@SiSo", lopHoc.SiSo);
                    command.Parameters.AddWithValue("@ThoiGianBatDau", lopHoc.ThoiGianBatDau); // Thêm ThoiGianBatDau
                    command.Parameters.AddWithValue("@ThoiGianKetThuc", lopHoc.ThoiGianKetThuc); // Thêm ThoiGianKetThuc
                    command.Parameters.AddWithValue("@TrangThai", lopHoc.TrangThai); // Thêm TrangThai

                    int result = command.ExecuteNonQuery();
                    return result > 0 ? "Thêm lớp học thành công" : "Thêm lớp học thất bại";
                }
            }
        }

        public static string UpdateLopHoc(LopHoc lopHoc)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_SuaLopHoc", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaLop", lopHoc.MaLop);
                    command.Parameters.AddWithValue("@MaNhanVien", lopHoc.MaNhanVien); // Thêm MaNhanVien
                    command.Parameters.AddWithValue("@TenLop", lopHoc.TenLop);
                    command.Parameters.AddWithValue("@ChuyenMon", lopHoc.ChuyenMon); // Thêm ChuyenMon
                    command.Parameters.AddWithValue("@SiSo", lopHoc.SiSo);
                    command.Parameters.AddWithValue("@ThoiGianBatDau", lopHoc.ThoiGianBatDau); // Thêm ThoiGianBatDau
                    command.Parameters.AddWithValue("@ThoiGianKetThuc", lopHoc.ThoiGianKetThuc); // Thêm ThoiGianKetThuc
                    command.Parameters.AddWithValue("@TrangThai", lopHoc.TrangThai); // Thêm TrangThai

                    int result = command.ExecuteNonQuery();
                    return result > 0 ? "Cập nhật lớp học thành công" : "Cập nhật lớp học thất bại";
                }
            }
        }

        public static string DeleteLopHoc(int maLop)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_XoaLopHoc", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaLop", maLop);

                    int result = command.ExecuteNonQuery();
                    return result > 0 ? "Xóa lớp học thành công" : "Xóa lớp học thất bại";
                }
            }
        }

        public static NhanVien GetNhanVienById(int maNhanVien)
        {
            NhanVien nhanVien = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_GetNhanVienById", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nhanVien = new NhanVien
                            {
                                MaNhanVien = reader.GetInt32(0),
                                TenNhanVien = reader.GetString(1),
                                NgaySinh = reader.GetDateTime(2),
                                GioiTinh = reader.GetString(3),
                                SoDienThoai = reader.GetString(4),
                                ChucVu = reader.GetString(5),
                                ChuyenMon = reader.GetString(6),
                                TrangThai = reader.GetString(7),
                                Email = reader.GetString(8),
                                Luong = reader.GetDecimal(9),
                                MaTaiKhoan = reader.IsDBNull(10) ? null : (int?)reader.GetInt32(10),
                                MaPhongBan = reader.IsDBNull(11) ? null : (int?)reader.GetInt32(11)
                            };
                        }
                    }
                }
            }

            return nhanVien;
        }

        public static List<NhanVien> LoadNhanVien()
        {
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_LoadNhanVien", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NhanVien nv = new NhanVien
                            {
                                MaNhanVien = reader.GetInt32(0),
                                TenNhanVien = reader.GetString(1),
                                NgaySinh = reader.GetDateTime(2),
                                GioiTinh = reader.GetString(3),
                                SoDienThoai = reader.GetString(4),
                                ChucVu = reader.GetString(5),
                                ChuyenMon = reader.GetString(6),
                                TrangThai = reader.GetString(7),
                                Email = reader.GetString(8),
                                Luong = reader.GetDecimal(9),
                                MaTaiKhoan = reader.IsDBNull(10) ? null : (int?)reader.GetInt32(10),
                                MaPhongBan = reader.IsDBNull(11) ? null : (int?)reader.GetInt32(11)
                            };
                            danhSachNhanVien.Add(nv);
                        }
                    }
                }
            }

            return danhSachNhanVien;
        }

        public static string AddNhanVien(NhanVien nhanVien)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_ThemNhanVien", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenNhanVien", nhanVien.TenNhanVien);
                    command.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
                    command.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai);
                    command.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu);
                    command.Parameters.AddWithValue("@ChuyenMon", nhanVien.ChuyenMon);
                    command.Parameters.AddWithValue("@TrangThai", nhanVien.TrangThai);
                    command.Parameters.AddWithValue("@Email", nhanVien.Email);
                    command.Parameters.AddWithValue("@Luong", nhanVien.Luong);
                    command.Parameters.AddWithValue("@MaTaiKhoan", nhanVien.MaTaiKhoan ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MaPhongBan", nhanVien.MaPhongBan ?? (object)DBNull.Value);

                    int result = command.ExecuteNonQuery();
                    return result > 0 ? "Thêm nhân viên thành công" : "Thêm nhân viên thất bại";
                }
            }
        }

        public static string UpdateNhanVien(NhanVien nhanVien)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_SuaNhanVien", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaNhanVien", nhanVien.MaNhanVien);
                    command.Parameters.AddWithValue("@TenNhanVien", nhanVien.TenNhanVien);
                    command.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
                    command.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai);
                    command.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu);
                    command.Parameters.AddWithValue("@ChuyenMon", nhanVien.ChuyenMon);
                    command.Parameters.AddWithValue("@TrangThai", nhanVien.TrangThai);
                    command.Parameters.AddWithValue("@Email", nhanVien.Email);
                    command.Parameters.AddWithValue("@Luong", nhanVien.Luong);
                    command.Parameters.AddWithValue("@MaTaiKhoan", nhanVien.MaTaiKhoan ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MaPhongBan", nhanVien.MaPhongBan ?? (object)DBNull.Value);

                    int result = command.ExecuteNonQuery();
                    return result > 0 ? "Cập nhật nhân viên thành công" : "Cập nhật nhân viên thất bại";
                }
            }
        }

        public static string DeleteNhanVien(int maNhanVien)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_XoaNhanVien", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                    int result = command.ExecuteNonQuery();
                    return result > 0 ? "Xóa nhân viên thành công" : "Xóa nhân viên thất bại";
                }
            }
        }

    }
}
=======
    }
}
>>>>>>> 7ca0bcebd288371c20329ac3812f1025c6559255
