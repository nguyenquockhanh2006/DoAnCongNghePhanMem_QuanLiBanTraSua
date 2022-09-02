using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhanVien
    {
        QLTraSuaDbContext db = new QLTraSuaDbContext();

        public List<NhanVien> loadlisst()
        {
            return db.NhanViens.ToList();
        }

        public void SuaNV(NhanVien nv)
        {
            NhanVien a = db.NhanViens.FirstOrDefault(x => x.IdNV.Trim() == nv.IdNV.Trim());
            a.TenNV = nv.TenNV;
            a.GioiTinh = nv.GioiTinh;
            a.NgaySinh = nv.NgaySinh;
            a.QueQuan = nv.QueQuan;
            a.NgayVaoLam = nv.NgayVaoLam;
            a.SDT = nv.SDT;
            db.SaveChanges();
        }
        public void SuaNVADmin(NhanVien nv)
        {
            NhanVien a = db.NhanViens.FirstOrDefault(x => x.IdNV.Trim() == nv.IdNV.Trim());
            a.Pass = nv.Pass;
            a.GioiTinh = nv.GioiTinh;
            a.NgaySinh = nv.NgaySinh;
            a.QueQuan = nv.QueQuan;
            a.NgayVaoLam = nv.NgayVaoLam;
            a.SDT = nv.SDT;
            a.ChucVu = nv.ChucVu;
            a.LuongCoBan = nv.LuongCoBan;
            db.SaveChanges();
        }
        public void SuaPass(NhanVien nv)
        {
            NhanVien a = db.NhanViens.FirstOrDefault(x => x.IdNV.Trim() == nv.IdNV.Trim());
            a.Pass = nv.Pass;
            db.SaveChanges();
        }

        public List<NhanVien> LoadAllList()
        {
            return db.NhanViens.ToList();
        }

        public void XoaNV(string id)
        {
            NhanVien a = db.NhanViens.FirstOrDefault(x => x.IdNV.Trim() == id.Trim());
            db.NhanViens.Remove(a);
            db.SaveChanges();
        }
        public void ThemNV(NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges();
        }
        
    }
}
