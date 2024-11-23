using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
namespace QL_NhaThieuNhi
{
    public partial class QuanLyPhuHuynh : Form
    {

        public QuanLyPhuHuynh()
        {
            InitializeComponent();
            SetupListView();
            LoadDataToListView();
            listView_Bang.SelectedIndexChanged += listView_Bang_SelectedIndexChanged;

        }


        private bool ValidateInput()
        {
            // Kiểm tra các trường dữ liệu không được để trống
            if (string.IsNullOrWhiteSpace(txt_MaPH.Text))
            {
                MessageBox.Show("Mã phụ huynh không được để trống.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_TenPH.Text))
            {
                MessageBox.Show("Tên phụ huynh không được để trống.");
                return false;
            }
            if (rdo_Nam.Checked == false && rdo_Nu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Nghenghiep.Text))
            {
                MessageBox.Show("Nghề nghiệp không được để trống.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_DiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                MessageBox.Show("Email không được để trống.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_SDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.");
                return false;
            }
            return true;
        }
        private bool IsDuplicateMaPhuHuynh(int maPhuHuynh)
        {
            foreach (ListViewItem item in listView_Bang.Items)
            {
                if (item.SubItems[0].Text == maPhuHuynh.ToString())
                {
                    return true; // Nếu mã phụ huynh trùng, trả về true
                }
            }
            return false; // Không trùng
        }
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaPH.Text) || string.IsNullOrEmpty(txt_TenPH.Text) ||
                string.IsNullOrEmpty(txt_DiaChi.Text) || string.IsNullOrEmpty(txt_SDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            int maPhuHuynh;
            if (!int.TryParse(txt_MaPH.Text, out maPhuHuynh))
            {
                MessageBox.Show("Mã phụ huynh phải là số!", "Lỗi");
                return;
            }

            string tenPhuHuynh = txt_TenPH.Text;
            string gioiTinh = rdo_Nam.Checked ? "Nam" : "Nữ";
            DateTime ngaySinh = dtp_NgaySinh.Value;
            string ngheNghiep = txt_Nghenghiep.Text;
            string diaChi = txt_DiaChi.Text;
            string email = txt_Email.Text;
            string soDienThoai = txt_SDT.Text;


            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                conn.Open();
                string query = @"
            IF EXISTS (SELECT 1 FROM PhuHuynh WHERE MaPhuHuynh = @MaPhuHuynh)
            BEGIN
                THROW 51000, 'Mã phụ huynh đã tồn tại!', 1;
            END
            ELSE
            BEGIN
                INSERT INTO PhuHuynh 
                (MaPhuHuynh, TenPhuHuynh, GioiTinh, NgaySinh, NgheNghiep, DiaChi, Email, SoDienThoai) 
                VALUES 
                (@MaPhuHuynh, @TenPhuHuynh, @GioiTinh, @NgaySinh, @NgheNghiep, @DiaChi, @Email, @SoDienThoai);
            END";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhuHuynh", maPhuHuynh);
                    cmd.Parameters.AddWithValue("@TenPhuHuynh", tenPhuHuynh);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@NgheNghiep", ngheNghiep);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);


                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm phụ huynh thành công!", "Thông báo");
                        // Thêm vào listView
                        ListViewItem item = new ListViewItem(maPhuHuynh.ToString());
                        item.SubItems.Add(tenPhuHuynh);
                        item.SubItems.Add(ngaySinh.ToShortDateString());
                        item.SubItems.Add(gioiTinh);
                        
                        item.SubItems.Add(ngheNghiep);
                        item.SubItems.Add(diaChi);
                        item.SubItems.Add(email);
                        item.SubItems.Add(soDienThoai);

                        listView_Bang.Items.Add(item);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi");
                    }
                }
            }
        }


        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_Bang.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phụ huynh để xóa!", "Thông báo");
                return;
            }

            ListViewItem selectedItem = listView_Bang.SelectedItems[0];
            int maPhuHuynh = int.Parse(selectedItem.SubItems[0].Text);

            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                conn.Open();
                string query = "DELETE FROM PhuHuynh WHERE MaPhuHuynh = @MaPhuHuynh";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhuHuynh", maPhuHuynh);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa phụ huynh thành công!", "Thông báo");

                    // Xóa khỏi listView
                    listView_Bang.Items.Remove(selectedItem);
                }
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_Bang.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phụ huynh để sửa!", "Thông báo");
                return;
            }

            ListViewItem selectedItem = listView_Bang.SelectedItems[0];
            int maPhuHuynh = int.Parse(selectedItem.SubItems[0].Text);

            string tenPhuHuynh = txt_TenPH.Text;
            string gioiTinh = rdo_Nam.Checked ? "Nam" : "Nữ";
            DateTime ngaySinh = dtp_NgaySinh.Value;
            string ngheNghiep = txt_Nghenghiep.Text;
            string diaChi = txt_DiaChi.Text;
            string email = txt_Email.Text;
            string soDienThoai = txt_SDT.Text;

            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                conn.Open();
                string query = @"
            UPDATE PhuHuynh
            SET 
                TenPhuHuynh = @TenPhuHuynh,
                GioiTinh = @GioiTinh,
                NgaySinh = @NgaySinh,
                NgheNghiep = @NgheNghiep,
                DiaChi = @DiaChi,
                Email = @Email,
                SoDienThoai = @SoDienThoai
            WHERE MaPhuHuynh = @MaPhuHuynh";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhuHuynh", maPhuHuynh);
                    cmd.Parameters.AddWithValue("@TenPhuHuynh", tenPhuHuynh);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@NgheNghiep", ngheNghiep);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật phụ huynh thành công!", "Thông báo");

                        // Cập nhật trên listView
                        selectedItem.SubItems[1].Text = tenPhuHuynh;
                        selectedItem.SubItems[3].Text = gioiTinh;
                        selectedItem.SubItems[2].Text = ngaySinh.ToShortDateString();
                        selectedItem.SubItems[4].Text = ngheNghiep;
                        selectedItem.SubItems[5].Text = diaChi;
                        selectedItem.SubItems[6].Text = email;
                        selectedItem.SubItems[7].Text = soDienThoai;
                    }
                    else
                    {
                        MessageBox.Show("Không có thay đổi nào được thực hiện!", "Thông báo");
                    }
                }
            }
        }

   

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            var keyword = txt_TimKiem.Text;
        }

        private void SetupListView()
        {
            listView_Bang.View = View.Details;
            listView_Bang.Columns.Add("Mã Phụ Huynh");
            listView_Bang.Columns.Add("Tên Phụ Huynh");
            listView_Bang.Columns.Add("Ngày Sinh");
            listView_Bang.Columns.Add("Giới Tính");
            listView_Bang.Columns.Add("Nghề Nghiệp");
            listView_Bang.Columns.Add("Địa Chỉ");
            listView_Bang.Columns.Add("Email");
            listView_Bang.Columns.Add("Số Điện Thoại");
        }

        private void LoadDataToListView()
        {
            listView_Bang.Items.Clear(); // Xóa các mục cũ trong ListView

            using (SqlConnection conn = ConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM PhuHuynh"; // Truy vấn lấy thông tin phụ huynh
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["MaPhuHuynh"].ToString());
                            item.SubItems.Add(reader["TenPhuHuynh"].ToString());
                            item.SubItems.Add(reader["NgaySinh"].ToString());
                            item.SubItems.Add(reader["GioiTinh"].ToString());
                            item.SubItems.Add(reader["NgheNghiep"].ToString());
                            item.SubItems.Add(reader["DiaChi"].ToString());
                            item.SubItems.Add(reader["Email"].ToString());
                            item.SubItems.Add(reader["SoDienThoai"].ToString());
                            listView_Bang.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }




        private void listView_Bang_ItemActivate_1(object sender, EventArgs e)
        {

            if (listView_Bang.SelectedItems.Count > 0)
            {
                ListViewItem item = listView_Bang.SelectedItems[0]; // Lấy mục được chọn

                // Gán giá trị từ ListView vào các TextBox
                txt_MaPH.Text = item.SubItems[0].Text;         // Mã Phụ Huynh
                txt_TenPH.Text = item.SubItems[1].Text;        // Tên Phụ Huynh
                dtp_NgaySinh.Value = DateTime.Parse(item.SubItems[2].Text); // Ngày Sinh
                if (item.SubItems[3].Text == "Nam")
                    rdo_Nam.Checked = true;
                else
                    rdo_Nu.Checked = true; // Giới tính

                txt_Nghenghiep.Text = item.SubItems[4].Text;   // Nghề Nghiệp
                txt_DiaChi.Text = item.SubItems[5].Text;       // Địa Chỉ
                txt_Email.Text = item.SubItems[6].Text;        // Email
                txt_SDT.Text = item.SubItems[7].Text;          // Số Điện Thoại
            }
        }

        private void listView_Bang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có mục nào được chọn
            if (listView_Bang.SelectedItems.Count > 0)
            {
                // Lấy mục đầu tiên được chọn
                ListViewItem item = listView_Bang.SelectedItems[0];

                // Hiển thị thông tin trong MessageBox để kiểm tra
                MessageBox.Show("Đã chọn: " + item.SubItems[0].Text);

                // Gán giá trị từ ListView vào các TextBox
                txt_MaPH.Text = item.SubItems[0].Text;
                txt_TenPH.Text = item.SubItems[1].Text;
                dtp_NgaySinh.Value = DateTime.Parse(item.SubItems[3].Text);
                if (item.SubItems[2].Text == "Nam")
                    rdo_Nam.Checked = true;
                else
                    rdo_Nu.Checked = true;
                txt_Nghenghiep.Text = item.SubItems[4].Text;
                txt_DiaChi.Text = item.SubItems[5].Text;
                txt_Email.Text = item.SubItems[6].Text;
                txt_SDT.Text = item.SubItems[7].Text;
            }
        }
        private void TimKiemPhuHuynh(string tenPhuHuynh)
        {
            // Xóa dữ liệu cũ trong ListView
            listView_Bang.Items.Clear();

            using (SqlConnection conn = new SqlConnection(ConnectionData.GetConnectionString()))
            {
                conn.Open();
                string query = @"
            SELECT MaPhuHuynh, TenPhuHuynh, GioiTinh, NgaySinh, NgheNghiep, DiaChi, Email, SoDienThoai 
            FROM PhuHuynh 
            WHERE TenPhuHuynh LIKE @TenPhuHuynh";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenPhuHuynh", "%" + tenPhuHuynh + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Thêm từng dòng dữ liệu vào ListView
                            ListViewItem item = new ListViewItem(reader["MaPhuHuynh"].ToString());
                            item.SubItems.Add(reader["TenPhuHuynh"].ToString());
                            item.SubItems.Add(reader["GioiTinh"].ToString());
                            item.SubItems.Add(Convert.ToDateTime(reader["NgaySinh"]).ToShortDateString());
                            item.SubItems.Add(reader["NgheNghiep"].ToString());
                            item.SubItems.Add(reader["DiaChi"].ToString());
                            item.SubItems.Add(reader["Email"].ToString());
                            item.SubItems.Add(reader["SoDienThoai"].ToString());

                            listView_Bang.Items.Add(item);
                        }
                    }
                }
            }

            // Kiểm tra nếu không có kết quả, hiển thị thông báo
            if (listView_Bang.Items.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phụ huynh với tên này.", "Thông báo");
            }
        }

        private void btn_TimKiem_Click_1(object sender, EventArgs e)
        {
            string tenPhuHuynh = txt_TimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tenPhuHuynh))
            {
                MessageBox.Show("Vui lòng nhập tên phụ huynh cần tìm.", "Thông báo");
                return;
            }

            // Tìm kiếm trong cơ sở dữ liệu
            TimKiemPhuHuynh(tenPhuHuynh);
        }
    }
}
