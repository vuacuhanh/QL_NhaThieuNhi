using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Drawing;
using System.Web.UI.WebControls;
using System.IO;

namespace DAL
{
    public class NhanVienAccess
    {
        public static List<NhanVien> LoadNhanVien()
        {
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_LoadNhanVien", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] hinhAnhBytes = !reader.IsDBNull(2) ? (byte[])reader["HinhAnh"] : null;

                            NhanVien nv = new NhanVien
                            {
                                MaNhanVien = reader.GetInt32(0),
                                TenNhanVien = reader.GetString(1),
                                HinhAnh = hinhAnhBytes,
                                NgaySinh = reader.GetDateTime(3),
                                GioiTinh = reader.GetString(4),
                                SoDienThoai = reader.GetString(5),
                                ChucVu = reader.GetString(6),
                                ChuyenMon = reader.GetString(7),
                                TrangThai = reader.GetString(8),
                                Email = reader.GetString(9),
                                Luong = reader.GetDecimal(10),
                                MaTaiKhoan = reader.GetInt32(11),
                                MaPhongBan = reader.GetInt32(12)
                            };

                            danhSachNhanVien.Add(nv);
                        }
                    }
                }
            }
            return danhSachNhanVien;
        }


        public static void AddNhanVien(NhanVien nv)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_ThemNhanVien", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);
                        cmd.Parameters.AddWithValue("@TenNhanVien", nv.TenNhanVien);
                        cmd.Parameters.AddWithValue("@HinhAnh", nv.HinhAnh ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                        cmd.Parameters.AddWithValue("@SoDienThoai", nv.SoDienThoai);
                        cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
                        cmd.Parameters.AddWithValue("@ChuyenMon", nv.ChuyenMon);
                        cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai);
                        cmd.Parameters.AddWithValue("@Email", nv.Email);
                        cmd.Parameters.AddWithValue("@Luong", nv.Luong);
                        cmd.Parameters.AddWithValue("@MaTaiKhoan", nv.MaTaiKhoan);
                        cmd.Parameters.AddWithValue("@MaPhongBan", nv.MaPhongBan);

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
                    }
                }
            }
        }


        public static void DeleteNhanVien(int maNhanVien)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_DeleteNhanVien", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EditNhanVien(NhanVien nv)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_EditNhanVien", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);
                    cmd.Parameters.AddWithValue("@TenNhanVien", nv.TenNhanVien);
                    cmd.Parameters.AddWithValue("@HinhAnh", nv.HinhAnh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                    cmd.Parameters.AddWithValue("@SoDienThoai", nv.SoDienThoai);
                    cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
                    cmd.Parameters.AddWithValue("@ChuyenMon", nv.ChuyenMon);
                    cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai);
                    cmd.Parameters.AddWithValue("@Email", nv.Email);
                    cmd.Parameters.AddWithValue("@Luong", nv.Luong);
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", nv.MaTaiKhoan);
                    cmd.Parameters.AddWithValue("@MaPhongBan", nv.MaPhongBan);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void ImportFromExcel(string filePath)
        {
            try
            {
                // Mở file Excel
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1); // Lấy sheet đầu tiên
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Bỏ qua dòng tiêu đề

                    foreach (var row in rows)
                    {
                        NhanVien nv = new NhanVien
                        {
                            MaNhanVien = int.Parse(row.Cell(1).GetValue<string>()),
                            TenNhanVien = row.Cell(2).GetValue<string>(),
                            HinhAnh = File.Exists(row.Cell(3).GetValue<string>()) ? File.ReadAllBytes(row.Cell(3).GetValue<string>()) : null,
                            NgaySinh = row.Cell(4).GetValue<DateTime>(),
                            GioiTinh = row.Cell(5).GetValue<string>(),
                            SoDienThoai = row.Cell(6).GetValue<string>(),
                            ChucVu = row.Cell(7).GetValue<string>(),
                            ChuyenMon = row.Cell(8).GetValue<string>(),
                            TrangThai = row.Cell(9).GetValue<string>(),
                            Email = row.Cell(10).GetValue<string>(),
                            Luong = row.Cell(11).GetValue<decimal>(),
                            MaTaiKhoan = int.Parse(row.Cell(12).GetValue<string>()), 
                            MaPhongBan = int.Parse(row.Cell(13).GetValue<string>())  // Giả sử MaPhongBan nằm ở cột 13
                        };
                        AddNhanVien(nv);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi import dữ liệu từ Excel: " + ex.Message);
            }
        }


        public static List<NhanVien> GetAllNhanVien()
        {
            using (var context = new NTNContext())
            {
                return context.NhanViens.ToList();
            }
        }

        public int CountNhanVien()
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM NhanVien", conn))
                    {
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi đếm nhân viên: " + ex.Message);
                    return 0;
                }
            }
        }

        public static List<NhanVien> FilterNhanVien(string gioiTinh, string chucVu, int? maPhongBan)
        {
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_FilterNhanVien", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ChucVu", chucVu ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaPhongBan", maPhongBan ?? (object)DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NhanVien nv = new NhanVien
                            {
                                MaNhanVien = reader.GetInt32(0),
                                TenNhanVien = reader.GetString(1),
                                HinhAnh = reader.IsDBNull(2) ? null : (byte[])reader["HinhAnh"],
                                NgaySinh = reader.GetDateTime(3),
                                GioiTinh = reader.GetString(4),
                                SoDienThoai = reader.GetString(5),
                                ChucVu = reader.GetString(6),
                                ChuyenMon = reader.GetString(7),
                                TrangThai = reader.GetString(8),
                                Email = reader.GetString(9),
                                Luong = reader.GetDecimal(10)
                            };
                            danhSachNhanVien.Add(nv);
                        }
                    }
                }
            }
            return danhSachNhanVien;
        }
    }
}
