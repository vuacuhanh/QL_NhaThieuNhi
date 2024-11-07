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
            data_TaiKhoan.DataSource = ds_HT.Tables["TaiKhoan"];
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_HT.Tables["TaiKhoan"].Columns[0];
            ds_HT.Tables["TaiKhoan"].PrimaryKey = key;
        }

        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            Load_DuLieu_TK();
            sort_By();
            Quyen();
        }
        public void sort_By()
        {
            cb_SortBy.Items.Add("Xếp theo tên quyền");
            cb_SortBy.Items.Add("Mới nhất");
            cb_SortBy.Items.Add("Cũ nhất");
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
                    Load_DuLieu_TK();
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
                    Load_DuLieu_TK(); // Nạp lại dữ liệu
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
                Load_DuLieu_TK(); // Nạp lại dữ liệu
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
                // Lấy dữ liệu từ các cột của dòng đã chọn
                DataGridViewRow row = data_TaiKhoan.Rows[e.RowIndex];

                // Hiển thị giá trị vào các TextBox
                txt_ID.Text = row.Cells["MaTaiKhoan"].Value.ToString(); // Đảm bảo tên cột đúng với tên cột trong DataGridView
                txt_NameAcc.Text = row.Cells["TenDangNhap"].Value.ToString();
                txt_Password.Text = row.Cells["MatKhau"].Value.ToString();
                cbQuyen.SelectedValue = row.Cells["MaQuyen"].Value;
            }
        }
    }
}
