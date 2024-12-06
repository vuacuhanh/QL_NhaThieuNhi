using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class CaHocAccess
    {
        // Lấy danh sách tất cả các ca học
        public List<CaHoc> LoadAllCaHoc()
        {
            List<CaHoc> danhSachCaHoc = new List<CaHoc>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllCaHoc", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CaHoc caHoc = new CaHoc
                                {
                                    MaCaHoc = reader.GetInt32(reader.GetOrdinal("MaCaHoc")),
                                    TietHoc = reader.GetString(reader.GetOrdinal("TietHoc"))
                                };

                                // Sử dụng if-else thay cho target-typed conditional expressions
                                if (reader.IsDBNull(reader.GetOrdinal("ThoiGianBatDau")))
                                    caHoc.ThoiGianBatDau = null;
                                else
                                    caHoc.ThoiGianBatDau = reader.GetTimeSpan(reader.GetOrdinal("ThoiGianBatDau"));

                                if (reader.IsDBNull(reader.GetOrdinal("ThoiGianKetThuc")))
                                    caHoc.ThoiGianKetThuc = null;
                                else
                                    caHoc.ThoiGianKetThuc = reader.GetTimeSpan(reader.GetOrdinal("ThoiGianKetThuc"));

                                danhSachCaHoc.Add(caHoc);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy danh sách Ca Học: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachCaHoc;
        }

        // Thêm ca học mới
        public bool AddCaHoc(CaHoc caHoc)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_InsertCaHoc", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaCaHoc", caHoc.MaCaHoc);
                        cmd.Parameters.AddWithValue("@TietHoc", caHoc.TietHoc ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ThoiGianBatDau", caHoc.ThoiGianBatDau ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ThoiGianKetThuc", caHoc.ThoiGianKetThuc ?? (object)DBNull.Value);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm Ca Học: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Cập nhật ca học
        public bool UpdateCaHoc(CaHoc caHoc)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateCaHoc", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaCaHoc", caHoc.MaCaHoc);
                        cmd.Parameters.AddWithValue("@TietHoc", caHoc.TietHoc ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ThoiGianBatDau", caHoc.ThoiGianBatDau ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ThoiGianKetThuc", caHoc.ThoiGianKetThuc ?? (object)DBNull.Value);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật Ca Học: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Xóa ca học
        public bool DeleteCaHoc(int maCaHoc)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteCaHoc", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaCaHoc", maCaHoc);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi xóa Ca Học: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
