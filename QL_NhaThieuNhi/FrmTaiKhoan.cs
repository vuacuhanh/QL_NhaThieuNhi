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
        TaiKhoanBLL tkBLL = new TaiKhoanBLL(); // Khởi tạo đối tượng BLL

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
            Load_DuLieu_TK(); // Gọi phương thức để tải dữ liệu khi form được tải
        }
    }
}
