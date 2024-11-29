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

namespace QL_NhaThieuNhi.FChuongTrinhNangKhieu
{
    public partial class FrmChuongTrinhNangKhieu : Form
    {
        public FrmChuongTrinhNangKhieu()
        {
            InitializeComponent();
            LoadChuongTrinhData();

            // Đăng ký sự kiện CellClick cho DataGridView
            dgvChuongTrinhNangKhieu.CellClick += dgvChuongTrinhNangKhieu_CellClick;
        }

        private void LoadChuongTrinhData()
        {
            try
            {
                var ChuongTrinhs = ChuongTrinhNangKhieuBLL.GetAllChuongTrinhNangKhieu();
                dgvChuongTrinhNangKhieu.DataSource = ChuongTrinhs;

                // Kiểm tra và ẩn các cột cần thiết
                if (dgvChuongTrinhNangKhieu.Columns.Contains("NhanVien"))
                {
                    dgvChuongTrinhNangKhieu.Columns["NhanVien"].Visible = false;
                }
                if (dgvChuongTrinhNangKhieu.Columns.Contains("ThamGiaHoatDongs"))
                {
                    dgvChuongTrinhNangKhieu.Columns["ThamGiaHoatDongs"].Visible = false;
                }
                UpdateTongChuongTrinh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách chương Trình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvChuongTrinhNangKhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng không click vào tiêu đề cột
                if (e.RowIndex >= 0)
                {
                    // Lấy dữ liệu từ dòng được chọn
                    DataGridViewRow row = dgvChuongTrinhNangKhieu.Rows[e.RowIndex];

                    // Gán giá trị vào các trường nhập liệu
                    txtMaChuongTrinh.Text = row.Cells["MaCTNK"].Value.ToString();
                    txtTenChuongTrinh.Text = row.Cells["TenCT"].Value.ToString();
                    txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                    dtpBatDau.Value = Convert.ToDateTime(row.Cells["ThoiGianBatDau"].Value);
                    dtpKetThuc.Value = Convert.ToDateTime(row.Cells["ThoiGianKetThuc"].Value);
                    txtDiaDiem.Text = row.Cells["DiaDiem"].Value.ToString();
                    txtMaGiaoVien.Text = row.Cells["MaGiaoVien"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTongChuongTrinh()
        {
            try
            {
                int soChuongTrinh = dgvChuongTrinhNangKhieu.RowCount;
                txtTongSoChuongTrinh.Text = soChuongTrinh.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng số hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimKiemChuongTrinh(string tuKhoa)
        {
            try
            {
                var ChuongTrinhs = ChuongTrinhNangKhieuBLL.GetAllChuongTrinhNangKhieu();

                // Nếu từ khóa trống hoặc null, hiển thị toàn bộ danh sách
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    dgvChuongTrinhNangKhieu.DataSource = ChuongTrinhs;
                    UpdateTongChuongTrinh();
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
                var ketQuaTimKiem = ChuongTrinhs.Where(hd =>
                    (!string.IsNullOrEmpty(hd.MaCTNK.ToString()) && hd.MaCTNK.ToString().Contains(tuKhoa)) ||
                    (!string.IsNullOrEmpty(CleanString(hd.TenCT)) && CleanString(hd.TenCT).Contains(tuKhoa)) ||
                    (!string.IsNullOrEmpty(hd.MaGiaoVien?.ToString()) && hd.MaGiaoVien.ToString().Contains(tuKhoa))
                ).ToList();

                // Gán kết quả tìm kiếm vào DataGridView
                dgvChuongTrinhNangKhieu.DataSource = ketQuaTimKiem;
                UpdateTongChuongTrinh();

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
        private void LocChuongTrinhNangKhieu(DateTime? thoiGianBatDau, DateTime? thoiGianKetThuc, string trangThaiThanhToan)
        {
            try
            {
                var ChuongTrinhs = ChuongTrinhNangKhieuBLL.GetAllChuongTrinhNangKhieu();

                // Lọc theo thời gian nếu có
                if (thoiGianBatDau.HasValue && thoiGianKetThuc.HasValue)
                {
                    ChuongTrinhs = ChuongTrinhs.Where(hd =>
                        hd.ThoiGianBatDau >= thoiGianBatDau.Value.Date &&
                        hd.ThoiGianKetThuc <= thoiGianKetThuc.Value.Date).ToList();
                }

                // Lọc theo trạng thái thanh toán nếu có
                if (!string.IsNullOrWhiteSpace(trangThaiThanhToan))
                {
                    ChuongTrinhs = ChuongTrinhs.Where(hd => hd.DiaDiem == trangThaiThanhToan).ToList();
                }

                // Hiển thị kết quả lọc trên DataGridView
                dgvChuongTrinhNangKhieu.DataSource = ChuongTrinhs;
                UpdateTongChuongTrinh();

                if (ChuongTrinhs.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào phù hợp với tiêu chí lọc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                // Đặt lại các trường nhập liệu về giá trị mặc định
                txtMaChuongTrinh.Clear();         // Xóa text của txtMaChuongTrinh
                txtTenChuongTrinh.Clear();        // Xóa text của txtTenChuongTrinh
                txtMoTa.Clear();                  // Xóa text của txtMoTa
                dtpBatDau.Value = DateTime.Now;   // Đặt lại giá trị của DateTimePicker về ngày hiện tại
                dtpKetThuc.Value = DateTime.Now; // Đặt lại giá trị của DateTimePicker về ngày hiện tại
                txtDiaDiem.Clear();     // Đặt lại ComboBox về không có lựa chọn nào
                txtMaGiaoVien.Clear();            // Xóa text của txtMaGiaoVien

                LoadChuongTrinhData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi reset các trường nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemChuongTrinh_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường hợp bắt buộc không được để trống
                if (string.IsNullOrWhiteSpace(txtMaChuongTrinh.Text) || string.IsNullOrWhiteSpace(txtTenChuongTrinh.Text) ||
                    string.IsNullOrWhiteSpace(txtMoTa.Text) || txtDiaDiem.Text == null || txtMaGiaoVien.Text == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy dữ liệu từ form và gán vào đối tượng Chương Trình
                var chuongTrinh = new ChuongTrinhNangKhieu
                {
                    MaCTNK = int.Parse(txtMaChuongTrinh.Text.Trim()), // Chuyển đổi thành int
                    TenCT = txtTenChuongTrinh.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    ThoiGianBatDau = dtpBatDau.Value,
                    ThoiGianKetThuc = dtpKetThuc.Value,
                    DiaDiem = txtDiaDiem.Text.Trim(),
                    MaGiaoVien = int.Parse(txtMaGiaoVien.Text.Trim()) // Chuyển đổi thành int
                };

                // Gọi BLL để thêm chương trình
                if (ChuongTrinhNangKhieuBLL.AddChuongTrinhNangKhieu(chuongTrinh))
                {
                    MessageBox.Show("Thêm chương trình thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChuongTrinhData(); // Tải lại dữ liệu
                }
                else
                {
                    MessageBox.Show("Thêm chương trình thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm chương trình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoaChuongTrinh_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có chương trình nào được chọn không
                if (dgvChuongTrinhNangKhieu.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một chương trình để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy mã chương trình được chọn
                int maCTNK = Convert.ToInt32(dgvChuongTrinhNangKhieu.SelectedRows[0].Cells["MaCTNK"].Value);

                // Hỏi người dùng xác nhận xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa chương trình này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    // Gọi BLL để xóa chương trình
                    if (ChuongTrinhNangKhieuBLL.DeleteChuongTrinhNangKhieu(maCTNK))
                    {
                        MessageBox.Show("Xóa chương trình thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadChuongTrinhData(); // Tải lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Xóa chương trình thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa chương trình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaChuongTrinh_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có chương trình nào được chọn không
                if (dgvChuongTrinhNangKhieu.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một chương trình để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra các trường hợp bắt buộc không được để trống
                if (string.IsNullOrWhiteSpace(txtMaChuongTrinh.Text) || string.IsNullOrWhiteSpace(txtTenChuongTrinh.Text) ||
                    string.IsNullOrWhiteSpace(txtMoTa.Text) || txtDiaDiem.Text == null || txtMaGiaoVien.Text == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy mã chương trình được chọn
                int maCTNK = Convert.ToInt32(dgvChuongTrinhNangKhieu.SelectedRows[0].Cells["MaCTNK"].Value);

                // Tạo đối tượng Chương Trình từ các dữ liệu nhập vào
                var chuongTrinh = new ChuongTrinhNangKhieu
                {
                    MaCTNK = maCTNK, // Sử dụng mã chương trình hiện tại
                    TenCT = txtTenChuongTrinh.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    ThoiGianBatDau = dtpBatDau.Value,
                    ThoiGianKetThuc = dtpKetThuc.Value,
                    DiaDiem = txtDiaDiem.Text.Trim(),
                    MaGiaoVien = int.Parse(txtMaGiaoVien.Text.Trim()) // Chuyển đổi thành int
                };

                // Gọi BLL để sửa chương trình
                if (ChuongTrinhNangKhieuBLL.UpdateChuongTrinhNangKhieu(chuongTrinh))
                {
                    MessageBox.Show("Cập nhật chương trình thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChuongTrinhData(); // Tải lại dữ liệu
                }
                else
                {
                    MessageBox.Show("Cập nhật chương trình thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa chương trình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnExportFileExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một workbook mới
                using (var workbook = new XLWorkbook())
                {
                    // Tạo một worksheet trong workbook
                    var worksheet = workbook.AddWorksheet("ChuongTrinhNangKhieu");

                    // Tạo tiêu đề cột từ DataGridView
                    for (int col = 0; col < dgvChuongTrinhNangKhieu.Columns.Count; col++)
                    {
                        if (dgvChuongTrinhNangKhieu.Columns[col].Visible) // Chỉ thêm các cột hiển thị
                        {
                            worksheet.Cell(1, col + 1).Value = dgvChuongTrinhNangKhieu.Columns[col].HeaderText; // Tiêu đề cột
                        }

                    }

                    // Xuất dữ liệu từng dòng vào worksheet
                    for (int row = 0; row < dgvChuongTrinhNangKhieu.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvChuongTrinhNangKhieu.Columns.Count; col++)
                        {
                            // Lấy giá trị từ từng ô trong DataGridView và gán vào Excel
                            worksheet.Cell(row + 2, col + 1).Value = dgvChuongTrinhNangKhieu.Rows[row].Cells[col].Value?.ToString();
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

        private void btnLocTimKiemChuongTrinh_Click(object sender, EventArgs e)
        {
            FrmLocChuongTrinhNangKhieu frmLoc = new FrmLocChuongTrinhNangKhieu();


            // Thiết lập vị trí cho form con
            frmLoc.StartPosition = FormStartPosition.Manual; // Chỉ định vị trí thủ công

            if (frmLoc.ShowDialog() == DialogResult.OK) // Chỉ tiếp tục nếu người dùng nhấn nút Lọc
            {
                // Lấy tiêu chí lọc từ FrmLocHoaDon
                DateTime? thoiGianBatDau = frmLoc.ThoiGianBatDau;
                DateTime? thoiGianKetThuc = frmLoc.ThoiGianKetThuc;
                string DiaDiem = frmLoc.DiaDiem;

                // Gọi phương thức lọc và cập nhật dgvHoaDon
                LocChuongTrinhNangKhieu(thoiGianBatDau, thoiGianKetThuc, DiaDiem);
            }
        }
    }
}
