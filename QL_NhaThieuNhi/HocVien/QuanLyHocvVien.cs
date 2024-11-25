//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using DAL;
//using DTO;

//namespace QL_NhaThieuNhi
//{
//    public partial class QuanLyHocvVien : Form
//    {
//        public QuanLyHocvVien()
//        {
//            InitializeComponent();
//            LoadDanhSachHocVien();
//            ConfigureListView();
//        }

//        public List<HocVien> LoadHocVien()
//        {
//            List<HocVien> danhSachHocVien = new List<HocVien>();

//            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
//            {
//                string query = @"
//            SELECT 
//                MaHocVien, TenHocVien, GioiTinh, NgaySinh, DiaChi, 
//                MaLop, SoDienThoai, TrangThai, MaPhuHuynh, HinhAnh
//            FROM HocVien";

//                SqlCommand command = new SqlCommand(query, conn);

//                try
//                {
//                    conn.Open();
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            HocVien hocVien = new HocVien
//                            {
//                                MaHocVien = reader.GetInt32(0),
//                                TenHocVien = reader.GetString(1),
//                                GioiTinh = reader.GetString(2),
//                                NgaySinh = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
//                                DiaChi = reader.GetString(4),
//                                MaLop = reader.GetInt32(5),
//                                SoDienThoai = reader.GetString(6),
//                                TrangThai = reader.GetString(7),
//                                MaPhuHuynh = reader.GetInt32(8),
//                                HinhAnh = reader.GetString(9)
//                            };

//                            danhSachHocVien.Add(hocVien);
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("Lỗi: " + ex.Message);
//                }
//                finally
//                {
//                    conn.Close();
//                }
//            }

//            return danhSachHocVien;
//        }
//        // Hàm kiểm tra mã học viên có tồn tại
//        private bool KiemTraMaHocVien(string maHocVien)
//        {
//            string connectionString = @"Data Source=DESKTOP-MGLI1G6\HUUPHU;Initial Catalog=QL_NhaThieuNhi;Integrated Security=True";
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                string query = "SELECT COUNT(*) FROM HocVien WHERE MaHocVien = @MaHocVien";
//                using (SqlCommand cmd = new SqlCommand(query, conn))
//                {
//                    cmd.Parameters.AddWithValue("@MaHocVien", maHocVien);
//                    int count = (int)cmd.ExecuteScalar();
//                    return count > 0; // Trả về true nếu tìm thấy
//                }
//            }
//        }
//        private void LoadDanhSachHocVien()
//        {

//            listView_Bang.Items.Clear(); // Xóa dữ liệu cũ

//            List<HocVien> danhSachHocVien = LoadHocVien();

//            foreach (HocVien hv in danhSachHocVien)
//            {
//                ListViewItem item = new ListViewItem(hv.MaHocVien.ToString());
//                item.SubItems.Add(hv.TenHocVien);
//                item.SubItems.Add(hv.HinhAnh);
//                item.SubItems.Add(hv.NgaySinh.HasValue ? hv.NgaySinh.Value.ToString("dd/MM/yyyy") : "");
//                item.SubItems.Add(hv.GioiTinh);
//                item.SubItems.Add(hv.DiaChi);
//                item.SubItems.Add(hv.SoDienThoai);
//                item.SubItems.Add(hv.TrangThai);
//                item.SubItems.Add(hv.MaPhuHuynh.ToString());
//                item.SubItems.Add(hv.MaLop.ToString());

//                // Gán đường dẫn ảnh vào Tag của ListViewItem
//                item.Tag = hv.HinhAnh;

//                listView_Bang.Items.Add(item);
//            }
//        }
//        private void ConfigureListView()
//        {
//            listView_Bang.Columns.Clear();
//            listView_Bang.Columns.Add("Mã Học Viên", 100, HorizontalAlignment.Left);
//            listView_Bang.Columns.Add("Tên Học Viên", 150, HorizontalAlignment.Left);
//            listView_Bang.Columns.Add("Hình Ảnh", 200, HorizontalAlignment.Left);
//            listView_Bang.Columns.Add("Ngày Sinh", 100, HorizontalAlignment.Left);
//            listView_Bang.Columns.Add("Giới Tính", 70, HorizontalAlignment.Left);
//            listView_Bang.Columns.Add("Địa Chỉ", 200, HorizontalAlignment.Left);
//            listView_Bang.Columns.Add("Số Điện Thoại", 100, HorizontalAlignment.Left);
//            listView_Bang.Columns.Add("Trạng Thái", 100, HorizontalAlignment.Left);
//            listView_Bang.Columns.Add("Mã Phụ Huynh", 100, HorizontalAlignment.Left);
//            listView_Bang.Columns.Add("Mã Lớp", 70, HorizontalAlignment.Left);

