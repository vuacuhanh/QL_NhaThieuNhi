using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ClosedXML.Excel;
using DAL;
namespace QL_NhaThieuNhi.NhanVienGUI
{
    public partial class DK_LichDay : Form
    {
        private Dictionary<string, string> dictNhanVien = new Dictionary<string, string>();
        private Dictionary<string, string> dictLop = new Dictionary<string, string>();
        private Dictionary<string, string> dictCaHoc = new Dictionary<string, string>();
        public DK_LichDay()
        {
            InitializeComponent();
            LoadMaLop();
            LoadLichDay();
            LoadComboBoxData();

            // Đăng ký sự kiện CellClick cho DataGridView LichDay
            this.dgvLichDay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichDay_CellClick);

            // Đăng ký sự kiện SelectedIndexChanged cho ComboBox Lọc (lọc Lịch Dạy)
            this.cbLoc.SelectedIndexChanged += new System.EventHandler(this.cbLoc_SelectedIndexChanged);

            // Đăng ký sự kiện TextChanged cho TextBox Tìm Kiếm (tìm kiếm Lịch Dạy)
            this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);

        }
        private void LoadComboBoxData()
        {
           // LoadNhanVien();
           // LoadLop();
           // LoadCaHoc();
           // LoadTrangThai();
           // LoadPhongHoc();
        }
        // Tải danh sách nhân viên vào cmb_NhanVien
        private void LoadNhanVien()
        {
            try
            {
                using (SqlConnection conn = ConnectionData.Connect())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_LayDanhSachNhanVien", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán dữ liệu cho ComboBox
                    cb_MaNhanVien.DisplayMember = "TenNhanVien";
                    cb_MaNhanVien.ValueMember = "MaNhanVien";
                    cb_MaNhanVien.DataSource = dt;

                    // Lưu vào Dictionary
                    dictNhanVien = dt.AsEnumerable().ToDictionary(
                        row => row["MaNhanVien"].ToString(),
                        row => row["TenNhanVien"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        //load phòng học
        private void LoadPhongHoc()
        {
            try
            {
                // Sử dụng phương thức Connect() từ lớp ConnectionData
                using (SqlConnection conn = ConnectionData.Connect())
                {
                    conn.Open();

                    // Tạo SqlCommand để gọi Stored Procedure
                    SqlCommand cmd = new SqlCommand("SP_LayDanhSachPhongHoc", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Tạo SqlDataAdapter để thực thi Stored Procedure
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    // Đổ dữ liệu vào DataTable
                    adapter.Fill(dt);

                    // Gán dữ liệu cho ComboBox
                    cb_PhongHoc.DisplayMember = "PhongHoc";
                    cb_PhongHoc.ValueMember = "MaLichHoc";
                    cb_PhongHoc.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng học: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tải danh sách lớp vào cb_MaLop
        private void LoadLop()
        {
            try
            {
                // Sử dụng phương thức Connect() từ lớp ConnectionData
                using (SqlConnection conn = ConnectionData.Connect())
                {
                    conn.Open();

                    // Tạo SqlCommand để gọi Stored Procedure
                    SqlCommand cmd = new SqlCommand("SP_LayDanhSachLop", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Tạo SqlDataAdapter để thực thi Stored Procedure
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    // Đổ dữ liệu vào DataTable
                    adapter.Fill(dt);

                    // Gán dữ liệu cho ComboBox
                    cb_MaLop.DisplayMember = "TenLop";
                    cb_MaLop.ValueMember = "MaLop";
                    cb_MaLop.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Tải danh sách ca học vào cb_CaHoc
        private void LoadCaHoc()
        {
            try
            {
                // Sử dụng phương thức Connect() từ lớp ConnectionData
                using (SqlConnection conn = ConnectionData.Connect())
                {
                    conn.Open();

                    // Tạo SqlCommand để gọi Stored Procedure
                    SqlCommand cmd = new SqlCommand("SP_LayDanhSachCaHoc", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Tạo SqlDataAdapter để thực thi Stored Procedure
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    // Đổ dữ liệu vào DataTable
                    adapter.Fill(dt);

                    // Gán dữ liệu cho ComboBox
                    cb_CaHoc.DisplayMember = "TietHoc";
                    cb_CaHoc.ValueMember = "MaCaHoc";
                    cb_CaHoc.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách ca học: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Tải trạng thái vào cmb_TrangThai
        private void LoadTrangThai()
        {
            cb_TrangThai.Items.Add("Đang dạy");
            cb_TrangThai.Items.Add("Hoàn thành");
            cb_TrangThai.Items.Add("Chuẩn Bị");
        }
        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public ComboBoxItem(string value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void dgvLichDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (e.RowIndex >= 0)
                {
                    var row = dgvLichDay.Rows[e.RowIndex]; // Lấy dòng được chọn

                    // Cập nhật các trường nhập với dữ liệu từ dòng được chọn
                    txt_MaLichDay.Text = row.Cells["MaLichDay"].Value.ToString(); // Mã lịch dạy

                    // Cập nhật Mã Nhân Viên (ComboBox)
                    var maNhanVien = row.Cells["MaNhanVien"].Value?.ToString();
                    if (!string.IsNullOrEmpty(maNhanVien))
                    {
                        cb_MaNhanVien.SelectedItem = cb_MaNhanVien.Items.Cast<ComboBoxItem>()
                                                        .FirstOrDefault(item => item.Value == maNhanVien); // Cập nhật giá trị ComboBox
                    }

                    // Cập nhật Mã Lớp (ComboBox)
                    var maLop = row.Cells["MaLop"].Value?.ToString();
                    if (!string.IsNullOrEmpty(maLop))
                    {
                        cb_MaLop.SelectedItem = cb_MaLop.Items.Cast<ComboBoxItem>()
                                                      .FirstOrDefault(item => item.Value == maLop); // Cập nhật giá trị ComboBox
                    }

                    // Cập nhật Phòng Học (ComboBox)
                    var phongHoc = row.Cells["PhongHoc"].Value?.ToString();
                    if (!string.IsNullOrEmpty(phongHoc))
                    {
                        cb_PhongHoc.SelectedItem = cb_PhongHoc.Items.Cast<ComboBoxItem>()
                                                       .FirstOrDefault(item => item.Value == phongHoc); // Cập nhật giá trị ComboBox
                    }

                    // Cập nhật Trạng Thái (ComboBox)
                    var trangThai = row.Cells["TrangThai"].Value?.ToString();
                    if (!string.IsNullOrEmpty(trangThai))
                    {
                        cb_TrangThai.SelectedItem = cb_TrangThai.Items.Cast<ComboBoxItem>()
                                                       .FirstOrDefault(item => item.Value == trangThai); // Cập nhật giá trị ComboBox
                    }

                    // Cập nhật ngày dạy
                    if (row.Cells["NgayDay"].Value != null && DateTime.TryParse(row.Cells["NgayDay"].Value.ToString(), out DateTime ngayDay))
                    {
                        dtp_NgayDay.Value = ngayDay;
                    }
                    else
                    {
                        dtp_NgayDay.Value = DateTime.Now; // Gán giá trị mặc định
                    }

                    // Cập nhật ngày kết thúc (nếu có)
                    if (row.Cells["NgayKetThuc"].Value != null && DateTime.TryParse(row.Cells["NgayKetThuc"].Value.ToString(), out DateTime ngayKetThuc))
                    {
                        dtp_NgayKetThuc.Value = ngayKetThuc;
                    }
                    else
                    {
                        dtp_NgayKetThuc.Value = DateTime.Now; // Gán giá trị mặc định
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
                var maLop = cbLoc.SelectedItem.ToString(); // Lấy giá trị lớp từ ComboBox

                if (maLop == "Tất Cả")
                {
                    // Nếu chọn "Tất Cả", load lại toàn bộ danh sách lịch dạy
                    LoadLichDay();
                }
                else
                {
                    // Lọc lịch dạy theo mã lớp
                    var danhSachLichDay = LichDayBLL.LocLichDayTheoLop(maLop);
                    dgvLichDay.DataSource = danhSachLichDay; // Gán dữ liệu cho DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lọc lịch dạy theo mã lớp: " + ex.Message);
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
        private void LoadLichDay()
        {
            try
            {
                // Giả sử bạn có phương thức lấy tất cả các lịch dạy từ LichDayBLL
                dgvLichDay.DataSource = LichDayBLL.LayTatCaLichDay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lịch dạy: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_TimKiem.Text.ToLower(); // Chuyển từ khóa tìm kiếm thành chữ thường

                // Lấy tất cả danh sách lịch dạy
                var danhSachLichDay = LichDayBLL.LayTatCaLichDay();

                // Lọc danh sách lịch dạy theo từ khóa tìm kiếm, không phân biệt hoa thường
                var filteredLichDay = danhSachLichDay.Where(lichDay =>
                    lichDay.PhongHoc.ToLower().Contains(keyword) ||    // So sánh phòng học
                    lichDay.TrangThai.ToLower().Contains(keyword)      // So sánh trạng thái
                ).ToList();

                // Gán lại danh sách đã lọc cho DataGridView
                dgvLichDay.DataSource = filteredLichDay;
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
                var MaLichDay = Convert.ToInt32(txt_MaLichDay.Text); // Mã lịch dạy
                var MaNhanVien = Convert.ToInt32(cb_MaNhanVien.SelectedValue); // Mã nhân viên từ ComboBox
                var MaLop = Convert.ToInt32(cb_MaLop.SelectedValue); // Mã lớp từ ComboBox
                var MaCaHoc = Convert.ToInt32(cb_CaHoc.SelectedValue); // Mã ca học từ ComboBox
                var NgayDay = dtp_NgayDay.Value; // Ngày dạy từ DateTimePicker
                var NgayKetThuc = dtp_NgayKetThuc.Value; // Ngày kết thúc từ DateTimePicker
                var PhongHoc = cb_PhongHoc.SelectedItem.ToString(); // Phòng học từ ComboBox
                var TrangThai = cb_TrangThai.SelectedItem.ToString(); // Trạng thái từ ComboBox

                // Kiểm tra dữ liệu nhập
                if (MaNhanVien == 0 || MaLop == 0 || MaCaHoc == 0 || string.IsNullOrEmpty(PhongHoc) || string.IsNullOrEmpty(TrangThai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin lịch dạy.");
                    return;
                }

                // Tạo đối tượng lịch dạy mới
                var lichDayMoi = new DTO.LichDay
                {
                    MaLichDay = MaLichDay,
                    MaNhanVien = MaNhanVien,
                    MaLop = MaLop,
                    MaCaHoc = MaCaHoc,
                    NgayDay = NgayDay,
                    NgayKetThuc = NgayKetThuc,
                    PhongHoc = PhongHoc,
                    TrangThai = TrangThai
                };

                // Thêm lịch dạy thông qua BLL
                if (LichDayBLL.ThemLichDay(lichDayMoi))
                {
                    MessageBox.Show("Thêm lịch dạy thành công!");
                    LoadLichDay(); // Tải lại danh sách lịch dạy
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm lịch dạy.");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm lịch dạy: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {

            if (dgvLichDay.SelectedRows.Count > 0)
            {
                // Lấy mã lịch dạy từ cột trong DataGridView
                int maLichDay = Convert.ToInt32(dgvLichDay.SelectedRows[0].Cells["MaLichDay"].Value);

                try
                {
                    if (MessageBox.Show($"Bạn có chắc chắn muốn xóa lịch dạy có mã {maLichDay}?",
                                        "Xác nhận",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Gọi phương thức xóa lịch dạy trong BLL
                        if (LichDayBLL.XoaLichDay(maLichDay))
                        {
                            MessageBox.Show("Xóa lịch dạy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLichDay(); // Cập nhật lại danh sách sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy lịch dạy để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Vui lòng chọn lịch dạy để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvLichDay.SelectedRows.Count > 0) // Kiểm tra có dòng lịch dạy nào được chọn không
                {
                    // Lấy mã lịch dạy từ dòng được chọn
                    var MaLichDay = Convert.ToInt32(txt_MaLichDay.Text); // Mã lịch dạy
                    var MaNhanVien = Convert.ToInt32(cb_MaNhanVien.SelectedValue); // Mã nhân viên từ ComboBox
                    var MaLop = Convert.ToInt32(cb_MaLop.SelectedValue); // Mã lớp từ ComboBox
                    var MaCaHoc = Convert.ToInt32(cb_CaHoc.SelectedValue); // Mã ca học từ ComboBox
                    var NgayDay = dtp_NgayDay.Value; // Ngày dạy từ DateTimePicker
                    var NgayKetThuc = dtp_NgayKetThuc.Value; // Ngày kết thúc từ DateTimePicker
                    var PhongHoc = cb_PhongHoc.SelectedItem.ToString(); // Phòng học từ ComboBox
                    var TrangThai = cb_TrangThai.SelectedItem.ToString(); // Trạng thái từ ComboBox

                    // Kiểm tra dữ liệu nhập
                    if (MaNhanVien == 0 || MaLop == 0 || MaCaHoc == 0 || string.IsNullOrEmpty(PhongHoc) || string.IsNullOrEmpty(TrangThai))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin lịch dạy.");
                        return;
                    }

                    // Tạo đối tượng lịch dạy mới để cập nhật
                    var lichDayMoi = new DTO.LichDay
                    {
                        MaLichDay = MaLichDay,
                        MaNhanVien = MaNhanVien,
                        MaLop = MaLop,
                        MaCaHoc = MaCaHoc,
                        NgayDay = NgayDay,
                        NgayKetThuc = NgayKetThuc,
                        PhongHoc = PhongHoc,
                        TrangThai = TrangThai
                    };

                    // Gọi BLL để cập nhật thông tin lịch dạy
                    if (LichDayBLL.SuaLichDay(lichDayMoi))
                    {
                        MessageBox.Show("Cập nhật thông tin lịch dạy thành công!");
                        LoadLichDay(); // Tải lại danh sách lịch dạy
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi cập nhật thông tin lịch dạy.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn lịch dạy cần sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi sửa thông tin lịch dạy: " + ex.Message);
            }
        }

        private void btnExportFileExcel_Click(object sender, EventArgs e)
        {

            try
            {
                // Kiểm tra nếu DataGridView có dữ liệu
                if (dgvLichDay.Rows.Count > 0)
                {
                    // Tạo workbook mới
                    using (var workbook = new XLWorkbook())
                    {
                        // Tạo một worksheet
                        var worksheet = workbook.Worksheets.Add("DanhSachLichDay");

                        int visibleColumnIndex = 1; // Dùng để theo dõi các cột hiển thị

                        // Thêm tiêu đề cột vào worksheet (chỉ cột hiển thị)
                        for (int i = 0; i < dgvLichDay.Columns.Count; i++)
                        {
                            if (dgvLichDay.Columns[i].Visible) // Chỉ thêm các cột hiển thị
                            {
                                worksheet.Cell(1, visibleColumnIndex).Value = dgvLichDay.Columns[i].HeaderText;
                                visibleColumnIndex++;
                            }
                        }

                        // Thêm dữ liệu từ DataGridView vào worksheet (chỉ cột hiển thị)
                        for (int i = 0; i < dgvLichDay.Rows.Count; i++)
                        {
                            visibleColumnIndex = 1; // Reset index cho mỗi hàng
                            for (int j = 0; j < dgvLichDay.Columns.Count; j++)
                            {
                                if (dgvLichDay.Columns[j].Visible) // Chỉ thêm dữ liệu cho cột hiển thị
                                {
                                    worksheet.Cell(i + 2, visibleColumnIndex).Value = dgvLichDay.Rows[i].Cells[j].Value?.ToString() ?? "";
                                    visibleColumnIndex++;
                                }
                            }
                        }

                        // Mở hộp thoại lưu file để chọn nơi lưu file
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save an Excel File";
                        saveFileDialog.FileName = "DanhSachLichDay.xlsx";

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
        private void TimKiemLichDay(string tuKhoa)
        {
            try
            {
                // Lấy tất cả lịch dạy từ BLL
                var danhSachLichDay = LichDayBLL.LayTatCaLichDay(); // Giả sử bạn có BLL để lấy danh sách lịch dạy

                // Nếu từ khóa trống hoặc null, hiển thị toàn bộ danh sách
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    dgvLichDay.DataSource = danhSachLichDay;
                    return;
                }

                // Chuyển từ khóa về chữ thường để so sánh không phân biệt hoa thường
                tuKhoa = tuKhoa.ToLower();

                // Lọc danh sách theo từ khóa (tuKhoa)
                var ketQuaTimKiem = danhSachLichDay.Where(ld =>
                    ld.MaLichDay.ToString().Contains(tuKhoa) || // Tìm theo Mã lịch dạy
                    ld.MaNhanVien.ToString().Contains(tuKhoa) || // Tìm theo Mã nhân viên
                    ld.MaLop.ToString().Contains(tuKhoa) || // Tìm theo Mã lớp
                    ld.MaCaHoc.ToString().Contains(tuKhoa) || // Tìm theo Mã ca học
                    ld.PhongHoc.ToLower().Contains(tuKhoa) || // Tìm theo Phòng học
                    ld.TrangThai.ToLower().Contains(tuKhoa) // Tìm theo Trạng thái
                ).ToList();

                dgvLichDay.DataSource = ketQuaTimKiem; // Gán kết quả tìm kiếm vào DataGridView

                // Nếu không có kết quả nào
                if (ketQuaTimKiem.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm lịch dạy: " + ex.Message);
            }
        }

        private void dgvLichDay_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLichDay.CurrentRow != null)
            {
                DataGridViewRow row = dgvLichDay.CurrentRow;

                // Lấy giá trị từ dòng được chọn
                string maNhanVien = row.Cells["MaNhanVien"].Value?.ToString();
                string maLop = row.Cells["MaLop"].Value?.ToString();
                string maCaHoc = row.Cells["MaCaHoc"].Value?.ToString();

                // Ánh xạ mã sang tên
                string tenNhanVien = dictNhanVien.ContainsKey(maNhanVien) ? dictNhanVien[maNhanVien] : "";
                string tenLop = dictLop.ContainsKey(maLop) ? dictLop[maLop] : "";
                string tietHoc = dictCaHoc.ContainsKey(maCaHoc) ? dictCaHoc[maCaHoc] : "";

                // Hiển thị trong TextBox
                cb_MaNhanVien.Text = tenNhanVien;
                cb_MaLop.Text = tenLop;
                cb_CaHoc.Text = tietHoc;

                // Nếu muốn hiển thị thêm
                cb_PhongHoc.Text = row.Cells["PhongHoc"].Value?.ToString();
                cb_TrangThai.Text = row.Cells["TrangThai"].Value?.ToString();
            }

        }
    }
}
