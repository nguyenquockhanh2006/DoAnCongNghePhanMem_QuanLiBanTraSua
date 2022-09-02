using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_HoaDon
    {
        DAL_HoaDon hd = new DAL_HoaDon();
        QLTraSuaDbContext db = new QLTraSuaDbContext();
        public void ThemHD(HoaDon hoadon)
        {
            hd.ThemHD(hoadon);
        }

        public List<HoaDon> LoadHoaDon(DateTime nbd, DateTime nkt)
        {
            return hd.LoadHoaDon(nbd, nkt);
        }
        public int KT_MaHD(string s)
        {
            DAL_HoaDon dhd = new DAL_HoaDon();
            foreach(var c in dhd.loadlisthd())
            {
                if (c.IdNV.Trim() == s.Trim())
                    return 1;
            }
            return 0;
        }
    }

}
