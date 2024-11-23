using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PhuHuynhAccess
    {
        public static List<PhuHuynh> GetPhuHuynhList()
        {
            List<PhuHuynh> danhSachPhuHuynh = new List<PhuHuynh>();

            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PhuHuynh", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PhuHuynh ph = new PhuHuynh
                            {
                                MaPhuHuynh = reader.GetInt32(0),
                                TenPhuHuynh = reader.GetString(1),
                                NgaySinh = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                                GioiTinh = reader.GetString(3),
                                NgheNghiep = reader.GetString(4),
                                DiaChi = reader.GetString(5),
                                Email = reader.GetString(6),
                                SoDienThoai = reader.GetString(7)
                            };
                            danhSachPhuHuynh.Add(ph);
                        }
                    }
                }
            }

            return danhSachPhuHuynh;
        }

    }
}
