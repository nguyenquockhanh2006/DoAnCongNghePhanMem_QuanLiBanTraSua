using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_DangNhap
    {
        public string KTDangNhap(string id, string pass)
        {
            DAL_DangNhap dn = new DAL_DangNhap();
            List<NhanVien> listNhanVien = dn.LoadList();
            foreach(var c in listNhanVien)
            {
                if (c.IdNV == id && c.Pass == pass)
                    return "true";
            }
            listNhanVien = dn.LoadList();
            int xetid = 0;
            foreach (var c in listNhanVien)
            {
                if (c.IdNV == id)
                    xetid = 1;
            }
            if(xetid == 0)
                return "wrongid";
            return "wrongpass";
        }
        public NhanVien login(string id, string pass)
        {
            DAL_DangNhap dn = new DAL_DangNhap();
            List<NhanVien> listNhanVien = dn.LoadList();
            NhanVien nv = new NhanVien();
            foreach (var c in listNhanVien)
            {
                if (c.IdNV == id && c.Pass == pass)
                    nv= c;
            }
            return nv;
        }

    }
}
