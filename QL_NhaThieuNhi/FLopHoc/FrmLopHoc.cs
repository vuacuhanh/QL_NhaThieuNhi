using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using System.Windows.Forms;
using BLL; // Import lớp LopHocBLL để lấy dữ liệu
using DTO;
using System.IO;
using System.Data;
using System.Linq;

namespace QL_NhaThieuNhi.FLopHoc
{
    public partial class FrmLopHoc : Form
    {
        public FrmLopHoc()
        {
            InitializeComponent();

            LoadChuyenMon();

            LoadLopHoc(); // Gọi phương thức load dữ liệu khi khởi tạo form

            // Đăng ký sự kiện CellClick trong InitializeComponent
            this.dgvLopHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLopHoc_CellClick);
            this.cbLocTheoChuyenMon.SelectedIndexChanged += new System.EventHandler(this.cbLocTheoChuyenMon_SelectedIndexChanged);
            this.txtTimKiemLopHoc.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);


        }

        private List<string> chuyenMons = new List<string>
        {
            "Tất Cả","Mỹ Thuật", "Học Thuật", "nghệ Thuật", "Năng Khiếu"
        };

        private void LoadChuyenMon()
        {
            try
            {
                // Gán danh sách chuyên môn vào ComboBox
                cbLocTheoChuyenMon.DataSource = chuyenMons;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load chuyên môn: " + ex.Message);
            }
        }

        // Phương thức để load dữ liệu lớp học vào dgvLopHoc
        private void LoadLopHoc()
        {
            try
            {
                var danhSachLopHoc = LopHocBLL.LayTatCaLopHoc(); // Gọi BLL để lấy danh sách lớp học
                dgvLopHoc.DataSource = danhSachLopHoc; // Gán dữ liệu cho DataGridView

                // Ẩn các cột không mong muốn
                dgvLopHoc.Columns["HoaDons"].Visible = false;
                dgvLopHoc.Columns["HocViens"].Visible = false;
                dgvLopHoc.Columns["LichDays"].Visible = false;
                dgvLopHoc.Columns["LichHocs"].Visible = false;
                dgvLopHoc.Columns["NhanVien"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu lớp học: " + ex.Message);
            }
        }

        // Thêm lớp học mới
        private void btnThemLopHoc_Click(object sender, EventArgs e)
        {
            try
            {
                var maLop = Convert.ToInt32(txtMaLop.Text); // Lấy mã lớp học từ TextBox
                var tenLop = txtTenLop.Text; // Lấy tên lớp từ TextBox
                var chuyenMon = txtChuyenMon.Text; // Lấy chuyên môn từ TextBox
                var maNhanVien = Convert.ToInt32(txtMaNhanVien.Text); // Lấy mã nhân viên từ TextBox
                var siSo = Convert.ToInt32(nbSiSo.Value); // Lấy sĩ số từ NumericUpDown
                var thoiGianBatDau = dtpBatDau.Value; // Lấy thời gian bắt đầu từ DateTimePicker
                var thoiGianKetThuc = dtpKetThuc.Value; // Lấy thời gian kết thúc từ DateTimePicker
                var trangThai = txtTrangThai.Text; // Lấy trạng thái lớp học từ TextBox

                if (string.IsNullOrEmpty(tenLop) || string.IsNullOrEmpty(chuyenMon) || maNhanVien == 0 || siSo == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin lớp học.");
                    return;
                }

                var lopHocMoi = new LopHoc
                {
                    MaLop = maLop,
                    TenLop = tenLop,
                    ChuyenMon = chuyenMon,
                    MaNhanVien = maNhanVien,
                    SiSo = siSo,
                    ThoiGianBatDau = thoiGianBatDau,
                    ThoiGianKetThuc = thoiGianKetThuc,
                    TrangThai = trangThai
                };

                if (LopHocBLL.ThemLopHoc(lopHocMoi)) // Thêm lớp học thông qua BLL
                {
                    MessageBox.Show("Thêm lớp học thành công!");
                    LoadLopHoc(); // Tải lại danh sách lớp học
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm lớp học.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm lớp học: " + ex.Message);
            }
        }

        // Xóa lớp học
        private void BtnXoaLopHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLopHoc.SelectedRows.Count > 0)
                {
                    var maLop = Convert.ToInt32(dgvLopHoc.SelectedRows[0].Cells["MaLop"].Value); // Lấy mã lớp học từ dòng được chọn

                    if (LopHocBLL.XoaLopHoc(maLop)) // Xóa lớp học thông qua BLL
                    {
                        MessageBox.Show("Xóa lớp học thành công!");
                        LoadLopHoc(); // Tải lại danh sách lớp học
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa lớp học.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn lớp học cần xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa lớp học: " + ex.Message);
            }
        }

        // Sửa lớp học
        private void btnSuaLopHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLopHoc.SelectedRows.Count > 0)
                {
                    var maLop = Convert.ToInt32(dgvLopHoc.SelectedRows[0].Cells["MaLop"].Value); // Lấy mã lớp học từ dòng được chọn
                    var tenLop = txtTenLop.Text; // Lấy tên lớp từ TextBox
                    var chuyenMon = txtChuyenMon.Text; // Lấy chuyên môn từ TextBox
                    var maNhanVien = Convert.ToInt32(txtMaNhanVien.Text); // Lấy mã nhân viên từ TextBox
                    var siSo = Convert.ToInt32(nbSiSo.Value); // Lấy sĩ số từ NumericUpDown
                    var thoiGianBatDau = dtpBatDau.Value; // Lấy thời gian bắt đầu từ DateTimePicker
                    var thoiGianKetThuc = dtpKetThuc.Value; // Lấy thời gian kết thúc từ DateTimePicker
                    var trangThai = txtTrangThai.Text; // Lấy trạng thái lớp học từ TextBox

                    if (string.IsNullOrEmpty(tenLop) || string.IsNullOrEmpty(chuyenMon) || maNhanVien == 0 || siSo == 0)
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin lớp học.");
                        return;
                    }

                    var lopHocMoi = new LopHoc
                    {
                        MaLop = maLop,
                        TenLop = tenLop,
                        ChuyenMon = chuyenMon,
                        MaNhanVien = maNhanVien,
                        SiSo = siSo,
                        ThoiGianBatDau = thoiGianBatDau,
                        ThoiGianKetThuc = thoiGianKetThuc,
                        TrangThai = trangThai
                    };

                    if (LopHocBLL.SuaLopHoc(lopHocMoi)) // Cập nhật lớp học thông qua BLL
                    {
                        MessageBox.Show("Cập nhật lớp học thành công!");
                        LoadLopHoc(); // Tải lại danh sách lớp học
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi cập nhật lớp học.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn lớp học cần sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi sửa lớp học: " + ex.Message);
            }
        }

        // Lọc lớp học theo chuyên môn
        private void cbLocTheoChuyenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var chuyenMon = cbLocTheoChuyenMon.SelectedItem.ToString(); // Lấy giá trị chuyên môn từ ComboBox

                if (chuyenMon == "Tất Cả")
                {
                    // Nếu chọn "None", load lại toàn bộ danh sách lớp học
                    LoadLopHoc();
                }
                else
                {
                    // Lọc lớp học theo chuyên môn
                    var danhSachLopHoc = LopHocBLL.LocLopHocTheoChuyenMon(chuyenMon);
                    dgvLopHoc.DataSource = danhSachLopHoc; // Gán dữ liệu cho DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lọc lớp học theo chuyên môn: " + ex.Message);
            }
        }


        // Sự kiện khi người dùng click vào một dòng trong DataGridView
        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (e.RowIndex >= 0)
                {
                    var row = dgvLopHoc.Rows[e.RowIndex]; // Lấy dòng được chọn

                    // Cập nhật các trường nhập với dữ liệu từ dòng được chọn
                    txtMaLop.Text = row.Cells["MaLop"].Value.ToString(); // Cập nhật mã lớp học
                    txtTenLop.Text = row.Cells["TenLop"].Value.ToString(); // Cập nhật tên lớp
                    txtChuyenMon.Text = row.Cells["ChuyenMon"].Value.ToString(); // Cập nhật chuyên môn
                    txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString(); // Cập nhật mã nhân viên
                    nbSiSo.Value = Convert.ToDecimal(row.Cells["SiSo"].Value); // Cập nhật sĩ số
                    dtpBatDau.Value = Convert.ToDateTime(row.Cells["ThoiGianBatDau"].Value); // Cập nhật thời gian bắt đầu
                    dtpKetThuc.Value = Convert.ToDateTime(row.Cells["ThoiGianKetThuc"].Value); // Cập nhật thời gian kết thúc
                    txtTrangThai.Text = row.Cells["TrangThai"].Value.ToString(); // Cập nhật trạng thái lớp học
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi chọn dòng: " + ex.Message);
            }
        }

        private void btnExportFileExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu DataGridView có dữ liệu
                if (dgvLopHoc.Rows.Count > 0)
                {
                    // Tạo workbook mới
                    using (var workbook = new XLWorkbook())
                    {
                        // Tạo một worksheet
                        var worksheet = workbook.Worksheets.Add("DanhSachLopHoc");

                        int visibleColumnIndex = 1; // Dùng để theo dõi các cột hiển thị

                        // Thêm tiêu đề cột vào worksheet (chỉ cột hiển thị)
                        for (int i = 0; i < dgvLopHoc.Columns.Count; i++)
                        {
                            if (dgvLopHoc.Columns[i].Visible) // Chỉ thêm các cột hiển thị
                            {
                                worksheet.Cell(1, visibleColumnIndex).Value = dgvLopHoc.Columns[i].HeaderText;
                                visibleColumnIndex++;
                            }
                        }

                        // Thêm dữ liệu từ DataGridView vào worksheet (chỉ cột hiển thị)
                        for (int i = 0; i < dgvLopHoc.Rows.Count; i++)
                        {
                            visibleColumnIndex = 1; // Reset index cho mỗi hàng
                            for (int j = 0; j < dgvLopHoc.Columns.Count; j++)
                            {
                                if (dgvLopHoc.Columns[j].Visible) // Chỉ thêm dữ liệu cho cột hiển thị
                                {
                                    worksheet.Cell(i + 2, visibleColumnIndex).Value = dgvLopHoc.Rows[i].Cells[j].Value?.ToString() ?? "";
                                    visibleColumnIndex++;
                                }
                            }
                        }

                        // Mở hộp thoại lưu file để chọn nơi lưu file
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save an Excel File";
                        saveFileDialog.FileName = "DanhSachLopHoc.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Lưu workbook vào file
                            using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                            {
                                workbook.SaveAs(stream);
                            }

                            MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimKiemLopHoc(string tuKhoa)
        {
            try
            {
                var danhSachLopHoc = LopHocBLL.LayTatCaLopHoc(); // Lấy tất cả lớp học từ BLL

                // Nếu từ khóa trống hoặc null, hiển thị toàn bộ danh sách
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    dgvLopHoc.DataSource = danhSachLopHoc;
                    return;
                }

                // Chuyển từ khóa về chữ thường để so sánh không phân biệt hoa thường
                tuKhoa = tuKhoa.ToLower();

                // Lọc danh sách theo từ khóa (tuKhoa)
                var ketQuaTimKiem = danhSachLopHoc.Where(lh =>
                    lh.MaLop.ToString().Contains(tuKhoa) || // Tìm theo Mã lớp
                    lh.TenLop.ToLower().Contains(tuKhoa) || // Tìm theo Tên lớp (chuyển về chữ thường)
                    lh.ChuyenMon.ToLower().Contains(tuKhoa) // Tìm theo Chuyên môn (chuyển về chữ thường)
                ).ToList();

                dgvLopHoc.DataSource = ketQuaTimKiem; // Gán kết quả tìm kiếm vào DataGridView

                // Nếu không có kết quả nào
                if (ketQuaTimKiem.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm lớp học: " + ex.Message);
            }
        }

        // Tìm kiếm lớp học theo tên khi người dùng nhập vào TextBox txtTimKiemLopHoc
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiemLopHoc.Text.ToLower(); // Chuyển từ khóa tìm kiếm thành chữ thường

                // Lấy tất cả danh sách lớp học
                var danhSachLopHoc = LopHocBLL.LayTatCaLopHoc();

                // Lọc danh sách lớp học theo từ khóa tìm kiếm, không phân biệt hoa thường
                var filteredLopHoc = danhSachLopHoc.Where(lopHoc =>
                    lopHoc.TenLop.ToLower().Contains(keyword) ||  // So sánh tên lớp
                    lopHoc.ChuyenMon.ToLower().Contains(keyword)   // So sánh chuyên môn
                ).ToList();

                // Gán lại danh sách đã lọc cho DataGridView
                dgvLopHoc.DataSource = filteredLopHoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message);
            }
        }




    }
}
