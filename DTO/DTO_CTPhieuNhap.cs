using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CTPhieuNhap
    {
        public int STT { get; set; }
        public string MaPN { get; set; }
        public string MaNL { get; set; }
        public Nullable<int> SL { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
    }
}
