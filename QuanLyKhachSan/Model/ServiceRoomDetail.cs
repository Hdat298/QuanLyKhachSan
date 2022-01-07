using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class ServiceRoomDetail : BaseViewModel
    {
        private string _TenDV;
        public string TenDV { get => _TenDV; set { _TenDV = value; OnPropertyChanged(); } }
        private int? _SoLuong;
        public int? SoLuong { get => _SoLuong; set { _SoLuong = value; OnPropertyChanged(); } }
        private int? _ThanhTien;
        public int? ThanhTien { get => _ThanhTien; set { _ThanhTien = value; OnPropertyChanged(); } }

    }
}
