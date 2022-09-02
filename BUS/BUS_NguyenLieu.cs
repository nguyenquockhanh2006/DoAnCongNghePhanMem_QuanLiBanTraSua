using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_NguyenLieu
    {
        DAL_NguyenLieu dnl = new DAL_NguyenLieu();
        public List<NguyenLieu> LoadAllList()
        {
            return dnl.LoadAllList();
        }
        public List<NguyenLieu> LoadList(string s1, string s2)
        {
            List<NguyenLieu> lnl = new List<NguyenLieu>();
            if (s2.Trim() == "")
                lnl = dnl.LoadAllList();
            if (s1 == "Mã" && s2 != "")
                lnl = dnl.LoadListMa(s2);
            if(s1 == "Tên" && s2 != "")
                lnl = dnl.LoadListTen(s2);
            return lnl;
        }
        public int KTMa(string s)
        {
            foreach(var c in dnl.LoadAllList())
            {
                if (c.MaNL.Trim() == s.Trim())
                    return 1;
            }
            return 0;
        }
        public void Them(NguyenLieu nl)
        {
            dnl.Them(nl);
        }
        public int KTdvt(string s)
        {
            foreach(char c in s)
            {
                if (c > '9' || c < '0')
                    return 0;
            }
            return 1;
        }
        
        public void Xoa(NguyenLieu nl)
        {
            dnl.Xoa(nl);
        }
        public void Sua(NguyenLieu nl)
        {
            dnl.Sua(nl);
        }
        public List<NguyenLieu> LoadList(string s)
        {
            return dnl.LoadListTen(s);
        }
        
    }
}
