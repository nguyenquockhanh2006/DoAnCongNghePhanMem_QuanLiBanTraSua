using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_ThucUong
    {

        public List<String> LoadTheoLoai(string loai)
        {
            List<String> s = new List<string>();
            DAL_ThucUong tu = new DAL_ThucUong();

            foreach(var c in tu.LoadList(loai))
            {
                s.Add(c.TenTU);
            }
            return s;
        }
        
        public ThucUong LoadThucUong(string s)
        {
            DAL_ThucUong tu = new DAL_ThucUong();
            ThucUong _tu = tu.LoadThucUong(s);
            return _tu;
        }
        public ThucUong LoadThucUongT(string s)
        {
            DAL_ThucUong tu = new DAL_ThucUong();
            ThucUong _tu = tu.LoadThucUongT(s);
            return _tu;
        }
        public string SetMaTU(string ten)
        {
            string s = "";
            DAL_ThucUong tu = new DAL_ThucUong();
            foreach(ThucUong c in tu.LoadAllList())
            {
                if (c.TenTU == ten)
                    s = c.MaTU.Trim();
            }
            return s;
        }
        public List<ThucUong> LoadListTU(string loai, string dk)
        {
            List<ThucUong> ltu = new List<ThucUong>();
            DAL_ThucUong dtu = new DAL_ThucUong();
            if (loai == "Tên" && dk.Trim() == "")
                ltu = dtu.LoadAllList();
            if(loai == "Tên" && dk.Trim() != "")
            {
                ltu = dtu.LoadList_Ten(dk);
            }
            if (loai == "Loại" && dk.Trim() == "Tất cả".Trim())
                ltu = dtu.LoadAllList();
            if(loai == "Loại" && dk.Trim() != "Tất cả".Trim())
            {
                ltu = dtu.LoadList_Loai(dk);
            }    
            return ltu;
        }

        public void SuaThucUong(ThucUong tu)
        {
            DAL_ThucUong btu = new DAL_ThucUong();
            btu.SuaThucUong(tu);
        }
        public string DeSetMaLTU(string ten)
        {
            string ma = "";

            DAL_LoaiThucUong dalltu = new DAL_LoaiThucUong();
            foreach (var c in dalltu.LoadList())
            {
                if (c.TenLoai == ten)
                    ma = c.TenLoai;
            }
            return ma;
        }
        public void XoaThucUong(ThucUong tu)
        {
            DAL_ThucUong btu = new DAL_ThucUong();
            btu.XoaThucUong(tu);
        }
        public int kiemtrama(string id)
        {
            DAL_ThucUong dtu = new DAL_ThucUong();
            foreach(ThucUong c in dtu.LoadAllList())
            {
                if (c.MaTU.Trim() == id.Trim())
                    return 1;
            }
            return 0;
        }
        public void ThemTU(ThucUong tu)
        {
            DAL_ThucUong dtu = new DAL_ThucUong();
            dtu.ThemThucUong(tu);
        }
    }
}
