using QL_NhaThieuNhi.FChuongTrinhNangKhieu;
using QL_NhaThieuNhi.FHoatDongNgoaiKhoa;
using QL_NhaThieuNhi.FLopHoc;
using QL_NhaThieuNhi.LichHoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NhaThieuNhi.TrangChu
{
    public partial class FrmEmp : Form
    {
        private Form currentFormChild;
        public FrmEmp()
        {
            InitializeComponent();
        }

        
        public void openChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btn_QLTaiLichDay_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmLichDay());
        }

        private void btn_QLLopHoc_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmLopHoc());
        }

        private void btn_CTNK_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmChuongTrinhNangKhieu());
        }

        private void btnHDNK_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmHoatDongNgoaiKhoa());
        }

        private void btnHocBong_Click(object sender, EventArgs e)
        {

        }

        private void btn_Khac_Click(object sender, EventArgs e)
        {
            openChildForm(new Menu2());
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
