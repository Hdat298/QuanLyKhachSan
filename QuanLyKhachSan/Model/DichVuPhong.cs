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
    
    public partial class DichVuPhong
    {
        public int ID { get; set; }
        public string MaChiTietDVPhong { get; set; }
        public Nullable<int> MaChiTietPhieuThue { get; set; }
        public Nullable<int> MaDichVu { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> ThanhTien { get; set; }
    
        public virtual ChiTietPhieuThue ChiTietPhieuThue { get; set; }
        public virtual DichVu DichVu { get; set; }
    }
}