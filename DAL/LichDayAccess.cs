using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class LichDayDAL
    {
        public static List<LichDay> GetLichDayForWeek(DateTime startOfWeek)
        {
            List<LichDay> lichDays = new List<LichDay>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();

                // Sử dụng Stored Procedure SP_LoadLichDay
                SqlCommand cmd = new SqlCommand("SP_LoadLichDay", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Thêm tham số cho stored procedure
                cmd.Parameters.AddWithValue("@StartDate", startOfWeek);
                cmd.Parameters.AddWithValue("@EndDate", startOfWeek.AddDays(7));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LichDay lichDay = new LichDay
                    {
                        MaLichDay = reader.GetInt32(0),   
                        MaNhanVien = reader.GetInt32(1), 
                        MaLop = reader.GetInt32(2),     
                        MaCaHoc = reader.GetInt32(3),    
                        NgayDay = reader.GetDateTime(4), 
                        NgayKetThuc = reader.GetDateTime(5), 
                        PhongHoc = reader.GetString(6), 
                        TrangThai = reader.GetString(7)  
                    };
                    lichDays.Add(lichDay);
                }
            }

            return lichDays;
        }
    }
}
