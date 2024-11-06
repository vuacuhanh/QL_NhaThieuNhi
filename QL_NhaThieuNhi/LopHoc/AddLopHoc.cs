using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DTO;
using BLL;

namespace QL_NhaThieuNhi.LopHoc
{
    public partial class AddLopHoc : Form
    {
        LopHocBLL lopHocBLL = new LopHocBLL();
        NhanVienBLL nhanVienBLL = new NhanVienBLL();

        public AddLopHoc()
        {
            InitializeComponent();
        }

        private void LoadMaNhanVienComboBox()
        {
            try
            {
                // Lấy tất cả nhân viên
                List<DTO.NhanVien> nhanVienList = nhanVienBLL.LoadNhanVien();

                // Kiểm tra nếu danh sách nhân viên có dữ liệu
                if (nhanVienList != null && nhanVienList.Count > 0)
                {
                    // Gán DataSource cho ComboBox là danh sách nhân viên
                    cbMaNhanVien.DataSource = nhanVienList;

                    // Thiết lập ComboBox hiển thị tên nhân viên và giá trị là mã nhân viên
                    //   cbMaNhanVien.DisplayMember = "TenNhanVien";  // Hiển thị tên nhân viên
                    cbMaNhanVien.ValueMember = "MaNhanVien";    // Lấy mã nhân viên làm giá trị

                    // Chọn mặc định phần tử đầu tiên trong ComboBox
                    cbMaNhanVien.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Không có nhân viên nào.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message);
            }
        }

        private void btnThemLopHoc_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các trường bắt buộc chưa được điền đầy đủ
            if (string.IsNullOrEmpty(txtMaLop.Text) || string.IsNullOrEmpty(txtTenLop.Text) || string.IsNullOrEmpty(txtChuyenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin lớp học.");
                return;
            }

            // Kiểm tra và chuyển đổi Mã lớp từ TextBox sang int
            int maLop;
            if (!int.TryParse(txtMaLop.Text, out maLop))
            {
                MessageBox.Show("Vui lòng nhập mã lớp hợp lệ.");
                return;
            }

            // Tạo đối tượng LopHoc mới
            DTO.LopHoc newLopHoc = new DTO.LopHoc
            {
                MaLop = maLop, // Mã lớp lấy từ TextBox
                MaNhanVien = (int)cbMaNhanVien.SelectedValue, // Giá trị lấy từ ComboBox chọn nhân viên
                TenLop = txtTenLop.Text,
                ChuyenMon = txtChuyenMon.Text, // Chuyên môn của lớp học
                SiSo = (int)nuSiSo.Value,  // Số lượng học sinh từ NumericUpDown
                ThoiGianBatDau = dtBatDau.Value, // Ngày bắt đầu lớp học
                ThoiGianKetThuc = dtKetThuc.Value, // Ngày kết thúc lớp học
                TrangThai = txtTrangThai.Text // Trạng thái lớp học
            };

            // Gọi BLL để thêm lớp học
            string result = lopHocBLL.AddLopHoc(newLopHoc);

            // Hiển thị kết quả
            MessageBox.Show(result);

            // Nếu thêm thành công, đóng form
            if (result == "Thêm lớp học thành công")
            {
                this.Close();
            }
        }

        // Load MaNhanVien khi form được mở, nếu cần
        private void AddLopHoc_Load(object sender, EventArgs e)
        {
            // Gọi LoadMaNhanVienComboBox để tải danh sách nhân viên
            LoadMaNhanVienComboBox();
        }
    }
}
