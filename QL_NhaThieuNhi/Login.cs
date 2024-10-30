using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace QL_NhaThieuNhi
{    public partial class Login : Form
    {
        TaiKhoan taikhoan = new TaiKhoan();
        TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        public Login()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các ô nhập liệu
            taikhoan.TenDangNhap = txtUserName.Text; // Giả sử guna2TextBox1 là ô nhập tên đăng nhập
            taikhoan.MatKhau = txtPass.Text; // Giả sử guna2TextBox2 là ô nhập mật khẩu

            // Kiểm tra thông tin đăng nhập
            string result = tkBLL.CheckLogicLogin(taikhoan);

            // Hiển thị thông báo kết quả
            if (result == "tài khoản hoặc mật khẩu không chính xác")
            {
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công: " + result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Tiến hành mở form chính hoặc chuyển hướng nếu cần
                // Ví dụ: new MainForm().Show();
                // this.Hide();
            }
        }
    }
}
