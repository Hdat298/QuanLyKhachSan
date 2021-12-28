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
        private string _MaPhong;
        private string _TinHTrangPhong;
        private string _TenKH;
        public string MaPhong { get => _MaPhong; set { _MaPhong = value; OnPropertyChanged(); } }
        public string TinhTrangPhong { get => _TinHTrangPhong; set { _TinHTrangPhong = value; OnPropertyChanged();  } }
        public string TenKH { get => _TenKH; set { _TenKH = value; OnPropertyChanged(); } }

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
