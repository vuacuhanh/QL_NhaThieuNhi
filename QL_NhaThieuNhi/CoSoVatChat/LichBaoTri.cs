using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;

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
    } 
}
