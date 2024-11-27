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
            txtUserName.Text = Properties.Settings.Default.UserName;
            txtPass.Text = Properties.Settings.Default.Password;
            tgRemember.Checked = !string.IsNullOrEmpty(Properties.Settings.Default.UserName);
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

            // Lưu hoặc xóa thông tin dựa trên trạng thái 
            if (tgRemember.Checked)
            {
                SaveLoginInfo(tenDangNhap, matKhau);
            }
            else
            {
                ClearLoginInfo();
            }

            // Điều hướng theo quyền người dùng
            string quyen = loginResult.tenQuyen;

            if (quyen == "Admin")
            {
                this.Hide();
                Form1 adminForm = new Form1();
                adminForm.ShowDialog();
            }
            else if (quyen == "User")
            {
                this.Hide();
                UsersForm userForm = new UsersForm();
                userForm.FormClosed += (s, args) => this.Show();
            }
            else
            {
                MessageBox.Show("Quyền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void tgRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void SaveLoginInfo(string userName, string password)
        {
            // Lưu thông tin vào Settings
            Properties.Settings.Default.UserName = userName;
            Properties.Settings.Default.Password = password;
            Properties.Settings.Default.Save();
        }

        private void ClearLoginInfo()
        {
            // Xóa thông tin khỏi Settings
            Properties.Settings.Default.UserName = string.Empty;
            Properties.Settings.Default.Password = string.Empty;
            Properties.Settings.Default.Save();
        }

        private bool isPasswordVisible = false;
        private void btn_eye_Click(object sender, EventArgs e)
        {

            if (isPasswordVisible)
            {
                txtPass.PasswordChar = '*';
                btn_eye.Image = Properties.Resources.close_eye;
                isPasswordVisible = false;
                
            }
            else
            {
                txtPass.PasswordChar = '\0';
                btn_eye.Image = Properties.Resources.visible;
                isPasswordVisible = true;
            }
        }
    }
}
