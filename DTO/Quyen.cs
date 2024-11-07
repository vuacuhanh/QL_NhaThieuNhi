using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Quyen
    {
        public int MaQuyen { get; set; }
        public string TenQuyen { get; set; }

        // Constructor không tham số
        public Quyen() { }

        // Constructor đầy đủ tham số
        public Quyen(int maQuyen, string tenQuyen)
        {
            MaQuyen = maQuyen;
            TenQuyen = tenQuyen;
        }
    }
}
