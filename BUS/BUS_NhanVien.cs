using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_NhanVien
    {
        public NhanVien loadnhanvien(string id)
        {
            NhanVien temp = new NhanVien();
            DAL_NhanVien dal_temp = new DAL_NhanVien();
            List<NhanVien> listNV = dal_temp.loadlisst();
            foreach(var c in listNV)
            {
                if(c.IdNV.Trim() == id)
                {
                    temp = c;
                }
            }
            return temp;
        }

        public string KT_SDT(string sdt)
        {
            string s = "true";

            if (sdt.Trim().Length != 10)
                s = "wrsl";
            else
            {
                foreach(char c in sdt)
                {
                    if (c > '9' || c < '0')
                        s = "wrkt";
                }
            }
            return s;
        }

        public string KT_Pass(string pass)
        {
            string s = "true";

            if (pass.Trim().Length < 8)
                s = "wrsl";

            return s;
        }

        public void SuaNV(NhanVien nv)
        {
            DAL_NhanVien dnhanvien = new DAL_NhanVien();
            dnhanvien.SuaNV(nv);
        }
        public void SuaNVAdmin(NhanVien nv)
        {
            DAL_NhanVien dnhanvien = new DAL_NhanVien();
            dnhanvien.SuaNVADmin(nv);
        }
        public void SuaPass(NhanVien nv)
        {
            DAL_NhanVien dnhanvien = new DAL_NhanVien();
            dnhanvien.SuaPass(nv);
        }
        public List<NhanVien> LoadAllList(string pt, string ten)
        {
            List<NhanVien> lnv = new List<NhanVien>();
            DAL_NhanVien dnv = new DAL_NhanVien();

            if(pt == "Tất cả")
            {
                lnv = dnv.LoadAllList();
            }
            else
            {
                if(pt == "Tên")
                {
                    foreach (NhanVien c in dnv.LoadAllList())
                        if (c.TenNV.Contains(ten) == true)
                            lnv.Add(c);  
                }
                else
                {
                    foreach (NhanVien c in dnv.LoadAllList())
                        if (c.IdNV.Contains(ten) == true)
                            lnv.Add(c);
                }
            }

            return lnv;
        }
        
        public void XoaNV(string id)
        {
            DAL_NhanVien nv = new DAL_NhanVien();
            nv.XoaNV(id);
        }
        public int KT_id(string id)
        {
            DAL_NhanVien dnv = new DAL_NhanVien();
            foreach (NhanVien c in dnv.LoadAllList())
                if (c.IdNV.Trim() == id.Trim())
                    return 1;
            return 0;
        }
        public void ThemNV(NhanVien nv)
        {
            DAL_NhanVien dnv = new DAL_NhanVien();
            dnv.ThemNV(nv);
        }
    }
}
