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
    
    public partial class DichVu : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            this.DichVuPhongs = new HashSet<DichVuPhong>();
        }
    
        public int ID { get; set; }
        public string MaDichVu { get; set; }

        private string _TenDichVu;
        public string TenDichVu { get => _TenDichVu; set { _TenDichVu = value; OnPropertyChanged(); } }

        private Nullable<int> _DonGia;
        public Nullable<int> DonGia { get => _DonGia; set { _DonGia = value; OnPropertyChanged(); } }

        private Nullable<int> _MaLoaiDichVu;
        public Nullable<int> MaLoaiDichVu { get => _MaLoaiDichVu; set { _MaLoaiDichVu = value; OnPropertyChanged(); } }

        public virtual LoaiDichVu LoaiDichVu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DichVuPhong> DichVuPhongs { get; set; }
    }
}
