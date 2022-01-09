using QuanLyKhachSan.Model;
using QuanLyKhachSan.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for QLPhongUC.xaml
    /// </summary>
    public partial class QLPhongUC : UserControl
    {
        public ObservableCollection<Phong> room;
        private ObservableCollection<QLPhongCustom> _lsQLPhong;
        public ObservableCollection<QLPhongCustom> lsQLPhong { get => _lsQLPhong; set { _lsQLPhong = value; } }

        public QLPhongUC()
        {
            InitializeComponent();
        }


        private void ucQLPhong_Loaded(object sender, RoutedEventArgs e)
        {
            var ls = (from p in DataProvider.Ins.DB.Phongs
                      join lp in DataProvider.Ins.DB.LoaiPhongs on p.MaLoaiPhong equals lp.ID into o
                      from q in o.DefaultIfEmpty()
                      select new QLPhongCustom()
                      {
                          MaPhong = p.MaPhong,
                          TinhTrang = p.TinhTrangPhong,
                          LoaiPhong = q.TenLoaiPhong
                      }
                      ).ToList();
            lsQLPhong = new ObservableCollection<QLPhongCustom>(ls);
            lsvPhong.ItemsSource = lsQLPhong;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddRoomWindow arw = new AddRoomWindow();
            arw.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            QLPhongCustom phong = (sender as Button).DataContext as QLPhongCustom;
            var thongbao = new DialogCustom("Bạn có thật sự muốn xóa phòng " + phong.MaPhong, "Thông báo", DialogCustom.YesNo);
            if (thongbao.ShowDialog() == true)
            {
                new DialogCustom("Xóa thành công", "Thông báo", DialogCustom.OK).Show();
                var p = DataProvider.Ins.DB.Phongs.Where(l => l.MaPhong == phong.MaPhong).SingleOrDefault();
                DataProvider.Ins.DB.Phongs.Remove(p);
                DataProvider.Ins.DB.SaveChanges();
            }
        }

    }
}
