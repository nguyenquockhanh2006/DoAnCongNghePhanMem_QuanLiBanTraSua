using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhieuNhap
    {
        QLTraSuaDbContext db = new QLTraSuaDbContext();
        public List<PhieuNhap> LoadAllList()
        {
            return db.PhieuNhaps.ToList();
        }
        public void Them(PhieuNhap temp)
        {
            db.PhieuNhaps.Add(temp);
            db.SaveChanges();
        }
        public List<PhieuNhap> LoadPNDK(DateTime nbd, DateTime nkt)
        {
            return (from c in db.PhieuNhaps where c.NgayLap.Value >= nbd && c.NgayLap.Value <= nkt select c).ToList();

        }
    }
}
