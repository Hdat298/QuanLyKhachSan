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
        private int? _SoNgayO;
        public int? SoNgayO { get => _SoNgayO; set { _SoNgayO = value; OnPropertyChanged(); } }
        private DateTime? _NgayDen;
        public DateTime? NgayDen { get => _NgayDen; set { _NgayDen = value; OnPropertyChanged(); } }
        private DateTime? _NgayDi;
        public DateTime? NgayDi { get => _NgayDi; set { _NgayDi = value; OnPropertyChanged(); } }
        private bool? _isDay;
        public bool? isDay { get => _isDay; set { _isDay = value; OnPropertyChanged(); } }
        private string _LoaiPhong;
        public string LoaiPhong { get => _LoaiPhong; set { _LoaiPhong = value; OnPropertyChanged(); } }


        private int? _MaCTPT;
        private string _TrangThai;
        private string _MaPhong;
        private string _TinHTrangPhong;
        private string _TenKH;
        public string MaPhong { get => _MaPhong; set { _MaPhong = value; OnPropertyChanged(); } }
        public string TinhTrangPhong { get => _TinHTrangPhong; set { _TinHTrangPhong = value; OnPropertyChanged(); } }
        public string TenKH { get => _TenKH; set { _TenKH = value; OnPropertyChanged(); } }
        public int? MaCTPT { get => _MaCTPT; set { _MaCTPT = value; OnPropertyChanged(); } }
        public string TrangThai { get => _TrangThai; set { _TrangThai = value; OnPropertyChanged(); } }

        public Room()
        {
        }
       
    }
}
