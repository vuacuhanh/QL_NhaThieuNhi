using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PhuHuynhBLL
    {
        // Lấy danh sách tất cả phụ huynh

        public static List<PhuHuynh> LayTatCaPhuHuynh()
        {

            try
            {
                return PhuHuynhAccess.LoadPhuHuynh();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lấy danh sách phụ huynh: " + ex.Message);
            }
        }
        // Thêm mới phụ huynh
        public static bool ThemPhuHuynh(PhuHuynh PhuHuynh)
        {
            // Kiểm tra dữ liệu trước khi thêm
            if (PhuHuynh == null)
                throw new ArgumentNullException("Phụ huynh không được để trống");

            if (string.IsNullOrEmpty(PhuHuynh.TenPhuHuynh))
                throw new ArgumentException("Tên phụ huynh không được để trống");

            try
            {
                return PhuHuynhAccess.AddPhuHuynh(PhuHuynh);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi thêm phụ huynh: " + ex.Message);
            }
        }

        // Cập nhật thông tin phụ huynh
        public static bool SuaPhuHuynh(PhuHuynh phuHuynh)
        {
            // Kiểm tra dữ liệu trước khi cập nhật
            if (phuHuynh == null)
                throw new ArgumentNullException("Phụ huynh không được để trống");

            if (phuHuynh.MaPhuHuynh <= 0)
                throw new ArgumentException("Mã phụ huynh không hợp lệ");

            if (string.IsNullOrEmpty(phuHuynh.TenPhuHuynh))
                throw new ArgumentException("Tên phụ huynh không được để trống");

            try
            {
                return PhuHuynhAccess.UpdatePhuHuynh(phuHuynh);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi cập nhật phụ huynh: " + ex.Message);
            }
        }

        // Xóa phụ huynh
        public static bool XoaPhuHuynh(int MaPhuHuynh)
        {
            if (MaPhuHuynh <= 0)
                throw new ArgumentException("Mã phụ huynh không hợp lệ");

            try
            {
                return PhuHuynhAccess.DeletePhuHuynh(MaPhuHuynh);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi xóa phụ huynh: " + ex.Message);
            }
        }

        // Tìm phụ huynh theo mã
        public static PhuHuynh TimPhuHuynhTheoMa(int maPhuHuynh)
        {
            if (maPhuHuynh <= 0)
                throw new ArgumentException("Mã phụ huynh không hợp lệ");

            try
            {
                return PhuHuynhAccess.GetPhuHuynhById(maPhuHuynh);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tìm phụ huynh theo mã: " + ex.Message);
            }
        }

        // Lọc phụ huynh theo nghề nghiệp
        public static List<PhuHuynh> LocPhuHuynhTheoNgheNghiep(string ngheNghiep)
        {
            if (string.IsNullOrEmpty(ngheNghiep))
                throw new ArgumentException("Nghề nghiệp không được để trống");

            try
            {
                return PhuHuynhAccess.FilterPhuHuynhByNgheNghiep(ngheNghiep);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lọc phụ huynh theo nghề nghiệp: " + ex.Message);
            }
        }
    }
}
