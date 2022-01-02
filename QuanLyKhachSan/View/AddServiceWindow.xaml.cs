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
using System.Windows.Shapes;

namespace QuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {



        public ObservableCollection<Service> lsdichVu_Customs;
        public ObservableCollection<Service2> lsDichVu_DaChon;
        List<Service> lsCache;

        public AddServiceWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Service dvct = (sender as Button).DataContext as Service;
            lsDichVu_DaChon.Add(new Service2() { ThanhTien = dvct.DonGia, SoLuong = 1, TenDV = dvct.TenDV, Gia = dvct.DonGia });
            lsCache.Add(dvct);
            lsdichVu_Customs.Remove(dvct);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var ls = (from dv in DataProvider.Ins.DB.DichVus
                      join ldv in DataProvider.Ins.DB.LoaiDichVus on dv.MaLoaiDichVu equals ldv.ID into t
                      from ldv in t.DefaultIfEmpty()
                      select new Service()
                      {
                          TenDV = dv.TenDichVu,
                          DonGia = dv.DonGia,
                          LoaiDV = ldv.LoaiDichVu1
                      }).ToList();
            lsdichVu_Customs = new ObservableCollection<Service>(ls);

            lsDichVu_DaChon = new ObservableCollection<Service2>();
            lsCache = new List<Service>();
            lvDanhSachDV.ItemsSource = lsdichVu_Customs;
            lvDichVuDaChon.ItemsSource = lsDichVu_DaChon;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lsDichVu_DaChon)
            {

            }
        }
    }
}
