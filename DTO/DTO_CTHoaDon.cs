using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CTHoaDon
    {
        public int STT { get; set; }
        public string MaHD { get; set; }
        public string MaTU { get; set; }
        public Nullable<int> SL { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
    }
}
