using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_LoaiThucUong
    {
        DAL_LoaiThucUong ltu = new DAL_LoaiThucUong();
        public List<string> LoadList()
        {
            List<string> s = new List<string>();

            foreach(var c in ltu.LoadList())
            {
                s.Add(c.TenLoai.ToString());
            }
            return s;
        }

        public string SetMaLTU(string ten)
        {
            string ma = "";

            DAL_LoaiThucUong dalltu = new DAL_LoaiThucUong();
            foreach(LoaiThucUong c in dalltu.LoadList())
            {
                if (c.TenLoai.Trim() == ten.Trim())
                    ma = c.MaLoai.Trim();
            }
            return ma;
        }

        public List<LoaiThucUong> LoadAllList()
        {
            DAL_LoaiThucUong dltu = new DAL_LoaiThucUong();
            return dltu.LoadAllList();
        }
        
        public int KT_MaLTU(string ma)
        {
            DAL_LoaiThucUong dltu = new DAL_LoaiThucUong();
            List<LoaiThucUong> lltu = dltu.LoadAllList();
            
            foreach(LoaiThucUong c in lltu)
            {
                if (c.MaLoai.Trim() == ma.Trim())
                    return 1;
            }
            return 0;
        }
        public void Them(LoaiThucUong th)
        {
            DAL_LoaiThucUong dltu = new DAL_LoaiThucUong();
            dltu.Them(th);
                
        }
        public void Xoa(LoaiThucUong th)
        {
            DAL_LoaiThucUong dltu = new DAL_LoaiThucUong();
            dltu.Xoa(th);
        }
        public void Sua(LoaiThucUong th)
        {
            DAL_LoaiThucUong dltu = new DAL_LoaiThucUong();
            dltu.Sua(th);
        }
    }
}
