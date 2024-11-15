using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class LopHocBLL
    {

        // Lấy danh sách tất cả các lớp học
        public static List<LopHoc> LayTatCaLopHoc()
        {
            try
            {
                return LopHocAccess.LoadLopHoc();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lấy danh sách lớp học: " + ex.Message);
            }
        }

        // Thêm mới lớp học
        public static bool ThemLopHoc(LopHoc lopHoc)
        {
            // Kiểm tra dữ liệu trước khi thêm
            if (lopHoc == null)
                throw new ArgumentNullException("Lớp học không được để trống");

            if (string.IsNullOrEmpty(lopHoc.TenLop))
                throw new ArgumentException("Tên lớp học không được để trống");

            try
            {
                return LopHocAccess.AddLopHoc(lopHoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi thêm lớp học: " + ex.Message);
            }
        }

        // Cập nhật lớp học
        public static bool SuaLopHoc(LopHoc lopHoc)
        {
            // Kiểm tra dữ liệu trước khi cập nhật
            if (lopHoc == null)
                throw new ArgumentNullException("Lớp học không được để trống");

            if (lopHoc.MaLop <= 0)
                throw new ArgumentException("Mã lớp không hợp lệ");

            if (string.IsNullOrEmpty(lopHoc.TenLop))
                throw new ArgumentException("Tên lớp học không được để trống");

            try
            {
                return LopHocAccess.UpdateLopHoc(lopHoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi cập nhật lớp học: " + ex.Message);
            }
        }

        // Xóa lớp học
        public static bool XoaLopHoc(int maLop)
        {
            if (maLop <= 0)
                throw new ArgumentException("Mã lớp không hợp lệ");

            try
            {
                return LopHocAccess.DeleteLopHoc(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi xóa lớp học: " + ex.Message);
            }
        }

        // Tìm lớp học theo mã
        public static LopHoc TimLopHocTheoMa(int maLop)
        {
            if (maLop <= 0)
                throw new ArgumentException("Mã lớp không hợp lệ");

            try
            {
                return LopHocAccess.GetLopHocById(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tìm lớp học theo mã: " + ex.Message);
            }
        }

        //Lọc lớp học theo chuyên môn
        public static List<LopHoc> LocLopHocTheoChuyenMon(string chuyenMon)
        {
            if (string.IsNullOrEmpty(chuyenMon))
                throw new ArgumentException("Chuyên môn không được để trống");

            try
            {
                return LopHocAccess.FilterLopHocByChuyenMon(chuyenMon);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lọc lớp học theo chuyên môn: " + ex.Message);
            }

        }
    }
}
