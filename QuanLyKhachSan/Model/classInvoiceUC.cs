using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class classInvoiceUC : BaseViewModel
    {
        private int? _MaHD;
        public int? MaHD { get => _MaHD; set { _MaHD = value; OnPropertyChanged(); } }
        private DateTime? _NgayLap;
        public DateTime? NgayLap { get => _NgayLap; set { _NgayLap = value; OnPropertyChanged(); } }
        private int? _TienDV;
        public int? TienDV { get => _TienDV; set { _TienDV = value; OnPropertyChanged(); } }
        private int? _TongTien;
        public int? TongTien { get => _TongTien; set { _TongTien = value; OnPropertyChanged(); } }
        private int? _MaCTPT;
        public int? MaCTPT { get => _MaCTPT; set { _MaCTPT = value; OnPropertyChanged(); } }
    }
}
