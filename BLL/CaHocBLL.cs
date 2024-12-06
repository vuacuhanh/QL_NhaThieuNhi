using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class CaHocBLL
    {
        private CaHocAccess caHocAccess;

        public CaHocBLL()
        {
            caHocAccess = new CaHocAccess();
        }

        // Lấy danh sách tất cả các ca học
        public List<CaHoc> GetAllCaHoc()
        {
            try
            {
                return caHocAccess.LoadAllCaHoc();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách ca học: " + ex.Message);
            }
        }

        // Thêm ca học mới
        public bool AddCaHoc(CaHoc caHoc)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (caHoc == null)
                    throw new ArgumentNullException("Ca học không được null.");
                if (string.IsNullOrWhiteSpace(caHoc.TietHoc))
                    throw new ArgumentException("Tiết học không được để trống.");

                return caHocAccess.AddCaHoc(caHoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm ca học: " + ex.Message);
            }
        }

        // Cập nhật ca học
        public bool UpdateCaHoc(CaHoc caHoc)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (caHoc == null)
                    throw new ArgumentNullException("Ca học không được null.");
                if (string.IsNullOrWhiteSpace(caHoc.TietHoc))
                    throw new ArgumentException("Tiết học không được để trống.");

                return caHocAccess.UpdateCaHoc(caHoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật ca học: " + ex.Message);
            }
        }

        // Xóa ca học
        public bool DeleteCaHoc(int maCaHoc)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (maCaHoc <= 0)
                    throw new ArgumentException("Mã ca học không hợp lệ.");

                return caHocAccess.DeleteCaHoc(maCaHoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa ca học: " + ex.Message);
            }
        }
    }
}
