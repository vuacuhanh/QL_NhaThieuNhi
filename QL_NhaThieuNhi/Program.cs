using QL_NhaThieuNhi.HocVien;
using QL_NhaThieuNhi.NhanVien;
using QL_NhaThieuNhi.NhanVienGUI;
using QL_NhaThieuNhi.PhuHuynh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NhaThieuNhi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DK_LichDay());
        }
    }
}
