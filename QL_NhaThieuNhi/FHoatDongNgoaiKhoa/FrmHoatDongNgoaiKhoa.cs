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
using ClosedXML.Excel;


namespace QL_NhaThieuNhi.FHoatDongNgoaiKhoa
{
    public partial class FrmHoatDongNgoaiKhoa : Form
    {
        public FrmHoatDongNgoaiKhoa()
        {
            InitializeComponent();
            LoadHoatDongData();

            dgvHoatDongNgoaiKhoa.CellClick += dgvHoatDongNgoaiKhoa_CellClick;
        }

        private void LoadHoatDongData()
        {
            try
            {
                var HoatDongs = HoatDongNgoaiKhoaBLL.GetAllHoatDongNgoaiKhoa();
                dgvHoatDongNgoaiKhoa.DataSource = HoatDongs;

                //Kiểm tra và ẩn các cột cần thiết
                if (dgvHoatDongNgoaiKhoa.Columns.Contains("NhanVien"))
                {
                    dgvHoatDongNgoaiKhoa.Columns["NhanVien"].Visible = false;
                }
                if (dgvHoatDongNgoaiKhoa.Columns.Contains("ThamGiaHoatDongs"))
                {
                    dgvHoatDongNgoaiKhoa.Columns["ThamGiaHoatDongs"].Visible = false;
                }
                UpdateTongHoatDong();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách chương Trình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHoatDongNgoaiKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Make sure a valid row is clicked
                if (e.RowIndex >= 0)
                {
                    var selectedRow = dgvHoatDongNgoaiKhoa.Rows[e.RowIndex];

                    // Populate textboxes and other controls with the values from the selected row
                    txtMaHoatDong.Text = selectedRow.Cells["MaHDNK"].Value.ToString();
                    txtTenHoatDong.Text = selectedRow.Cells["TenHoatDong"].Value.ToString();
                    txtMoTa.Text = selectedRow.Cells["MoTa"].Value.ToString();
                    txtDiaDiem.Text = selectedRow.Cells["DiaDiem"].Value.ToString();
                    txtMaGiaoVien.Text = selectedRow.Cells["MaGiaoVien"].Value.ToString();

                    // Assuming you are using DateTimePickers for ThoiGianBatDau and ThoiGianToChuc
                    dtpBatDau.Value = Convert.ToDateTime(selectedRow.Cells["ThoiGianBatDau"].Value);
                    dtpKetThuc.Value = Convert.ToDateTime(selectedRow.Cells["ThoiGianToChuc"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTongHoatDong()
        {
            try
            {
                int soChuongTrinh = dgvHoatDongNgoaiKhoa.RowCount;
                txtTongSoHoatDong.Text = soChuongTrinh.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng số Hoạt Động: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTongSoHoatDong_TextChanged(object sender, EventArgs e)
        {

        }

        private void TimKiemChuongTrinh(string tuKhoa)
        {
            try
            {
                var hoatDongs = HoatDongNgoaiKhoaBLL.GetAllHoatDongNgoaiKhoa();

                // Nếu từ khóa trống hoặc null, hiển thị toàn bộ danh sách
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    dgvHoatDongNgoaiKhoa.DataSource = hoatDongs;
                    UpdateTongHoatDong();
                    return;
                }

                // Làm sạch và chuẩn hóa từ khóa
                tuKhoa = tuKhoa.Trim().Replace("\u00A0", " ").ToLower();

                // Giới hạn độ dài từ khóa
                if (tuKhoa.Length > 100)
                {
                    MessageBox.Show("Từ khóa quá dài, vui lòng nhập từ khóa ngắn hơn.");
                    return;
                }

                // Hàm làm sạch dữ liệu
                string CleanString(string input)
                {
                    return input?.Trim().Replace("\u00A0", " ").ToLower();
                }

                // Lọc danh sách theo từ khóa
                var ketQuaTimKiem = hoatDongs.Where(hd =>
                    (!string.IsNullOrEmpty(hd.MaHDNK.ToString()) && hd.MaHDNK.ToString().Contains(tuKhoa)) ||
                    (!string.IsNullOrEmpty(CleanString(hd.TenHoatDong)) && CleanString(hd.TenHoatDong).Contains(tuKhoa)) ||
                    (!string.IsNullOrEmpty(hd.MaGiaoVien?.ToString()) && hd.MaGiaoVien.ToString().Contains(tuKhoa))
                ).ToList();

                // Gán kết quả tìm kiếm vào DataGridView
                dgvHoatDongNgoaiKhoa.DataSource = ketQuaTimKiem;
                UpdateTongHoatDong();

                // Hiển thị thông báo nếu không tìm thấy kết quả
                if (!ketQuaTimKiem.Any())
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm chương trình: " + ex.Message);
                Console.WriteLine(ex.StackTrace); // Ghi log chi tiết
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                // Đặt lại các trường nhập liệu về giá trị mặc định
                txtMaHoatDong.Clear();         // Xóa text của txtMaChuongTrinh
                txtTenHoatDong.Clear();        // Xóa text của txtTenChuongTrinh
                txtMoTa.Clear();                  // Xóa text của txtMoTa
                dtpBatDau.Value = DateTime.Now;   // Đặt lại giá trị của DateTimePicker về ngày hiện tại
                dtpKetThuc.Value = DateTime.Now; // Đặt lại giá trị của DateTimePicker về ngày hiện tại
                txtDiaDiem.Clear();     // Đặt lại ComboBox về không có lựa chọn nào
                txtMaGiaoVien.Clear();            // Xóa text của txtMaGiaoVien

                LoadHoatDongData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi reset các trường nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemHoatDong_Click(object sender, EventArgs e)
        {
            try
            {
                var hoatDongMoi = new HoatDongNgoaiKhoa
                {
                    MaHDNK = int.Parse(txtMaHoatDong.Text.Trim()), // Chuyển đổi thành int
                    TenHoatDong = txtTenHoatDong.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    ThoiGianBatDau = dtpBatDau.Value,
                    ThoiGianToChuc = dtpKetThuc.Value,
                    DiaDiem = txtDiaDiem.Text.Trim(),
                    MaGiaoVien = int.Parse(txtMaGiaoVien.Text.Trim()) // Chuyển đổi thành int
                };

                bool isSuccess = HoatDongNgoaiKhoaBLL.AddHoatDongNgoaiKhoa(hoatDongMoi);
                if (isSuccess)
                {
                    MessageBox.Show("Thêm hoạt động thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoatDongData();
                }
                else
                {
                    MessageBox.Show("Thêm hoạt động không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hoạt động: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoaHoatDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoatDongNgoaiKhoa.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một Hoạt Động để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int maHDNK = Convert.ToInt32(dgvHoatDongNgoaiKhoa.SelectedRows[0].Cells["MaHDNK"].Value);

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Hoạt Động này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    // Gọi BLL để xóa chương trình
                    if (HoatDongNgoaiKhoaBLL.DeleteHoatDongNgoaiKhoa(maHDNK))
                    {
                        MessageBox.Show("Xóa Hoạt Động thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHoatDongData(); // Tải lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Xóa Hoạt Động thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa chương trình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaHoatDong_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có chương trình nào được chọn không
                if (dgvHoatDongNgoaiKhoa.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một chương trình để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra các trường hợp bắt buộc không được để trống
                if (string.IsNullOrWhiteSpace(txtMaHoatDong.Text) || string.IsNullOrWhiteSpace(txtTenHoatDong.Text) ||
                    string.IsNullOrWhiteSpace(txtMoTa.Text) || txtDiaDiem.Text == null || txtMaGiaoVien.Text == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy mã chương trình được chọn
                int maHDNK = Convert.ToInt32(dgvHoatDongNgoaiKhoa.SelectedRows[0].Cells["MaHDNK"].Value);

                // Tạo đối tượng Chương Trình từ các dữ liệu nhập vào
                var hoatDong = new HoatDongNgoaiKhoa
                {
                    MaHDNK = maHDNK, // Sử dụng mã chương trình hiện tại
                    TenHoatDong = txtTenHoatDong.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    ThoiGianBatDau = dtpBatDau.Value,
                    ThoiGianToChuc = dtpKetThuc.Value,
                    DiaDiem = txtDiaDiem.Text.Trim(),
                    MaGiaoVien = int.Parse(txtMaGiaoVien.Text.Trim()) // Chuyển đổi thành int
                };

                // Gọi BLL để sửa chương trình
                if (HoatDongNgoaiKhoaBLL.UpdateHoatDongNgoaiKhoa(hoatDong))
                {
                    MessageBox.Show("Cập nhật Hoạt Động thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoatDongData(); // Tải lại dữ liệu
                }
                else
                {
                    MessageBox.Show("Cập nhật Hoạt Động thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa Hoạt Động: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportFileExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một workbook mới
                using (var workbook = new XLWorkbook())
                {
                    // Tạo một worksheet trong workbook
                    var worksheet = workbook.AddWorksheet("HoatDongNgoaiKhoa");

                    // Tạo tiêu đề cột từ DataGridView
                    for (int col = 0; col < dgvHoatDongNgoaiKhoa.Columns.Count; col++)
                    {
                        if (dgvHoatDongNgoaiKhoa.Columns[col].Visible) // Chỉ thêm các cột hiển thị
                        {
                            worksheet.Cell(1, col + 1).Value = dgvHoatDongNgoaiKhoa.Columns[col].HeaderText; // Tiêu đề cột
                        }

                    }

                    // Xuất dữ liệu từng dòng vào worksheet
                    for (int row = 0; row < dgvHoatDongNgoaiKhoa.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvHoatDongNgoaiKhoa.Columns.Count; col++)
                        {
                            // Lấy giá trị từ từng ô trong DataGridView và gán vào Excel
                            worksheet.Cell(row + 2, col + 1).Value = dgvHoatDongNgoaiKhoa.Rows[row].Cells[col].Value?.ToString();
                        }
                    }

                    // Mở SaveFileDialog để người dùng chọn nơi lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx;*.xls",
                        Title = "Lưu file Excel"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Lưu file Excel tại vị trí người dùng chọn
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Dữ liệu đã được xuất ra file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.ToLower(); // Chuyển từ khóa tìm kiếm thành chữ thường

                // Gọi phương thức tìm kiếm hóa đơn
                TimKiemChuongTrinh(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message);
            }
        }
    }
}
