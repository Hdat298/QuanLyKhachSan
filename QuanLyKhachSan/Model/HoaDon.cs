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
    
    public partial class HoaDon
    {
        public int ID { get; set; }
        public string MaHoaDon { get; set; }
        public Nullable<int> MaPhong { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
        public Nullable<int> MaCTPT { get; set; }
        public Nullable<int> TongTienDichVu { get; set; }
        public Nullable<int> TongTienThanhToan { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
    
        public virtual DichVu DichVu { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual Phong Phong { get; set; }
    }
}
