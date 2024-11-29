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
    public class CoSoVatChatAccess
    {
        // Lấy danh sách cơ sở vật chất
        public static List<CoSoVatChat> LoadCoSoVatChat()
        {
            List<CoSoVatChat> danhSachCoSo = new List<CoSoVatChat>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_DanhSachCoSoVatChat", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CoSoVatChat coSo = new CoSoVatChat
                                {
                                    MaCSVC = reader.GetInt32(0),
                                    TenCoSo = reader.GetString(1),
                                    HinhAnh = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    LoaiCoSo = reader.GetString(3),
                                    SoLuong = reader.GetInt32(4)
                                };
                                danhSachCoSo.Add(coSo);
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

            return danhSachCoSo;
        }

        // Lấy cơ sở vật chất theo mã
        public static CoSoVatChat GetCoSoVatChatById(int maCSVC)
        {
            CoSoVatChat coSo = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCoSoVatChatById", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaCSVC", maCSVC);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                coSo = new CoSoVatChat
                                {
                                    MaCSVC = reader.GetInt32(0),
                                    TenCoSo = reader.GetString(1),
                                    HinhAnh = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    LoaiCoSo = reader.GetString(3),
                                    SoLuong = reader.GetInt32(4)
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi tìm cơ sở vật chất: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return coSo;
        }

        // Thêm cơ sở vật chất
        public static bool AddCoSoVatChat(CoSoVatChat coSo)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_ThemCoSoVatChat", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaCSVC", coSo.MaCSVC);
                        command.Parameters.AddWithValue("@TenCoSo", coSo.TenCoSo);
                        command.Parameters.AddWithValue("@HinhAnh", coSo.HinhAnh ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LoaiCoSo", coSo.LoaiCoSo);
                        command.Parameters.AddWithValue("@SoLuong", coSo.SoLuong);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi thêm cơ sở vật chất: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Sửa thông tin cơ sở vật chất
        public static bool UpdateCoSoVatChat(CoSoVatChat coSo)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_SuaCoSoVatChat", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaCSVC", coSo.MaCSVC);
                        command.Parameters.AddWithValue("@TenCoSo", coSo.TenCoSo);
                        command.Parameters.AddWithValue("@HinhAnh", coSo.HinhAnh ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LoaiCoSo", coSo.LoaiCoSo);
                        command.Parameters.AddWithValue("@SoLuong", coSo.SoLuong);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi cập nhật cơ sở vật chất: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Xóa cơ sở vật chất
        public static bool DeleteCoSoVatChat(int maCSVC)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_XoaCoSoVatChat", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaCSVC", maCSVC);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi xóa cơ sở vật chất: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static List<CoSoVatChat> FilterCoSoVatChatByLoai(string loaiCoSo)
        {
            List<CoSoVatChat> danhSachCoSoVatChat = new List<CoSoVatChat>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_LocCoSoVatChatTheoLoai", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoaiCoSo", loaiCoSo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CoSoVatChat coSoVatChat = new CoSoVatChat
                                {
                                    MaCSVC = reader.GetInt32(0),
                                    TenCoSo = reader.GetString(1),
                                    HinhAnh = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    LoaiCoSo = reader.GetString(3),
                                    SoLuong = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                                };
                                danhSachCoSoVatChat.Add(coSoVatChat);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi khi lọc cơ sở vật chất: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return danhSachCoSoVatChat;
        }

    }
}