//            listView_Bang.View = View.Details;
//            listView_Bang.FullRowSelect = true;
//            listView_Bang.GridLines = true;
//        }


//        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            // 1. Kiểm tra thông tin đầu vào
//            if (string.IsNullOrWhiteSpace(txt_MaHV.Text) ||
//                string.IsNullOrWhiteSpace(txt_TenHV.Text) ||
//                (!rdo_Nam.Checked && !rdo_Nu.Checked) ||
//                string.IsNullOrWhiteSpace(txt_DiaChi.Text) ||
//                string.IsNullOrWhiteSpace(txt_SDT.Text))
//            {
//                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            // Kiểm tra định dạng số điện thoại
//            if (!long.TryParse(txt_SDT.Text, out _))
//            {
//                MessageBox.Show("Số điện thoại không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            // 2. Kiểm tra trùng mã HocVien
//            string connectionString = @"Data Source=DESKTOP-MGLI1G6\HUUPHU;Initial Catalog=QL_NhaThieuNhi;Integrated Security=True";
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                string checkQuery = "SELECT COUNT(*) FROM HocVien WHERE MaHocVien = @MaHocVien";
//                using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
//                {
//                    cmd.Parameters.AddWithValue("@MaHocVien", txt_MaHV.Text);
//                    int count = (int)cmd.ExecuteScalar();
//                    if (count > 0)
//                    {
//                        MessageBox.Show("Mã học viên đã tồn tại, vui lòng chọn mã khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        return;
//                    }
//                }

//                // 3. Thêm dữ liệu vào bảng HocVien
//                string insertQuery = @"
//            INSERT INTO HocVien (MaHocVien, TenHocVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, TrangThai, MaPhuHuynh, MaLop, HinhAnh)
//            VALUES (@MaHocVien, @TenHocVien, @GioiTinh, @NgaySinh, @DiaChi, @SoDienThoai, @TrangThai, @MaPhuHuynh, @MaLop, @HinhAnh)";
//                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
//                {
//                    cmd.Parameters.AddWithValue("@MaHocVien", txt_MaHV.Text);
//                    cmd.Parameters.AddWithValue("@TenHocVien", txt_TenHV.Text);
//                    cmd.Parameters.AddWithValue("@GioiTinh", rdo_Nam.Checked ? "Nam" : "Nữ");
//                    cmd.Parameters.AddWithValue("@NgaySinh", dtp_NgaySinh.Value.Date);
//                    cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text);
//                    cmd.Parameters.AddWithValue("@SoDienThoai", txt_SDT.Text);
//                    cmd.Parameters.AddWithValue("@TrangThai", txt_TrangThai.Text);
//                    cmd.Parameters.AddWithValue("@MaPhuHuynh", string.IsNullOrWhiteSpace(txt_MaPhuHuynh.Text) ? DBNull.Value : (object)txt_MaPhuHuynh.Text);
//                    cmd.Parameters.AddWithValue("@MaLop", string.IsNullOrWhiteSpace(txt_MaLop.Text) ? DBNull.Value : (object)txt_MaLop.Text);
//                    cmd.Parameters.AddWithValue("@HinhAnh", txt_HinhAnh.Text);

//                    int rowsAffected = cmd.ExecuteNonQuery();
//                    if (rowsAffected > 0)
//                    {
//                        MessageBox.Show("Thêm học viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        LoadDanhSachHocVien(); // Hàm cập nhật lại ListView sau khi thêm
//                    }
//                    else
//                    {
//                        MessageBox.Show("Đã xảy ra lỗi khi thêm học viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//            }
//        }

//        private void btn_HinhAnh_Click(object sender, EventArgs e)
//        {
//            using (OpenFileDialog ofd = new OpenFileDialog())
//            {
//                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
//                if (ofd.ShowDialog() == DialogResult.OK)
//                {
//                    txt_HinhAnh.Text = ofd.FileName;
//                    ptb_HinhAnh.Image = new Bitmap(ofd.FileName);
//                }
//            }
//        }

//        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            if (listView_Bang.SelectedItems.Count == 0)
//            {
//                MessageBox.Show("Vui lòng chọn một học viên để xóa!", "Thông báo");
//                return;
//            }

//            ListViewItem selectedItem = listView_Bang.SelectedItems[0];
//            int maHocVien = int.Parse(selectedItem.SubItems[0].Text);

//            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
//            {
//                conn.Open();
//                string query = "DELETE FROM HocVien WHERE MaHocVien = @MaHocVien";

//                using (SqlCommand cmd = new SqlCommand(query, conn))
//                {
//                    cmd.Parameters.AddWithValue("@MaHocVien", maHocVien);
//                    cmd.ExecuteNonQuery();
//                    MessageBox.Show("Xóa Học Viên thành công!", "Thông báo");

