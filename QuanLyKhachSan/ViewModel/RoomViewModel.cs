﻿using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ViewModel
{
    class RoomViewModel : BaseViewModel
    {
        private ObservableCollection<Phong> _List;
        public ObservableCollection<Phong> List { get => _List; set { _List = value; OnPropertyChanged(); } }
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
            List<PhieuThue> PT = DataProvider.Ins.DB.PhieuThues.ToList();
            List<Phong> P = DataProvider.Ins.DB.Phongs.ToList();
            foreach (var item in P)
            {
                foreach (var item1 in PT)
                {
                        if (item1.MaPhong == item.ID)
                        {
                            item.TinhTrangPhong = "Phòng đang thuê";
                            DataProvider.Ins.DB.SaveChanges();
                            break;
                        }
                        else
                        {
                            item.TinhTrangPhong = "Phòng trống";
                            DataProvider.Ins.DB.SaveChanges();
                        }      
                }          
            }


            var lsRoom = (from p in DataProvider.Ins.DB.Phongs
                          join c in DataProvider.Ins.DB.PhieuThues on p.ID equals c.MaPhong into r
                          from x in r.DefaultIfEmpty()
                          join a in DataProvider.Ins.DB.KhachHangs on x.MaKhachHang equals a.ID into i
                          from q in i.DefaultIfEmpty()
                          where p.MaLoaiPhong == 1
                          select new Room
                          {
                              MaPhong = p.MaPhong,
                              TinhTrangPhong = p.TinhTrangPhong,
                              TenKH = q == null ? "" : q.TenKhachHang.ToString()
                          }).ToList();
            List1 = new ObservableCollection<Room>(lsRoom);


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
            //List = new ObservableCollection<Phong>(R1);

            //List<Phong> R2 = DataProvider.Ins.DB.Phongs.Where(x => x.MaLoaiPhong == 2).ToList();
            //List2 = new ObservableCollection<Room>(R2);
        }
    }
}

