using QuanLyKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class classInvoiceWindow2 : BaseViewModel
    {
        private int? _Gia;
        public int? Gia { get => _Gia; set { _Gia = value; OnPropertyChanged(); } }
    }
}
