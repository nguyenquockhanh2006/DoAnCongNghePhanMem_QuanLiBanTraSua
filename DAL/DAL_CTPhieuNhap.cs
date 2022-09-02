using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CTPhieuNhap
    {
        QLTraSuaDbContext db = new QLTraSuaDbContext();
        public void Them(List<CT_PhieuNhap> ctpn)
        {
            foreach(var c in ctpn)
            {
                db.CT_PhieuNhap.Add(c);
                db.SaveChanges();
            }
        }

    }
}
