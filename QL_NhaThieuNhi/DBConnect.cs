using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NhaThieuNhi
{
    public class DBConnect
    {
        public static string GetConnectionString()
        {
            // Thay thế dòng sau bằng chuỗi kết nối thực tế của bạn
            string connectionString = "Data Source=DESKTOP-FGIC7BA\\SQLEXPRESSQUAN;Initial Catalog=QL_NhaThieuNhi;Integrated Security=True";
            return connectionString;
        }
    }
}
