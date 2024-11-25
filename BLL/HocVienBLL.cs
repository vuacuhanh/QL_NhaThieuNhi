using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class HocVienBLL
    {
        // Lấy danh sách tất cả học viên
        public static List<HocVien> LayTatCaHocVien()
        {
            try
            {
                return HocVienAccess.LoadHocVien();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lấy danh sách học viên: " + ex.Message);
            }
        }

        // Thêm mới học viên
        public static bool ThemHocVien(HocVien hocVien)
        {
            // Kiểm tra dữ liệu trước khi thêm
            if (hocVien == null)
                throw new ArgumentNullException("Học viên không được để trống");

            if (string.IsNullOrEmpty(hocVien.TenHocVien))
                throw new ArgumentException("Tên học viên không được để trống");

            try
            {
                return HocVienAccess.AddHocVien(hocVien);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi thêm học viên: " + ex.Message);
            }
        }

        // Cập nhật thông tin học viên
        public static bool SuaHocVien(HocVien hocVien)
        {
            // Kiểm tra dữ liệu trước khi cập nhật
            if (hocVien == null)
                throw new ArgumentNullException("Học viên không được để trống");

            if (hocVien.MaHocVien <= 0)
                throw new ArgumentException("Mã học viên không hợp lệ");

            if (string.IsNullOrEmpty(hocVien.TenHocVien))
                throw new ArgumentException("Tên học viên không được để trống");

            try
            {
                return HocVienAccess.UpdateHocVien(hocVien);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi cập nhật học viên: " + ex.Message);
            }
        }

        // Xóa học viên
        public static bool XoaHocVien(int maHocVien)
        {
            if (maHocVien <= 0)
                throw new ArgumentException("Mã học viên không hợp lệ");

            try
            {
                return HocVienAccess.DeleteHocVien(maHocVien);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi xóa học viên: " + ex.Message);
            }
        }

        // Tìm học viên theo mã
        public static HocVien TimHocVienTheoMa(int maHocVien)
        {
            if (maHocVien <= 0)
                throw new ArgumentException("Mã học viên không hợp lệ");

            try
            {
                return HocVienAccess.GetHocVienById(maHocVien);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tìm học viên theo mã: " + ex.Message);
            }
        }

        // Lọc học viên theo lớp
        public static List<HocVien> LocHocVienTheoLop(string maLop)
        {
            if (string.IsNullOrEmpty(maLop))
                throw new ArgumentException("Mã lớp không được để trống");

            try
            {
                return HocVienAccess.FilterHocVienByMaLop(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lọc học viên theo lớp: " + ex.Message);
            }
        }
    }
}
