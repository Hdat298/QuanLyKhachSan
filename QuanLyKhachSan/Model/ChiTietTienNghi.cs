//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyKhachSan.Model
{
    using System;
    using System.Collections.Generic;
    using QuanLyKhachSan.ViewModel;

    public partial class ChiTietTienNghi : BaseViewModel
    {
        public int ID { get; set; }
        public string MaChiTietTienNghi { get; set; }

        private Nullable<int> _Soluong;
        public Nullable<int> Soluong { get => _Soluong; set { _Soluong = value; OnPropertyChanged(); } }

        private Nullable<int> _MaTienNghi;
        public Nullable<int> MaTienNghi { get => _MaTienNghi; set { _MaTienNghi = value; OnPropertyChanged(); } }

        private Nullable<int> _MaPhong;
        public Nullable<int> MaPhong { get => _MaPhong; set { _MaPhong = value; OnPropertyChanged(); } }

        private Phong _Phong;
        public virtual Phong Phong { get => _Phong; set { _Phong = value; OnPropertyChanged(); } }

        private TienNghi _TienNghi;
        public virtual TienNghi TienNghi { get => _TienNghi; set { _TienNghi = value; OnPropertyChanged(); } }
    }
}
