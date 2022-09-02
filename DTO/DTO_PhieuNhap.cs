using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhieuNhap
    {
        public string MaPN { get; set; }
        public string IdNV { get; set; }
        public DateTime NgayLap { get; set; }
        public Nullable<decimal> TriGia { get; set; }
    }
}
