using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for RoomDetailWindow.xaml
    /// </summary>
    public partial class RoomDetailWindow : Window
    {
        public delegate void truyenDataPhong(Room phong);
        public truyenDataPhong truyenData;
        private Room phong_CTPhong;
        private string maCTPhieuThue;


        public RoomDetailWindow()
        {
            truyenData = new truyenDataPhong(setDataPhongCustom);
            InitializeComponent();
        }

        void setDataPhongCustom(Room phong)
        {
            //Nhận dữ liệu từ form cha và gán giá trị lên form con
            phong_CTPhong = phong;
            txblTieuDe.Text = phong.MaPhong;
            txblTenKH.Text = phong.TenKH;
            {
                icDayorHour.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlarmCheck;
            }
            cbTinhTrang.Text = phong.TrangThai;
            //Lấy ra mã CT phiếu thuê
            maCTPhieuThue = phong.MaCTPT;

        }
        
    }
}
