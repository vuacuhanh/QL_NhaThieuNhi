using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LichHocBLL
    {
        public List<LichHoc> GetLichHocForWeek(DateTime startOfWeek)
        {
            return LichHocDAL.GetLichHocDataForWeek(startOfWeek);
        }
    }
}
