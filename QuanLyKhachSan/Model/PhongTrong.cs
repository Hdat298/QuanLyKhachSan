using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class PhongTrong : BaseViewModel
    {
        private int? _MaPhong;
        public int? MaPhong { get => _MaPhong; set { _MaPhong = value; OnPropertyChanged(); }  }
        private int? _MaLoaiPhong;
        public int? MaLoaiPhong { get => _MaLoaiPhong; set { _MaLoaiPhong = value; OnPropertyChanged(); } }
        private string _LoaiPhong;
        public string LoaiPhong { get => _LoaiPhong; set { _LoaiPhong = value; OnPropertyChanged(); } }
    }
}
