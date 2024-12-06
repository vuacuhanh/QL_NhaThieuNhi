using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QL_NhaThieuNhi.CaHocGUI
{
    public partial class FrmCaHoc : Form
    {
        private CaHocBLL caHocBLL;

        public FrmCaHoc()
        {
            InitializeComponent();
            caHocBLL = new CaHocBLL();
            LoadDataIntoDgv();

            this.dgvCaHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaHoc_CellClick);
        }

        // Tải dữ liệu vào DataGridView
        private void LoadDataIntoDgv()
        {
            try
            {
                // Lấy danh sách các ca học từ BLL
                List<CaHoc> danhSachCaHoc = caHocBLL.GetAllCaHoc();

                // Gán dữ liệu vào DataGridView
                dgvCaHoc.DataSource = danhSachCaHoc;

                // Ẩn các cột không cần thiết
                dgvCaHoc.Columns["LichDays"].Visible = false;
                dgvCaHoc.Columns["LichHocs"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu vào bảng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemCaHoc_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan thoiGianBatDau, thoiGianKetThuc;

                // Kiểm tra và chuyển đổi thời gian
                if (TimeSpan.TryParse(dtpBatDau.Value.ToString("HH:mm"), out thoiGianBatDau) &&
                    TimeSpan.TryParse(dtpKetThuc.Value.ToString("HH:mm"), out thoiGianKetThuc))
                {
                    CaHoc newCaHoc = new CaHoc
                    {
                        MaCaHoc = int.Parse(txtMaCaHoc.Text),
                        TietHoc = txtTietHoc.Text,
                        ThoiGianBatDau = thoiGianBatDau,
                        ThoiGianKetThuc = thoiGianKetThuc
                    };

                    if (caHocBLL.AddCaHoc(newCaHoc))
                    {
                        MessageBox.Show("Thêm ca học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataIntoDgv();
                    }
                    else
                    {
                        MessageBox.Show("Thêm ca học thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Định dạng thời gian không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm ca học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaCaHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCaHoc.SelectedRows.Count > 0)
                {
                    TimeSpan thoiGianBatDau, thoiGianKetThuc;

                    // Kiểm tra và chuyển đổi thời gian
                    if (TimeSpan.TryParse(dtpBatDau.Value.ToString("HH:mm"), out thoiGianBatDau) &&
                        TimeSpan.TryParse(dtpKetThuc.Value.ToString("HH:mm"), out thoiGianKetThuc))
                    {
                        CaHoc updatedCaHoc = new CaHoc
                        {
                            MaCaHoc = int.Parse(txtMaCaHoc.Text),
                            TietHoc = txtTietHoc.Text,
                            ThoiGianBatDau = thoiGianBatDau,
                            ThoiGianKetThuc = thoiGianKetThuc
                        };

                        if (caHocBLL.UpdateCaHoc(updatedCaHoc))
                        {
                            MessageBox.Show("Cập nhật ca học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataIntoDgv();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật ca học thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Định dạng thời gian không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ca học để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật ca học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnXoaCaHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCaHoc.SelectedRows.Count > 0)
                {
                    int maCaHoc = int.Parse(dgvCaHoc.SelectedRows[0].Cells["MaCaHoc"].Value.ToString());
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa ca học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (caHocBLL.DeleteCaHoc(maCaHoc))
                        {
                            MessageBox.Show("Xóa ca học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataIntoDgv();
                        }
                        else
                        {
                            MessageBox.Show("Xóa ca học thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ca học để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa ca học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaCaHoc.Clear();
            txtTietHoc.Clear();
            dtpBatDau.Value = DateTime.Now; // Đặt lại giá trị mặc định cho DateTimePicker
            dtpKetThuc.Value = DateTime.Now; // Đặt lại giá trị mặc định cho DateTimePicker
        }

        private void dgvCaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCaHoc.Rows[e.RowIndex].Cells["MaCaHoc"].Value != null)
            {
                try
                {
                    // Lấy dòng được chọn
                    DataGridViewRow row = dgvCaHoc.Rows[e.RowIndex];

                    // Đổ dữ liệu từ dòng được chọn vào các trường nhập liệu
                    txtMaCaHoc.Text = row.Cells["MaCaHoc"].Value.ToString();
                    txtTietHoc.Text = row.Cells["TietHoc"].Value?.ToString();

                    // Chuyển đổi thời gian và điền vào DateTimePicker
                    TimeSpan thoiGianBatDau;
                    TimeSpan thoiGianKetThuc;

                    // Sử dụng TryParse để tránh lỗi
                    if (TimeSpan.TryParse(row.Cells["ThoiGianBatDau"].Value?.ToString(), out thoiGianBatDau))
                    {
                        dtpBatDau.Value = DateTime.Today.Add(thoiGianBatDau);
                    }
                    else
                    {
                        dtpBatDau.Value = DateTime.Today; // Nếu không thể chuyển đổi, gán ngày mặc định
                    }

                    if (TimeSpan.TryParse(row.Cells["ThoiGianKetThuc"].Value?.ToString(), out thoiGianKetThuc))
                    {
                        dtpKetThuc.Value = DateTime.Today.Add(thoiGianKetThuc);
                    }
                    else
                    {
                        dtpKetThuc.Value = DateTime.Today; // Nếu không thể chuyển đổi, gán ngày mặc định
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hiển thị dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
