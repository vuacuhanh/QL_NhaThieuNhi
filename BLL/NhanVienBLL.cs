using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClosedXML.Excel;
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
        public static void ImportNhanVienFromExcel(string filePath)
        {
            try
            {
                // Gọi phương thức DAL để xử lý việc import dữ liệu từ Excel
                NhanVienAccess.ImportFromExcel(filePath);
                Console.WriteLine("Dữ liệu nhân viên đã được import thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi import dữ liệu: " + ex.Message);
            }
        }

    }
}
