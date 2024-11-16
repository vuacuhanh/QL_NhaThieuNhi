using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DTO;

namespace DAL
{
    public class LopHocAccess
    {
        // Lấy danh sách lớp học
        //public static List<LopHoc> GetAllLopHoc()
        //{
        //    using (var context = new NTNContext())
        //    {
        //        return context.LopHocs.ToList();
        //    }
        //}
        public static List<LopHoc> LoadLopHoc()
        {
            List<LopHoc> danhSachLopHoc = new List<LopHoc>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_DanhSachLopHoc", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LopHoc lopHoc = new LopHoc
                                {
                                    MaLop = reader.GetInt32(0),
                                    MaNhanVien = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                    TenLop = reader.GetString(2),
                                    ChuyenMon = reader.GetString(3),
                                    SiSo = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                                    ThoiGianBatDau = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                                    ThoiGianKetThuc = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),
                                    TrangThai = reader.GetString(7)
                                };
                                danhSachLopHoc.Add(lopHoc);
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

            return danhSachLopHoc;
        }

        // Thêm lớp học
        public static bool AddLopHoc(LopHoc lopHoc)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_ThemLopHoc", conn)) // Giả sử dùng stored procedure SP_ThemLopHoc
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLop", lopHoc.MaLop);
                        command.Parameters.AddWithValue("@MaNhanVien", (object)lopHoc.MaNhanVien ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TenLop", lopHoc.TenLop);
                        command.Parameters.AddWithValue("@ChuyenMon", lopHoc.ChuyenMon);
                        command.Parameters.AddWithValue("@SiSo", (object)lopHoc.SiSo ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianBatDau", (object)lopHoc.ThoiGianBatDau ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianKetThuc", (object)lopHoc.ThoiGianKetThuc ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TrangThai", lopHoc.TrangThai);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi thêm lớp học: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Xóa lớp học
        public static bool DeleteLopHoc(int maLop)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_XoaLopHoc", conn)) // Giả sử dùng stored procedure SP_XoaLopHoc
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLop", maLop);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi xóa lớp học: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Sửa lớp học
        public static bool UpdateLopHoc(LopHoc lopHoc)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_SuaLopHoc", conn)) // Giả sử dùng stored procedure SP_SuaLopHoc
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLop", lopHoc.MaLop);
                        command.Parameters.AddWithValue("@MaNhanVien", (object)lopHoc.MaNhanVien ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TenLop", lopHoc.TenLop);
                        command.Parameters.AddWithValue("@ChuyenMon", lopHoc.ChuyenMon);
                        command.Parameters.AddWithValue("@SiSo", (object)lopHoc.SiSo ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianBatDau", (object)lopHoc.ThoiGianBatDau ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianKetThuc", (object)lopHoc.ThoiGianKetThuc ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TrangThai", lopHoc.TrangThai);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi cập nhật lớp học: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Tìm lớp học theo mã
        public static LopHoc GetLopHocById(int maLop)
        {
            LopHoc lopHoc = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetLopHocById", conn)) // Giả sử dùng stored procedure SP_GetLopHocById
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLop", maLop);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lopHoc = new LopHoc
                                {
                                    MaLop = reader.GetInt32(0),
                                    MaNhanVien = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                    TenLop = reader.GetString(2),
                                    ChuyenMon = reader.GetString(3),
                                    SiSo = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                                    ThoiGianBatDau = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                                    ThoiGianKetThuc = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),
                                    TrangThai = reader.GetString(7)
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi tìm lớp học: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return lopHoc;
        }

        // Lọc lớp học theo chuyên môn
        public static List<LopHoc> FilterLopHocByChuyenMon(string chuyenMon)
        {
            List<LopHoc> danhSachLopHoc = new List<LopHoc>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_LocLopHocTheoChuyenMon", conn)) // Giả sử dùng stored procedure SP_FilterLopHocByChuyenMon
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ChuyenMon", chuyenMon);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LopHoc lopHoc = new LopHoc
                                {
                                    MaLop = reader.GetInt32(0),
                                    MaNhanVien = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                    TenLop = reader.GetString(2),
                                    ChuyenMon = reader.GetString(3),
                                    SiSo = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                                    ThoiGianBatDau = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                                    ThoiGianKetThuc = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),
                                    TrangThai = reader.GetString(7)
                                };
                                danhSachLopHoc.Add(lopHoc);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi lọc lớp học: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachLopHoc;
        }
    }
}
