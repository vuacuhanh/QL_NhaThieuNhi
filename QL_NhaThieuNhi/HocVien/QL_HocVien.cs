using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ClosedXML.Excel;

namespace QL_NhaThieuNhi.HocVien
{
    public partial class QL_HocVien : Form
    {
        public QL_HocVien()
        {

            InitializeComponent();
            LoadHocVien();
            LoadMaLop();
            // Đăng ký sự kiện CellClick cho DataGridView HocVien
            this.dgvHocVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHocVien_CellClick);

            // Đăng ký sự kiện SelectedIndexChanged cho ComboBox Lọc
            this.cbLoc.SelectedIndexChanged += new System.EventHandler(this.cbLoc_SelectedIndexChanged);

            // Đăng ký sự kiện TextChanged cho TextBox Tìm Kiếm
            this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);
        }
        private void LoadHocVien()
        {
            try
            {
                dgvHocVien.DataSource = HocVienBLL.LayTatCaHocVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách học viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHocVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (e.RowIndex >= 0)
                {
                    var row = dgvHocVien.Rows[e.RowIndex]; // Lấy dòng được chọn

                    // Cập nhật các trường nhập với dữ liệu từ dòng được chọn
                    txt_MaHV.Text = row.Cells["MaHocVien"].Value.ToString(); // Cập nhật mã học viên
                    txt_TenHV.Text = row.Cells["TenHocVien"].Value.ToString(); // Cập nhật tên học viên
                    txt_HinhAnh.Text = row.Cells["HinhAnh"].Value.ToString();
                    txt_DiaChi.Text = row.Cells["DiaChi"].Value.ToString(); // Cập nhật địa chỉ
                    txt_SDT.Text = row.Cells["SoDienThoai"].Value.ToString(); // Cập nhật số điện thoại
                    dtp_NgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value); // Cập nhật ngày sinh
                                                                                          // Cập nhật trạng thái (nếu cần)
                    txt_TrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                    // Cập nhật giới tính
                    if (row.Cells["GioiTinh"].Value.ToString() == "Nam")
                    {
                        rdo_Nam.Checked = true;
                    }
                    else if (row.Cells["GioiTinh"].Value.ToString() == "Nữ")
                    {
                        rdo_Nu.Checked = true;
                    }

                    // Cập nhật mã phụ huynh (nếu cần)
                    txt_MaPhuHuynh.Text = row.Cells["MaPhuHuynh"].Value.ToString();

                    // Cập nhật mã lớp (nếu cần)
                    txt_MaLop.Text = row.Cells["MaLop"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi chọn dòng: " + ex.Message);
            }
        }

        private void cbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                var maLop = cbLoc.SelectedItem.ToString(); // Lấy giá trị lớp từ ComboBox

                if (maLop == "Tất Cả")
                {
                    // Nếu chọn "Tất Cả", load lại toàn bộ danh sách học viên
                    LoadHocVien();
                }
                else
                {
                    // Lọc học viên theo mã lớp
                    var danhSachHocVien = HocVienBLL.LocHocVienTheoLop(maLop);
                    dgvHocVien.DataSource = danhSachHocVien; // Gán dữ liệu cho DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lọc học viên theo mã lớp: " + ex.Message);
            }
        }
        private List<string> maLops = new List<string>
{
    "Tất Cả", "1", "2", "3", "4", "5"
};

        private void LoadMaLop()
        {
            try
            {
                // Giả sử bạn có danh sách mã lớp trong biến 'maLops'
                cbLoc.DataSource = maLops; // Gán danh sách lớp học vào ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải mã lớp: " + ex.Message);
            }
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string keyword = txt_TimKiem.Text.ToLower(); // Chuyển từ khóa tìm kiếm thành chữ thường

                // Lấy tất cả danh sách học viên
                var danhSachHocVien = HocVienBLL.LayTatCaHocVien();

                // Lọc danh sách học viên theo từ khóa tìm kiếm, không phân biệt hoa thường
                var filteredHocVien = danhSachHocVien.Where(hocVien =>
                    hocVien.TenHocVien.ToLower().Contains(keyword) ||    // So sánh tên học viên
                    hocVien.DiaChi.ToLower().Contains(keyword) ||        // So sánh địa chỉ
                    hocVien.SoDienThoai.ToLower().Contains(keyword)      // So sánh số điện thoại
                ).ToList();

                // Gán lại danh sách đã lọc cho DataGridView
                dgvHocVien.DataSource = filteredHocVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            try
            {
                // Lấy dữ liệu từ các điều khiển
                var MaHocVien = Convert.ToInt32(txt_MaHV.Text); // Mã học viên
                var TenHocVien = txt_TenHV.Text; // Lấy tên học viên từ TextBox
                var HinhAnh = txt_HinhAnh.Text;
                var NgaySinh = dtp_NgaySinh.Value; // Lấy ngày sinh từ DateTimePicker
                var GioiTinh = rdo_Nam.Checked ? "Nam" : "Nữ"; // Xác định giới tính dựa trên RadioButton
                var DiaChi = txt_DiaChi.Text; // Lấy địa chỉ từ TextBox
                var SoDienThoai = txt_SDT.Text; // Lấy số điện thoại từ TextBox
                var TrangThai = txt_TrangThai.Text; // Lấy trạng thái học viên từ ComboBox
                var MaPhuHuynh = Convert.ToInt32(txt_MaPhuHuynh.Text); // Mã phụ huynh liên quan đến học viên
                var MaLop = Convert.ToInt32(txt_MaLop.Text); // Mã lớp học viên tham gia

                // Kiểm tra dữ liệu nhập
                if (string.IsNullOrEmpty(TenHocVien) || string.IsNullOrEmpty(DiaChi) ||
                    string.IsNullOrEmpty(SoDienThoai) || string.IsNullOrEmpty(TrangThai) ||
                    MaPhuHuynh == 0 || MaLop == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin học viên.");
                    return;
                }

                // Kiểm tra Hình ảnh nếu có
                if (!string.IsNullOrEmpty(HinhAnh) && !File.Exists(HinhAnh))
                {
                    MessageBox.Show("Không tìm thấy hình ảnh tại đường dẫn: " + HinhAnh);
                    return;
                }

                // Tạo đối tượng học viên mới
                var hocVienMoi = new DTO.HocVien
                {
                    MaHocVien = MaHocVien,
                    TenHocVien = TenHocVien,
                    HinhAnh = HinhAnh,
                    NgaySinh = NgaySinh,
                    GioiTinh = GioiTinh,
                    DiaChi = DiaChi,
                    SoDienThoai = SoDienThoai,
                    TrangThai = TrangThai,
                    MaPhuHuynh = MaPhuHuynh,
                    MaLop = MaLop
                };

                // Thêm học viên thông qua BLL
                if (HocVienBLL.ThemHocVien(hocVienMoi))
                {
                    MessageBox.Show("Thêm học viên thành công!");
                    LoadHocVien(); // Tải lại danh sách học viên
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm học viên.");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm học viên: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {

            if (dgvHocVien.SelectedRows.Count > 0)
            {
                // Lấy mã học viên từ cột trong DataGridView
                int maHocVien = Convert.ToInt32(dgvHocVien.SelectedRows[0].Cells["MaHocVien"].Value);

                try
                {
                    if (MessageBox.Show($"Bạn có chắc chắn muốn xóa học viên có mã {maHocVien}?",
                                        "Xác nhận",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (HocVienBLL.XoaHocVien(maHocVien))
                        {
                            MessageBox.Show("Xóa học viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadHocVien(); // Cập nhật lại danh sách sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy học viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn học viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvHocVien.SelectedRows.Count > 0) // Kiểm tra có dòng học viên nào được chọn không
                {
                    // Lấy mã học viên từ dòng được chọn
                    var MaHocVien = Convert.ToInt32(txt_MaHV.Text); // Mã học viên
                    var TenHocVien = txt_TenHV.Text; // Lấy tên học viên từ TextBox
                    var HinhAnh = txt_HinhAnh.Text;
                    var NgaySinh = dtp_NgaySinh.Value; // Lấy ngày sinh từ DateTimePicker
                    var GioiTinh = rdo_Nam.Checked ? "Nam" : "Nữ"; // Xác định giới tính dựa trên RadioButton
                    var DiaChi = txt_DiaChi.Text; // Lấy địa chỉ từ TextBox
                    var SoDienThoai = txt_SDT.Text; // Lấy số điện thoại từ TextBox
                    var TrangThai = txt_TrangThai.Text; // Lấy trạng thái học viên từ ComboBox
                    var MaPhuHuynh = Convert.ToInt32(txt_MaPhuHuynh.Text); // Mã phụ huynh liên quan đến học viên
                    var MaLop = Convert.ToInt32(txt_MaLop.Text); // Mã lớp học viên tham gia


                    if (string.IsNullOrEmpty(TenHocVien) || string.IsNullOrEmpty(SoDienThoai))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin học viên.");
                        return;
                    }

                    // Tạo đối tượng học viên mới để cập nhật
                    var hocVienMoi = new DTO.HocVien
                    {

                        MaHocVien = MaHocVien,
                        TenHocVien = TenHocVien,
                        HinhAnh = HinhAnh,
                        NgaySinh = NgaySinh,
                        GioiTinh = GioiTinh,
                        DiaChi = DiaChi,
                        SoDienThoai = SoDienThoai,
                        TrangThai = TrangThai,
                        MaPhuHuynh = MaPhuHuynh,
                        MaLop = MaLop
                    };

                    // Gọi BLL để cập nhật thông tin học viên
                    if (HocVienBLL.SuaHocVien(hocVienMoi))
                    {
                        MessageBox.Show("Cập nhật thông tin học viên thành công!");
                        LoadHocVien(); // Tải lại danh sách học viên
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi cập nhật thông tin học viên.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn học viên cần sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi sửa thông tin học viên: " + ex.Message);
            }
        }

        private void btnExportFileExcel_Click(object sender, EventArgs e)
        {

            try
            {
                // Kiểm tra nếu DataGridView có dữ liệu
                if (dgvHocVien.Rows.Count > 0)
                {
                    // Tạo workbook mới
                    using (var workbook = new XLWorkbook())
                    {
                        // Tạo một worksheet
                        var worksheet = workbook.Worksheets.Add("DanhSachHocVien");

                        int visibleColumnIndex = 1; // Dùng để theo dõi các cột hiển thị

                        // Thêm tiêu đề cột vào worksheet (chỉ cột hiển thị)
                        for (int i = 0; i < dgvHocVien.Columns.Count; i++)
                        {
                            if (dgvHocVien.Columns[i].Visible) // Chỉ thêm các cột hiển thị
                            {
                                worksheet.Cell(1, visibleColumnIndex).Value = dgvHocVien.Columns[i].HeaderText;
                                visibleColumnIndex++;
                            }
                        }

                        // Thêm dữ liệu từ DataGridView vào worksheet (chỉ cột hiển thị)
                        for (int i = 0; i < dgvHocVien.Rows.Count; i++)
                        {
                            visibleColumnIndex = 1; // Reset index cho mỗi hàng
                            for (int j = 0; j < dgvHocVien.Columns.Count; j++)
                            {
                                if (dgvHocVien.Columns[j].Visible) // Chỉ thêm dữ liệu cho cột hiển thị
                                {
                                    worksheet.Cell(i + 2, visibleColumnIndex).Value = dgvHocVien.Rows[i].Cells[j].Value?.ToString() ?? "";
                                    visibleColumnIndex++;
                                }
                            }
                        }

                        // Mở hộp thoại lưu file để chọn nơi lưu file
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save an Excel File";
                        saveFileDialog.FileName = "DanhSachHocVien.xlsx";

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

        private void ptb_HinhAnh_Click(object sender, EventArgs e)
        {
            ptb_HinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void HienHinhAnh()
        {
            try
            {
                // Lấy đường dẫn thư mục gốc của dự án
                string thuMucGoc = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                string thuMucHinhAnh = Path.Combine(thuMucGoc, "QL_NhaThieuNhi\\img\\hv");
                string tenFileHinhAnh = txt_HinhAnh.Text.Trim(); // Lấy tên file từ TextBox

                if (string.IsNullOrEmpty(tenFileHinhAnh))
                {
                    MessageBox.Show("Vui lòng nhập tên file hình ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kết hợp đường dẫn đầy đủ
                string duongDanHinhAnh = Path.Combine(thuMucHinhAnh, tenFileHinhAnh);

                if (!File.Exists(duongDanHinhAnh))
                {
                    MessageBox.Show("Không tìm thấy tệp hình ảnh: " + duongDanHinhAnh, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị hình ảnh trong PictureBox
                ptb_HinhAnh.Image = Image.FromFile(duongDanHinhAnh);
                ptb_HinhAnh.SizeMode = PictureBoxSizeMode.StretchImage; // Co dãn hình ảnh cho vừa PictureBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi hiển thị hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_HinhAnh_Click(object sender, EventArgs e)
        {
            HienHinhAnh();
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txt_HinhAnh.Text = ofd.FileName;
                    ptb_HinhAnh.Image = new Bitmap(ofd.FileName);
                }
            }
        }
        private void TimKiemHocVien(string tuKhoa)
        {
            try
            {
                // Lấy tất cả học viên từ BLL
                var danhSachHocVien = HocVienBLL.LayTatCaHocVien(); // Giả sử bạn có BLL để lấy danh sách học viên

                // Nếu từ khóa trống hoặc null, hiển thị toàn bộ danh sách
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    dgvHocVien.DataSource = danhSachHocVien;
                    return;
                }

                // Chuyển từ khóa về chữ thường để so sánh không phân biệt hoa thường
                tuKhoa = tuKhoa.ToLower();

                // Lọc danh sách theo từ khóa (tuKhoa)
                var ketQuaTimKiem = danhSachHocVien.Where(hv =>
                    hv.MaHocVien.ToString().Contains(tuKhoa) || // Tìm theo Mã học viên
                    hv.TenHocVien.ToLower().Contains(tuKhoa) || // Tìm theo Tên học viên (chuyển về chữ thường)
                    hv.GioiTinh.ToLower().Contains(tuKhoa) || // Tìm theo Giới tính (chuyển về chữ thường)
                    hv.SoDienThoai.Contains(tuKhoa) // Tìm theo Số điện thoại

                ).ToList();

                dgvHocVien.DataSource = ketQuaTimKiem; // Gán kết quả tìm kiếm vào DataGridView

                // Nếu không có kết quả nào
                if (ketQuaTimKiem.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm học viên: " + ex.Message);
            }
        }

        private void txt_HinhAnh_TextChanged(object sender, EventArgs e)
        {
            HienHinhAnh();
        }
    }
}
