using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class HoaDonAccess
    {
        // Lấy danh sách hóa đơn
        public static List<HoaDon> LoadHoaDon()
        {
            List<HoaDon> danhSachHoaDon = new List<HoaDon>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_DanhSachHoaDon", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HoaDon hoaDon = new HoaDon
                                {
                                    MaHoaDon = reader.GetInt32(0),
                                    SoTien = reader.IsDBNull(1) ? (decimal?)null : reader.GetDecimal(1),
                                    NgayLap = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                                    HinhThucThanhToan = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    TrangThaiThanhToan = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    ThoiGianBatDauDongTien = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                                    ThoiGianKetThucDongTien = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),
                                    MaHocVien = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7),
                                    MaLop = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                                };
                                danhSachHoaDon.Add(hoaDon);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachHoaDon;
        }


        // Thêm hóa đơn
        public static bool AddHoaDon(HoaDon hoaDon)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_ThemHoaDon", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
                        command.Parameters.AddWithValue("@SoTien", hoaDon.SoTien);
                        command.Parameters.AddWithValue("@NgayLap", hoaDon.NgayLap);
                        command.Parameters.AddWithValue("@HinhThucThanhToan", hoaDon.HinhThucThanhToan);
                        command.Parameters.AddWithValue("@TrangThaiThanhToan", hoaDon.TrangThaiThanhToan);
                        command.Parameters.AddWithValue("@ThoiGianBatDauDongTien", hoaDon.ThoiGianBatDauDongTien);
                        command.Parameters.AddWithValue("@ThoiGianKetThucDongTien", hoaDon.ThoiGianKetThucDongTien);
                        command.Parameters.AddWithValue("@MaHocVien", hoaDon.MaHocVien);
                        command.Parameters.AddWithValue("@MaLop", hoaDon.MaLop);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi thêm hóa đơn: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Xóa hóa đơn
        public static bool DeleteHoaDon(int maHoaDon)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_XoaHoaDon", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi xóa hóa đơn: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Cập nhật hóa đơn
        public static bool UpdateHoaDon(HoaDon hoaDon)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_SuaHoaDon", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
                        command.Parameters.AddWithValue("@SoTien", hoaDon.SoTien);
                        command.Parameters.AddWithValue("@NgayLap", hoaDon.NgayLap);
                        command.Parameters.AddWithValue("@HinhThucThanhToan", hoaDon.HinhThucThanhToan);
                        command.Parameters.AddWithValue("@TrangThaiThanhToan", hoaDon.TrangThaiThanhToan);
                        command.Parameters.AddWithValue("@ThoiGianBatDauDongTien", hoaDon.ThoiGianBatDauDongTien);
                        command.Parameters.AddWithValue("@ThoiGianKetThucDongTien", hoaDon.ThoiGianKetThucDongTien);
                        command.Parameters.AddWithValue("@MaHocVien", hoaDon.MaHocVien);
                        command.Parameters.AddWithValue("@MaLop", hoaDon.MaLop);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi cập nhật hóa đơn: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Tìm hóa đơn theo mã
        public static HoaDon GetHoaDonById(int maHoaDon)
        {
            HoaDon hoaDon = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetHoaDonById", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hoaDon = new HoaDon
                                {
                                    MaHoaDon = reader.GetInt32(0),
                                    SoTien = reader.GetDecimal(1),
                                    NgayLap = reader.GetDateTime(2),
                                    HinhThucThanhToan = reader.GetString(3),
                                    TrangThaiThanhToan = reader.GetString(4),
                                    ThoiGianBatDauDongTien = reader.GetDateTime(5),
                                    ThoiGianKetThucDongTien = reader.GetDateTime(6),
                                    MaHocVien = reader.GetInt32(7),
                                    MaLop = reader.GetInt32(8)
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi tìm hóa đơn: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return hoaDon;
        }

        // Lọc hóa đơn theo trạng thái thanh toán
        public static List<HoaDon> FilterHoaDonByTrangThaiThanhToan(string trangThaiThanhToan)
        {
            List<HoaDon> danhSachHoaDon = new List<HoaDon>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_LocHoaDonTheoTrangThaiThanhToan", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TrangThaiThanhToan", trangThaiThanhToan);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HoaDon hoaDon = new HoaDon
                                {
                                    MaHoaDon = reader.GetInt32(0),
                                    SoTien = reader.GetDecimal(1),
                                    NgayLap = reader.GetDateTime(2),
                                    HinhThucThanhToan = reader.GetString(3),
                                    TrangThaiThanhToan = reader.GetString(4),
                                    ThoiGianBatDauDongTien = reader.GetDateTime(5),
                                    ThoiGianKetThucDongTien = reader.GetDateTime(6),
                                    MaHocVien = reader.GetInt32(7),
                                    MaLop = reader.GetInt32(8)
                                };
                                danhSachHoaDon.Add(hoaDon);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi lọc hóa đơn: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachHoaDon;
        }
        public static bool UpdateTrangThaiThanhToan(int maHoaDon, string trangThaiThanhToan)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE HoaDon SET TrangThaiThanhToan = @TrangThaiThanhToan WHERE MaHoaDon = @MaHoaDon", conn))
                    {
                        command.Parameters.AddWithValue("@TrangThaiThanhToan", trangThaiThanhToan);
                        command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi cập nhật trạng thái thanh toán: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static bool UpdateHinhThucThanhToan(int maHoaDon, string hinhThucThanhToan)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE HoaDon SET HinhThucThanhToan = @HinhThucThanhToan WHERE MaHoaDon = @MaHoaDon", conn))
                    {
                        command.Parameters.AddWithValue("@HinhThucThanhToan", hinhThucThanhToan);
                        command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi cập nhật hình thức thanh toán: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }
}
