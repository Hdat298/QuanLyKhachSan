using QuanLyKhachSan.Model;
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
using System.Windows.Shapes;

namespace QuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for BookRoomWindow.xaml
    /// </summary>
    public partial class BookRoomWindow : Window
    {
        public ObservableCollection<PhongTrong> lsPhongTrongs;
        public ObservableCollection<CTThue> lsPDaChons;
        List<PhongTrong> lsPhongCaches;


        public BookRoomWindow()
        {
            InitializeComponent();
        }
        private void getPhongTrongTheoNgayGio()
        {
            var lsCTPT = DataProvider.Ins.DB.ChiTietPhieuThues.Where(p => p.TrangThai.CompareTo("Đã thanh toán") != 0).AsEnumerable();

            var ls = (from p in DataProvider.Ins.DB.Phongs
                      join ct in lsCTPT on p.ID equals ct.MaPhong into t
                      from ct in t.DefaultIfEmpty()
                      where ct.TrangThai == null || ct.TrangThai == "Đã thanh toán"
                      select new PhongTrong()
                      {
                          MaPhong = p.MaPhong,
                          LoaiPhong = p.LoaiPhong.TenLoaiPhong,
                      }
                      ).ToList();

            lsPhongTrongs = new ObservableCollection<PhongTrong>(ls);
            lvPhongTrong.ItemsSource = lsPhongTrongs;
        }

        private void bookRoomWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lsPDaChons = new ObservableCollection<CTThue>();
            lsPhongCaches = new List<PhongTrong>();
            lvPhongDaChon.ItemsSource = lsPDaChons;
            getPhongTrongTheoNgayGio();
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {

            PhongTrong ephongTrong = (sender as Button).DataContext as PhongTrong;
            lsPhongCaches.Add(ephongTrong);
            lsPhongTrongs.Remove(ephongTrong);
            CTThue phongDaChon = new CTThue()
            {
                SoPhong = ephongTrong.MaPhong,
                NgayBD = DateTime.Parse(dtpNgayBD.Text),
                NgayKT = DateTime.Parse(dtpNgayKT.Text)
            };
            lsPDaChons.Add(phongDaChon);
        }
    }
}
