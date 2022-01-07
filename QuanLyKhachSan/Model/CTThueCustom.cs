using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class CTThueCustom : BaseViewModel
    {
        private int? _SoPhong;
        public int? SoPhong { get => _SoPhong; set { _SoPhong = value; OnPropertyChanged(); } }
        private int? _MaPhieuThue;
        public int? MaPhieuThue { get => _MaPhieuThue; set { _MaPhieuThue = value; OnPropertyChanged(); } }
        private DateTime? _NgayBD;
        public DateTime? NgayBD { get => _NgayBD; set { _NgayBD = value; OnPropertyChanged(); } }
        private DateTime? _NgayKT;
        public DateTime? NgayKT { get => _NgayKT; set { _NgayKT = value; OnPropertyChanged(); } }
        private string _TrangThai;
        public string TrangThai { get => _TrangThai; set { _TrangThai = value; OnPropertyChanged(); } }
        private int? _TienPhong;
        public int? TienPhong { get => _TienPhong; set { _TienPhong = value; OnPropertyChanged(); } }

    }
}
