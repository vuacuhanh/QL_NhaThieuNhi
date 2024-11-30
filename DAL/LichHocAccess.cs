using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class LichHocDAL
    {
        public static List<LichHoc> GetLichHocDataForWeek()
        {
            List<LichHoc> lichHocs = new List<LichHoc>();
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                // Lọc dữ liệu từ thứ 2 đến chủ nhật của tuần hiện tại
                string query = @"
                    SELECT * 
                    FROM LichHoc 
                    WHERE ThoiGianHoc >= DATEADD(DAY, -(DATEPART(WEEKDAY, GETDATE())-2), CAST(GETDATE() AS DATE))
                    AND ThoiGianHoc < DATEADD(DAY, 7-(DATEPART(WEEKDAY, GETDATE())-2), CAST(GETDATE() AS DATE))";
                SqlCommand cmd = new SqlCommand(query, conn);
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
