using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class Room
    {
        public Phong phong { get; set; }
        public LoaiPhong loaiPhong { get; set; }
        public KhachHang khachHang { get; set; }
    }
}
