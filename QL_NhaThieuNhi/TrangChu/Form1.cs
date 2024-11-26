using QL_NhaThieuNhi.FLopHoc;
using QL_NhaThieuNhi.TrangChu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NhaThieuNhi
{
    public partial class Form1 : Form
    {
        private Form currentFormChild;
        public Form1()
        {
            InitializeComponent();
            this.Width = 1400;  // Thiết lập chiều rộng của form
            this.Height = 750;  // Thiết lập chiều cao của form
            this.MinimumSize = new Size(800, 600);
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

        private void btn_QLLopHoc_Click(object sender, EventArgs e)
        {
            openChildForm(new FLopHoc.FrmLopHoc());
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?","Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               Application.Exit();
            }
            
        }

        private void btn_QLTaiLichHoc_Click(object sender, EventArgs e)
        {

        }

        private void btn_QLLopHoc_Click_1(object sender, EventArgs e)
        {
            openChildForm(new FrmLopHoc());
        }

        private void btn_CTNK_Click(object sender, EventArgs e)
        {

        }

        private void btnHocBong_Click(object sender, EventArgs e)
        {

        }

        private void btn_Khac_Click(object sender, EventArgs e)
        {
            openChildForm(new Menu2());
        }
    }
}
