using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data.SqlClient;
namespace BLL
{
    public class LichDayBLL
    {
        // Lấy danh sách tất cả lịch dạy
        public static List<LichDay> LayTatCaLichDay()
        {
            try
            {
                return LichDayAccess.LoadLichDay();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lấy danh sách lịch dạy: " + ex.Message);
            }
        }

        // Thêm mới lịch dạy
        public static bool ThemLichDay(LichDay lichDay)
        {
            // Kiểm tra dữ liệu trước khi thêm
            if (lichDay == null)
                throw new ArgumentNullException("Lịch dạy không được để trống");

            if (lichDay.MaLichDay <= 0)
                throw new ArgumentException("Mã lịch dạy không hợp lệ");

            if (lichDay.NgayDay >= lichDay.NgayKetThuc)
                throw new ArgumentException("Thời gian bắt đầu phải trước thời gian kết thúc");

            try
            {
                // Kiểm tra mã lịch dạy trùng lặp
                if (LichDayAccess.CheckMaLichDayExists(lichDay.MaLichDay))
                {
                    throw new Exception("Mã lịch dạy đã tồn tại");
                }

                return LichDayAccess.AddLichDay(lichDay);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi thêm lịch dạy: " + ex.Message);
            }
        }

        // Cập nhật thông tin lịch dạy
        public static bool SuaLichDay(LichDay lichDay)
        {
            // Kiểm tra dữ liệu trước khi cập nhật
            if (lichDay == null)
                throw new ArgumentNullException("Lịch dạy không được để trống");

            if (lichDay.MaLichDay <= 0)
                throw new ArgumentException("Mã lịch dạy không hợp lệ");

            if (lichDay.NgayDay >= lichDay.NgayKetThuc)
                throw new ArgumentException("Thời gian bắt đầu phải trước thời gian kết thúc");

            try
            {
                return LichDayAccess.UpdateLichDay(lichDay);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi cập nhật lịch dạy: " + ex.Message);
            }
        }

        // Xóa lịch dạy
        public static bool XoaLichDay(int maLichDay)
        {
            if (maLichDay <= 0)
                throw new ArgumentException("Mã lịch dạy không hợp lệ");

            try
            {
                return LichDayAccess.DeleteLichDay(maLichDay);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi xóa lịch dạy: " + ex.Message);
            }
        }

        // Tìm lịch dạy theo mã
        public static LichDay TimLichDayTheoMa(int maLichDay)
        {
            if (maLichDay <= 0)
                throw new ArgumentException("Mã lịch dạy không hợp lệ");

            try
            {
                return LichDayAccess.GetLichDayById(maLichDay);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tìm lịch dạy theo mã: " + ex.Message);
            }
        }

        // Lọc lịch dạy theo lớp
        public static List<LichDay> LocLichDayTheoLop(string maLop)
        {
            if (string.IsNullOrEmpty(maLop))
                throw new ArgumentException("Mã lớp không được để trống");

            try
            {
                return LichDayAccess.FilterLichDayByMaLop(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lọc lịch dạy theo lớp: " + ex.Message);
            }
        }

        // Lọc lịch dạy theo giáo viên
        public static List<LichDay> LocLichDayTheoNhanVien(int TenNhanVien)
        {
            if (TenNhanVien <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ");

            try
            {
                return LichDayAccess.FilterLichDayByMaNhanVien(TenNhanVien);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lọc lịch dạy theo nhân viên: " + ex.Message);
            }
        }
       
    }
}
