using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LichDayBLL
    {
        public List<LichDay> GetLichDayForWeek(DateTime startDate) 
        { 
            return LichDayDAL.GetLichDayForWeek(startDate); 
        }
    }
}
