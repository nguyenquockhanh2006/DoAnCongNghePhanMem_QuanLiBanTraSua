using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_CTHoaDon
    {
        DAL_CTHoaDon cthd = new DAL_CTHoaDon();

        public void ThemCTHoaDon(List<CT_HoaDon> chitiethd)
        {
            cthd.ThemCTHoaDon(chitiethd);
        }

        public List<CT_HoaDon> LoadListCT(string s)
        {
            DAL_CTHoaDon ct = new DAL_CTHoaDon();
            List<CT_HoaDon> cthd = ct.LoadCTHoaDon(s);
            return cthd;
        }
    }
}
