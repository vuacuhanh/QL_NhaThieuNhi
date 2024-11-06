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
using DTO;
using QL_NhaThieuNhi.NhanVien;
namespace QL_NhaThieuNhi
{
    public partial class FrmNhanVien : Form
    {
        NhanVienBLL nhanVienBll = new NhanVienBLL();
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {

            //List<NhanViens> danhSachNhanVien = nhanVienBll.LoadNhanVien();

            // Hiển thị danh sách nhân viên lên DataGridView (hoặc bất kỳ nơi nào bạn muốn)
            //data_NhanVien.DataSource = danhSachNhanVien;
        }

        private void btn_addNhanVien_Click(object sender, EventArgs e)
        {
            AddNhanVien addNhanVien = new AddNhanVien();
            addNhanVien.ShowDialog();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
