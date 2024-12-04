using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LichBaoTriBLL
    {
        // Lấy danh sách tất cả lịch bảo trì
        public static List<LichBaoTri> LayTatCaLichBaoTri()
        {
            try
            {
                return LichBaoTriAccess.LoadLichBaoTri();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lấy danh sách lịch bảo trì: " + ex.Message);
            }
        }

        // Thêm mới lịch bảo trì
        public static bool ThemLichBaoTri(LichBaoTri lichBaoTri)
        {
            // Kiểm tra dữ liệu trước khi thêm
            if (lichBaoTri == null)
                throw new ArgumentNullException("Lịch bảo trì không được để trống");

            if (lichBaoTri.MaNhanVienLapLich == null || lichBaoTri.MaNhanVienLapLich <= 0)
                throw new ArgumentException("Mã nhân viên lập lịch không hợp lệ");

            if (lichBaoTri.ThoiGianBD == default || lichBaoTri.ThoiGianKT == default)
                throw new ArgumentException("Thời gian bắt đầu và kết thúc không được để trống");

            if (lichBaoTri.ThoiGianKT <= lichBaoTri.ThoiGianBD)
                throw new ArgumentException("Thời gian kết thúc phải lớn hơn thời gian bắt đầu");

            if (lichBaoTri.MaCSVC == null || lichBaoTri.MaCSVC <= 0)
                throw new ArgumentException("Mã cơ sở vật chất không hợp lệ");

            try
            {
                // Gọi lớp truy cập dữ liệu để thêm lịch bảo trì
                return LichBaoTriAccess.AddLichBaoTri(lichBaoTri);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi thêm lịch bảo trì: " + ex.Message);
            }
        }


        // Cập nhật thông tin lịch bảo trì
        public static bool SuaLichBaoTri(LichBaoTri lichBaoTri)
        {
            // Kiểm tra dữ liệu trước khi cập nhật
            if (lichBaoTri == null)
                throw new ArgumentNullException("Lịch bảo trì không được để trống");

            if (lichBaoTri.MaLichBaoTri <= 0)
                throw new ArgumentException("Mã lịch bảo trì không hợp lệ");

            if (lichBaoTri.ThoiGianBD >= lichBaoTri.ThoiGianKT)
                throw new ArgumentException("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc");

            try
            {
                return LichBaoTriAccess.UpdateLichBaoTri(lichBaoTri);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi cập nhật lịch bảo trì: " + ex.Message);
            }
        }

        // Xóa lịch bảo trì
        public static bool XoaLichBaoTri(int maLichBaoTri)
        {
            if (maLichBaoTri <= 0)
                throw new ArgumentException("Mã lịch bảo trì không hợp lệ");

            try
            {
                return LichBaoTriAccess.DeleteLichBaoTri(maLichBaoTri);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi xóa lịch bảo trì: " + ex.Message);
            }
        }

        // Tìm lịch bảo trì theo mã
        public static LichBaoTri TimLichBaoTriTheoMa(int maLichBaoTri)
        {
            if (maLichBaoTri <= 0)
                throw new ArgumentException("Mã lịch bảo trì không hợp lệ");

            try
            {
                return LichBaoTriAccess.GetLichBaoTriById(maLichBaoTri);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tìm lịch bảo trì theo mã: " + ex.Message);
            }
        }

        // Lọc lịch bảo trì theo trạng thái
        public static List<LichBaoTri> LocLichBaoTriTheoTrangThai(string trangThai)
        {
            if (string.IsNullOrEmpty(trangThai))
                throw new ArgumentException("Trạng thái không được để trống");

            try
            {
                return LichBaoTriAccess.FilterLichBaoTriByTrangThai(trangThai);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lọc lịch bảo trì theo trạng thái: " + ex.Message);
            }
        }
    }

}
