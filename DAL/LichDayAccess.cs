using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class LichDayAccess
    {
        // Lấy danh sách tất cả lịch dạy
        public static List<LichDay> LoadLichDay()
        {
            List<LichDay> danhSachLichDay = new List<LichDay>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_DanhSachLichDay", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LichDay lichDay = new LichDay
                                {
                                    MaLichDay = reader.GetInt32(0),
                                    MaNhanVien = reader.GetInt32(1),
                                    MaLop = reader.GetInt32(2),
                                    MaCaHoc = reader.GetInt32(3),
                                    NgayDay = reader.GetDateTime(4),
                                    NgayKetThuc = (DateTime)(reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)),
                                    PhongHoc = reader.GetString(6),
                                    TrangThai = reader.GetString(7)
                                };
                                danhSachLichDay.Add(lichDay);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi lấy danh sách lịch dạy: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachLichDay;
        }

        // Lấy lịch dạy theo mã
        public static LichDay GetLichDayById(int maLichDay)
        {
            LichDay lichDay = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetLichDayById", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLichDay", maLichDay);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lichDay = new LichDay
                                {
                                    MaLichDay = reader.GetInt32(0),
                                    MaNhanVien = reader.GetInt32(1),
                                    MaLop = reader.GetInt32(2),
                                    MaCaHoc = reader.GetInt32(3),
                                    NgayDay = reader.GetDateTime(4),
                                    NgayKetThuc = (DateTime)(reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)),
                                    PhongHoc = reader.GetString(6),
                                    TrangThai = reader.GetString(7)
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi tìm lịch dạy: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return lichDay;
        }

        // Thêm mới lịch dạy
        public static bool AddLichDay(LichDay lichDay)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_ThemLichDay", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaNhanVien", lichDay.MaNhanVien);
                        command.Parameters.AddWithValue("@MaLop", lichDay.MaLop);
                        command.Parameters.AddWithValue("@MaCaHoc", lichDay.MaCaHoc);
                        command.Parameters.AddWithValue("@NgayDay", lichDay.NgayDay);
                        command.Parameters.AddWithValue("@NgayKetThuc", lichDay.NgayKetThuc);
                        command.Parameters.AddWithValue("@PhongHoc", lichDay.PhongHoc);
                        command.Parameters.AddWithValue("@TrangThai", lichDay.TrangThai);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi thêm lịch dạy: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Sửa thông tin lịch dạy
        public static bool UpdateLichDay(LichDay lichDay)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_SuaLichDay", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLichDay", lichDay.MaLichDay);
                        command.Parameters.AddWithValue("@MaNhanVien", lichDay.MaNhanVien);
                        command.Parameters.AddWithValue("@MaLop", lichDay.MaLop);
                        command.Parameters.AddWithValue("@MaCaHoc", lichDay.MaCaHoc);
                        command.Parameters.AddWithValue("@NgayDay", lichDay.NgayDay);
                        command.Parameters.AddWithValue("@NgayKetThuc", lichDay.NgayKetThuc);
                        command.Parameters.AddWithValue("@PhongHoc", lichDay.PhongHoc);
                        command.Parameters.AddWithValue("@TrangThai", lichDay.TrangThai);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi cập nhật lịch dạy: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Xóa lịch dạy
        public static bool DeleteLichDay(int maLichDay)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_XoaLichDay", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLichDay", maLichDay);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi xóa lịch dạy: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }
        //CheckMaLichDayExists
        public static bool CheckMaLichDayExists(int maLichDay)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_CheckMaLichDayExists", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLichDay", maLichDay);

                        var result = command.ExecuteScalar();
                        return result != null && (int)result > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi kiểm tra mã lịch dạy: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        public static List<LichDay> FilterLichDayByMaLop(string maLop)
        {
            List<LichDay> danhSachLichDay = new List<LichDay>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_LocLichDayTheoMaLop", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLop", maLop);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LichDay lichDay = new LichDay
                                {
                                    MaLichDay = reader.GetInt32(0),
                                    MaNhanVien = reader.GetInt32(1),
                                    MaLop = reader.GetInt32(2),
                                    MaCaHoc = reader.GetInt32(3),
                                    NgayDay = reader.GetDateTime(4),
                                    NgayKetThuc = (DateTime)(reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)),
                                    PhongHoc = reader.GetString(6),
                                    TrangThai = reader.GetString(7)
                                };
                                danhSachLichDay.Add(lichDay);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi lọc lịch dạy: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachLichDay;
        }
        public static List<LichDay> FilterLichDayByMaNhanVien(int maNhanVien)
        {
            List<LichDay> danhSachLichDay = new List<LichDay>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_LocLichDayTheoMaNhanVien", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LichDay lichDay = new LichDay
                                {
                                    MaLichDay = reader.GetInt32(0),
                                    MaNhanVien = reader.GetInt32(1),
                                    MaLop = reader.GetInt32(2),
                                    MaCaHoc = reader.GetInt32(3),
                                    NgayDay = reader.GetDateTime(4),
                                    NgayKetThuc = (DateTime)(reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)),
                                    PhongHoc = reader.GetString(6),
                                    TrangThai = reader.GetString(7)
                                };
                                danhSachLichDay.Add(lichDay);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi lọc lịch dạy theo mã nhân viên: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachLichDay;
        }

    }

}
