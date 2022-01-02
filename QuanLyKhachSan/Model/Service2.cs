using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class Service2 : BaseViewModel
    {

        private string _TenDV;
        public string TenDV { get => _TenDV; set { _TenDV = value; OnPropertyChanged(); } }
        private int? _SoLuong;
        public int? SoLuong { get => _SoLuong; set { _SoLuong = value; OnPropertyChanged(); } }
        private decimal? _ThanhTien;
        public decimal? ThanhTien { get => _ThanhTien; set { _ThanhTien = value; OnPropertyChanged(); } }
        private int? _Gia;
        public int? Gia { get => _Gia; set { _Gia = value; OnPropertyChanged(); } }

    }
}
