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
    /// Interaction logic for InvoiceUC.xaml
    /// </summary>
    public partial class InvoiceUC : UserControl
    {
        private ObservableCollection<classInvoiceUC> _lsInvoice;
        public ObservableCollection<classInvoiceUC> lsInvoice { get => _lsInvoice; set { _lsInvoice = value; } }

        public InvoiceUC()
        {
            InitializeComponent();
        }

        private void invoiceWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var HoaDon = (from hd in DataProvider.Ins.DB.HoaDons
                          select new classInvoiceUC()
                          {
                              MaHD = hd.ID,
                              NgayLap = hd.NgayLap,
                              TienDV = hd.TongTienDichVu,
                              TongTien = hd.TongTienThanhToan,
                              MaCTPT = hd.MaChiTietPhieuThue
                          }
                          ).ToList();
            lsInvoice = new ObservableCollection<classInvoiceUC>(HoaDon);
            lsvHoaDon.ItemsSource = lsInvoice;
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            classInvoiceUC hd = (sender as Button).DataContext as classInvoiceUC;
            new InvoiceWindow((int)hd.MaHD).ShowDialog();
        }

        private void Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsvHoaDon.ItemsSource);
            view.Filter = HoaDonFilter;
            CollectionViewSource.GetDefaultView(lsvHoaDon.ItemsSource).Refresh();
        }
        private bool HoaDonFilter(object obj)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
            {
                return true;
            }
            else
                return (obj as classInvoiceUC).MaHD == int.Parse(txtFilter.Text);
        }
    }
}
