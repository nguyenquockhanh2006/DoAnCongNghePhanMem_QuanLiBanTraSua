using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_CTPhieuNhap
    {
        DAL_CTPhieuNhap dct = new DAL_CTPhieuNhap();
        public void Them(List<CT_PhieuNhap> ctpn)
        {
            dct.Them(ctpn);
        }
    }
}
