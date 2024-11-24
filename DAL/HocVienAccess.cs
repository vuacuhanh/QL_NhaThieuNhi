using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Spreadsheet;
using DTO;

namespace DAL
{
    public class HocVienAccess
    {
        public static List<HocVien> LoadHocVien()
        {
            List<HocVien> danhSachHocVien = new List<HocVien>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_DanhSachHocVien", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HocVien hocVien = new HocVien
                                {
                                    MaHocVien = reader.GetInt32(0),
                                    TenHocVien = reader.GetString(1),
                                    HinhAnh = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    NgaySinh = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                    GioiTinh = reader.GetString(4),
                                    DiaChi = reader.GetString(5),
                                    SoDienThoai = reader.GetString(6),
                                    TrangThai = reader.IsDBNull(7) ? null : reader.GetString(7),
                                    MaPhuHuynh = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                                    MaLop = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9)
                                };
                                danhSachHocVien.Add(hocVien);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachHocVien;
        }

        public static HocVien GetHocVienById(int MaHocVien)
        {
            HocVien hocVien = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetHocVienById", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHocVien", MaHocVien);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hocVien = new HocVien
                                {
                                    MaHocVien = reader.GetInt32(0),
                                    TenHocVien = reader.GetString(1),
                                    HinhAnh = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    NgaySinh = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                    GioiTinh = reader.GetString(4),
                                    DiaChi = reader.GetString(5),
                                    SoDienThoai = reader.GetString(6),
                                    TrangThai = reader.IsDBNull(7) ? null : reader.GetString(7),
                                    MaPhuHuynh = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                                    MaLop = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9)
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi tìm học viên: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return hocVien;
        }

        public static bool AddHocVien(HocVien hocVien)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_ThemHocVien", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHocVien", hocVien.MaHocVien);
                        command.Parameters.AddWithValue("@TenHocVien", hocVien.TenHocVien);
                        command.Parameters.AddWithValue("@HinhAnh", hocVien.HinhAnh ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@NgaySinh", hocVien.NgaySinh ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@GioiTinh", hocVien.GioiTinh);
                        command.Parameters.AddWithValue("@DiaChi", hocVien.DiaChi);
                        command.Parameters.AddWithValue("@SoDienThoai", hocVien.SoDienThoai);
                        command.Parameters.AddWithValue("@TrangThai", hocVien.TrangThai ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@MaPhuHuynh", hocVien.MaPhuHuynh ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@MaLop", hocVien.MaLop ?? (object)DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi thêm học viên: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        // Xóa học viên
        public static bool DeleteHocVien(int MaHocVien)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_XoaHocVien", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHocVien", MaHocVien);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi xóa học viên: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Sửa thông tin học viên
        public static bool UpdateHocVien(HocVien hocVien)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_SuaHocVien", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHocVien", hocVien.MaHocVien);
                        command.Parameters.AddWithValue("@TenHocVien", hocVien.TenHocVien);
                        command.Parameters.AddWithValue("@HinhAnh", hocVien.HinhAnh);
                        command.Parameters.AddWithValue("@NgaySinh", (object)hocVien.NgaySinh ?? DBNull.Value);
                        command.Parameters.AddWithValue("@GioiTinh", hocVien.GioiTinh);
                        command.Parameters.AddWithValue("@DiaChi", hocVien.DiaChi);
                        command.Parameters.AddWithValue("@SoDienThoai", hocVien.SoDienThoai);
                        command.Parameters.AddWithValue("@TrangThai", hocVien.TrangThai);
                        command.Parameters.AddWithValue("@MaPhuHuynh", hocVien.MaPhuHuynh);
                        command.Parameters.AddWithValue("@MaLop", hocVien.MaLop);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi cập nhật học viên: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static List<HocVien> FilterHocVienByMaLop(string maLop)
        {
            List<HocVien> danhSachHocVien = new List<HocVien>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_LocHocVienTheoMaLop", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLop", maLop);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HocVien hocVien = new HocVien
                                {
                                    MaHocVien = reader.GetInt32(0),
                                    TenHocVien = reader.GetString(1),
                                    HinhAnh = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    NgaySinh = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                    GioiTinh = reader.GetString(4),
                                    DiaChi = reader.GetString(5),
                                    SoDienThoai = reader.GetString(6),
                                    TrangThai = reader.GetString(7),
                                    MaPhuHuynh = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                                    MaLop = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9)
                                };
                                danhSachHocVien.Add(hocVien);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi lọc học viên: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachHocVien;
        }
    }
}
