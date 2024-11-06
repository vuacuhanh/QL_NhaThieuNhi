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

namespace QL_NhaThieuNhi.LopHoc
{
    public partial class FrmLopHoc : Form
    {
        LopHocBLL lopHocBLL = new LopHocBLL(); // Kết nối đến BLL
        List<DTO.LopHoc> danhSachLopHoc = new List<DTO.LopHoc>(); // Sử dụng DTO.LopHoc
        public FrmLopHoc()
        {
            InitializeComponent();
            LoadLopHoc(); // Tải danh sách lớp học khi khởi động form
        }

        private void LoadLopHoc()
        {
            danhSachLopHoc = lopHocBLL.LoadLopHoc(); // Gọi BLL để tải lớp học
            dgvLopHoc.DataSource = danhSachLopHoc; // Đưa dữ liệu vào DataGridView
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.CurrentRow == null) return;

            int maLop = (int)dgvLopHoc.CurrentRow.Cells["MaLop"].Value;
            string result = lopHocBLL.DeleteLopHoc(maLop); // Gọi BLL để xóa lớp học
            MessageBox.Show(result);
            LoadLopHoc(); // Tải lại danh sách
        }

        private void btn_addNhanVien_Click(object sender, EventArgs e)
        {
            AddLopHoc frmThemLopHoc = new AddLopHoc();

            // Hiển thị form thêm lớp học
            frmThemLopHoc.FormClosed += (s, args) =>
            {
                // Khi form thêm lớp học đóng, tải lại danh sách lớp học
                LoadLopHoc();
            };

            frmThemLopHoc.ShowDialog();
        }
        //private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvLopHoc.CurrentRow != null)
        //    {
        //        txtTenLop.Text = dgvLopHoc.CurrentRow.Cells["TenLop"].Value.ToString();
        //        txtSiSo.Text = dgvLopHoc.CurrentRow.Cells["SiSo"].Value.ToString();
        //    }
        //}
    }
}
