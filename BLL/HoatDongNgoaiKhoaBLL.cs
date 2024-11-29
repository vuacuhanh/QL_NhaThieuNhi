using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class HoatDongNgoaiKhoaBLL
    {
        // Lấy danh sách hoạt động ngoại khóa
        public static List<HoatDongNgoaiKhoa> GetAllHoatDongNgoaiKhoa()
        {
            try
            {
                return HoatDongNgoaiKhoaAccess.LoadHoatDongNgoaiKhoa();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hoạt động ngoại khóa: " + ex.Message);
            }
        }

        // Thêm mới hoạt động ngoại khóa
        public static bool AddHoatDongNgoaiKhoa(HoatDongNgoaiKhoa hdnk)
        {
            try
            {
                if (hdnk == null)
                {
                    throw new ArgumentNullException("Hoạt động ngoại khóa không được null");
                }

                // Kiểm tra logic dữ liệu trước khi thêm
                if (string.IsNullOrEmpty(hdnk.TenHoatDong))
                {
                    throw new ArgumentException("Tên hoạt động không được để trống");
                }

                return HoatDongNgoaiKhoaAccess.AddHoatDongNgoaiKhoa(hdnk);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm hoạt động ngoại khóa: " + ex.Message);
            }
        }

        // Cập nhật hoạt động ngoại khóa
        public static bool UpdateHoatDongNgoaiKhoa(HoatDongNgoaiKhoa hdnk)
        {
            try
            {
                if (hdnk == null || hdnk.MaHDNK <= 0)
                {
                    throw new ArgumentException("Dữ liệu hoạt động ngoại khóa không hợp lệ");
                }

                return HoatDongNgoaiKhoaAccess.UpdateHoatDongNgoaiKhoa(hdnk);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật hoạt động ngoại khóa: " + ex.Message);
            }
        }

        // Xóa hoạt động ngoại khóa
        public static bool DeleteHoatDongNgoaiKhoa(int maHDNK)
        {
            try
            {
                if (maHDNK <= 0)
                {
                    throw new ArgumentException("Mã hoạt động ngoại khóa không hợp lệ");
                }

                return HoatDongNgoaiKhoaAccess.DeleteHoatDongNgoaiKhoa(maHDNK);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa hoạt động ngoại khóa: " + ex.Message);
            }
        }

        // Lấy hoạt động ngoại khóa theo mã
        public static HoatDongNgoaiKhoa GetHoatDongNgoaiKhoaById(int maHDNK)
        {
            try
            {
                if (maHDNK <= 0)
                {
                    throw new ArgumentException("Mã hoạt động ngoại khóa không hợp lệ");
                }

                return HoatDongNgoaiKhoaAccess.GetHoatDongNgoaiKhoaById(maHDNK);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin hoạt động ngoại khóa: " + ex.Message);
            }
        }
    }
}
