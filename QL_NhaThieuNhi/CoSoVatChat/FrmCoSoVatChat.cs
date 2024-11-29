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
using DocumentFormat.OpenXml.Spreadsheet;

namespace QL_NhaThieuNhi.CoSoVatChat
{
    public partial class FrmCoSoVatChat : Form
    {
        public FrmCoSoVatChat()
        {
            InitializeComponent();
            LoadCoSoVatChat();
            LoaiCoSo();
            LoadLoaiCoSo();
            // Đăng ký sự kiện CellClick cho DataGridView CoSoVatChat
            this.dgvCoSoVatChat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCoSoVatChat_CellClick);

            // Đăng ký sự kiện SelectedIndexChanged cho ComboBox Lọc
            this.cbLoc.SelectedIndexChanged += new System.EventHandler(this.cbLoc_SelectedIndexChanged);

            // Đăng ký sự kiện TextChanged cho TextBox Tìm Kiếm
            this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);

        }
        private void LoadLoaiCoSo()
        {
            try
            {
                // Lấy danh sách loại cơ sở từ DataGridView
                var loaiCoSoList = dgvCoSoVatChat.Rows
                    .Cast<DataGridViewRow>()
                    .Where(row => row.Cells["LoaiCoSo"].Value != null) // Bỏ qua các giá trị null
                    .Select(row => row.Cells["LoaiCoSo"].Value.ToString())
                    .Distinct() // Loại bỏ các giá trị trùng lặp
                    .ToList();

                // Thêm "Tất Cả" vào danh sách
                loaiCoSoList.Insert(0, "Tất Cả");

                // Gán danh sách vào ComboBox
                cb_LoaiCoSo.DataSource = loaiCoSoList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải loại cơ sở: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCoSoVatChat()
        {
            try
            {
                dgvCoSoVatChat.DataSource = CoSoVatChatBLL.LayTatCaCoSoVatChat();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách cơ sở vật chất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<string> loaiCoSos = new List<string>
{
    "Tất Cả", "Bảng", "Ghế", "Thiết bị điện tử", "Sách", "Đồ dùng học tập"
};
        private void LoaiCoSo()
        {
            try
            {
                // Giả sử bạn có danh sách mã lớp trong biến 'maLops'
                cbLoc.DataSource = loaiCoSos; // Gán danh sách lớp học vào ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải mã lớp: " + ex.Message);
            }
        }

        private void dgvCoSoVatChat_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (e.RowIndex >= 0)
                {
                    var row = dgvCoSoVatChat.Rows[e.RowIndex]; // Lấy dòng được chọn

                    // Cập nhật các trường nhập với dữ liệu từ dòng được chọn
                    txt_MaCSVC.Text = row.Cells["MaCSVC"].Value.ToString(); // Cập nhật mã cơ sở vật chất
                    txt_TenCoSo.Text = row.Cells["TenCoSo"].Value.ToString(); // Cập nhật tên cơ sở
                    txt_HinhAnh.Text = row.Cells["HinhAnh"].Value.ToString(); // Cập nhật hình ảnh

                    // Cập nhật loại cơ sở (ComboBox)
                    var loaiCoSo = row.Cells["LoaiCoSo"].Value.ToString();
                    if (cb_LoaiCoSo.Items.Contains(loaiCoSo))
                    {
                        cb_LoaiCoSo.SelectedItem = loaiCoSo;
                    }
                    else
                    {
                        cb_LoaiCoSo.SelectedIndex = -1; // Nếu không tìm thấy, đặt giá trị mặc định
                    }

                    txt_SoLuong.Text = row.Cells["SoLuong"].Value?.ToString(); // Cập nhật số lượng (nếu có)

                    // Hiển thị hình ảnh (nếu có) từ đường dẫn
                    if (!string.IsNullOrEmpty(txt_HinhAnh.Text) && System.IO.File.Exists(txt_HinhAnh.Text))
                    {
                        ptb_HinhAnh.Image = Image.FromFile(txt_HinhAnh.Text);
                    }
                    else
                    {
                        ptb_HinhAnh.Image = null; // Nếu không có ảnh hoặc đường dẫn không hợp lệ, đặt về null
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi chọn dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                var loaiCoSo = cbLoc.SelectedItem.ToString(); // Lấy giá trị loại cơ sở từ ComboBox

                if (loaiCoSo == "Tất Cả")
                {
                    // Nếu chọn "Tất Cả", load lại toàn bộ danh sách cơ sở vật chất
                    LoadCoSoVatChat();
                }
                else
                {
                    // Lọc cơ sở vật chất theo loại
                    var danhSachCoSo = CoSoVatChatBLL.LocCoSoVatChatTheoLoai(loaiCoSo);
                    dgvCoSoVatChat.DataSource = danhSachCoSo; // Gán dữ liệu cho DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi lọc cơ sở vật chất theo loại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string keyword = txt_TimKiem.Text.ToLower(); // Chuyển từ khóa tìm kiếm thành chữ thường

                // Lấy tất cả danh sách cơ sở vật chất
                var danhSachCoSo = CoSoVatChatBLL.LayTatCaCoSoVatChat();

                // Lọc danh sách cơ sở vật chất theo từ khóa tìm kiếm, không phân biệt hoa thường
                var filteredCoSo = danhSachCoSo.Where(coSo =>
                    coSo.TenCoSo.ToLower().Contains(keyword) ||      // So sánh tên cơ sở
                    coSo.LoaiCoSo.ToLower().Contains(keyword) ||    // So sánh loại cơ sở
                    coSo.SoLuong.ToString().Contains(keyword)       // So sánh số lượng (chuyển thành chuỗi)
                ).ToList();

                // Gán lại danh sách đã lọc cho DataGridView
                dgvCoSoVatChat.DataSource = filteredCoSo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message);
            }
        }

        private void btn_addNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các điều khiển
                var MaCSVC = Convert.ToInt32(txt_MaCSVC.Text);
                var TenCoSo = txt_TenCoSo.Text;
                var HinhAnh = txt_HinhAnh.Text;
                var LoaiCoSo = cb_LoaiCoSo.SelectedValue?.ToString(); // Lấy mã loại cơ sở từ ComboBox
                var SoLuong = Convert.ToInt32(txt_SoLuong.Text);

                // Kiểm tra dữ liệu nhập
                if (string.IsNullOrEmpty(TenCoSo) || string.IsNullOrEmpty(LoaiCoSo) || SoLuong <= 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin cơ sở vật chất.");
                    return;
                }

                if (!string.IsNullOrEmpty(HinhAnh) && !File.Exists(HinhAnh))
                {
                    MessageBox.Show("Không tìm thấy hình ảnh tại đường dẫn: " + HinhAnh);
                    return;
                }

                // Tạo đối tượng cơ sở vật chất mới
                var coSoMoi = new DTO.CoSoVatChat
                {
                    MaCSVC = MaCSVC,
                    TenCoSo = TenCoSo,
                    HinhAnh = HinhAnh,
                    LoaiCoSo = LoaiCoSo,
                    SoLuong = SoLuong
                };

                // Thêm cơ sở vật chất thông qua BLL
                if (CoSoVatChatBLL.ThemCoSoVatChat(coSoMoi))
                {
                    MessageBox.Show("Thêm cơ sở vật chất thành công!");
                    LoadCoSoVatChat();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm cơ sở vật chất.");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm cơ sở vật chất: " + ex.Message);
            }
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


        private void txt_HinhAnh_TextChanged(object sender, EventArgs e)
        {
            HienHinhAnh();
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgvCoSoVatChat.SelectedRows.Count > 0)
            {
                // Lấy mã cơ sở vật chất từ cột trong DataGridView
                int maCSVC = Convert.ToInt32(dgvCoSoVatChat.SelectedRows[0].Cells["MaCSVC"].Value);

                try
                {
                    if (MessageBox.Show($"Bạn có chắc chắn muốn xóa cơ sở vật chất có mã {maCSVC}?",
                                        "Xác nhận",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (CoSoVatChatBLL.XoaCoSoVatChat(maCSVC)) // Gọi BLL xóa
                        {
                            MessageBox.Show("Xóa cơ sở vật chất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCoSoVatChat(); // Cập nhật lại danh sách sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy cơ sở vật chất để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa cơ sở vật chất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cơ sở vật chất để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
