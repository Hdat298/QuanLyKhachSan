using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class classInvoiceWindow : BaseViewModel
    {
        private int? _SoPhong;
        public int? SoPhong { get => _SoPhong; set { _SoPhong = value; OnPropertyChanged(); } }
        private DateTime? _NgayBD;
        public DateTime? NgayBD { get => _NgayBD; set { _NgayBD = value; OnPropertyChanged(); } }
        private DateTime? _NgayKT;
        public DateTime? NgayKT { get => _NgayKT; set { _NgayKT = value; OnPropertyChanged(); } }
        private string _TenKH;
        public string TenKH { get => _TenKH; set { _TenKH = value; OnPropertyChanged(); } }
        private DateTime? _NgayLap;
        public DateTime? NgayLap { get => _NgayLap; set { _NgayLap = value; OnPropertyChanged(); } }
        private int? _TongTien;
        public int? TongTien { get => _TongTien; set { _TongTien = value; OnPropertyChanged(); } }
    }
}
