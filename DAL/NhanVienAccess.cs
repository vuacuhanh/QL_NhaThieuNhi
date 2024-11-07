using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienAccess
    {
        public static List<Nhanvien> LoadNhanVien()
        {
            List<Nhanvien> danhSachNhanVien = new List<Nhanvien>();
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
                            Nhanvien nv = new Nhanvien
                            {
                                MaNhanVien = reader.GetInt32(0),
                                TenNhanVien = reader.GetString(1),
                                HinhAnh = reader.GetString(2),
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

        public static void AddNhanVien(Nhanvien nv)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_AddNhanVien", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);
                    cmd.Parameters.AddWithValue("@TenNhanVien", nv.TenNhanVien);
                    cmd.Parameters.AddWithValue("@HinhAnh", nv.HinhAnh);
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
        public static void EditNhanVien(Nhanvien nv)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_EditNhanVien", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);
                    cmd.Parameters.AddWithValue("@TenNhanVien", nv.TenNhanVien);
                    cmd.Parameters.AddWithValue("@HinhAnh", nv.HinhAnh);
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
    }
}
