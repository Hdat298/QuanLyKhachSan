using QuanLyKhachSan.Model;
using QuanLyKhachSan.UserControlAll;
using QuanLyKhachSan.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKhachSan.ViewModel
{
    public class RoomViewModel : BaseViewModel 
    {
        private ObservableCollection<Room> _List1;
        public ObservableCollection<Room> List1 { get => _List1; set { _List1 = value; OnPropertyChanged(); } }
        private ObservableCollection<Room> _List2;
        public ObservableCollection<Room> List2 { get => _List2; set { _List2 = value; OnPropertyChanged(); } }
        private ObservableCollection<Room> _List3;
        public ObservableCollection<Room> List3 { get => _List3; set { _List3 = value; OnPropertyChanged(); } }
        private ObservableCollection<Room> _List4;
        public ObservableCollection<Room> List4 { get => _List4; set { _List4 = value; OnPropertyChanged(); } }

        //public Phong phong { get; set; }
        //public LoaiPhong loaiPhong { get; set; }
        //public KhachHang khachHang { get; set; }


        //private string _MaPhong;
        //public string MaPhong { get => _MaPhong; set { _MaPhong = value; OnPropertyChanged(); } }
        //private string _TinhTrang;
        //public string TinhTrang { get => _TinhTrang; set { _TinhTrang = value; OnPropertyChanged(); } }
        //private string _TenKH;
        //public string TenKH { get => _TenKH; set { _TenKH = value; OnPropertyChanged(); } }


        public RoomViewModel()
        {

            var lsCTPT = DataProvider.Ins.DB.ChiTietPhieuThues.Where(p => p.TrangThai.CompareTo("Đã thanh toán") != 0).AsEnumerable();

            var ls1 = (from p in DataProvider.Ins.DB.Phongs
                      join ct in lsCTPT on p.ID equals ct.MaPhong into t
                      from ct in t.DefaultIfEmpty()
                      where p.MaLoaiPhong == 1
                      select new Room()
                      {
                          MaCTPT = ct.ID,
                          TenKH = (ct.PhieuThue.KhachHang.TenKhachHang == null) ? "" : ct.PhieuThue.KhachHang.TenKhachHang,
                          MaPhong = p.MaPhong,
                          TrangThai = (ct.TrangThai == null) ? "Phòng trống" : "Phòng đang thuê",
                          LoaiPhong = p.LoaiPhong.TenLoaiPhong,
                          NgayDen = ct.NgayBD,
                          NgayDi = ct.NgayKT,
                          SoNgayO = (ct.NgayBD == null) ? 0 : (int)SqlFunctions.DateDiff("day", ct.NgayBD, ct.NgayKT) + 1,
                          TinhTrangPhong = p.TinhTrangPhong
                      }
                      ).ToList();
            List1 = new ObservableCollection<Room>(ls1);

            var ls2 = (from p in DataProvider.Ins.DB.Phongs
                      join ct in lsCTPT on p.ID equals ct.MaPhong into t
                      from ct in t.DefaultIfEmpty()
                      where p.MaLoaiPhong == 2
                      select new Room()
                      {
                          MaCTPT = ct.ID,
                          TenKH = (ct.PhieuThue.KhachHang.TenKhachHang == null) ? "" : ct.PhieuThue.KhachHang.TenKhachHang,
                          MaPhong = p.MaPhong,
                          TrangThai = (ct.TrangThai == null) ? "Phòng trống" : "Phòng đang thuê",
                          LoaiPhong = p.LoaiPhong.TenLoaiPhong,
                          NgayDen = ct.NgayBD,
                          NgayDi = ct.NgayKT,
                          SoNgayO = (ct.NgayBD == null) ? 0 : (int)SqlFunctions.DateDiff("day", ct.NgayBD, ct.NgayKT) + 1,
                          TinhTrangPhong = p.TinhTrangPhong
                      }
                      ).ToList();
            List2 = new ObservableCollection<Room>(ls2);

            var ls3 = (from p in DataProvider.Ins.DB.Phongs
                      join ct in lsCTPT on p.ID equals ct.MaPhong into t
                      from ct in t.DefaultIfEmpty()
                      where p.MaLoaiPhong == 3
                      select new Room()
                      {
                          MaCTPT = ct.ID,
                          TenKH = (ct.PhieuThue.KhachHang.TenKhachHang == null) ? "" : ct.PhieuThue.KhachHang.TenKhachHang,
                          MaPhong = p.MaPhong,
                          TrangThai = (ct.TrangThai == null) ? "Phòng trống" : "Phòng đang thuê",
                          LoaiPhong = p.LoaiPhong.TenLoaiPhong,
                          NgayDen = ct.NgayBD,
                          NgayDi = ct.NgayKT,
                          SoNgayO = (ct.NgayBD == null) ? 0 : (int)SqlFunctions.DateDiff("day", ct.NgayBD, ct.NgayKT) + 1,
                          TinhTrangPhong = p.TinhTrangPhong
                      }
                      ).ToList();
            List3 = new ObservableCollection<Room>(ls3);

            var ls4 = (from p in DataProvider.Ins.DB.Phongs
                      join ct in lsCTPT on p.ID equals ct.MaPhong into t
                      from ct in t.DefaultIfEmpty()
                      where p.MaLoaiPhong == 4
                      select new Room()
                      {
                          MaCTPT = ct.ID,
                          TenKH = (ct.PhieuThue.KhachHang.TenKhachHang == null) ? "" : ct.PhieuThue.KhachHang.TenKhachHang,
                          MaPhong = p.MaPhong,
                          TrangThai = (ct.TrangThai == null) ? "Phòng trống" : "Phòng đang thuê",
                          LoaiPhong = p.LoaiPhong.TenLoaiPhong,
                          NgayDen = ct.NgayBD,
                          NgayDi = ct.NgayKT,
                          SoNgayO = (ct.NgayBD == null) ? 0 : (int)SqlFunctions.DateDiff("day", ct.NgayBD, ct.NgayKT) + 1,
                          TinhTrangPhong = p.TinhTrangPhong
                      }
                      ).ToList();
            List4 = new ObservableCollection<Room>(ls4);
        }
    }
}

