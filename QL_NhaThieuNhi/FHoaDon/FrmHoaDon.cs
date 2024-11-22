using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using BLL; // Thêm namespace của BLL
using DTO; // Thêm namespace của DTO

namespace QL_NhaThieuNhi.FHoaDon
{
    public partial class FrmHoaDon : Form
    {
        public FrmHoaDon()
        {
            InitializeComponent();
            LoadHoaDonData();
            dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged; // Thêm sự kiện SelectionChanged
            this.Load += new System.EventHandler(this.FrmHoaDon_Load);
            //this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

        }

        // Phương thức tải dữ liệu hóa đơn
        private void LoadHoaDonData()
        {
            try
            {
                var hoaDons = HoaDonBLL.GetHoaDons(); // Lấy danh sách hóa đơn từ BLL
                dgvHoaDon.DataSource = hoaDons;

                // Hiển thị các cột cần thiết
                dgvHoaDon.Columns["HocVien"].Visible = false;
                dgvHoaDon.Columns["LopHoc"].Visible = false;

                UpdateTongHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            // Thêm các giá trị vào ComboBox nếu chưa có
            cbHinhThucThanhToan.Items.Add(" ");
            cbHinhThucThanhToan.Items.Add("Tiền mặt");
            cbHinhThucThanhToan.Items.Add("Chuyển khoản");
            cbHinhThucThanhToan.Items.Add("Thẻ tín dụng");

            cbTrangThaiThanhToan.Items.Add(" ");
            cbTrangThaiThanhToan.Items.Add("Đã thanh toán");
            cbTrangThaiThanhToan.Items.Add("Chưa thanh toán");

            // Đặt giá trị mặc định cho ComboBox
            cbHinhThucThanhToan.SelectedIndex = 0;
            cbTrangThaiThanhToan.SelectedIndex = 0;
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                var selectedRow = dgvHoaDon.SelectedRows[0];

                txtMaHoaDon.Text = selectedRow.Cells["MaHoaDon"].Value?.ToString();
                decimal soTien = Convert.ToDecimal(selectedRow.Cells["SoTien"].Value);  // Changed "SoTien" to "txtSoTien"
                txtSoTien.Text = soTien.ToString("N0"); // Update the text box with the value

                string hinhThucThanhToan = selectedRow.Cells["HinhThucThanhToan"].Value?.ToString();
                string trangThaiThanhToan = selectedRow.Cells["TrangThaiThanhToan"].Value?.ToString();

                if (hinhThucThanhToan != null && cbHinhThucThanhToan.Items.Contains(hinhThucThanhToan))
                {
                    cbHinhThucThanhToan.SelectedItem = hinhThucThanhToan;
                }

                if (trangThaiThanhToan != null && cbTrangThaiThanhToan.Items.Contains(trangThaiThanhToan))
                {
                    cbTrangThaiThanhToan.SelectedItem = trangThaiThanhToan;
                }

                dtpNgayLap.Value = Convert.ToDateTime(selectedRow.Cells["NgayLap"].Value);
                dtpBatDau.Value = Convert.ToDateTime(selectedRow.Cells["ThoiGianBatDauDongTien"].Value);
                dtpKetThuc.Value = Convert.ToDateTime(selectedRow.Cells["ThoiGianKetThucDongTien"].Value);

                txtMaHocVien.Text = selectedRow.Cells["MaHocVien"].Value?.ToString();
                txtMaLop.Text = selectedRow.Cells["MaLop"].Value?.ToString();
            }
        }



        private void TimKiemHoaDon(string tuKhoa)
        {
            try
            {
                var danhSachHoaDon = HoaDonBLL.GetHoaDons(); // Lấy tất cả hóa đơn từ BLL

                // Nếu từ khóa trống hoặc null, hiển thị toàn bộ danh sách
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    dgvHoaDon.DataSource = danhSachHoaDon;
                    return;
                }

                // Chuyển từ khóa về chữ thường để so sánh không phân biệt hoa thường
                tuKhoa = tuKhoa.ToLower();

                // Lọc danh sách theo từ khóa (tuKhoa)
                var ketQuaTimKiem = danhSachHoaDon.Where(hd =>
                (!string.IsNullOrEmpty(hd.MaHoaDon.ToString()) && hd.MaHoaDon.ToString().Contains(tuKhoa)) ||
                (!string.IsNullOrEmpty(hd.MaLop.ToString()) && hd.MaLop.ToString().Contains(tuKhoa)) ||
                (!string.IsNullOrEmpty(hd.MaHocVien.ToString()) && hd.MaHocVien.ToString().Contains(tuKhoa))
                ).ToList();


                dgvHoaDon.DataSource = ketQuaTimKiem; // Gán kết quả tìm kiếm vào DataGridView
                UpdateTongHoaDon();
                // Nếu không có kết quả nào
                if (ketQuaTimKiem.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm hóa đơn: " + ex.Message);
            }
        }


