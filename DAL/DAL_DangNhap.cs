using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DangNhap
    {
        QLTraSuaDbContext db = new QLTraSuaDbContext();
        public List<NhanVien> LoadList()
        {
            List<NhanVien> listNV = new List<NhanVien>();
            var result = db.NhanViens.ToList();
            foreach (var c in result)
            {
                NhanVien temp = new NhanVien();
                temp.IdNV = c.IdNV.Trim();
                temp.Pass = c.Pass.Trim();
                temp.TenNV = c.TenNV;
                temp.GioiTinh = c.GioiTinh;
                temp.NgaySinh = c.NgaySinh;
                temp.QueQuan = c.QueQuan;
                temp.NgayVaoLam = c.NgayVaoLam;
                temp.SDT = c.SDT;
                temp.ChucVu = c.ChucVu;
                temp.LuongCoBan = c.LuongCoBan;
                listNV.Add(temp);
            }
            return listNV;
        }

    }
}
