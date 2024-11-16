using BLL;
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

namespace QL_NhaThieuNhi.NhanVienGUI
{
    public partial class AddNhanVien : Form
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public AddNhanVien()
        {
            InitializeComponent();
        }

        private void link_img_MouseClick(object sender, MouseEventArgs e)
        {
            // Mở hộp thoại chọn file hình ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                img_NV.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
        private string ConvertImageToBase64(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);  // Lưu hình ảnh vào MemoryStream
                byte[] imageBytes = ms.ToArray(); // Chuyển đổi thành mảng byte
                return Convert.ToBase64String(imageBytes); // Chuyển đổi mảng byte thành chuỗi Base64
            }
        }

        private void btn_ThemNhanVien_Click(object sender, EventArgs e)
        {
            // Lấy thông tin nhân viên từ các trường nhập liệu
            DTO.NhanVien nhanVien = new DTO.NhanVien
            {
                TenNhanVien = txt_Name.Text,
                ChucVu = cb_ChucVu.SelectedItem?.ToString(),
                ChuyenMon = cb_ChuyenMon.SelectedItem?.ToString(),  // Lấy giá trị Chuyên môn từ ComboBox
                TrangThai = cb_TrangThai.SelectedItem?.ToString(),
                NgaySinh = dt_NgaySinh.Value,
                SoDienThoai = txt_SDT.Text,
                Email = txt_email.Text,
                GioiTinh = rd_Nam.Checked ? "Nam" : (rd_Nu.Checked ? "Nữ" : ""),
                HinhAnh = img_NV.Image != null ? ConvertImageToBase64(img_NV.Image) : "", 
                Luong = decimal.TryParse(txt_Luong.Text, out decimal luong) ? luong : (decimal?)null // Lương
            };
            bool success = nhanVienBLL.AddNhanVien(nhanVien);

            if (success)
            {
                MessageBox.Show("Thêm nhân viên thành công.");
                this.DialogResult = DialogResult.OK;  
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm nhân viên.");
            }
        }

        private void AddNhanVien_Load(object sender, EventArgs e)
        {
            // Dữ liệu cho ComboBox Chức Vụ
            cb_ChucVu.Items.Add("Giám Đốc");
            cb_ChucVu.Items.Add("Nhân Viên");
            cb_ChucVu.Items.Add("Kỹ Thuật Viên");
            // Bạn có thể thêm các giá trị khác nếu cần
            cb_ChucVu.SelectedIndex = 0;  // Đặt mặc định cho ComboBox nếu cần

            // Dữ liệu cho ComboBox Chuyên Môn
            cb_ChuyenMon.Items.Add("Quản Lý");
            cb_ChuyenMon.Items.Add("Kế Toán");
            cb_ChuyenMon.Items.Add("IT");
            // Bạn có thể thêm các giá trị khác nếu cần
            cb_ChuyenMon.SelectedIndex = 0;  // Đặt mặc định cho ComboBox nếu cần

            // Dữ liệu cho ComboBox Trạng Thái
            cb_TrangThai.Items.Add("Đang làm việc");
            cb_TrangThai.Items.Add("Đã nghỉ việc");
            // Bạn có thể thêm các giá trị khác nếu cần
            cb_TrangThai.SelectedIndex = 0;  // Đặt mặc định cho ComboBox nếu cần
        }
    }
}
