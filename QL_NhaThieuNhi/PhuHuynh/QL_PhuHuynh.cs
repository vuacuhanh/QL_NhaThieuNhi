using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace QL_NhaThieuNhi.PhuHuynh
{
    public partial class QL_PhuHuynh : Form
    {
        public QL_PhuHuynh()
        {
            InitializeComponent();
            LoadPhuHuynh();
        }
        private void LoadPhuHuynh()
        {
            try
            {
                // Gọi BLL để lấy danh sách phụ huynh
                var danhSachPhuHuynh = PhuHuynhBLL.LayTatCaPhuHuynh();
                dgvPhuHuynh.DataSource = danhSachPhuHuynh; // Gán dữ liệu cho DataGridView

                // Ẩn các cột không mong muốn (nếu có)
                if (dgvPhuHuynh.Columns.Contains("HocViens"))
                {
                    dgvPhuHuynh.Columns["HocViens"].Visible = false;
                }

                // Tùy chỉnh tiêu đề cột hiển thị
                dgvPhuHuynh.Columns["MaPhuHuynh"].HeaderText = "Mã Phụ Huynh";
                dgvPhuHuynh.Columns["TenPhuHuynh"].HeaderText = "Tên Phụ Huynh";
                dgvPhuHuynh.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgvPhuHuynh.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvPhuHuynh.Columns["NgheNghiep"].HeaderText = "Nghề Nghiệp";
                dgvPhuHuynh.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                dgvPhuHuynh.Columns["Email"].HeaderText = "Email";
                dgvPhuHuynh.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";

                // Căn chỉnh cột nếu cần
                dgvPhuHuynh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu phụ huynh: " + ex.Message);
            }
        }

    }
}
