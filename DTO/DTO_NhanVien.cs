using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        public string IdNV { get; set; }
        public string Pass { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public DateTime NgayVaoLam  { get; set; }
        public string ChucVu { get; set; }
        public Nullable<decimal> LuongCoBan { get; set; }
        public string SDT { get; set; }
    }
}
