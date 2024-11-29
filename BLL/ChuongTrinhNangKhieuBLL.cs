using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class ChuongTrinhNangKhieuBLL
    {
        // Lấy danh sách tất cả chương trình năng khiếu
        public static List<ChuongTrinhNangKhieu> GetAllChuongTrinhNangKhieu()
        {
            try
            {
                return ChuongTrinhNangKhieuAccess.LoadChuongTrinhNangKhieu();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chương trình năng khiếu: " + ex.Message);
            }
        }

        // Thêm một chương trình năng khiếu
        public static bool AddChuongTrinhNangKhieu(ChuongTrinhNangKhieu ctnk)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ctnk.TenCT))
                {
                    throw new ArgumentException("Tên chương trình không được để trống.");
                }
                return ChuongTrinhNangKhieuAccess.AddChuongTrinhNangKhieu(ctnk);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chương trình năng khiếu: " + ex.Message);
            }
        }

        // Xóa một chương trình năng khiếu
        public static bool DeleteChuongTrinhNangKhieu(int maCTNK)
        {
            try
            {
                if (maCTNK <= 0)
                {
                    throw new ArgumentException("Mã chương trình không hợp lệ.");
                }
                return ChuongTrinhNangKhieuAccess.DeleteChuongTrinhNangKhieu(maCTNK);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chương trình năng khiếu: " + ex.Message);
            }
        }

        // Sửa thông tin chương trình năng khiếu
        public static bool UpdateChuongTrinhNangKhieu(ChuongTrinhNangKhieu ctnk)
        {
            try
            {
                if (ctnk.MaCTNK <= 0)
                {
                    throw new ArgumentException("Mã chương trình không hợp lệ.");
                }
                if (string.IsNullOrWhiteSpace(ctnk.TenCT))
                {
                    throw new ArgumentException("Tên chương trình không được để trống.");
                }
                return ChuongTrinhNangKhieuAccess.UpdateChuongTrinhNangKhieu(ctnk);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật chương trình năng khiếu: " + ex.Message);
            }
        }

        // Tìm chương trình năng khiếu theo mã
        public static ChuongTrinhNangKhieu GetChuongTrinhNangKhieuById(int maCTNK)
        {
            try
            {
                if (maCTNK <= 0)
                {
                    throw new ArgumentException("Mã chương trình không hợp lệ.");
                }
                return ChuongTrinhNangKhieuAccess.GetChuongTrinhNangKhieuById(maCTNK);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm chương trình năng khiếu: " + ex.Message);
            }
        }
    }
}
