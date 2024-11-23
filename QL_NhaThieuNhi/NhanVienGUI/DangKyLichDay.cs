using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace QL_NhaThieuNhi.NhanVienGUI
{
    public partial class DangKyLichDay : Form
    {
        SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString());
        public DangKyLichDay()
        {
            InitializeComponent();
            InitializeListView(); // Cấu hình ListView
            LoadComboBoxData();   // Tải dữ liệu combobox
            LoadDataGrid();
        }

        private void LoadComboBoxData()
        {
            LoadNhanVien();
            LoadLop();
            LoadCaHoc();
            LoadTrangThai();
            LoadPhongHoc();
        }
        // Tải danh sách nhân viên vào cmb_NhanVien
        private void LoadNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                string query = "SELECT MaNhanVien, TenNhanVien FROM NhanVien";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmb_NhanVien.DisplayMember = "TenNhanVien";
                cmb_NhanVien.ValueMember = "MaNhanVien";
                cmb_NhanVien.DataSource = dt;
            }
        }
        //load phòng học
        private void LoadPhongHoc()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                string query = "SELECT MaLichHoc, PhongHoc FROM LichHoc";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmd_PhongHoc.DisplayMember = "PhongHoc";
                cmd_PhongHoc.ValueMember = "MaLichHoc";
                cmd_PhongHoc.DataSource = dt;
            }
        }
        // Tải danh sách lớp vào cmb_Lop
        private void LoadLop()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                string query = "SELECT MaLop, TenLop FROM LopHoc";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmb_Lop.DisplayMember = "TenLop";
                cmb_Lop.ValueMember = "MaLop";
                cmb_Lop.DataSource = dt;
            }
        }
        // Tải danh sách ca học vào cmd_CaHoc
        private void LoadCaHoc()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                {
                    string query = "SELECT MaCaHoc,TietHoc FROM CaHoc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cmd_CaHoc.DisplayMember = "TietHoc";
                    cmd_CaHoc.ValueMember = "MaCaHoc";
                    cmd_CaHoc.DataSource = dt;
                }
            }
        }

        // Tải trạng thái vào cmb_TrangThai
        private void LoadTrangThai()
        {
            cmb_TrangThai.Items.Add("Đang dạy");
            cmb_TrangThai.Items.Add("Hoàn thành");
            cmb_TrangThai.Items.Add("Chuẩn Bị");
        }
        private void LoadDataGrid()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                // Truy vấn dữ liệu từ bảng LichDay
                string query = "SELECT L.MaLichDay, N.TenNhanVien, L.MaLop, C.TietHoc, L.NgayDay,L.NgayKetThuc, L.PhongHoc, L.TrangThai " +
                               "FROM LichDay L " +
                               "JOIN NhanVien N ON L.MaNhanVien = N.MaNhanVien " +
                               "JOIN LopHoc O ON L.MaLop = O.MaLop " +
                               "JOIN CaHoc C ON L.MaCaHoc = C.MaCaHoc";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Xóa tất cả mục hiện tại trong ListView
                listView_Bang.Items.Clear();

                // Duyệt qua các dòng dữ liệu và thêm vào ListView
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaLichDay"].ToString());
                    item.SubItems.Add(row["TenNhanVien"].ToString());
                    item.SubItems.Add(row["MaLop"].ToString());
                    item.SubItems.Add(row["TietHoc"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(row["NgayDay"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(Convert.ToDateTime(row["NgayKetThuc"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(row["PhongHoc"].ToString());
                    item.SubItems.Add(row["TrangThai"].ToString());
                    listView_Bang.Items.Add(item);
                }
            }
        }
        private void InitializeListView()
        {
            listView_Bang.Columns.Clear();
            listView_Bang.View = View.Details;
            listView_Bang.FullRowSelect = true;

            listView_Bang.Columns.Add("Mã Lịch Dạy", 100);
            listView_Bang.Columns.Add("Tên Nhân Viên", 150);
            listView_Bang.Columns.Add("Mã Lớp", 100);
            listView_Bang.Columns.Add("Tiết Học", 100);
            listView_Bang.Columns.Add("Ngày Dạy", 100);
            listView_Bang.Columns.Add("Ngày Kết Thúc", 100);
            listView_Bang.Columns.Add("Phòng Học", 100);
            listView_Bang.Columns.Add("Trạng Thái", 100);
        }
        public static bool CheckMaLichDayExists(int maLichDay)
        {
            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM LichDay WHERE MaLichDay = @MaLichDay";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@MaLichDay", maLichDay);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0; // Nếu count > 0 thì có tồn tại mã lịch dạy này
                    }
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi nếu cần
                    return false;
                }
            }
        }
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Thay đổi màu nền của các trường không hợp lệ
            if (string.IsNullOrEmpty(txt_MaLichDay.Text))
                txt_MaLichDay.BackColor = Color.LightCoral;
            else
                txt_MaLichDay.BackColor = Color.White;
            txt_MaLichDay.Enabled = cmd_PhongHoc.Enabled = tp_ThoiGianDay.Enabled = tp_ThoiGianKetThuc.Enabled =
            cmd_CaHoc.Enabled = cmb_NhanVien.Enabled = cmb_TrangThai.Enabled = cmb_Lop.Enabled = true;
            // Kiểm tra nếu tất cả các trường cần thiết đã được nhập
            if (string.IsNullOrEmpty(txt_MaLichDay.Text) ||
                string.IsNullOrEmpty(cmd_PhongHoc.Text) ||
                string.IsNullOrEmpty(cmd_CaHoc.Text) ||
                cmb_NhanVien.SelectedIndex == -1 ||
                cmb_Lop.SelectedIndex == -1 ||
                cmb_TrangThai.SelectedIndex == -1 ||
                tp_ThoiGianDay.Value >= tp_ThoiGianKetThuc.Value) // Kiểm tra thời gian
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm lịch dạy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_NhanVien.Text) || string.IsNullOrEmpty(cmd_PhongHoc.Text) ||
                string.IsNullOrEmpty(cmd_CaHoc.Text) || string.IsNullOrEmpty(cmb_Lop.Text) ||
                string.IsNullOrEmpty(cmb_TrangThai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kết nối và thêm dữ liệu vào cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                string query = "INSERT INTO LichDay (MaNhanVien, MaLop, MaCaHoc, NgayDay,NgayKetThuc, PhongHoc, TrangThai) " +
                               "VALUES (@MaNhanVien, @MaLop, @MaCaHoc, @NgayDay,@NgayKetThuc, @PhongHoc, @TrangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhanVien", cmb_NhanVien.SelectedValue);  // Thay giá trị theo control
                cmd.Parameters.AddWithValue("@MaLop", cmb_Lop.SelectedValue);
                cmd.Parameters.AddWithValue("@MaCaHoc", cmd_CaHoc.SelectedValue);
                cmd.Parameters.AddWithValue("@NgayDay", tp_ThoiGianDay.Value);
                cmd.Parameters.AddWithValue("@NgayKetThuc", tp_ThoiGianKetThuc.Value);
                cmd.Parameters.AddWithValue("@PhongHoc", cmd_PhongHoc.Text);
                cmd.Parameters.AddWithValue("@TrangThai", cmb_TrangThai.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Tải lại dữ liệu vào ListView
            LoadDataGrid();
            MessageBox.Show("Thêm lịch dạy thành công!");
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_NhanVien.Text) || string.IsNullOrEmpty(cmd_PhongHoc.Text) ||
                string.IsNullOrEmpty(cmd_CaHoc.Text) || string.IsNullOrEmpty(cmb_Lop.Text) ||
                string.IsNullOrEmpty(cmb_TrangThai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kết nối và cập nhật dữ liệu vào cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                string query = "UPDATE LichDay SET MaNhanVien = @MaNhanVien, MaLop = @MaLop, " +
                               "MaCaHoc = @MaCaHoc, NgayDay = @NgayDay, NgayKetThuc = @NgayKetThuc, PhongHoc = @PhongHoc, " +
                               "TrangThai = @TrangThai WHERE MaLichDay = @MaLichDay";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhanVien", cmb_NhanVien.SelectedValue);
                cmd.Parameters.AddWithValue("@MaLop", cmb_Lop.SelectedValue);
                cmd.Parameters.AddWithValue("@MaCaHoc", cmd_CaHoc.SelectedValue);
                cmd.Parameters.AddWithValue("@NgayDay", tp_ThoiGianDay.Value);
                cmd.Parameters.AddWithValue("@NgayKetThuc", tp_ThoiGianKetThuc.Value);
                cmd.Parameters.AddWithValue("@PhongHoc", cmd_PhongHoc.Text);
                cmd.Parameters.AddWithValue("@TrangThai", cmb_TrangThai.Text);
                cmd.Parameters.AddWithValue("@MaLichDay", txt_MaLichDay.Text);  // Mã Lịch Dạy của bản ghi cần sửa

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Tải lại dữ liệu vào ListView
            LoadDataGrid();
            MessageBox.Show("Cập nhật lịch dạy thành công!");
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có chọn một phụ huynh nào đó không
            if (listView_Bang.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phụ huynh để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận hành động xóa
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phụ huynh này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // Nếu người dùng chọn không, thoát khỏi hàm
            }

            try
            {
                conn.Open();
                string sql = "DELETE FROM LichDay WHERE  MaLichDay = @MaLichDay";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaLichDay", listView_Bang.SelectedItems[0].SubItems[0].Text); // Lấy mã phụ huynh từ item được chọn
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid(); // Cập nhật lại dữ liệu trong ListView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phụ huynh với mã đã cho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Đảm bảo kết nối luôn được đóng
            }
        }

        private void DangKyLichDay_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
            txt_MaLichDay.Enabled = cmd_PhongHoc.Enabled = tp_ThoiGianDay.Enabled = tp_ThoiGianKetThuc.Enabled =
            cmd_CaHoc.Enabled = cmb_NhanVien.Enabled = cmb_TrangThai.Enabled = cmb_Lop.Enabled = false;
        }

        private void btn_ChuyenChucNang_Click(object sender, EventArgs e)
        {

            xóaToolStripMenuItem.Enabled = thêmToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = true;
            txt_MaLichDay.Enabled = cmd_PhongHoc.Enabled = tp_ThoiGianDay.Enabled = tp_ThoiGianKetThuc.Enabled = cmd_CaHoc.Enabled = cmb_NhanVien.Enabled = cmb_TrangThai.Enabled = cmb_Lop.Enabled = cb_Admin.Enabled = false;
        }

        private void listView_Bang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Bang.SelectedItems.Count > 0)
            {
                // Lấy dòng được chọn đầu tiên
                ListViewItem selectedItem = listView_Bang.SelectedItems[0];

                // Hiển thị thông tin vào các control trong form
                txt_MaLichDay.Text = selectedItem.SubItems[0].Text;
                cmb_NhanVien.SelectedValue = selectedItem.SubItems[2].Text; // MaNhanVien
                cmb_Lop.SelectedValue = selectedItem.SubItems[0].Text;       // MaLop
                cmd_CaHoc.SelectedValue = selectedItem.SubItems[0].Text;     // MaCaHoc
                tp_ThoiGianDay.Value = Convert.ToDateTime(selectedItem.SubItems[4].Text); // Ngày Dạy
                tp_ThoiGianKetThuc.Value = Convert.ToDateTime(selectedItem.SubItems[5].Text);
                cmd_PhongHoc.Text = selectedItem.SubItems[6].Text;            // Phòng Học
                cmb_TrangThai.SelectedItem = selectedItem.SubItems[7].Text;   // Trang Thái
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {

            listView_Bang.Items.Clear(); // Xóa danh sách cũ

            string sql = "SELECT * FROM LichDay WHERE PhongHoc LIKE @PhongHoc";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PhongHoc", "%" + cmd_PhongHoc.Text + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem listItem = new ListViewItem(dr["MaLichDay"].ToString()); // Mã Lịch Dạy
                listItem.SubItems.Add(dr["MaNhanVien"].ToString()); // Mã Nhân Viên
                listItem.SubItems.Add(dr["MaLop"].ToString());      // Mã Lớp
                listItem.SubItems.Add(dr["MaCaHoc"].ToString());    // Mã Ca Học
                listItem.SubItems.Add(dr["NgayDay"].ToString());    // Ngày Dạy
                listItem.SubItems.Add(dr["PhongHoc"].ToString());   // Phòng Học
                listItem.SubItems.Add(dr["TrangThai"].ToString());  // Trạng Thái

                listView_Bang.Items.Add(listItem); // Thêm dòng vào ListView
            }
        }
    }
}
