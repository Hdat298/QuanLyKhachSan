using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class CTThue : BaseViewModel
    {
        private string _TrangThai;
        public string TrangThai { get => _TrangThai; set { _TrangThai = value; OnPropertyChanged(); } }
        //private string _SoPhong;
        //public string SoPhong { get => _SoPhong; set { _SoPhong = value; OnPropertyChanged(); } }
        //private DateTime? _NgayBD;
        //public DateTime? NgayBD { get => _NgayBD; set { _NgayBD = value; OnPropertyChanged(); } }
        //private DateTime? _NgayKT;
        //public DateTime? NgayKT { get => _NgayKT; set { _NgayKT = value; OnPropertyChanged(); } }
    }
}
