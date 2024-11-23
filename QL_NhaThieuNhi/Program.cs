using QL_NhaThieuNhi.NhanVien;
using QL_NhaThieuNhi.NhanVienGUI;
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
<<<<<<< HEAD
            Application.Run(new Login());
=======
            Application.Run(new QuanLyHocvVien());
>>>>>>> f164f09d6e82462b1138992c4508adef2df65aa3
        }
    }
}
