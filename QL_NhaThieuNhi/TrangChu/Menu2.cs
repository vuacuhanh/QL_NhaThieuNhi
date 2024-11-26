using QL_NhaThieuNhi.FHoaDon;
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
    public partial class Menu2 : Form
    {
        public Menu2()
        {
            InitializeComponent();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu2_Load(object sender, EventArgs e)
        {

        }

        private void btn_QLTaiKhoan_Click(object sender, EventArgs e)
        {
            FrmTaiKhoan tk = new FrmTaiKhoan();
            tk.Show();
        }

        private void btn_QLNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien frmNhanVien = new FrmNhanVien();
            frmNhanVien.Show();
        }

        private void btn_QLPhuHuynh_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_LichBaoTri_Click(object sender, EventArgs e)
        {

        }

        private void btn_PhongBan_Click(object sender, EventArgs e)
        {

        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            FrmHoaDon frmHoaDon = new FrmHoaDon();
            frmHoaDon.Show();
        }

        private void btn_THONGKE_Click(object sender, EventArgs e)
        {

        }

        private void btn_CaHoc_Click(object sender, EventArgs e)
        {

        }
    }
}
