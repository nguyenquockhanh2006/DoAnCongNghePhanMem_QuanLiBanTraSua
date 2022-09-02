using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CTHoaDon
    {
        QLTraSuaDbContext db = new QLTraSuaDbContext();
        public List<CT_HoaDon> loadlisthd(string mahd)
        {
            return (from c in db.CT_HoaDon where c.MaHD.Trim() == mahd select c).ToList();
        }

        public void ThemCTHoaDon(List<CT_HoaDon> cthd)
        {
            foreach(CT_HoaDon c in cthd)
            {
                db.CT_HoaDon.Add(c);  
            }
            db.SaveChanges();
        }
        public List<CT_HoaDon> LoadCTHoaDon(string s)
        {

            return (from c in db.CT_HoaDon where c.MaHD.Trim() == s.Trim() select c ).ToList();
        }
    }
}
