﻿using System;
using System.Data.SqlClient;
using DTO;
using System.Data;
using System.Collections.Generic;

namespace DAL
{

    public class ConnectionData
    {
        private static readonly string connectionString = @"Data Source=LAPTOP-0GJ5N2UI\SQLEXPRESS;Initial Catalog=QL_NhaThieuNhi;Integrated Security=True";

        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }


    }

    public class DataBaseAccess
    {
        public static string CheckLogin(TaiKhoan taikhoan)
        {
            string tenQuyen = null;

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SP_CheckDangNhap", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TenDangNhap", taikhoan.TenDangNhap);
                        command.Parameters.AddWithValue("@MatKhau", taikhoan.MatKhau);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    tenQuyen = reader.GetString(reader.GetOrdinal("Quyen")); 
                                }
                            }
                            else
                            {
                                return "Tài khoản hoặc mật khẩu không chính xác";
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    return "Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            return tenQuyen; // Trả về tên quyền
        }

        public static List<TaiKhoan> LoadTaiKhoan()
        {
            List<TaiKhoan> danhSachTaiKhoan = new List<TaiKhoan>();

            using (SqlConnection conn = ConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SP_LoadTaiKhoan", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaiKhoan tk = new TaiKhoan
                            {
                                MaTaiKhoan = reader.GetInt32(0),
                                TenDangNhap = reader.GetString(1),
                                MatKhau = reader.GetString(2),
                                MaQuyen = reader.GetInt32(3)
                            };
                            danhSachTaiKhoan.Add(tk);
                        }
                    }
                }
            }

            return danhSachTaiKhoan;
        }
    }
}
