using BLL;
using DTO;
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
        private DTO.NhanVien nhanVien;

        public AddNhanVien()
        {
            InitializeComponent();
        }

        // Constructor nhận một tham số NhanVien
        public AddNhanVien(DTO.NhanVien nhanVien) : this()
        {
            this.nhanVien = nhanVien;
            LoadNhanVienInfo();
        }

        private void LoadNhanVienInfo()
        {
            if (nhanVien != null)
            {
                txt_MaNV.Text = nhanVien.MaNhanVien.ToString();
                txt_Name.Text = nhanVien.TenNhanVien;
                cb_ChucVu.SelectedItem = nhanVien.ChucVu;
                cb_ChuyenMon.SelectedItem = nhanVien.ChuyenMon;
                cb_TrangThai.SelectedItem = nhanVien.TrangThai;
                dt_NgaySinh.Value = nhanVien.NgaySinh.HasValue ? nhanVien.NgaySinh.Value : DateTime.Now;
                txt_SDT.Text = nhanVien.SoDienThoai;
                txt_email.Text = nhanVien.Email;
                if (nhanVien.GioiTinh == "Nam")
                    rd_Nam.Checked = true;
                else if (nhanVien.GioiTinh == "Nữ")
                    rd_Nu.Checked = true;
                if (nhanVien.HinhAnh != null)
                {
                    Image originalImage = ByteArrayToImage(nhanVien.HinhAnh);
                    img_NV.Image = ResizeImage(originalImage, 257, 278); // Sử dụng hàm ResizeImage
                }
                txt_Luong.Text = nhanVien.Luong.HasValue ? nhanVien.Luong.Value.ToString() : string.Empty;
                cb_TaiKhoan.SelectedValue = nhanVien.MaTaiKhoan;
                cb_PhongBan.SelectedValue = nhanVien.MaPhongBan;
            }
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            float aspectRatio = (float)image.Width / image.Height;
            int newWidth, newHeight;

            if (image.Width > image.Height)
            {
                newWidth = width;
                newHeight = (int)(width / aspectRatio);
            }
            else
            {
                newHeight = height;
                newWidth = (int)(height * aspectRatio);
            }

            Bitmap resizedBitmap = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(resizedBitmap))
            {
                g.Clear(Color.White);
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return resizedBitmap;
        }




        private byte[] ConvertImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void btn_ThemNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.NhanVien nhanVien = new DTO.NhanVien
                {
                    MaNhanVien = int.Parse(txt_MaNV.Text),
                    TenNhanVien = txt_Name.Text,
                    ChucVu = cb_ChucVu.SelectedItem?.ToString(),
                    ChuyenMon = cb_ChuyenMon.SelectedItem?.ToString(),
                    TrangThai = cb_TrangThai.SelectedItem?.ToString(),
                    NgaySinh = dt_NgaySinh.Value,
                    SoDienThoai = txt_SDT.Text,
                    Email = txt_email.Text,
                    GioiTinh = rd_Nam.Checked ? "Nam" : (rd_Nu.Checked ? "Nữ" : ""),
                    HinhAnh = img_NV.Image != null ? ConvertImageToByteArray(img_NV.Image) : null,
                    Luong = decimal.TryParse(txt_Luong.Text, out decimal luong) ? luong : (decimal?)null,
                    MaTaiKhoan = (int)cb_TaiKhoan.SelectedValue, // Lấy mã tài khoản từ combobox
                    MaPhongBan = (int)cb_PhongBan.SelectedValue  // Lấy mã phòng ban từ combobox
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
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void AddNhanVien_Load(object sender, EventArgs e)
        {
            cb_ChucVu.Items.Add("Giám Đốc");
            cb_ChucVu.Items.Add("Nhân Viên");
            cb_ChucVu.Items.Add("Kỹ Thuật Viên");
            cb_ChucVu.SelectedIndex = 0;
            cb_ChuyenMon.Items.Add("Quản Lý");
            cb_ChuyenMon.Items.Add("Kế Toán");
            cb_ChuyenMon.Items.Add("IT");
            cb_ChuyenMon.SelectedIndex = 0;
            cb_TrangThai.Items.Add("Đang làm việc");
            cb_TrangThai.Items.Add("Đã nghỉ việc");
            cb_TrangThai.SelectedIndex = 0;

            LoadTaiKhoanComboBox();
            LoadPhongBanComboBox();
        }

        private void LoadTaiKhoanComboBox()
        {
            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
            List<DTO.TaiKhoan> danhSachTaiKhoan = taiKhoanBLL.LoadTaiKhoan();
            cb_TaiKhoan.DataSource = danhSachTaiKhoan;
            cb_TaiKhoan.DisplayMember = "TenDangNhap"; // Hiển thị tên tài khoản
            cb_TaiKhoan.ValueMember = "MaTaiKhoan"; // Giá trị là mã tài khoản
        }

        private void LoadPhongBanComboBox()
        {
            PhongBanBLL phongBanBLL = new PhongBanBLL();
            List<PhongBan> danhSachPhongBan = phongBanBLL.LoadPhongBan();
            cb_PhongBan.DataSource = danhSachPhongBan;
            cb_PhongBan.DisplayMember = "TenPhongBan";
            cb_PhongBan.ValueMember = "MaPhongBan";
        }



        private void btn_AddImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy hình ảnh đã chọn
                Image originalImage = Image.FromFile(openFileDialog.FileName);

                // Thay đổi kích thước hình ảnh về 257x278
                Image resizedImage = ResizeImage(originalImage, 257, 278);

                // Gán hình ảnh đã thay đổi kích thước vào PictureBox
                img_NV.Image = resizedImage;
            }
        }

        private void img_NV_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.NhanVien nhanVien = new DTO.NhanVien
                {
                    MaNhanVien = int.Parse(txt_MaNV.Text),
                    TenNhanVien = txt_Name.Text,
                    ChucVu = cb_ChucVu.SelectedItem?.ToString(),
                    ChuyenMon = cb_ChuyenMon.SelectedItem?.ToString(),
                    TrangThai = cb_TrangThai.SelectedItem?.ToString(),
                    NgaySinh = dt_NgaySinh.Value,
                    SoDienThoai = txt_SDT.Text,
                    Email = txt_email.Text,
                    GioiTinh = rd_Nam.Checked ? "Nam" : (rd_Nu.Checked ? "Nữ" : ""),
                    HinhAnh = img_NV.Image != null ? ConvertImageToByteArray(img_NV.Image) : null,
                    Luong = decimal.TryParse(txt_Luong.Text, out decimal luong) ? luong : (decimal?)null,
                    MaTaiKhoan = (int)cb_TaiKhoan.SelectedValue, 
                    MaPhongBan = (int)cb_PhongBan.SelectedValue  
                };

                bool success = nhanVienBLL.EditNhanVien(nhanVien);

                if (success)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công.");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật nhân viên.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\n{ex.StackTrace}");
            }
        }

    }
}
