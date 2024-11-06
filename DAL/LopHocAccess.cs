using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LopHocAccess
    {
        public List<LopHoc> LoadLopHoc()
        {
            // Gọi đến phương thức LoadLopHoc trong lớp DataBaseAccess
            return DataBaseAccess.LoadLopHoc();
        }

        public string AddLopHoc(LopHoc lopHoc)

        {
            // Gọi đến phương thức AddLopHoc trong lớp DataBaseAccess
            return DataBaseAccess.AddLopHoc(lopHoc);
        }

        public string UpdateLopHoc(LopHoc lopHoc)
        {
            // Gọi đến phương thức UpdateLopHoc trong lớp DataBaseAccess
            return DataBaseAccess.UpdateLopHoc(lopHoc);
        }

        public string DeleteLopHoc(int maLop)
        {
            // Gọi đến phương thức DeleteLopHoc trong lớp DataBaseAccess
            return DataBaseAccess.DeleteLopHoc(maLop);
        }

        
    }
}
