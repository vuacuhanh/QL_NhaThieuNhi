using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVienAccess
    {
        public NhanVien GetNhanVienById(int maNhanVien)
        {
            // Gọi đến phương thức GetNhanVienById trong lớp DataBaseAccess
            return DataBaseAccess.GetNhanVienById(maNhanVien);
        }
        // Phương thức để tải danh sách nhân viên
        public List<NhanVien> LoadNhanVien()
        {
            // Gọi đến phương thức LoadNhanVien trong lớp DataBaseAccess
            return DataBaseAccess.LoadNhanVien();
        }

        // Phương thức để thêm nhân viên mới
        public string AddNhanVien(NhanVien nhanVien)
        {
            // Gọi đến phương thức AddNhanVien trong lớp DataBaseAccess
            return DataBaseAccess.AddNhanVien(nhanVien);
        }

        // Phương thức để cập nhật thông tin nhân viên
        public string UpdateNhanVien(NhanVien nhanVien)
        {
            // Gọi đến phương thức UpdateNhanVien trong lớp DataBaseAccess
            return DataBaseAccess.UpdateNhanVien(nhanVien);
        }

        // Phương thức để xóa nhân viên
        public string DeleteNhanVien(int maNhanVien)
        {
            // Gọi đến phương thức DeleteNhanVien trong lớp DataBaseAccess
            return DataBaseAccess.DeleteNhanVien(maNhanVien);
        }
    }
}
