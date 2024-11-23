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
    public class PhuHuynhAccess
    {
        public static List<PhuHuynh> LoadPhuHuynh()
        {
            List<PhuHuynh> danhSachPhuHuynh = new List<PhuHuynh>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_DanhSachPhuHuynh", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhuHuynh phuHuynh = new PhuHuynh
                                {
                                    MaPhuHuynh = reader.GetInt32(0), // Mã phụ huynh
                                    TenPhuHuynh = reader.GetString(1), // Tên phụ huynh
                                    GioiTinh = reader.GetString(2), // Giới tính
                                    NgaySinh = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3), // Ngày sinh
                                    NgheNghiep = reader.GetString(4), // Nghề nghiệp
                                    DiaChi = reader.GetString(5), // Địa chỉ
                                    Email = reader.IsDBNull(6) ? null : reader.GetString(6), // Email
                                    SoDienThoai = reader.GetString(7) // Số điện thoại
                                };
                                danhSachPhuHuynh.Add(phuHuynh);
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

            return danhSachPhuHuynh;
        }

        public static List<PhuHuynh> FilterPhuHuynhByNgheNghiep(string ngheNghiep)
        {
            List<PhuHuynh> danhSachPhuHuynh = new List<PhuHuynh>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_LocPhuHuynhTheoNgheNghiep", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NgheNghiep", ngheNghiep);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhuHuynh phuHuynh = new PhuHuynh
                                {
                                    MaPhuHuynh = reader.GetInt32(0),
                                    TenPhuHuynh = reader.GetString(1),
                                    NgaySinh = reader.GetDateTime(2),
                                    NgheNghiep = reader.GetString(3),
                                    DiaChi = reader.GetString(4),
                                    Email = reader.GetString(5),
                                    SoDienThoai = reader.GetString(6)
                                };
                                danhSachPhuHuynh.Add(phuHuynh);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi lọc phụ huynh: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachPhuHuynh;
        }

        // Thêm phụ huynh
        public static bool AddPhuHuynh(PhuHuynh phuHuynh)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_ThemPhuHuynh", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TenPhuHuynh", phuHuynh.TenPhuHuynh);
                        command.Parameters.AddWithValue("@GioiTinh", phuHuynh.GioiTinh);
                        command.Parameters.AddWithValue("@NgheNghiep", phuHuynh.NgheNghiep);
                        command.Parameters.AddWithValue("@NgaySinh", (object)phuHuynh.NgaySinh ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DiaChi", phuHuynh.DiaChi);
                        command.Parameters.AddWithValue("@Email", phuHuynh.Email);
                        command.Parameters.AddWithValue("@SoDienThoai", phuHuynh.SoDienThoai);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi thêm phụ huynh: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Xóa phụ huynh
        public static bool DeletePhuHuynh(int maPhuHuynh)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_XoaPhuHuynh", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaPhuHuynh", maPhuHuynh);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi xóa phụ huynh: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Sửa thông tin phụ huynh
        public static bool UpdatePhuHuynh(PhuHuynh phuHuynh)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_SuaPhuHuynh", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaPhuHuynh", phuHuynh.MaPhuHuynh);
                        command.Parameters.AddWithValue("@TenPhuHuynh", phuHuynh.TenPhuHuynh);
                        command.Parameters.AddWithValue("@GioiTinh", phuHuynh.GioiTinh);
                        command.Parameters.AddWithValue("@NgheNghiep", phuHuynh.NgheNghiep);
                        command.Parameters.AddWithValue("@NgaySinh", (object)phuHuynh.NgaySinh ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DiaChi", phuHuynh.DiaChi);
                        command.Parameters.AddWithValue("@Email", phuHuynh.Email);
                        command.Parameters.AddWithValue("@SoDienThoai", phuHuynh.SoDienThoai);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi cập nhật phụ huynh: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Tìm phụ huynh theo mã
        public static PhuHuynh GetPhuHuynhById(int maPhuHuynh)
        {
            PhuHuynh phuHuynh = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPhuHuynhById", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaPhuHuynh", maPhuHuynh);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                phuHuynh = new PhuHuynh
                                {
                                    MaPhuHuynh = reader.GetInt32(0),
                                    TenPhuHuynh = reader.GetString(1),
                                    GioiTinh = reader.GetString(2),
                                    NgheNghiep = reader.GetString(3),
                                    NgaySinh = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                                    DiaChi = reader.GetString(5),
                                    Email = reader.GetString(6),
                                    SoDienThoai = reader.GetString(7)
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi tìm phụ huynh: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return phuHuynh;
        }
    }
}

