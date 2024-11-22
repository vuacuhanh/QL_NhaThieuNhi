using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NhaThieuNhi.FHoaDon
{
    public partial class FrmLocHoaDon : Form
    {
        public DateTime? ThoiGianBatDau { get; private set; } // Ngày bắt đầu
        public DateTime? ThoiGianKetThuc { get; private set; } // Ngày kết thúc
        public string TrangThaiThanhToan { get; private set; } // Trạng thái thanh toán

        public FrmLocHoaDon()
        {
            InitializeComponent();
            this.Load += FrmLocHoaDon_Load;
        }

        private void FrmLocHoaDon_Load(object sender, EventArgs e)
        {
            // Khởi tạo giá trị ComboBox
            cbTrangThaiThanhToan.Items.Clear();
            cbTrangThaiThanhToan.Items.Add("Đã thanh toán");
            cbTrangThaiThanhToan.Items.Add("Chưa thanh toán");

            // Đặt giá trị mặc định (tuỳ chọn)
            cbTrangThaiThanhToan.SelectedIndex = 0; // Chọn "Đã Thanh Toán"
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
            if (checkboxLocTheoTrangThaiThanhToan.Checked)
            {
                if (cbTrangThaiThanhToan.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TrangThaiThanhToan = cbTrangThaiThanhToan.SelectedItem.ToString(); // Lấy giá trị được chọn
            }


            // Đóng form và trả kết quả
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
