using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class HoaDonBLL
    {
        // Lấy danh sách hóa đơn
        public static List<HoaDon> GetHoaDons()
        {
            try
            {
                return HoaDonAccess.LoadHoaDon();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
            }
        }

        // Thêm hóa đơn
        public static bool AddHoaDon(HoaDon hoaDon)
        {
            try
            {
                if (hoaDon == null)
                    throw new ArgumentNullException(nameof(hoaDon), "Hóa đơn không thể null.");

                // Validation logic (optional)
                if (hoaDon.SoTien <= 0)
                    throw new ArgumentException("Số tiền phải lớn hơn 0.");

                return HoaDonAccess.AddHoaDon(hoaDon);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
        }

        // Xóa hóa đơn
        public static bool DeleteHoaDon(int maHoaDon)
        {
            try
            {
                if (maHoaDon <= 0)
                    throw new ArgumentException("Mã hóa đơn không hợp lệ.");

                return HoaDonAccess.DeleteHoaDon(maHoaDon);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa hóa đơn: " + ex.Message);
            }
        }

        // Cập nhật hóa đơn
        public static bool UpdateHoaDon(HoaDon hoaDon)
        {
            try
            {
                if (hoaDon == null)
                    throw new ArgumentNullException(nameof(hoaDon), "Hóa đơn không thể null.");

                // Validation logic (optional)
                if (hoaDon.MaHoaDon <= 0)
                    throw new ArgumentException("Mã hóa đơn không hợp lệ.");

                return HoaDonAccess.UpdateHoaDon(hoaDon);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật hóa đơn: " + ex.Message);
            }
        }

        // Tìm hóa đơn theo mã
        public static HoaDon GetHoaDonById(int maHoaDon)
        {
            try
            {
                if (maHoaDon <= 0)
                    throw new ArgumentException("Mã hóa đơn không hợp lệ.");

                return HoaDonAccess.GetHoaDonById(maHoaDon);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm hóa đơn: " + ex.Message);
            }
        }

        // Lọc hóa đơn theo trạng thái thanh toán
        public static List<HoaDon> FilterHoaDonsByPaymentStatus(string trangThaiThanhToan)
        {
            try
            {
                if (string.IsNullOrEmpty(trangThaiThanhToan))
                    throw new ArgumentException("Trạng thái thanh toán không thể trống.");

                return HoaDonAccess.FilterHoaDonByTrangThaiThanhToan(trangThaiThanhToan);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lọc hóa đơn theo trạng thái thanh toán: " + ex.Message);
            }
        }

        public static bool CapNhatTrangThaiThanhToan(int maHoaDon, string trangThaiThanhToan)
        {
            // Gọi phương thức trong DAL để cập nhật trạng thái thanh toán
            return HoaDonAccess.UpdateTrangThaiThanhToan(maHoaDon, trangThaiThanhToan);
        }

    }
}
