using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class LopHocBLL
    {
        LopHocAccess lhAccess = new LopHocAccess();

        public List<LopHoc> LoadLopHoc()
        {
            // Gọi phương thức LoadLopHoc từ lớp truy cập dữ liệu
            return lhAccess.LoadLopHoc();
        }

        public string AddLopHoc(LopHoc lopHoc)
        {
            // Kiểm tra nghiệp vụ
            if (string.IsNullOrEmpty(lopHoc.TenLop))
            {
                return "Tên lớp không được để trống";
            }

            if (lopHoc.SiSo <= 0)
            {
                return "Sĩ số phải lớn hơn 0";
            }

            // Gọi tầng DAL để thêm lớp học
            return lhAccess.AddLopHoc(lopHoc);
        }

        public string UpdateLopHoc(LopHoc lopHoc)
        {
            // Kiểm tra nghiệp vụ
            if (lopHoc.MaLop <= 0)
            {
                return "Mã lớp không hợp lệ";
            }

            if (string.IsNullOrEmpty(lopHoc.TenLop))
            {
                return "Tên lớp không được để trống";
            }

            // Gọi tầng DAL để cập nhật lớp học
            return lhAccess.UpdateLopHoc(lopHoc);
        }

        public string DeleteLopHoc(int maLop)
        {
            // Kiểm tra nghiệp vụ
            if (maLop <= 0)
            {
                return "Mã lớp không hợp lệ";
            }

            // Gọi tầng DAL để xóa lớp học
            return lhAccess.DeleteLopHoc(maLop);
        }
    }
}
