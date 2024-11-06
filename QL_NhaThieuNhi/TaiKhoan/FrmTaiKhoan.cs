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
using DTO;
using BLL;

namespace QL_NhaThieuNhi
{
    public partial class FrmTaiKhoan : Form
    {
<<<<<<< HEAD:QL_NhaThieuNhi/TaiKhoan/FrmTaiKhoan.cs
        string connectionString = ConnectionData.GetConnectionString();
        DataSet ds_HT = new DataSet();
        SqlDataAdapter da_HT;
=======
        TaiKhoanBLL tkBLL = new TaiKhoanBLL(); // Khởi tạo đối tượng BLL

>>>>>>> 7ca0bcebd288371c20329ac3812f1025c6559255:QL_NhaThieuNhi/FrmTaiKhoan.cs
        public FrmTaiKhoan()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
            // Bạn có thể thêm mã vẽ ở đây nếu cần
        }

        void Load_DuLieu_TK()
        {
            try
            {
                // Gọi phương thức từ BLL để lấy danh sách tài khoản
                List<TaiKhoan> danhSachTaiKhoan = tkBLL.LoadTaiKhoan();

                // Gán dữ liệu vào DataGridView
                guna2DataGridView1.DataSource = danhSachTaiKhoan.Select(tk => new {
                    tk.MaTaiKhoan,
                    tk.TenDangNhap,
                    tk.MatKhau,
                    tk.MaQuyen
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD:QL_NhaThieuNhi/TaiKhoan/FrmTaiKhoan.cs
            Load_DuLieu_TK();
            sort_By();
        }
        public void sort_By()
        {
            cb_SortBy.Items.Add("Xếp theo tên quyền");
            cb_SortBy.Items.Add("Mới nhất");
            cb_SortBy.Items.Add("Cũ nhất");
        }

        private void cb_SortBy_SelectedIndexChanged(object sender, EventArgs e)
        {

=======
            Load_DuLieu_TK(); // Gọi phương thức để tải dữ liệu khi form được tải
>>>>>>> 7ca0bcebd288371c20329ac3812f1025c6559255:QL_NhaThieuNhi/FrmTaiKhoan.cs
        }
    }
}
