using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class HoatDongNgoaiKhoaAccess
    {
        // Lấy danh sách hoạt động ngoại khóa
        public static List<HoatDongNgoaiKhoa> LoadHoatDongNgoaiKhoa()
        {
            List<HoatDongNgoaiKhoa> danhSachHDNK = new List<HoatDongNgoaiKhoa>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("GetAllHoatDongNgoaiKhoa", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HoatDongNgoaiKhoa hdnk = new HoatDongNgoaiKhoa
                                {
                                    MaHDNK = reader.GetInt32(0),
                                    TenHoatDong = reader.GetString(1),
                                    MoTa = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    ThoiGianBatDau = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                    ThoiGianToChuc = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                                    DiaDiem = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    MaGiaoVien = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6)
                                };
                                danhSachHDNK.Add(hdnk);
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

            return danhSachHDNK;
        }

        // Thêm hoạt động ngoại khóa
        public static bool AddHoatDongNgoaiKhoa(HoatDongNgoaiKhoa hdnk)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("AddHoatDongNgoaiKhoa", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHDNK", hdnk.MaHDNK);
                        command.Parameters.AddWithValue("@TenHoatDong", hdnk.TenHoatDong);
                        command.Parameters.AddWithValue("@MoTa", (object)hdnk.MoTa ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianBatDau", (object)hdnk.ThoiGianBatDau ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianToChuc", (object)hdnk.ThoiGianToChuc ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DiaDiem", (object)hdnk.DiaDiem ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MaGiaoVien", (object)hdnk.MaGiaoVien ?? DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi thêm hoạt động ngoại khóa: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Xóa hoạt động ngoại khóa
        public static bool DeleteHoatDongNgoaiKhoa(int maHDNK)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("DeleteHoatDongNgoaiKhoa", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHDNK", maHDNK);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi xóa hoạt động ngoại khóa: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Sửa hoạt động ngoại khóa
        public static bool UpdateHoatDongNgoaiKhoa(HoatDongNgoaiKhoa hdnk)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("UpdateHoatDongNgoaiKhoa", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHDNK", hdnk.MaHDNK);
                        command.Parameters.AddWithValue("@TenHoatDong", hdnk.TenHoatDong);
                        command.Parameters.AddWithValue("@MoTa", (object)hdnk.MoTa ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianBatDau", (object)hdnk.ThoiGianBatDau ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianToChuc", (object)hdnk.ThoiGianToChuc ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DiaDiem", (object)hdnk.DiaDiem ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MaGiaoVien", (object)hdnk.MaGiaoVien ?? DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi cập nhật hoạt động ngoại khóa: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Tìm hoạt động ngoại khóa theo mã
        public static HoatDongNgoaiKhoa GetHoatDongNgoaiKhoaById(int maHDNK)
        {
            HoatDongNgoaiKhoa hdnk = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetHDNKById", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHDNK", maHDNK);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hdnk = new HoatDongNgoaiKhoa
                                {
                                    MaHDNK = reader.GetInt32(0),
                                    TenHoatDong = reader.GetString(1),
                                    MoTa = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    ThoiGianBatDau = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                    ThoiGianToChuc = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                                    DiaDiem = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    MaGiaoVien = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6)
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi tìm hoạt động ngoại khóa: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return hdnk;
        }
    }
}
