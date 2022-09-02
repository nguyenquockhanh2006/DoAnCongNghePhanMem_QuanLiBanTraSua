using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NguyenLieu
    {
        QLTraSuaDbContext db = new QLTraSuaDbContext();
        public List<NguyenLieu> LoadAllList()
        {
            return db.NguyenLieux.ToList();
        }
        public List<NguyenLieu> LoadListTen(string s)
        {
            return (from c in db.NguyenLieux where c.TenNL.Contains(s) == true select c).ToList();
        }
        public List<NguyenLieu> LoadListMa(string s)
        {
            return (from c in db.NguyenLieux where c.MaNL.Contains(s) == true select c).ToList();
        }
        public void Them(NguyenLieu nl)
        {
            db.NguyenLieux.Add(nl);
            db.SaveChanges();
        }
        public void Xoa(NguyenLieu nl)
        {
            NguyenLieu ngl = db.NguyenLieux.FirstOrDefault(x => x.MaNL.Trim() == nl.MaNL.Trim());
            db.NguyenLieux.Remove(ngl);
            db.SaveChanges();
        }
        public void Sua(NguyenLieu nl)
        {
            NguyenLieu ngl = db.NguyenLieux.FirstOrDefault(x => x.MaNL.Trim() == nl.MaNL.Trim());
            ngl.TenNL = nl.TenNL;
            ngl.DonViTinh = nl.DonViTinh;
            ngl.GiaNhap = nl.GiaNhap;
            db.SaveChanges();
        }
        
    }
}
