using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhongBanBLL
    {
        public List<PhongBan> LoadPhongBan() 
        { 
            return PhongBanAccess.LoadPhongBan();
        }

        public bool AddNPhongBan(PhongBan pb)
        {
            PhongBanAccess.AddPhongBan(pb);
             return true;
        }
        public bool DeletePhongBan(int phongBanId)
        {
            PhongBanAccess.DeletePhongBan(phongBanId);
            return true;    
        }
        public bool UpdatePhongBan(PhongBan pb)
        {
            PhongBanAccess.UpdatePhongBan(pb);
            return true;
        }
    }
}
