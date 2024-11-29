using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ChuongTrinhNangKhieuAccess
    {
        // Lấy danh sách chương trình năng khiếu
        public static List<ChuongTrinhNangKhieu> LoadChuongTrinhNangKhieu()
        {
            List<ChuongTrinhNangKhieu> danhSachCTNK = new List<ChuongTrinhNangKhieu>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_DanhSachCTNK", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChuongTrinhNangKhieu ctnk = new ChuongTrinhNangKhieu
                                {
                                    MaCTNK = reader.GetInt32(0),
                                    TenCT = reader.GetString(1),
                                    MoTa = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    ThoiGianBatDau = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                    ThoiGianKetThuc = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                                    DiaDiem = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    MaGiaoVien = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6)
                                };
                                danhSachCTNK.Add(ctnk);
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

            return danhSachCTNK;
        }

        // Thêm chương trình năng khiếu
        public static bool AddChuongTrinhNangKhieu(ChuongTrinhNangKhieu ctnk)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_ThemCTNK", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaCTNK", ctnk.MaCTNK);
                        command.Parameters.AddWithValue("@TenCT", ctnk.TenCT);
                        command.Parameters.AddWithValue("@MoTa", (object)ctnk.MoTa ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianBatDau", (object)ctnk.ThoiGianBatDau ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianKetThuc", (object)ctnk.ThoiGianKetThuc ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DiaDiem", (object)ctnk.DiaDiem ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MaGiaoVien", (object)ctnk.MaGiaoVien ?? DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi thêm chương trình năng khiếu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Xóa chương trình năng khiếu
        public static bool DeleteChuongTrinhNangKhieu(int maCTNK)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_XoaCTNK", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaCTNK", maCTNK);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi xóa chương trình năng khiếu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Sửa chương trình năng khiếu
        public static bool UpdateChuongTrinhNangKhieu(ChuongTrinhNangKhieu ctnk)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_SuaCTNK", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaCTNK", ctnk.MaCTNK);
                        command.Parameters.AddWithValue("@TenCT", ctnk.TenCT);
                        command.Parameters.AddWithValue("@MoTa", (object)ctnk.MoTa ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianBatDau", (object)ctnk.ThoiGianBatDau ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThoiGianKetThuc", (object)ctnk.ThoiGianKetThuc ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DiaDiem", (object)ctnk.DiaDiem ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MaGiaoVien", (object)ctnk.MaGiaoVien ?? DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi cập nhật chương trình năng khiếu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Tìm chương trình năng khiếu theo mã
        public static ChuongTrinhNangKhieu GetChuongTrinhNangKhieuById(int maCTNK)
        {
            ChuongTrinhNangKhieu ctnk = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCTNKById", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaCTNK", maCTNK);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ctnk = new ChuongTrinhNangKhieu
                                {
                                    MaCTNK = reader.GetInt32(0),
                                    TenCT = reader.GetString(1),
                                    MoTa = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    ThoiGianBatDau = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                    ThoiGianKetThuc = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                                    DiaDiem = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    MaGiaoVien = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6)
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi tìm chương trình năng khiếu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return ctnk;
        }
    }
}
