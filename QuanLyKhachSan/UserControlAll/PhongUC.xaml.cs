using QuanLyKhachSan.Model;
using QuanLyKhachSan.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.SqlServer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyKhachSan.UserControlAll
{
    /// <summary>
    /// Interaction logic for PhongUC.xaml
    /// </summary>
    public partial class PhongUC : UserControl
    {
        private ObservableCollection<Room> _List1;
        public ObservableCollection<Room> List1 { get => _List1; set { _List1 = value; } }
        public PhongUC()
        {
            InitializeComponent();
        }

        private void LvPhongDon_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView lv = sender as ListView;
            Room phong = lv.SelectedItem as Room;
            if (phong != null)
            {
                RoomDetailWindow ct = new RoomDetailWindow();
                ct.truyenData(phong);
                ct.ShowDialog();
                //lv.UnselectAll();
            }
        }
        public void Refresh()
        {
            var lsCTPT = DataProvider.Ins.DB.ChiTietPhieuThues.Where(p => p.TrangThai.CompareTo("Đã thanh toán") != 0).AsEnumerable();

            var ls = (from p in DataProvider.Ins.DB.Phongs
                      join ct in lsCTPT on p.ID equals ct.MaPhong into t
                      from ct in t.DefaultIfEmpty()
                      where p.MaLoaiPhong == 1
                      select new Room()
                      {
                          MaCTPT = ct.ID,
                          TenKH = (ct.PhieuThue.KhachHang.TenKhachHang == null) ? "" : ct.PhieuThue.KhachHang.TenKhachHang,
                          MaPhong = p.MaPhong,
                          TrangThai = (ct.TrangThai == null) ? "Phòng trống" : "Phòng đang thuê",
                          LoaiPhong = p.LoaiPhong.TenLoaiPhong,
                          NgayDen = ct.NgayBD,
                          NgayDi = ct.NgayKT,
                          SoNgayO = (ct.NgayBD == null) ? 0 : (int)SqlFunctions.DateDiff("day", ct.NgayBD, ct.NgayKT) + 1,
                          TinhTrangPhong = p.TinhTrangPhong
                      }
                      ).ToList();
            List1 = new ObservableCollection<Room>(ls);
            lvSingleRoom.ItemsSource = List1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
