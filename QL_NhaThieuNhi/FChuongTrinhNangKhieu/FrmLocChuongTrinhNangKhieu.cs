using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NhaThieuNhi.FChuongTrinhNangKhieu
{
    public partial class FrmLocChuongTrinhNangKhieu : Form
    {
        public DateTime? ThoiGianBatDau { get; private set; } // Ngày bắt đầu
        public DateTime? ThoiGianKetThuc { get; private set; } // Ngày kết thúc
        public string DiaDiem { get; private set; } // Trạng thái thanh toán
        public FrmLocChuongTrinhNangKhieu()
        {
            InitializeComponent();
            this.Load += FrmLocChuongTrinhNangKhieu_Load;
        }
        private void FrmLocChuongTrinhNangKhieu_Load(object sender, EventArgs e)
        {
            // Khởi tạo giá trị ComboBox
            cbDiaDiem.Items.Clear();
            cbDiaDiem.Items.Add("Phòng Âm Nhạc");
            cbDiaDiem.Items.Add("Sân Thể Dục");
            cbDiaDiem.Items.Add("Phòng Khiêu Vũ");

            // Đặt giá trị mặc định (tuỳ chọn)
            cbDiaDiem.SelectedIndex = 0; // Chọn "Đã Thanh Toán"
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            // Kiểm tra checkbox lọc theo thời gian
            if (checkboxLocTheoThoiGian.Checked)
            {
                ThoiGianBatDau = dtpThoiGianBatDau.Value;
                ThoiGianKetThuc = dtpThoiGianKetThuc.Value;

                // Kiểm tra logic thời gian
                if (ThoiGianBatDau > ThoiGianKetThuc)
                {
                    MessageBox.Show("Thời gian bắt đầu không được lớn hơn thời gian kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Kiểm tra checkbox lọc theo trạng thái thanh toán
            if (checkboxLocDiaDiem.Checked)
            {
                if (cbDiaDiem.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DiaDiem = cbDiaDiem.SelectedItem.ToString(); // Lấy giá trị được chọn
            }


            // Đóng form và trả kết quả
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
