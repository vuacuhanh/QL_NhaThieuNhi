using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;
using BLL;
namespace QL_NhaThieuNhi
{
    public partial class FrmTaiKhoan : Form
    {

        private TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        public FrmTaiKhoan()
        {
            InitializeComponent();
        }
        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            List<DTO.TaiKhoan> danhSachTaiKhoan = taiKhoanBLL.LoadTaiKhoan();
            data_TaiKhoann.DataSource = danhSachTaiKhoan;

            sort_By();
        }
        public void sort_By()
        {
            cb_SortBy.Items.Add("Xếp theo tên quyền");
            cb_SortBy.Items.Add("Mới nhất");
            cb_SortBy.Items.Add("Cũ nhất");
        }

        private void cb_SortBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
