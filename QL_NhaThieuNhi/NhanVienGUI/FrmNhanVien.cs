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
        private DTO.NhanVien selectedNhanVien;
        private NhanVienBLL nhanVienBLL;

        public FrmNhanVien()
        {
            InitializeComponent();
            nhanVienBLL = new NhanVienBLL();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVienData();
            UpdateNVCount();
            data_NhanVien.CellFormatting += data_NhanVien_CellFormatting;
        }
        private void LoadNhanVienData()
        {
            List<DTO.NhanVien> danhSachNhanVien = nhanVienBLL.LoadNhanVien();

            // Thay đổi kích thước hình ảnh ngay khi tải dữ liệu
            foreach (var nhanVien in danhSachNhanVien)
            {
                if (nhanVien.HinhAnh != null)
                {
                    Image originalImage = ByteArrayToImage(nhanVien.HinhAnh);
                    Image resizedImage = ResizeImage(originalImage, 100, 130); // Thay đổi kích thước theo yêu cầu của bạn
                    nhanVien.HinhAnh = ImageToByteArray(resizedImage); // Lưu hình ảnh đã thay đổi kích thước
                }
            }

            data_NhanVien.DataSource = null; // Xóa dữ liệu cũ trong DataGridView
            data_NhanVien.DataSource = danhSachNhanVien;
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); 
                return ms.ToArray(); 
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            // Tính toán tỷ lệ khung hình của hình ảnh gốc
            float aspectRatio = (float)image.Width / image.Height;

            // Tính toán kích thước mới
            int newWidth, newHeight;

            if (image.Width > image.Height)
            {
                newWidth = width;
                newHeight = (int)(width / aspectRatio);
            }
            else
            {
                newHeight = height;
                newWidth = (int)(height * aspectRatio);
            }

            // Tạo một đối tượng Bitmap mới với kích thước đã tính toán
            Bitmap resizedBitmap = new Bitmap(newWidth, newHeight);

            // Vẽ hình ảnh đã thay đổi kích thước vào Bitmap mới
            using (Graphics g = Graphics.FromImage(resizedBitmap))
            {
                g.Clear(Color.White);  // Có thể thay đổi màu nền nếu cần
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return resizedBitmap;
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

        private void lb_SoLuongNV_Click(object sender, EventArgs e)
        {
            UpdateNVCount();
        }
        private void UpdateNVCount()
        {
            int soLuongNV = nhanVienBLL.CountNhanVien();
            lb_SoLuongNV.Text = $"{soLuongNV}";
        }

        private void data_NhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data_NhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (data_NhanVien.Columns[e.ColumnIndex].Name == "HinhAnh" && e.Value is byte[])
            {
                byte[] imageData = (byte[])e.Value;

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image img = Image.FromStream(ms);
                    e.Value = img;
                }
            }
        }






        private void btn_seen_Click(object sender, EventArgs e)
        {
            if (selectedNhanVien != null)
            {
                AddNhanVien addNhanVien = new AddNhanVien(selectedNhanVien);
                addNhanVien.ShowDialog();
                LoadNhanVienData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ bảng.");
            }
        }

        private void data_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = data_NhanVien.Rows[e.RowIndex];
                selectedNhanVien = row.DataBoundItem as DTO.NhanVien;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (selectedNhanVien != null)
            {
                AddNhanVien addNhanVien = new AddNhanVien(selectedNhanVien); // Truyền thông tin nhân viên được chọn vào form chỉnh sửa
                if (addNhanVien.ShowDialog() == DialogResult.OK)
                {
                    LoadNhanVienData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ bảng để chỉnh sửa.");
            }
        }

    }
}