        private void LocHoaDon(DateTime? thoiGianBatDau, DateTime? thoiGianKetThuc, string trangThaiThanhToan)
        {
            try
            {
                var danhSachHoaDon = HoaDonBLL.GetHoaDons(); // Lấy danh sách hóa đơn từ BLL

                // Lọc theo thời gian nếu có
                if (thoiGianBatDau.HasValue && thoiGianKetThuc.HasValue)
                {
                    danhSachHoaDon = danhSachHoaDon.Where(hd =>
                        hd.ThoiGianBatDauDongTien >= thoiGianBatDau.Value.Date &&
                        hd.ThoiGianKetThucDongTien <= thoiGianKetThuc.Value.Date).ToList();
                }

                // Lọc theo trạng thái thanh toán nếu có
                if (!string.IsNullOrWhiteSpace(trangThaiThanhToan))
                {
                    danhSachHoaDon = danhSachHoaDon.Where(hd => hd.TrangThaiThanhToan == trangThaiThanhToan).ToList();
                }

                // Hiển thị kết quả lọc trên DataGridView
                dgvHoaDon.DataSource = danhSachHoaDon;
                UpdateTongHoaDon();

                if (danhSachHoaDon.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào phù hợp với tiêu chí lọc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTongHoaDon()
        {
            try
            {
                // Lấy danh sách hóa đơn từ nguồn dữ liệu
                //var danhSachHoaDon = HoaDonBLL.GetHoaDons();
                // Đếm số lượng hóa đơn
                int soHoaDon = dgvHoaDon.RowCount;
                // Hiển thị số lượng hóa đơn trong txtTongHoaDon
                txtTongHoaDon.Text = soHoaDon.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng số hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtTongHoaDon_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void btnLocTimKiemHoaDon_Click_1(object sender, EventArgs e)
        {
            FrmLocHoaDon frmLoc = new FrmLocHoaDon();


            // Thiết lập vị trí cho form con
            frmLoc.StartPosition = FormStartPosition.Manual; // Chỉ định vị trí thủ công

            if (frmLoc.ShowDialog() == DialogResult.OK) // Chỉ tiếp tục nếu người dùng nhấn nút Lọc
            {
                // Lấy tiêu chí lọc từ FrmLocHoaDon
                DateTime? thoiGianBatDau = frmLoc.ThoiGianBatDau;
                DateTime? thoiGianKetThuc = frmLoc.ThoiGianKetThuc;
                string trangThaiThanhToan = frmLoc.TrangThaiThanhToan;

                // Gọi phương thức lọc và cập nhật dgvHoaDon
                LocHoaDon(thoiGianBatDau, thoiGianKetThuc, trangThaiThanhToan);
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            // Làm trống các trường nhập liệu
            txtMaHoaDon.Text = string.Empty;
            txtSoTien.Text = string.Empty;
            txtMaHocVien.Text = string.Empty;
            txtMaLop.Text = string.Empty;

            // Đặt ComboBox về giá trị mặc định
            if (cbHinhThucThanhToan.Items.Count > 0)
                cbHinhThucThanhToan.SelectedIndex = 0;

            if (cbTrangThaiThanhToan.Items.Count > 0)
                cbTrangThaiThanhToan.SelectedIndex = 0;

            // Đặt ngày giờ về ngày hiện tại
            dtpNgayLap.Value = DateTime.Now;
            dtpBatDau.Value = DateTime.Now;
            dtpKetThuc.Value = DateTime.Now;
            LoadHoaDonData();
            // Nếu có các thành phần khác, bạn cũng làm trống hoặc reset ở đây
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường hợp bắt buộc không được để trống
                if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text) || string.IsNullOrWhiteSpace(txtSoTien.Text) ||
                    string.IsNullOrWhiteSpace(txtMaHocVien.Text) || string.IsNullOrWhiteSpace(txtMaLop.Text) ||
                    cbHinhThucThanhToan.SelectedItem == null || cbTrangThaiThanhToan.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin từ các trường nhập liệu
                HoaDon hoaDon = new HoaDon
                {
                    MaHoaDon = int.Parse(txtMaHoaDon.Text), // Mã hóa đơn
                    SoTien = Convert.ToDecimal(txtSoTien.Text), // Sử dụng giá trị nhập từ TextBox cho số tiền
                    NgayLap = dtpNgayLap.Value,
                    HinhThucThanhToan = cbHinhThucThanhToan.SelectedItem.ToString(), // Hình thức thanh toán
                    TrangThaiThanhToan = cbTrangThaiThanhToan.SelectedItem.ToString(), // Trạng thái thanh toán
                    ThoiGianBatDauDongTien = dtpBatDau.Value, // Ngày bắt đầu
                    ThoiGianKetThucDongTien = dtpKetThuc.Value, // Ngày kết thúc
                    MaHocVien = int.Parse(txtMaHocVien.Text), // Mã học viên
                    MaLop = int.Parse(txtMaLop.Text) // Mã lớp học
                };

                // Gọi BLL để thêm hóa đơn
                if (HoaDonBLL.AddHoaDon(hoaDon))
                {
                    MessageBox.Show("Thêm hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateTongHoaDon();
                    LoadHoaDonData(); // Tải lại danh sách hóa đơn
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho các trường số (Mã hóa đơn, Số tiền, Mã học viên, Mã lớp).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoaHoaDon_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có dòng nào được chọn
                if (dgvHoaDon.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvHoaDon.SelectedRows[0];
                    int maHoaDon = int.Parse(selectedRow.Cells["MaHoaDon"].Value.ToString());

                    // Gọi BLL để xóa hóa đơn
                    if (HoaDonBLL.DeleteHoaDon(maHoaDon))
                    {
                        MessageBox.Show("Xóa hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateTongHoaDon();
                        LoadHoaDonData(); // Tải lại danh sách hóa đơn
                    }
                    else
                    {
                        MessageBox.Show("Xóa hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các trường nhập liệu
                HoaDon hoaDon = new HoaDon
                {
                    MaHoaDon = int.Parse(txtMaHoaDon.Text), // Mã hóa đơn
                    SoTien = Convert.ToDecimal(txtSoTien.Text), // Use txtSoTien.Text instead of nbSotien.Value
                    NgayLap = dtpNgayLap.Value,
                    HinhThucThanhToan = cbHinhThucThanhToan.SelectedItem.ToString(), // Hình thức thanh toán
                    TrangThaiThanhToan = cbTrangThaiThanhToan.SelectedItem.ToString(), // Trạng thái thanh toán
                    ThoiGianBatDauDongTien = dtpBatDau.Value, // Ngày bắt đầu
                    ThoiGianKetThucDongTien = dtpKetThuc.Value, // Ngày kết thúc
                    MaHocVien = int.Parse(txtMaHocVien.Text), // Mã học viên
                    MaLop = int.Parse(txtMaLop.Text) // Mã lớp học
                };

                // Gọi BLL để cập nhật hóa đơn
                if (HoaDonBLL.UpdateHoaDon(hoaDon))
                {
                    MessageBox.Show("Cập nhật hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoaDonData(); // Tải lại danh sách hóa đơn
                }
                else
                {
                    MessageBox.Show("Cập nhật hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var worksheet = workbook.AddWorksheet("HoaDon");

                    // Tạo tiêu đề cột từ DataGridView
                    for (int col = 0; col < dgvHoaDon.Columns.Count; col++)
                    {
                        if (dgvHoaDon.Columns[col].Visible) // Chỉ thêm các cột hiển thị
                        {
                            worksheet.Cell(1, col + 1).Value = dgvHoaDon.Columns[col].HeaderText; // Tiêu đề cột
                        }

                    }

                    // Xuất dữ liệu từng dòng vào worksheet
                    for (int row = 0; row < dgvHoaDon.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvHoaDon.Columns.Count; col++)
                        {
                            // Lấy giá trị từ từng ô trong DataGridView và gán vào Excel
                            worksheet.Cell(row + 2, col + 1).Value = dgvHoaDon.Rows[row].Cells[col].Value?.ToString();
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
                TimKiemHoaDon(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message);
            }
        }
    }
}
