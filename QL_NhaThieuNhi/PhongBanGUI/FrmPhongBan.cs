using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NhaThieuNhi.PhongBanGUI
{
    public partial class FrmPhongBan : Form
    {
        private PhongBanBLL phongBanBLL;
        public FrmPhongBan()
        {
            phongBanBLL = new PhongBanBLL();
            InitializeComponent();
            LoadDataPhongBan();
        }

        public void LoadDataPhongBan()
        {
            List<DTO.PhongBan> dsPhongBan = phongBanBLL.LoadPhongBan();
            data_PhongBan.DataSource = dsPhongBan;
        }



        private void btn_addNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.PhongBan phongBan = new DTO.PhongBan
                {
                    MaPhongBan = int.Parse(txtMaPhongBan.Text),
                    TenPhongBan = txtTenPB.Text,
                    MoTaNhiemVu = txtMoTa.Text
                };

                bool success = phongBanBLL.AddNPhongBan(phongBan);

                if (success)
                {
                    MessageBox.Show("Thêm phòng ban thành công.");
                    LoadDataPhongBan();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm phòng ban.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\n{ex.StackTrace}");
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (data_PhongBan.SelectedRows.Count > 0)
            {
                int maPhongBan =Convert.ToInt32(data_PhongBan.SelectedRows[0].Cells["MaPhongBan"].Value);
                bool success = phongBanBLL.DeletePhongBan(maPhongBan);
                if (success)
                {
                    MessageBox.Show("Xóa phòng ban thành công.");
                    LoadDataPhongBan();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa phòng ban.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban để xóa.");
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.PhongBan phongBan = new DTO.PhongBan
                {
                    MaPhongBan = int.Parse(txtMaPhongBan.Text),
                    TenPhongBan = txtTenPB.Text,
                    MoTaNhiemVu = txtMoTa.Text
                };

                bool success = phongBanBLL.UpdatePhongBan(phongBan);

                if (success)
                {
                    MessageBox.Show("Cập nhật phòng ban thành công.");
                    LoadDataPhongBan();
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật phòng ban.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void data_PhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = data_PhongBan.Rows[e.RowIndex];

                // Lấy thông tin từ các ô trong dòng được chọn
                txtMaPhongBan.Text = selectedRow.Cells["MaPhongBan"].Value.ToString();
                txtTenPB.Text = selectedRow.Cells["TenPhongBan"].Value.ToString();
                txtMoTa.Text = selectedRow.Cells["MoTaNhiemVu"].Value.ToString();
            }
        }
    }
}
