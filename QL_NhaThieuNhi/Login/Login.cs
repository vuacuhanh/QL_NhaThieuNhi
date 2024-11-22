using BLL;
using DTO;
using QL_NhaThieuNhi.TrangChu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NhaThieuNhi
{
    public partial class Login : Form
    {
        public TaiKhoanBLL taiKhoanBLL;
        public string TK = "";
        public string loaiTK;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ form
            string tenDangNhap = txtUserName.Text.Trim();
            string matKhau = txtPass.Text.Trim();

            DTO.TaiKhoan taikhoan = new DTO.TaiKhoan
            {
                TenDangNhap = tenDangNhap,
                MatKhau = matKhau
            };

            // Kiểm tra đăng nhập
            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
            var loginResult = taiKhoanBLL.CheckLogin(taikhoan);

            if (!loginResult.isSuccess)
            {
                MessageBox.Show(loginResult.message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string quyen = loginResult.tenQuyen;

            if (quyen == "Admin")
            {
                this.Hide();
                Form1 adminForm = new Form1();
                adminForm.ShowDialog();
                this.Show();
            }
            else if (quyen == "User")
            {
                this.Hide();
                UsersForm userForm = new UsersForm();
                userForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Quyền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
