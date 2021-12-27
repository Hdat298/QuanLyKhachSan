using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class Room : BaseViewModel
    {
        public Phong phong { get; set; }
        public LoaiPhong loaiPhong { get; set; }
        public KhachHang khachHang { get; set; }

        public string MaPhong { get => MaPhong; set { MaPhong = value; OnPropertyChanged(); } }
        public string TinhTrang { get => TinhTrang; set { TinhTrang = value; OnPropertyChanged();  } }
        public string TenKH { get => TenKH; set { TenKH = value; OnPropertyChanged();  } }
    }
}
