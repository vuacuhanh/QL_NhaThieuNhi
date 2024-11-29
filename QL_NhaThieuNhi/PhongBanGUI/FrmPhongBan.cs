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
    }
}
