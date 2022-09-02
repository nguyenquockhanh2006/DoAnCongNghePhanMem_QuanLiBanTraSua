using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HoaDon
    {
        QLTraSuaDbContext db = new QLTraSuaDbContext();
        public List<HoaDon> loadlisthd()
        {
            return db.HoaDons.ToList();
        }
        public void ThemHD(HoaDon hd)
        {
            db.HoaDons.Add(hd);
            db.SaveChanges();
        }
        public List<HoaDon> LoadHoaDon(DateTime nbd, DateTime nkt)
        {
            List<HoaDon> list = (from c in db.HoaDons where c.NgayLap.Value >= nbd && c.NgayLap.Value <= nkt select c).ToList();
            return list;
        }
        
    }
}
