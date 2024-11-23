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
using DTO;
using DocumentFormat.OpenXml.Office2010.Drawing;
using System.IO;
using ClosedXML.Excel;


namespace QL_NhaThieuNhi.PhuHuynh
{
    public partial class QL_PhuHuynh : Form
    {
        public QL_PhuHuynh()
        {
            InitializeComponent();
            LoadPhuHuynh();
            LoadNgheNghiep();
            // Đăng ký sự kiện CellClick trong InitializeComponent
            this.dgvPhuHuynh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhuHuynh_CellClick);
            this.cbLoc.SelectedIndexChanged += new System.EventHandler(this.cbLoc_SelectedIndexChanged);
            this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);

        }

        private void LoadPhuHuynh()
        {
            try
            {
                dgvPhuHuynh.DataSource = PhuHuynhBLL.LayTatCaPhuHuynh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phụ huynh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string keyword = txt_TimKiem.Text.ToLower(); // Chuyển từ khóa tìm kiếm thành chữ thường

                // Lấy tất cả danh sách phụ huynh
                var danhSachPhuHuynh = PhuHuynhBLL.LayTatCaPhuHuynh();

                // Lọc danh sách phụ huynh theo từ khóa tìm kiếm, không phân biệt hoa thường
                var filteredPhuHuynh = danhSachPhuHuynh.Where(phuHuynh =>
                    phuHuynh.TenPhuHuynh.ToLower().Contains(keyword) ||      // So sánh tên phụ huynh
                    phuHuynh.NgheNghiep.ToLower().Contains(keyword) || // So sánh nghề nghiệp
                    phuHuynh.DiaChi.ToLower().Contains(keyword)        // So sánh địa chỉ
                ).ToList();

                // Gán lại danh sách đã lọc cho DataGridView
                dgvPhuHuynh.DataSource = filteredPhuHuynh;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message);
            }
        }

        private void dgvPhuHuynh_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (e.RowIndex >= 0)
                {
                    var row = dgvPhuHuynh.Rows[e.RowIndex]; // Lấy dòng được chọn

                    // Cập nhật các trường nhập với dữ liệu từ dòng được chọn
                    txt_MaPH.Text = row.Cells["MaPhuHuynh"].Value.ToString(); // Cập nhật mã phụ huynh
                    txt_TenPH.Text = row.Cells["TenPhuHuynh"].Value.ToString(); // Cập nhật tên phụ huynh
                    txt_Nghenghiep.Text = row.Cells["NgheNghiep"].Value.ToString(); // Cập nhật nghề nghiệp
                    txt_DiaChi.Text = row.Cells["DiaChi"].Value.ToString(); // Cập nhật địa chỉ
                    txt_Email.Text = row.Cells["Email"].Value.ToString(); // Cập nhật email
                    txt_SDT.Text = row.Cells["SoDienThoai"].Value.ToString(); // Cập nhật số điện thoại
                    dtp_NgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value); // Cập nhật ngày sinh

                    // Cập nhật giới tính
                    if (row.Cells["GioiTinh"].Value.ToString() == "Nam")
                    {
                        rdo_Nam.Checked = true;
                    }
                    else if (row.Cells["GioiTinh"].Value.ToString() == "Nữ")
                    {
                        rdo_Nu.Checked = true;
                    }


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
                var ngheNghiep = cbLoc.SelectedItem.ToString(); // Lấy giá trị nghề nghiệp từ ComboBox

                if (ngheNghiep == "Tất Cả")
                {
                    // Nếu chọn "Tất Cả", load lại toàn bộ danh sách phụ huynh
                    LoadPhuHuynh();
                }
                else
                {
                    // Lọc phụ huynh theo nghề nghiệp
                    var danhSachPhuHuynh = PhuHuynhBLL.LocPhuHuynhTheoNgheNghiep(ngheNghiep);
                    dgvPhuHuynh.DataSource = danhSachPhuHuynh; // Gán dữ liệu cho DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lọc phụ huynh theo nghề nghiệp: " + ex.Message);
            }
        }
        private List<string> ngheNghieps = new List<string>
{
    "Tất Cả", "Giáo Viên", "Kỹ Sư", "Bác Sĩ", "Nội Trợ", "Kinh Doanh"
};

        private void LoadNgheNghiep()
        {
            try
            {
                // Gán danh sách nghề nghiệp vào ComboBox
                cbLoc.DataSource = ngheNghieps;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải nghề nghiệp: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var MaPhuHuynh = Convert.ToInt32(txt_MaPH.Text);
                var TenPhuHuynh = txt_TenPH.Text; // Lấy tên phụ huynh từ TextBox
                var NgaySinh = dtp_NgaySinh.Value; // Lấy ngày sinh từ DateTimePicker
                var GioiTinh = rdo_Nam.Checked ? "Nam" : "Nữ"; // Xác định giới tính dựa trên RadioButton
                var NgheNghiep = txt_Nghenghiep.Text; // Lấy nghề nghiệp từ TextBox
                var DiaChi = txt_DiaChi.Text; // Lấy địa chỉ từ TextBox
                var Email = txt_Email.Text; // Lấy email từ TextBox
                var SoDienThoai = txt_SDT.Text; // Lấy số điện thoại từ TextBox

                // Kiểm tra dữ liệu nhập
                if (string.IsNullOrEmpty(TenPhuHuynh) || string.IsNullOrEmpty(NgheNghiep) ||
                    string.IsNullOrEmpty(DiaChi) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(SoDienThoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin phụ huynh.");
                    return;
                }

                // Tạo đối tượng phụ huynh mới
                var phuHuynhMoi = new DTO.PhuHuynh
                {
                    MaPhuHuynh = MaPhuHuynh,
                    TenPhuHuynh = TenPhuHuynh,
                    NgaySinh = NgaySinh,
                    GioiTinh = GioiTinh,
                    NgheNghiep = NgheNghiep,
                    DiaChi = DiaChi,
                    Email = Email,
                    SoDienThoai = SoDienThoai
                };

                // Thêm phụ huynh thông qua BLL
                if (PhuHuynhBLL.ThemPhuHuynh(phuHuynhMoi))
                {
                    MessageBox.Show("Thêm phụ huynh thành công!");
                    LoadPhuHuynh(); // Tải lại danh sách phụ huynh
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm phụ huynh.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm phụ huynh: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhuHuynh.SelectedRows.Count > 0)
                {
                    // Lấy mã phụ huynh từ dòng được chọn
                    var maPhuHuynh = Convert.ToInt32(dgvPhuHuynh.SelectedRows[0].Cells["MaPhuHuynh"].Value);

                    // Gọi hàm xóa phụ huynh từ BLL
                    if (PhuHuynhBLL.XoaPhuHuynh(maPhuHuynh))
                    {
                        MessageBox.Show("Xóa phụ huynh thành công!");
                        LoadPhuHuynh(); // Tải lại danh sách phụ huynh
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa phụ huynh.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phụ huynh cần xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa phụ huynh: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhuHuynh.SelectedRows.Count > 0)
                {
                    // Lấy mã phụ huynh từ dòng được chọn
                    var maPhuHuynh = Convert.ToInt32(dgvPhuHuynh.SelectedRows[0].Cells["MaPhuHuynh"].Value);
                    var tenPhuHuynh = txt_TenPH.Text; // Lấy tên phụ huynh từ TextBox
                    var ngheNghiep = txt_Nghenghiep.Text; // Lấy nghề nghiệp từ TextBox
                    var ngaySinh = dtp_NgaySinh.Value; // Lấy ngày sinh từ DateTimePicker
                    var diaChi = txt_DiaChi.Text; // Lấy địa chỉ từ TextBox
                    var email = txt_Email.Text; // Lấy email từ TextBox
                    var soDienThoai = txt_SDT.Text; // Lấy số điện thoại từ TextBox
                    var gioiTinh = rdo_Nam.Checked ? "Nam" : "Nữ"; // Xác định giới tính từ RadioButton

                    if (string.IsNullOrEmpty(tenPhuHuynh) || string.IsNullOrEmpty(soDienThoai))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin phụ huynh.");
                        return;
                    }

                    // Tạo đối tượng phụ huynh mới để cập nhật
                    var phuHuynhMoi = new DTO.PhuHuynh
                    {
                        MaPhuHuynh = maPhuHuynh,
                        TenPhuHuynh = tenPhuHuynh,
                        NgheNghiep = ngheNghiep,
                        NgaySinh = ngaySinh,
                        DiaChi = diaChi,
                        Email = email,
                        SoDienThoai = soDienThoai,
                        GioiTinh = gioiTinh
                    };

                    // Gọi BLL để cập nhật thông tin phụ huynh
                    if (PhuHuynhBLL.SuaPhuHuynh(phuHuynhMoi))
                    {
                        MessageBox.Show("Cập nhật thông tin phụ huynh thành công!");
                        LoadPhuHuynh(); // Tải lại danh sách phụ huynh
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi cập nhật thông tin phụ huynh.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phụ huynh cần sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi sửa thông tin phụ huynh: " + ex.Message);
            }
        }

        private void btnExportFileExcel_Click(object sender, EventArgs e)
        {

            try
            {
                // Kiểm tra nếu DataGridView có dữ liệu
                if (dgvPhuHuynh.Rows.Count > 0)
                {
                    // Tạo workbook mới
                    using (var workbook = new XLWorkbook())
                    {
                        // Tạo một worksheet
                        var worksheet = workbook.Worksheets.Add("DanhSachPhuHuynh");

                        int visibleColumnIndex = 1; // Dùng để theo dõi các cột hiển thị

                        // Thêm tiêu đề cột vào worksheet (chỉ cột hiển thị)
                        for (int i = 0; i < dgvPhuHuynh.Columns.Count; i++)
                        {
                            if (dgvPhuHuynh.Columns[i].Visible) // Chỉ thêm các cột hiển thị
                            {
                                worksheet.Cell(1, visibleColumnIndex).Value = dgvPhuHuynh.Columns[i].HeaderText;
                                visibleColumnIndex++;
                            }
                        }

                        // Thêm dữ liệu từ DataGridView vào worksheet (chỉ cột hiển thị)
                        for (int i = 0; i < dgvPhuHuynh.Rows.Count; i++)
                        {
                            visibleColumnIndex = 1; // Reset index cho mỗi hàng
                            for (int j = 0; j < dgvPhuHuynh.Columns.Count; j++)
                            {
                                if (dgvPhuHuynh.Columns[j].Visible) // Chỉ thêm dữ liệu cho cột hiển thị
                                {
                                    worksheet.Cell(i + 2, visibleColumnIndex).Value = dgvPhuHuynh.Rows[i].Cells[j].Value?.ToString() ?? "";
                                    visibleColumnIndex++;
                                }
                            }
                        }

                        // Mở hộp thoại lưu file để chọn nơi lưu file
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save an Excel File";
                        saveFileDialog.FileName = "DanhSachPhuHuynh.xlsx";

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
        private void TimKiemPhuHuynh(string tuKhoa)
        {
            try
            {
                var danhSachPhuHuynh = PhuHuynhBLL.LayTatCaPhuHuynh(); // Lấy tất cả phụ huynh từ BLL

                // Nếu từ khóa trống hoặc null, hiển thị toàn bộ danh sách
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    dgvPhuHuynh.DataSource = danhSachPhuHuynh;
                    return;
                }

                // Chuyển từ khóa về chữ thường để so sánh không phân biệt hoa thường
                tuKhoa = tuKhoa.ToLower();

                // Lọc danh sách theo từ khóa (tuKhoa)
                var ketQuaTimKiem = danhSachPhuHuynh.Where(phh =>
                    phh.MaPhuHuynh.ToString().Contains(tuKhoa) || // Tìm theo Mã phụ huynh
                    phh.TenPhuHuynh.ToLower().Contains(tuKhoa) || // Tìm theo Tên phụ huynh (chuyển về chữ thường)
                    phh.NgheNghiep.ToLower().Contains(tuKhoa) ||  // Tìm theo Nghề nghiệp (chuyển về chữ thường)
                    phh.SoDienThoai.Contains(tuKhoa) ||                   // Tìm theo Số điện thoại
                    phh.Email.ToLower().Contains(tuKhoa)          // Tìm theo Email (chuyển về chữ thường)
                ).ToList();

                dgvPhuHuynh.DataSource = ketQuaTimKiem; // Gán kết quả tìm kiếm vào DataGridView

                // Nếu không có kết quả nào
                if (ketQuaTimKiem.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm phụ huynh: " + ex.Message);
            }
        }

        private void dgvPhuHuynh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhuHuynh.Columns[e.ColumnIndex].Name == "NgaySinh" && e.Value != null)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }
        }

        private void dgvPhuHuynh_SelectionChanged(object sender, EventArgs e)
        {

        }
    } 

}
