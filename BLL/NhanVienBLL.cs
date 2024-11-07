using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        public List<Nhanvien> LoadNhanVien()
        {
            return NhanVienAccess.LoadNhanVien();
        }


        public bool AddNhanVien(Nhanvien nv)
        {
            try
            {
                NhanVienAccess.AddNhanVien(nv);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm nhân viên: " + ex.Message);
                return false;
            }
        }

        public bool DeleteNhanVien(int maNhanVien)
        {
            try
            {
                NhanVienAccess.DeleteNhanVien(maNhanVien);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa nhân viên: " + ex.Message);
                return false;
            }
        }

        public bool EditNhanVien(Nhanvien nv)
        {
            try
            {
                NhanVienAccess.EditNhanVien(nv);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chỉnh sửa nhân viên: " + ex.Message);
                return false;
            }
        }
    }
}
