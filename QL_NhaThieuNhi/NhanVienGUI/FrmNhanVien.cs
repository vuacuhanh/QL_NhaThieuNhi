using BLL;
using DTO;
using QL_NhaThieuNhi.NhanVienGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace QL_NhaThieuNhi
{
    public partial class FrmNhanVien : Form
    {
        private NhanVienBLL nhanVienBLL;

        public FrmNhanVien()
        {
            InitializeComponent();
            nhanVienBLL = new NhanVienBLL();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVienData();
        }
        private void LoadNhanVienData()
        {
            List<DTO.NhanVien> danhSachNhanVien = nhanVienBLL.LoadNhanVien();
            data_NhanVien.DataSource = danhSachNhanVien;
        }

        private void btn_addNhanVien_Click(object sender, EventArgs e)
        {
            AddNhanVien addNhanVien = new AddNhanVien();
            if (addNhanVien.ShowDialog() == DialogResult.OK)
            {
                LoadNhanVienData();
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (data_NhanVien.SelectedRows.Count > 0)
            {
                int maNhanVien = (int)data_NhanVien.SelectedRows[0].Cells["MaNhanVien"].Value;
                bool success = nhanVienBLL.DeleteNhanVien(maNhanVien);
                if (success)
                {
                    MessageBox.Show("Xóa nhân viên thành công.");
                    LoadNhanVienData();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            openFileDialog.Title = "Chọn file Excel để import";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    // Gọi phương thức BLL để import nhân viên từ file Excel
                    NhanVienBLL.ImportNhanVienFromExcel(filePath);
                    MessageBox.Show("Dữ liệu nhân viên đã được import thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi import dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách nhân viên từ BLL
                List<DTO.NhanVien> danhSachNhanVien = nhanVienBLL.GetAllNhanVien(); // Gọi từ đối tượng nhanVienBLL

                // Kiểm tra danh sách nhân viên có dữ liệu hay không
                if (danhSachNhanVien == null || !danhSachNhanVien.Any())
                {
                    MessageBox.Show("Không có dữ liệu nhân viên để hiển thị báo cáo.");
                    return;
                }

                // Thiết lập ReportViewer
                ReportViewer reportViewer = new ReportViewer
                {
                    ProcessingMode = ProcessingMode.Local,
                    Dock = DockStyle.Fill,
                    Size = new Size(800, 600) // Thiết lập kích thước nếu cần
                };

                // Đường dẫn file .rdlc báo cáo
                reportViewer.LocalReport.ReportPath = "D:\\DoAnQLNTN\\QL_NhaThieuNhi\\QL_NhaThieuNhi\\ReportNV.rdlc";

                // Đặt nguồn dữ liệu cho ReportViewer
                reportViewer.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DATANHANVIEN", danhSachNhanVien);
                reportViewer.LocalReport.DataSources.Add(rds);

                // Refresh để hiển thị báo cáo
                reportViewer.RefreshReport();

                // Hiển thị ReportViewer trên Form mới
                Form reportForm = new Form
                {
                    Text = "Báo cáo Nhân viên",
                    Size = new Size(1000, 700)
                };
                reportForm.Controls.Add(reportViewer);
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị báo cáo: " + ex.Message);
            }
        }

        private void txtTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiemNV.Text.Trim();
            List<DTO.NhanVien> danhSachNhanVien;

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu không có từ khóa, tải toàn bộ dữ liệu
                danhSachNhanVien = nhanVienBLL.LoadNhanVien();
            }
            else
            {
                // Tìm kiếm nhân viên theo từ khóa
                danhSachNhanVien = nhanVienBLL.SearchNhanVien(keyword);
            }

            data_NhanVien.DataSource = danhSachNhanVien;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
