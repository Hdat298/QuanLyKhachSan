using QuanLyKhachSan.Model;
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
    }
}
