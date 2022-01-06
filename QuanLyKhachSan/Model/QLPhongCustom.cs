using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class QLPhongCustom : BaseViewModel
    {
        private string _MaPhong;
        public string MaPhong { get => _MaPhong; set { _MaPhong = value; OnPropertyChanged(); } }
        private string _TinhTrang;
        public string TinhTrang { get => _TinhTrang; set { _TinhTrang = value; OnPropertyChanged(); } }
        private string _LoaiPhong;
        public string LoaiPhong { get => _LoaiPhong; set { _LoaiPhong = value; OnPropertyChanged(); } }
    }
}
