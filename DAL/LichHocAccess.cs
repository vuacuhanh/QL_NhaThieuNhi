using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class LichHocDAL
    {
        public static List<LichHoc> GetLichHocDataForWeek(DateTime startOfWeek)
        {
            List<LichHoc> lichHocs = new List<LichHoc>();
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                // Sử dụng Stored Procedure SP_LoadLichHoc
                SqlCommand cmd = new SqlCommand("SP_LoadLichHoc", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Thêm tham số cho stored procedure
                cmd.Parameters.AddWithValue("@StartDate", startOfWeek);
                cmd.Parameters.AddWithValue("@EndDate", startOfWeek.AddDays(7));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LichHoc lichHoc = new LichHoc
                    {
                        MaLichHoc = reader.GetInt32(0),
                        ThoiGianHoc = reader.GetDateTime(1),
                        MaCaHoc = reader.GetInt32(2),
                        PhongHoc = reader.GetString(3),
                        TrangThai = reader.GetString(4),
                        MaLop = reader.GetInt32(5)
                    };
                    lichHocs.Add(lichHoc);
                }
            }
            return lichHocs;
        }
    }
}
