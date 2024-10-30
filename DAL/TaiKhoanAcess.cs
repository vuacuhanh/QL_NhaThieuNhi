using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public class TaiKhoanAccess
    {
        public string CheckLogin(TaiKhoan taikhoan)
        {
            // Gọi đến phương thức CheckLogin trong lớp DataBaseAccess
            return DataBaseAccess.CheckLogin(taikhoan);
        }

        public List<TaiKhoan> LoadTaiKhoan()
        {
            return DataBaseAccess.LoadTaiKhoan();
        }
    }
}
