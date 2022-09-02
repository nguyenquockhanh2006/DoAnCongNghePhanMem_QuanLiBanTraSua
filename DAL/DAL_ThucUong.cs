using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThucUong
    {
        QLTraSuaDbContext db = new QLTraSuaDbContext();

        public List<ThucUong> LoadList(string ten)
        {
            return (from c in db.ThucUongs where c.LoaiThucUong.TenLoai == ten select c).ToList();
        }

        public List<ThucUong> LoadAllList()
        {
            return db.ThucUongs.ToList();
        }
        public List<ThucUong> LoadList_Ten(string ten)
        {
            return (from c in db.ThucUongs where c.TenTU.Contains(ten) == true select c).ToList();
        }
        public ThucUong LoadThucUong(string ten)
        {
            return db.ThucUongs.FirstOrDefault(x => x.TenTU == ten);
        }
        public ThucUong LoadThucUongT(string ten)
        {
            return db.ThucUongs.FirstOrDefault(x => x.MaTU == ten);
        }
        
        public List<ThucUong> LoadList_Loai(string loai)
        {
            return (from c in db.ThucUongs where c.LoaiThucUong.TenLoai.Trim() == loai.Trim() select c).ToList();
        }

        public void SuaThucUong(ThucUong tu)
        {
            ThucUong thu = db.ThucUongs.FirstOrDefault(x => x.MaTU.Trim() == tu.MaTU.Trim());
            thu.MaLoai = tu.MaLoai;
            thu.TenTU = tu.TenTU;
            thu.GioiThieu = tu.GioiThieu;
            thu.GiaBan = tu.GiaBan;
            
            db.SaveChanges();
        }
        public void XoaThucUong(ThucUong tu)
        {
            ThucUong thu = db.ThucUongs.FirstOrDefault(x => x.MaTU.Trim() == tu.MaTU.Trim());
            db.ThucUongs.Remove(thu);
            db.SaveChanges();
        }
        public void ThemThucUong(ThucUong tu)
        {
            db.ThucUongs.Add(tu);
            db.SaveChanges();
        }
    }
}
