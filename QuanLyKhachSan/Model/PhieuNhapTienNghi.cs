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
    
    public partial class PhieuNhapTienNghi
    {
        public int MaTienNghi { get; set; }
        public int MaNhaCungCap { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
    
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual TienNghi TienNghi { get; set; }
    }
}