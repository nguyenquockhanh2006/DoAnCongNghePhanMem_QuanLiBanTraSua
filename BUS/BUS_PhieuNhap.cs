using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_PhieuNhap
    {
        DAL_PhieuNhap dpn = new DAL_PhieuNhap();

        public int KiemTraMa(string id)
        {
            foreach (var c in dpn.LoadAllList())
            {
                if (c.IdNV.Trim() == id.Trim())
                    return 1;
            }
            return 0;
        }
        public void Them(PhieuNhap temp)
        {
            dpn.Them(temp);
        }
        public List<PhieuNhap> LoadALLList()
        {
            return dpn.LoadAllList();
        }
        public List<PhieuNhap> LoadPNDK(DateTime nbd, DateTime nkt)
        {
            return dpn.LoadPNDK(nbd, nkt);

        }
    }
}
