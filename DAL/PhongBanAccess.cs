using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhongBanAccess
    {
        private static object ex;

        public static List<PhongBan> LoadPhongBan()
        {
            List<PhongBan> dsPhongBan = new List<PhongBan>();
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open(); 

                    using (SqlCommand cmd = new SqlCommand("SP_DanhSachPhongBan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhongBan dp = new PhongBan
                                {
                                    MaPhongBan = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    TenPhongBan = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    MoTaNhiemVu = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                                };
                                dsPhongBan.Add(dp);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return dsPhongBan; 
        }

        public static void AddPhongBan(PhongBan phongBan)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_ThemPhongBan",conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaPhongBan", phongBan.MaPhongBan);
                        cmd.Parameters.AddWithValue("@TenPhongBan", phongBan.TenPhongBan);
                        cmd.Parameters.AddWithValue("@MoTaNhiemVu", phongBan.MoTaNhiemVu);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
                    }
                    finally { conn.Close(); }
                }    
            }
        }
        public static void DeletePhongBan(int phongBanId)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("SP_XoaPhongBan", conn))
                {
                    try
                    {
                        cmd.CommandType= CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaPhongBan", phongBanId);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi không thể xóa phòng ban" + ex.Message);
                    }
                    finally { conn.Close(); }
                }
            }

        }
        public static void UpdatePhongBan(PhongBan phongBan)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_UpdatePhongBan", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaPhongBan", phongBan.MaPhongBan);
                        cmd.Parameters.AddWithValue("@TenPhongBan", phongBan.TenPhongBan);
                        cmd.Parameters.AddWithValue("@MoTaNhiemVu", phongBan.MoTaNhiemVu);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi" + ex.Message);
                    }
                    finally { conn.Close(); }

                }
            }
        }
    }
}
