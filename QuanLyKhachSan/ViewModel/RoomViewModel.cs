﻿using QuanLyKhachSan.Model;
using QuanLyKhachSan.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKhachSan.ViewModel
{
    class RoomViewModel : BaseViewModel
    {
        private ObservableCollection<Room> _List1;
        public ObservableCollection<Room> List1 { get => _List1; set { _List1 = value; OnPropertyChanged(); } }
        private ObservableCollection<Room> _List2;
        public ObservableCollection<Room> List2 { get => _List2; set { _List2 = value; OnPropertyChanged(); } }
        private ObservableCollection<Room> _List3;
        public ObservableCollection<Room> List3 { get => _List3; set { _List3 = value; OnPropertyChanged(); } }
        private ObservableCollection<Room> _List4;
        public ObservableCollection<Room> List4 { get => _List4; set { _List4 = value; OnPropertyChanged(); } }

        public ICommand PreviewMouseLeftButtonUpCommand { get; set; }

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
            PreviewMouseLeftButtonUpCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RoomDetailWindow roomDetailWindow = new RoomDetailWindow();
                roomDetailWindow.ShowDialog();
            }
                );


            var lsCTPT = DataProvider.Ins.DB.ChiTietPhieuThues.Where(p => p.TrangThai.CompareTo("Đã thanh toán") != 0).AsEnumerable();

            var ls = (from p in DataProvider.Ins.DB.Phongs
                      join ct in lsCTPT on p.ID equals ct.MaPhong into t
                      from ct in t.DefaultIfEmpty()
                      where p.MaLoaiPhong == 1
                      select new Room()
                      {
                          MaCTPT = ct.MaChiTietPhieuThue,
                          TenKH = (ct.PhieuThue.KhachHang.TenKhachHang == null) ? "" : ct.PhieuThue.KhachHang.TenKhachHang,
                          MaPhong = p.MaPhong,
                          TrangThai = (ct.TrangThai == null) ? "Phòng trống" : "Phòng đang thuê",
                      }
                      ).ToList();
            List1 = new ObservableCollection<Room>(ls);
            //var lsCTPT = DataProvider.Ins.DB.ChiTietPhieuThues.Where(p => p.TinhTrangThue.CompareTo("Đã thanh toán") != 0).AsEnumerable();

            //var ls = (from p in DataProvider.Ins.DB.Phongs
            //          join ct in lsCTPT on p.ID equals ct.MaPhong into t
            //          from ct in t.DefaultIfEmpty()
            //          where p.MaLoaiPhong == 1
            //          select new Room()
            //          {
            //              MaCTPT = ct.MaChiTietPhieuThue,
            //              TenKH = (ct.PhieuThue.KhachHang.TenKhachHang == null) ? "" : ct.PhieuThue.KhachHang.TenKhachHang,
            //              MaPhong = p.MaPhong,
            //              TinhTrangPhong = p.TinhTrangPhong,
            //              TinhTrangThue = (ct.TinhTrangThue == null ) ? "Phòng trống" : ct.TinhTrangThue,
            //          }
            //          ).ToList();
            //List1 = new ObservableCollection<Room>(ls);

            //var lsRoom = (from p in DataProvider.Ins.DB.Phongs
            //              join c in DataProvider.Ins.DB.ChiTietPhieuThues on p.ID equals c.MaPhong into r
            //              from x in r.DefaultIfEmpty()
            //              join i in DataProvider.Ins.DB.PhieuThues on x.MaPhieuThue equals i.ID into k
            //              from a in k.DefaultIfEmpty()
            //              join b in DataProvider.Ins.DB.KhachHangs on a.MaKhachHang equals b.ID into o
            //              from q in o.DefaultIfEmpty()
            //              where p.MaLoaiPhong == 1
            //              select new Room
            //              {
            //                  MaPhong = p.MaPhong,
            //                  TinhTrangPhong = p.TinhTrangPhong,
            //                  TenKH = q.TenKhachHang == null ? "" : q.TenKhachHang
            //              }).ToList();
            //List1 = new ObservableCollection<Room>(lsRoom);



            //var lsRoom = (from p in DataProvider.Ins.DB.Phongs
            //              join c in DataProvider.Ins.DB.PhieuThues on p.ID equals c.ID into r
            //              from rr in r.DefaultIfEmpty() 
            //              join rrr in DataProvider.Ins.DB.KhachHangs on rr.ID equals rrr.ID into rrrr
            //              from rrrrr in rrrr.DefaultIfEmpty()
            //              where p.MaLoaiPhong == 1 
            //              select new Room
            //              {
            //                  MaPhong = p.MaPhong,
            //                  TinhTrangPhong = p.TinhTrangPhong,
            //                  TenKH = rrrrr == null ? "" : rrrrr.TenKhachHang.ToString()
            //              }).ToList();
            //List1 = new ObservableCollection<Room>(lsRoom);

            //var lsRoom = (from p in DataProvider.Ins.DB.Phongs
            //              join c in DataProvider.Ins.DB.KhachHangs on p.ID equals c.ID
            //              join s in DataProvider.Ins.DB.PhieuThues on c.ID equals s.ID
            //              select new Room
            //              {
            //                  MaPhong = p.MaPhong,
            //                  TinhTrangPhong = p.TinhTrangPhong,
            //                  TenKH = c.TenKhachHang
            //              }).ToList();
            //List1 = new ObservableCollection<Room>(lsRoom);
            //public RoomViewModel()
            //{
            //    List<obj> = from p in DataProvider.Ins.DB.Phongs
            //              join c in DataProvider.Ins.DB.KhachHangs on p.ID equals c.ID
            //              join s in DataProvider.Ins.DB.PhieuThues on c.ID equals s.ID
            //              select new Room
            //              {
            //                  MaPhong = p.MaPhong,
            //                  TinhTrangPhong = p.TinhTrangPhong,
            //                  TenKH = c.TenKhachHang
            //              };

            //List<Phong> R1 = DataProvider.Ins.DB.Phongs.Where(x => x.MaLoaiPhong == 1).ToList();
            //List = new ObservableCollection<Room>(R1);

            //List<Phong> R2 = DataProvider.Ins.DB.Phongs.Where(x => x.MaLoaiPhong == 2).ToList();
            //List2 = new ObservableCollection<Room>(R2);
        }
    }
}

