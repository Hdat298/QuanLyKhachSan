using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class RentRoomCustom : BaseViewModel
    {
        private int? _MaPhieuThue;
        public int? MaPhieuThue { get => _MaPhieuThue; set { _MaPhieuThue = value; OnPropertyChanged(); } }
        private string _TenKH;
        public string TenKH { get => _TenKH; set { _TenKH = value; OnPropertyChanged(); } }
        public DateTime? _NgayLap;
        public DateTime? NgayLap { get => _NgayLap; set { _NgayLap = value; OnPropertyChanged(); }  }
        private string _TenNV;
        public string TenNV { get => _TenNV; set { _TenNV = value; OnPropertyChanged(); } }
    }
}
