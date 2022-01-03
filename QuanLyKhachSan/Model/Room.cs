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
        //public Phong phong { get; set; }
        //public LoaiPhong loaiPhong { get; set; }
        //public KhachHang khachHang { get; set; }
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
            //var obj = from p in DataProvider.Ins.DB.Phongs
            //          join c in DataProvider.Ins.DB.KhachHangs on p.ID equals c.ID
            //          join s in DataProvider.Ins.DB.PhieuThues on c.ID equals s.ID
            //          select new 
            //          {
            //              MaPhong = p.MaPhong,
            //              TinhTrangPhong = p.TinhTrangPhong,
            //              TenKH = c.TenKhachHang
            //          };
        }
       
    }
}
