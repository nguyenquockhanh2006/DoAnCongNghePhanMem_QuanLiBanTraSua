using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LoaiThucUong
    {
        QLTraSuaDbContext db = new QLTraSuaDbContext();
        public List<LoaiThucUong> LoadList()
        {
            List<LoaiThucUong> list = db.LoaiThucUongs.ToList();
            return list;
        }

        public List<LoaiThucUong> LoadAllList()
        {
            return db.LoaiThucUongs.ToList();
        }
       
        public void Them(LoaiThucUong th)
        {
            db.LoaiThucUongs.Add(th);
            db.SaveChanges();
        }
        public void Xoa(LoaiThucUong th)
        {
            LoaiThucUong a = db.LoaiThucUongs.FirstOrDefault(x => x.MaLoai.Trim() == th.MaLoai.Trim());
            db.LoaiThucUongs.Remove(a);
            db.SaveChanges();
        }
        public void Sua(LoaiThucUong th)
        {
            LoaiThucUong a = db.LoaiThucUongs.FirstOrDefault(x => x.MaLoai.Trim() == th.MaLoai.Trim());
            a.TenLoai = th.TenLoai;
            db.SaveChanges();
        }
    }


}
