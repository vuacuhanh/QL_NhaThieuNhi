using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{

    public class CoSoVatChatBLL
    {
        // Lấy danh sách tất cả cơ sở vật chất
        public static List<CoSoVatChat> LayTatCaCoSoVatChat()
        {
            try
            {
                return CoSoVatChatAccess.LoadCoSoVatChat();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lấy danh sách cơ sở vật chất: " + ex.Message);
            }
        }

        // Thêm mới cơ sở vật chất
        public static bool ThemCoSoVatChat(CoSoVatChat csvc)
        {
            // Kiểm tra dữ liệu trước khi thêm
            if (csvc == null)
                throw new ArgumentNullException("Cơ sở vật chất không được để trống");

            if (string.IsNullOrEmpty(csvc.TenCoSo))
                throw new ArgumentException("Tên cơ sở không được để trống");

            if (csvc.SoLuong < 0)
                throw new ArgumentException("Số lượng không hợp lệ");

            try
            {
                return CoSoVatChatAccess.AddCoSoVatChat(csvc);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi thêm cơ sở vật chất: " + ex.Message);
            }
        }

        // Cập nhật thông tin cơ sở vật chất
        public static bool SuaCoSoVatChat(CoSoVatChat csvc)
        {
            // Kiểm tra dữ liệu trước khi cập nhật
            if (csvc == null)
                throw new ArgumentNullException("Cơ sở vật chất không được để trống");

            if (csvc.MaCSVC <= 0)
                throw new ArgumentException("Mã cơ sở vật chất không hợp lệ");

            if (string.IsNullOrEmpty(csvc.TenCoSo))
                throw new ArgumentException("Tên cơ sở không được để trống");

            if (csvc.SoLuong < 0)
                throw new ArgumentException("Số lượng không hợp lệ");

            try
            {
                return CoSoVatChatAccess.UpdateCoSoVatChat(csvc);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi cập nhật cơ sở vật chất: " + ex.Message);
            }
        }

        // Xóa cơ sở vật chất
        public static bool XoaCoSoVatChat(int maCSVC)
        {
            if (maCSVC <= 0)
                throw new ArgumentException("Mã cơ sở vật chất không hợp lệ");

            try
            {
                return CoSoVatChatAccess.DeleteCoSoVatChat(maCSVC);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi xóa cơ sở vật chất: " + ex.Message);
            }
        }

        // Tìm cơ sở vật chất theo mã
        public static CoSoVatChat TimCoSoVatChatTheoMa(int maCSVC)
        {
            if (maCSVC <= 0)
                throw new ArgumentException("Mã cơ sở vật chất không hợp lệ");

            try
            {
                return CoSoVatChatAccess.GetCoSoVatChatById(maCSVC);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tìm cơ sở vật chất theo mã: " + ex.Message);
            }
        }
        // Lọc học viên theo lớp
        // Lọc cơ sở vật chất theo loại

        public static List<CoSoVatChat> LocCoSoVatChatTheoLoai(string loaiCoSo)
        {
            if (string.IsNullOrEmpty(loaiCoSo))
                throw new ArgumentException("Loại cơ sở không được để trống");

            try
            {
                return CoSoVatChatAccess.FilterCoSoVatChatByLoai(loaiCoSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lọc cơ sở vật chất theo loại: " + ex.Message);
            }
        }
    }
}