//                    // Xóa khỏi listView
//                    listView_Bang.Items.Remove(selectedItem);
//                }
//            }
//        }

//        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            // 1. Kiểm tra mã học viên
//            if (string.IsNullOrWhiteSpace(txt_MaHV.Text))
//            {
//                MessageBox.Show("Vui lòng nhập mã học viên để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            string maHocVien = txt_MaHV.Text.Trim();

//            // Kiểm tra mã học viên có tồn tại trong cơ sở dữ liệu
//            if (!KiemTraMaHocVien(maHocVien))
//            {
//                MessageBox.Show($"Không tìm thấy học viên với mã {maHocVien}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // 2. Hiển thị hộp thoại xác nhận
//            DialogResult confirmResult = MessageBox.Show(
//                $"Bạn có chắc chắn muốn sửa học viên có mã {maHocVien} không?",
//                "Xác nhận sửa",
//                MessageBoxButtons.YesNo,
//                MessageBoxIcon.Question);

//            if (confirmResult == DialogResult.Yes)
//            {
//                // 3. Lấy thông tin mới từ các TextBox
//                string tenHocVien = txt_TenHV.Text.Trim();
//                string gioiTinh = rdo_Nam.Checked ? "Nam" : "Nữ";
//                DateTime ngaySinh = dtp_NgaySinh.Value;
//                string diaChi = txt_DiaChi.Text.Trim();
//                string soDienThoai = txt_SDT.Text.Trim();
//                string trangThai = txt_TrangThai.Text.Trim();
//                string maLop = txt_MaLop.Text.Trim();
//                string maPhuHuynh = txt_MaPhuHuynh.Text.Trim();

//                // Lấy ảnh từ PictureBox nếu có
//                string hinhAnh = "";  // Nếu bạn có hỗ trợ ảnh, xử lý như sau:
//                if (ptb_HinhAnh.Image != null)
//                {
//                    hinhAnh = SaveImageToFile(ptb_HinhAnh.Image); // Hàm lưu ảnh
//                }

//                // 4. Kết nối SQL để cập nhật thông tin
//                string connectionString = @"Data Source=DESKTOP-MGLI1G6\HUUPHU;Initial Catalog=QL_NhaThieuNhi;Integrated Security=True";
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    string updateQuery = @"
//                UPDATE HocVien
//                SET TenHocVien = @TenHocVien,
//                    GioiTinh = @GioiTinh,
//                    NgaySinh = @NgaySinh,
//                    DiaChi = @DiaChi,
//                    SoDienThoai = @SoDienThoai,
//                    TrangThai = @TrangThai,
//                    MaLop = @MaLop,
//                    MaPhuHuynh = @MaPhuHuynh,
//                    HinhAnh = @HinhAnh
//                WHERE MaHocVien = @MaHocVien";

//                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@MaHocVien", maHocVien);
//                        cmd.Parameters.AddWithValue("@TenHocVien", tenHocVien);
//                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
//                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
//                        cmd.Parameters.AddWithValue("@DiaChi", diaChi);
//                        cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
//                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
//                        cmd.Parameters.AddWithValue("@MaLop", maLop);
//                        cmd.Parameters.AddWithValue("@MaPhuHuynh", maPhuHuynh);
//                        cmd.Parameters.AddWithValue("@HinhAnh", hinhAnh);  // Cập nhật ảnh (nếu có)

//                        try
//                        {
//                            int rowsAffected = cmd.ExecuteNonQuery();
//                            if (rowsAffected > 0)
//                            {
//                                MessageBox.Show("Sửa thông tin học viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                                LoadDanhSachHocVien(); // Tải lại dữ liệu
//                            }
//                            else
//                            {
//                                MessageBox.Show("Không thể sửa thông tin học viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                            }
//                        }
//                        catch (Exception ex)
//                        {
//                            MessageBox.Show("Lỗi khi sửa thông tin học viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        }
//                    }
//                }
//            }
//        }

//        // Hàm lưu ảnh vào thư mục và trả về đường dẫn của ảnh
//        private string SaveImageToFile(Image image)
//        {
//            string directoryPath = Path.Combine(Application.StartupPath, @"img\HocVien");
//            if (!Directory.Exists(directoryPath))
//            {
//                Directory.CreateDirectory(directoryPath);
//            }

//            string fileName = Guid.NewGuid().ToString() + ".jpg"; // Tạo tên file ảnh duy nhất
//            string filePath = Path.Combine(directoryPath, fileName);
//            image.Save(filePath); // Lưu ảnh vào file

