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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;
using ClosedXML.Excel;

namespace QL_NhaThieuNhi.CoSoVatChat
{
    public partial class LichBaoTri : Form
    {
        public LichBaoTri()
        {
            InitializeComponent();
            LoadLichBaoTri();
            LoadTrangThai();
            LoadTrangThaiLichBaoTri();
            // Đăng ký sự kiện CellClick cho DataGridView LichBaoTri
            this.dgvLichBaoTri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichBaoTri_CellClick);

            // Đăng ký sự kiện SelectedIndexChanged cho ComboBox Lọc (lọc theo trạng thái hoặc cơ sở vật chất)
            this.cbLoc.SelectedIndexChanged += new System.EventHandler(this.cbLoc_SelectedIndexChanged);

            // Đăng ký sự kiện TextChanged cho TextBox Tìm Kiếm (tìm theo mã lịch bảo trì hoặc cơ sở vật chất)
            this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);

        }
        // Phương thức tải danh sách nhân viên lên ComboBox
        // Form - Tải dữ liệu lên ComboBox


        private void LoadLichBaoTri()
        {
            try
            {
                // Gọi phương thức lấy dữ liệu từ BLL
                dgvLichBaoTri.DataSource = LichBaoTriBLL.LayTatCaLichBaoTri();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu xảy ra lỗi
                MessageBox.Show($"Lỗi khi tải danh sách lịch bảo trì: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLichBaoTri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (e.RowIndex >= 0)
                {
                    var row = dgvLichBaoTri.Rows[e.RowIndex]; // Lấy dòng được chọn

                    // Cập nhật các trường nhập với dữ liệu từ dòng được chọn
                    txt_MaLichBaoTri.Text = row.Cells["MaLichBaoTri"].Value.ToString(); // Mã lịch bảo trì
                    txt_MaNhanVienLapLich.Text = row.Cells["MaNhanVienLapLich"].Value.ToString(); // Mã nhân viên lập lịch
                    dtp_ThoiGianBD.Value = Convert.ToDateTime(row.Cells["ThoiGianBD"].Value); // Thời gian bắt đầu
                    dtp_ThoiGianKT.Value = Convert.ToDateTime(row.Cells["ThoiGianKT"].Value); // Thời gian kết thúc
                    cbb_TrangThai.Text = row.Cells["TrangThai"].Value.ToString(); // Trạng thái
                    txt_MaCSVC.Text = row.Cells["MaCSVC"].Value.ToString(); // Mã cơ sở vật chất
                    txt_MaNhanVienBaoTri.Text = row.Cells["MaNhanVienBaoTri"].Value.ToString(); // Mã nhân viên bảo trì
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var trangThai = cbLoc.SelectedItem.ToString(); // Lấy giá trị trạng thái từ ComboBox

                if (trangThai == "Tất Cả")
                {
                    // Nếu chọn "Tất Cả", load lại toàn bộ danh sách lịch bảo trì
                    LoadLichBaoTri();
                }
                else
                {
                    // Lọc lịch bảo trì theo trạng thái
                    var danhSachLichBaoTri = LichBaoTriBLL.LocLichBaoTriTheoTrangThai(trangThai);
                    dgvLichBaoTri.DataSource = danhSachLichBaoTri; // Gán dữ liệu cho DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lọc lịch bảo trì theo trạng thái: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<string> trangThais = new List<string>
{
    "Tất Cả", "Đang chờ", "Đã hoàn thành"
};

        private void LoadTrangThai()
        {
            try
            {
                // Gán danh sách trạng thái vào ComboBox
                cbLoc.DataSource = trangThais;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải trạng thái: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string keyword = txt_TimKiem.Text.ToLower(); // Chuyển từ khóa tìm kiếm thành chữ thường

                // Lấy tất cả danh sách lịch bảo trì
                var danhSachLichBaoTri = LichBaoTriBLL.LayTatCaLichBaoTri();

                // Lọc danh sách lịch bảo trì theo từ khóa tìm kiếm, không phân biệt hoa thường
                var filteredLichBaoTri = danhSachLichBaoTri.Where(lich =>
                    lich.MaLichBaoTri.ToString().ToLower().Contains(keyword) ||      // So sánh mã lịch bảo trì
                    lich.TrangThai.ToLower().Contains(keyword) ||                    // So sánh trạng thái
                    lich.MaNhanVienLapLich.ToString().ToLower().Contains(keyword) || // So sánh mã nhân viên lập lịch
                    lich.MaNhanVienBaoTri.ToString().ToLower().Contains(keyword) ||  // So sánh mã nhân viên bảo trì
                    lich.MaCSVC.ToString().ToLower().Contains(keyword)               // So sánh mã cơ sở vật chất
                ).ToList();

                // Gán lại danh sách đã lọc cho DataGridView
                dgvLichBaoTri.DataSource = filteredLichBaoTri;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTrangThaiLichBaoTri()
        {
            try
            {
                // Lấy danh sách trạng thái từ DataGridView (giả sử bạn có cột "TrangThai" trong DataGridView)
                var trangThaiList = dgvLichBaoTri.Rows
                    .Cast<DataGridViewRow>()
                    .Where(row => row.Cells["TrangThai"].Value != null) // Bỏ qua các giá trị null
                    .Select(row => row.Cells["TrangThai"].Value.ToString())
                    .Distinct() // Loại bỏ các giá trị trùng lặp
                    .ToList();

                // Thêm "Tất Cả" vào danh sách
                // Gán danh sách vào ComboBox
                cbb_TrangThai.DataSource = trangThaiList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải trạng thái lịch bảo trì: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Define and initialize connection object
                string connectionString = "Data Source=DESKTOP-MGLI1G6\\HUUPHU;Initial Catalog=QL_NhaThieuNhi;Integrated Security=True"; // Replace with your actual connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy dữ liệu từ các điều khiển
                    var maLichBaoTri = Convert.ToInt32(txt_MaLichBaoTri.Text);  // Lấy MaLichBaoTri từ txt_MaLichBaoTri
                    var maNhanVienLapLich = Convert.ToInt32(txt_MaNhanVienLapLich.Text);
                    var thoiGianBD = dtp_ThoiGianBD.Value;
                    var thoiGianKT = dtp_ThoiGianKT.Value;
                    var trangThai = cbb_TrangThai.SelectedItem?.ToString();  // Lấy trạng thái từ ComboBox
                    var maCSVC = Convert.ToInt32(txt_MaCSVC.Text);
                    var maNhanVienBaoTri = Convert.ToInt32(txt_MaNhanVienBaoTri.Text);

                    // Kiểm tra dữ liệu nhập
                    if (maNhanVienLapLich <= 0 || maCSVC <= 0 || maNhanVienBaoTri <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin lịch bảo trì.");
                        return;
                    }

                    if (thoiGianBD >= thoiGianKT)
                    {
                        MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc.");
                        return;
                    }

                    if (string.IsNullOrEmpty(trangThai))
                    {
                        MessageBox.Show("Vui lòng chọn trạng thái của lịch bảo trì.");
                        return;
                    }

                    // Tạo đối tượng Lịch bảo trì mới
                    var lichBaoTriMoi = new DTO.LichBaoTri
                    {
                        MaLichBaoTri = maLichBaoTri,
                        MaNhanVienLapLich = maNhanVienLapLich,
                        ThoiGianBD = thoiGianBD,
                        ThoiGianKT = thoiGianKT,
                        TrangThai = trangThai,
                        MaCSVC = maCSVC,
                        MaNhanVienBaoTri = maNhanVienBaoTri
                    };

                    // Gọi thủ tục thêm lịch bảo trì
                    SqlCommand cmd = new SqlCommand("SP_ThemLichBaoTri", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền các tham số
                    cmd.Parameters.AddWithValue("@MaLichBaoTri", lichBaoTriMoi.MaLichBaoTri); // Truyền MaLichBaoTri
                    cmd.Parameters.AddWithValue("@MaNhanVienLapLich", lichBaoTriMoi.MaNhanVienLapLich);
                    cmd.Parameters.AddWithValue("@ThoiGianBD", lichBaoTriMoi.ThoiGianBD);
                    cmd.Parameters.AddWithValue("@ThoiGianKT", lichBaoTriMoi.ThoiGianKT);
                    cmd.Parameters.AddWithValue("@TrangThai", lichBaoTriMoi.TrangThai);
                    cmd.Parameters.AddWithValue("@MaCSVC", lichBaoTriMoi.MaCSVC);
                    cmd.Parameters.AddWithValue("@MaNhanVienBaoTri", lichBaoTriMoi.MaNhanVienBaoTri);

                    // Thực thi thủ tục
                    cmd.ExecuteNonQuery();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Thêm lịch bảo trì thành công!");
                    LoadLichBaoTri();  // Hàm tải lại danh sách lịch bảo trì
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm lịch bảo trì: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {

            if (dgvLichBaoTri.SelectedRows.Count > 0)
            {
                // Lấy mã lịch bảo trì từ cột trong DataGridView
                int maLichBaoTri = Convert.ToInt32(dgvLichBaoTri.SelectedRows[0].Cells["MaLichBaoTri"].Value);

                try
                {
                    if (MessageBox.Show($"Bạn có chắc chắn muốn xóa lịch bảo trì có mã {maLichBaoTri}?",
                                        "Xác nhận",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (LichBaoTriBLL.XoaLichBaoTri(maLichBaoTri)) // Gọi BLL xóa
                        {
                            MessageBox.Show("Xóa lịch bảo trì thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLichBaoTri(); // Cập nhật lại danh sách sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy lịch bảo trì để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa lịch bảo trì: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lịch bảo trì để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLichBaoTri.SelectedRows.Count > 0) // Kiểm tra có dòng lịch bảo trì nào được chọn không
                {
                    // Lấy mã lịch bảo trì từ dòng được chọn
                    var MaLichBaoTri = Convert.ToInt32(txt_MaLichBaoTri.Text); // Mã lịch bảo trì
                    var MaNhanVienLapLich = Convert.ToInt32(txt_MaNhanVienLapLich.Text); // Mã nhân viên lập lịch
                    var ThoiGianBD = dtp_ThoiGianBD.Value; // Thời gian bắt đầu từ DateTimePicker
                    var ThoiGianKT = dtp_ThoiGianKT.Value; // Thời gian kết thúc từ DateTimePicker
                    var TrangThai = cbb_TrangThai.SelectedItem.ToString(); // Trạng thái từ ComboBox
                    var MaCSVC = Convert.ToInt32(txt_MaCSVC.Text); // Mã cơ sở vật chất
                    var MaNhanVienBaoTri = Convert.ToInt32(txt_MaNhanVienBaoTri.Text); // Mã nhân viên bảo trì

                    if (string.IsNullOrEmpty(TrangThai))
                    {
                        MessageBox.Show("Vui lòng chọn trạng thái lịch bảo trì.");
                        return;
                    }

                    // Tạo đối tượng lịch bảo trì mới để cập nhật
                    var lichBaoTriMoi = new DTO.LichBaoTri
                    {
                        MaLichBaoTri = MaLichBaoTri,
                        MaNhanVienLapLich = MaNhanVienLapLich,
                        ThoiGianBD = ThoiGianBD,
                        ThoiGianKT = ThoiGianKT,
                        TrangThai = TrangThai,
                        MaCSVC = MaCSVC,
                        MaNhanVienBaoTri = MaNhanVienBaoTri
                    };

                    // Gọi BLL để cập nhật thông tin lịch bảo trì
                    if (LichBaoTriBLL.SuaLichBaoTri(lichBaoTriMoi))
                    {
                        MessageBox.Show("Cập nhật thông tin lịch bảo trì thành công!");
                        LoadLichBaoTri(); // Tải lại danh sách lịch bảo trì
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi cập nhật thông tin lịch bảo trì.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn lịch bảo trì cần sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi sửa thông tin lịch bảo trì: " + ex.Message);
            }
        }

        private void btnExportFileExcel_Click(object sender, EventArgs e)
        {

            try
            {
                // Kiểm tra nếu DataGridView có dữ liệu
                if (dgvLichBaoTri.Rows.Count > 0)
                {
                    // Tạo workbook mới
                    using (var workbook = new XLWorkbook())
                    {
                        // Tạo một worksheet
                        var worksheet = workbook.Worksheets.Add("DanhSachLichBaoTri");

                        int visibleColumnIndex = 1; // Dùng để theo dõi các cột hiển thị

                        // Thêm tiêu đề cột vào worksheet (chỉ cột hiển thị)
                        for (int i = 0; i < dgvLichBaoTri.Columns.Count; i++)
                        {
                            if (dgvLichBaoTri.Columns[i].Visible) // Chỉ thêm các cột hiển thị
                            {
                                worksheet.Cell(1, visibleColumnIndex).Value = dgvLichBaoTri.Columns[i].HeaderText;
                                visibleColumnIndex++;
                            }
                        }

                        // Thêm dữ liệu từ DataGridView vào worksheet (chỉ cột hiển thị)
                        for (int i = 0; i < dgvLichBaoTri.Rows.Count; i++)
                        {
                            visibleColumnIndex = 1; // Reset index cho mỗi hàng
                            for (int j = 0; j < dgvLichBaoTri.Columns.Count; j++)
                            {
                                if (dgvLichBaoTri.Columns[j].Visible) // Chỉ thêm dữ liệu cho cột hiển thị
                                {
                                    worksheet.Cell(i + 2, visibleColumnIndex).Value = dgvLichBaoTri.Rows[i].Cells[j].Value?.ToString() ?? "";
                                    visibleColumnIndex++;
                                }
                            }
                        }

                        // Mở hộp thoại lưu file để chọn nơi lưu file
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save an Excel File";
                        saveFileDialog.FileName = "DanhSachLichBaoTri.xlsx";

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
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    } 
}
