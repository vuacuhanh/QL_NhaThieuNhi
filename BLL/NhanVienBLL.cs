using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
namespace BLL
{
    public class NhanVienBLL
    {
        public List<NhanVien> LoadNhanVien()
        {
            return NhanVienAccess.LoadNhanVien();
        }


        public bool AddNhanVien(NhanVien nv)
        {
              NhanVienAccess.AddNhanVien(nv);
              return true;
        }

        public bool DeleteNhanVien(int maNhanVien)
        {
             NhanVienAccess.DeleteNhanVien(maNhanVien);
             return true;
        }

        public bool EditNhanVien(NhanVien nv)
        {
             NhanVienAccess.EditNhanVien(nv);
             return true;
        }
        public static void ImportNhanVienFromExcel(string filePath)
        {
            NhanVienAccess.ImportFromExcel(filePath);
            Console.WriteLine("Dữ liệu nhân viên đã được import thành công.");
        }
        public List<NhanVien> SearchNhanVien(string keyword)
        {
            return LoadNhanVien().Where(nv => nv.TenNhanVien.Contains(keyword) || nv.MaNhanVien.ToString().Contains(keyword)).ToList();
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return NhanVienAccess.GetAllNhanVien(); 
        }
        public int CountNhanVien()
        {
            NhanVienAccess nvAccess = new NhanVienAccess();
            return nvAccess.CountNhanVien();
        }
        public List<NhanVien> FilterNhanVien(string gioiTinh, string chucVu, int? maPhongBan)
        {
            return NhanVienAccess.FilterNhanVien(gioiTinh, chucVu, maPhongBan);
        }
    }

}