//            return filePath; // Trả về đường dẫn ảnh đã lưu
//        }
//        private void listView_Bang_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (listView_Bang.SelectedItems.Count > 0) // Kiểm tra nếu có dòng được chọn
//            {
//                ListViewItem selectedItem = listView_Bang.SelectedItems[0]; // Lấy dòng được chọn

//                // Hiển thị dữ liệu lên các control
//                txt_MaHV.Text = selectedItem.SubItems[0].Text; // Mã học viên
//                txt_TenHV.Text = selectedItem.SubItems[1].Text; // Tên học viên

//                // Xử lý giới tính
//                if (selectedItem.SubItems[4].Text == "Nam")
//                {
//                    rdo_Nam.Checked = true;
//                }
//                else if (selectedItem.SubItems[4].Text == "Nữ")
//                {
//                    rdo_Nu.Checked = true;
//                }

//                // Ngày sinh
//                if (DateTime.TryParse(selectedItem.SubItems[3].Text, out DateTime ngaySinh))
//                {
//                    dtp_NgaySinh.Value = ngaySinh;
//                }
//                else
//                {
//                    dtp_NgaySinh.Value = DateTime.Now;
//                }

//                txt_DiaChi.Text = selectedItem.SubItems[5].Text; // Địa chỉ
//                txt_MaLop.Text = selectedItem.SubItems[9].Text; // Mã lớp
//                txt_SDT.Text = selectedItem.SubItems[6].Text; // Số điện thoại
//                txt_TrangThai.Text = selectedItem.SubItems[7].Text; // Trạng thái
//                txt_MaPhuHuynh.Text = selectedItem.SubItems[8].Text; // Mã phụ huynh
//                txt_HinhAnh.Text = selectedItem.SubItems[2].Text; // Hình ảnh
//                                                                  // Đường dẫn tương đối đến thư mục chứa ảnh trong dự án
//                string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
//                string imagePath = Path.Combine(projectPath, "img", "hv", selectedItem.SubItems[2].Text); // Cột 8 chứa tên file ảnh

//                // Kiểm tra sự tồn tại của ảnh và hiển thị lên PictureBox
//                if (File.Exists(imagePath))
//                {
//                    ptb_HinhAnh.Image = new Bitmap(imagePath);
//                    ptb_HinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
//                }
//                else
//                {
//                    ptb_HinhAnh.Image = null;
//                    MessageBox.Show($"Ảnh không tồn tại tại đường dẫn: {imagePath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }

//            }

//        }
//        private void TimKiemHocVien(string tenHocVien)
//        {
//            // Xóa dữ liệu cũ trong ListView
//            listView_Bang.Items.Clear();

//            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
//            {
//                conn.Open();
//                string query = @"
//    SELECT MaHocVien, TenHocVien,HinhAnh, GioiTinh, NgaySinh, DiaChi, SoDienThoai, TrangThai, MaPhuHuynh, MaLop 
//    FROM HocVien 
//    WHERE TenHocVien LIKE @TenHocVien";

//                using (SqlCommand cmd = new SqlCommand(query, conn))
//                {
//                    cmd.Parameters.AddWithValue("@TenHocVien", "%" + tenHocVien + "%");

//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            // Thêm từng dòng dữ liệu vào ListView
//                            ListViewItem item = new ListViewItem(reader["MaHocVien"].ToString());
//                            item.SubItems.Add(reader["TenHocVien"].ToString());
//                            item.SubItems.Add(reader["HinhAnh"].ToString());
//                            item.SubItems.Add(reader["GioiTinh"].ToString());
//                            item.SubItems.Add(Convert.ToDateTime(reader["NgaySinh"]).ToShortDateString());
//                            item.SubItems.Add(reader["DiaChi"].ToString());
//                            item.SubItems.Add(reader["SoDienThoai"].ToString());
//                            item.SubItems.Add(reader["TrangThai"].ToString());
//                            item.SubItems.Add(reader["MaPhuHuynh"].ToString());  // Mã phụ huynh liên kết
//                            item.SubItems.Add(reader["MaLop"].ToString());  // Mã lớp học

//                            listView_Bang.Items.Add(item);
//                        }
//                    }
//                }
//            }
//        }
//        private void ptb_HinhAnh_Click(object sender, EventArgs e)
//        {
//            ptb_HinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
//        }

//        private void btn_TimKiem_Click(object sender, EventArgs e)
//        {
//            string tenHocVien = txt_TimKiem.Text.Trim();

//            if (string.IsNullOrEmpty(tenHocVien))
//            {
//                MessageBox.Show("Vui lòng nhập tên học viên cần tìm.", "Thông báo");
//                return;
//            }

//            // Tìm kiếm trong cơ sở dữ liệu
//            TimKiemHocVien(tenHocVien);

//        }
//    }
//}
