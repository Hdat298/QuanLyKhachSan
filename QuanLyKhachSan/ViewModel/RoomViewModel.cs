using QuanLyKhachSan.Model;
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
            

        public Phong phong { get; set; }
        public LoaiPhong loaiPhong { get; set; }
        public KhachHang khachHang { get; set; }


        private string _MaPhong;
        public string MaPhong { get => _MaPhong; set { _MaPhong = value; OnPropertyChanged(); } }
        private string _TinhTrang;
        public string TinhTrang { get => _TinhTrang; set { _TinhTrang = value; OnPropertyChanged(); } }
        private string _TenKH;
        public string TenKH { get => _TenKH; set { _TenKH = value; OnPropertyChanged(); } }

        public RoomViewModel()
        {
            List<Phong> R1 = DataProvider.Ins.DB.Phongs.Where(x => x.MaLoaiPhong == 1).ToList();
            List = new ObservableCollection<Phong>(R1);
        }
    }
}
