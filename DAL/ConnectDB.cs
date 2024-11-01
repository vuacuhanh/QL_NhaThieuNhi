using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class ConnectDB
    {
        public static SqlConnection Connect()
        {
            string Strcon = @"Data Source=LAPTOP-0GJ5N2UI\SQLEXPRESS;Initial Catalog=QL_NhaThieuNhi;Integrated Security=True";
            SqlConnection conn = new SqlConnection(Strcon); // khỏie tạo connect
            return conn;
        }
    }
}
