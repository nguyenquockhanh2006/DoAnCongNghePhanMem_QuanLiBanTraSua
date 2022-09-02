using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDon
    {
        public string MaHD { get; set; }
        public string IdNV { get; set; }
        public DateTime NgayLap { get; set; }
        public Nullable<decimal> TriGia { get; set; }
    }
}
