using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Spreadsheet;
using DTO;

namespace DAL
{
    public class LichBaoTriAccess
    {
        public static List<LichBaoTri> LoadLichBaoTri()
        {
            List<LichBaoTri> danhSachLichBaoTri = new List<LichBaoTri>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_DanhSachLichBaoTri", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LichBaoTri lichBaoTri = new LichBaoTri
                                {
                                    MaLichBaoTri = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    MaNhanVienLapLich = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                                    ThoiGianBD = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2),
                                    ThoiGianKT = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                                    TrangThai = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                                    MaCSVC = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                    MaNhanVienBaoTri = reader.IsDBNull(6) ? 0 : reader.GetInt32(6)
                                };
                                danhSachLichBaoTri.Add(lichBaoTri);
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

            return danhSachLichBaoTri;
        }

        public static LichBaoTri GetLichBaoTriById(int maLichBaoTri)
        {
            LichBaoTri lichBaoTri = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetLichBaoTriById", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLichBaoTri", maLichBaoTri);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lichBaoTri = new LichBaoTri
                                {
                                    MaLichBaoTri = reader.GetInt32(0),
                                    MaNhanVienLapLich = reader.GetInt32(1),
                                    ThoiGianBD = reader.GetDateTime(2),
                                    ThoiGianKT = reader.GetDateTime(3),
                                    TrangThai = reader.GetString(4),
                                    MaCSVC = reader.GetInt32(5),
                                    MaNhanVienBaoTri = reader.GetInt32(6)
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi lấy lịch bảo trì: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return lichBaoTri;
        }

        public static bool AddLichBaoTri(LichBaoTri lichBaoTri)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_ThemLichBaoTri", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaNhanVienLapLich", lichBaoTri.MaNhanVienLapLich);
                        command.Parameters.AddWithValue("@ThoiGianBD", lichBaoTri.ThoiGianBD);
                        command.Parameters.AddWithValue("@ThoiGianKT", lichBaoTri.ThoiGianKT);
                        command.Parameters.AddWithValue("@TrangThai", lichBaoTri.TrangThai);
                        command.Parameters.AddWithValue("@MaCSVC", lichBaoTri.MaCSVC);
                        command.Parameters.AddWithValue("@MaNhanVienBaoTri", lichBaoTri.MaNhanVienBaoTri);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi thêm lịch bảo trì: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static bool UpdateLichBaoTri(LichBaoTri lichBaoTri)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_SuaLichBaoTri", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLichBaoTri", lichBaoTri.MaLichBaoTri);
                        command.Parameters.AddWithValue("@MaNhanVienLapLich", lichBaoTri.MaNhanVienLapLich);
                        command.Parameters.AddWithValue("@ThoiGianBD", lichBaoTri.ThoiGianBD);
                        command.Parameters.AddWithValue("@ThoiGianKT", lichBaoTri.ThoiGianKT);
                        command.Parameters.AddWithValue("@TrangThai", lichBaoTri.TrangThai);
                        command.Parameters.AddWithValue("@MaCSVC", lichBaoTri.MaCSVC);
                        command.Parameters.AddWithValue("@MaNhanVienBaoTri", lichBaoTri.MaNhanVienBaoTri);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi cập nhật lịch bảo trì: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static bool DeleteLichBaoTri(int maLichBaoTri)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_XoaLichBaoTri", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLichBaoTri", maLichBaoTri);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi xóa lịch bảo trì: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static List<LichBaoTri> FilterLichBaoTriByTrangThai(string trangThai)
        {
            List<LichBaoTri> danhSachLichBaoTri = new List<LichBaoTri>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_LocLichBaoTriTheoTrangThai", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TrangThai", trangThai);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LichBaoTri lichBaoTri = new LichBaoTri
                                {
                                    MaLichBaoTri = reader.GetInt32(0),
                                    MaNhanVienLapLich = reader.GetInt32(1),
                                    ThoiGianBD = reader.GetDateTime(2),
                                    ThoiGianKT = reader.GetDateTime(3),
                                    TrangThai = reader.GetString(4),
                                    MaCSVC = reader.GetInt32(5),
                                    MaNhanVienBaoTri = reader.GetInt32(6),
                                };
                                danhSachLichBaoTri.Add(lichBaoTri);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi lọc lịch bảo trì theo trạng thái: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachLichBaoTri;
        }


    }

}
