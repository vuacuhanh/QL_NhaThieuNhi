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

        }

        private void btn_QLTaiKhoan_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmTaiKhoan());
        }

        private void btn_QLNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmNhanVien());
        }

        private void btn_QLHocVien_Click(object sender, EventArgs e)
        {

        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {

        }

        private void btn_Khac_Click(object sender, EventArgs e)
        {

        }
    }
}
