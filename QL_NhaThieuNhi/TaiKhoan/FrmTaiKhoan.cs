using DAL;
using DTO;
using BLL;
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
using Guna.UI2.WinForms;

namespace QL_NhaThieuNhi
{
    public partial class FrmTaiKhoan : Form
    {
        private TaiKhoanBLL taiKhoanBLL;
        public FrmTaiKhoan()
        {
            InitializeComponent();
            taiKhoanBLL = new TaiKhoanBLL();
        }

        private void LoadTaiKhoanData()
        {
            List<DTO.TaiKhoan> danhSachNhanVien = taiKhoanBLL.LoadTaiKhoan();
            data_TaiKhoan.DataSource = danhSachNhanVien;
        }


        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadTaiKhoanData();
            sort_By();
            Quyen();
            UpdateTaiKhoanCount();
        }

        public void sort_By()
        {
            cb_SortBy.Items.Clear();
            cb_SortBy.Items.Add(new KeyValuePair<string, string>("TenQuyen", "Xếp theo tên quyền"));
            cb_SortBy.Items.Add(new KeyValuePair<string, string>("MaTaiKhoan_DESC", "Mới nhất"));
            cb_SortBy.Items.Add(new KeyValuePair<string, string>("MaTaiKhoan_ASC", "Cũ nhất"));

            cb_SortBy.DisplayMember = "Value";
            cb_SortBy.ValueMember = "Key";

            cb_SortBy.SelectedIndex = 0; // Đặt mặc định là lựa chọn đầu tiên
        }
        private List<DTO.TaiKhoan> SortTaiKhoan(string sortKey)
        {
            // Lấy danh sách tài khoản từ tầng BLL
            List<DTO.TaiKhoan> danhSachTaiKhoan = taiKhoanBLL.LoadTaiKhoan();

            // Sắp xếp dựa theo sortKey
            switch (sortKey)
            {
                case "TenQuyen":
                    danhSachTaiKhoan = danhSachTaiKhoan.OrderBy(tk => tk.Quyen).ToList();
                    break;
                case "MaTaiKhoan_DESC":
                    danhSachTaiKhoan = danhSachTaiKhoan.OrderByDescending(tk => tk.MaTaiKhoan).ToList();
                    break;
                case "MaTaiKhoan_ASC":
                    danhSachTaiKhoan = danhSachTaiKhoan.OrderBy(tk => tk.MaTaiKhoan).ToList();
                    break;
                default:
                    break;
            }

            return danhSachTaiKhoan;
        }

        public void Quyen()
        {
            // Tạo một danh sách các quyền
            List<Quyen> listQuyen = new List<Quyen>();
            listQuyen.Add(new Quyen { MaQuyen = 1, TenQuyen = "Admin" });
            listQuyen.Add(new Quyen { MaQuyen = 2, TenQuyen = "User" });
            cbQuyen.DataSource = listQuyen;
            cbQuyen.DisplayMember = "TenQuyen";
            cbQuyen.ValueMember = "MaQuyen";
        }



        private void cb_SortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_SortBy.SelectedItem != null)
            {
                // Lấy khóa sắp xếp từ giá trị đã chọn trong ComboBox
                var selectedKey = ((KeyValuePair<string, string>)cb_SortBy.SelectedItem).Key;

                // Gọi hàm SortTaiKhoan để sắp xếp danh sách
                List<DTO.TaiKhoan> sortedList = SortTaiKhoan(selectedKey);

                // Cập nhật lại DataGridView
                data_TaiKhoan.DataSource = null;
                data_TaiKhoan.DataSource = sortedList;
            }
        }


        private void btn_delete_Click(object sender, EventArgs e)
        {
            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
            if (data_TaiKhoan.SelectedRows.Count > 0)
            {
                int maTaiKhoan = Convert.ToInt32(data_TaiKhoan.SelectedRows[0].Cells["MaTaiKhoan"].Value);

                if (taiKhoanBLL.DeleteTaiKhoan(maTaiKhoan))
                {
                    MessageBox.Show("Xóa tài khoản thành công!");
                    LoadTaiKhoanData();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa tài khoản.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa.");
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();

            if (data_TaiKhoan.SelectedRows.Count > 0)
            {
                // Kiểm tra nếu các trường cần thiết không được để trống
                if (string.IsNullOrEmpty(txt_NameAcc.Text) || string.IsNullOrEmpty(txt_Password.Text))
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.");
                    return;
                }

                // Tạo đối tượng TaiKhoan với thông tin cập nhật
                DTO.TaiKhoan updatedTaiKhoan = new DTO.TaiKhoan
                {
                    MaTaiKhoan = Convert.ToInt32(data_TaiKhoan.SelectedRows[0].Cells["MaTaiKhoan"].Value),
                    TenDangNhap = txt_NameAcc.Text,
                    MatKhau = txt_Password.Text,
                    MaQuyen = Convert.ToInt32(cbQuyen.SelectedValue)
                };

                // Thực hiện cập nhật tài khoản
                if (taiKhoanBLL.EditTaiKhoan(updatedTaiKhoan))
                {
                    MessageBox.Show("Sửa tài khoản thành công!");
                    LoadTaiKhoanData();
                }
                else
                {
                    MessageBox.Show("Lỗi khi sửa tài khoản.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa.");
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();

            // Kiểm tra nếu các trường cần thiết không được để trống
            if (string.IsNullOrEmpty(txt_NameAcc.Text) || string.IsNullOrEmpty(txt_Password.Text))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.");
                return;
            }

            // Tạo đối tượng TaiKhoan mới mà không cần MaTaiKhoan
            DTO.TaiKhoan newTaiKhoan = new DTO.TaiKhoan
            {
                TenDangNhap = txt_NameAcc.Text,
                MatKhau = txt_Password.Text,
                MaQuyen = Convert.ToInt32(cbQuyen.SelectedValue)
            };

            // Thực hiện thêm tài khoản
            if (taiKhoanBLL.AddTaiKhoan(newTaiKhoan))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                LoadTaiKhoanData(); 
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm tài khoản.");
            }
        }

        private void data_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng không click vào tiêu đề cột (chỉ click vào các dòng dữ liệu)
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = data_TaiKhoan.Rows[e.RowIndex];
                txt_NameAcc.Text = row.Cells["TenDangNhap"].Value.ToString();
                txt_Password.Text = row.Cells["MatKhau"].Value.ToString();
                cbQuyen.SelectedValue = row.Cells["MaQuyen"].Value;
            }
        }

        private void btn_importTK_Click(object sender, EventArgs e)
        {

        }
        private void UpdateTaiKhoanCount()
        { 
            int soLuongTaiKhoan = taiKhoanBLL.CountTaiKhoan(); 
            lb_SoLuongTK.Text = $"{soLuongTaiKhoan}"; 
        }

        private void lb_SoLuongTK_Click(object sender, EventArgs e)
        {
            UpdateTaiKhoanCount();
        }
    }
}
