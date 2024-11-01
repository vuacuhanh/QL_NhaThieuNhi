using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NhaThieuNhi
{
    public partial class FrmTaiKhoan : Form
    {
        string connectionString = ConnectionData.GetConnectionString();
        DataSet ds_HT = new DataSet();
        SqlDataAdapter da_HT;
        public FrmTaiKhoan()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        void Load_DuLieu_TK()
        {
            string strselect = "select * from TaiKhoan";
            da_HT = new SqlDataAdapter(strselect, connectionString);
            da_HT.Fill(ds_HT, "TaiKhoan");
            guna2DataGridView1.DataSource = ds_HT.Tables["TaiKhoan"];
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_HT.Tables["TaiKhoan"].Columns[0];
            ds_HT.Tables["TaiKhoan"].PrimaryKey = key;
        }

        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            Load_DuLieu_TK();



        }
    }
}
