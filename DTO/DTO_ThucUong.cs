using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ThucUong
    {
        public string MaTU { get; set; }
        public string MaLoai { get; set; }
        public string TenTU { get; set; }
        public string GioiThieu { get; set; }
        public Nullable<decimal> GiaBan { get; set; }
    }
}
