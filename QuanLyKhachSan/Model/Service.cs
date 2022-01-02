using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class Service : BaseViewModel
    {
        private int? _MaDV;
        public int? MaDV { get => _MaDV; set { _MaDV = value; OnPropertyChanged(); } }
        private string _TenDV;
        public string TenDV { get => _TenDV; set { _TenDV = value; OnPropertyChanged(); } }
        private int? _DonGia;
        public int? DonGia { get => _DonGia; set { _DonGia = value; OnPropertyChanged(); } }
        private string _LoaiDV;
        public string LoaiDV { get => _LoaiDV; set { _LoaiDV = value; OnPropertyChanged(); } }
    }
}
