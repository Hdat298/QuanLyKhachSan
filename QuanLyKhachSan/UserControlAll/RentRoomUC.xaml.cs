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
    /// Interaction logic for RentRoomUC.xaml
    /// </summary>
    public partial class RentRoomUC : UserControl
    {
        ObservableCollection<RentRoomCustom> lsPhieuThueCustom;
        private ObservableCollection<RentRoomCustom> _List1;
        public ObservableCollection<RentRoomCustom> List1 { get => _List1; set { _List1 = value; } }

        private int maNV;
        public int MaNV { get => maNV; set => maNV = value; }
        public RentRoomUC()
        {
            InitializeComponent();
        }

        public RentRoomUC(int maNV) : this()
        {
            this.MaNV = maNV;
        }

        private void click_DatPhong(object sender, RoutedEventArgs e)
        {
            BookRoomWindow dp = new BookRoomWindow(MaNV);
            dp.ShowDialog();
        }

        private void click_Xoa(object sender, RoutedEventArgs e)
        {
            //PhieuThue_Custom phieuThue = (sender as Button).DataContext as PhieuThue_Custom;
            //string error = string.Empty;
            //DialogCustoms dlg = new DialogCustoms("Bạn có muốn xóa phiếu thuê " + phieuThue.MaPhieuThue, "Thông báo", DialogCustoms.YesNo);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var ls = (from pt in DataProvider.Ins.DB.PhieuThues
                      join nv in DataProvider.Ins.DB.NhanViens on pt.MaNhanVien equals nv.ID into p
                      from k in p.DefaultIfEmpty()
                      join kh in DataProvider.Ins.DB.KhachHangs on pt.MaKhachHang equals kh.ID into q
                      from o in q.DefaultIfEmpty()
                      select new RentRoomCustom()
                      {
                          MaPhieuThue = pt.ID,
                          TenKH = o.TenKhachHang,
                          NgayLap = pt.Ngaylap,
                          TenNV = k.TenNhanVien,
                      }
                      );
            List1 = new ObservableCollection<RentRoomCustom>(ls);
            lvPhieuThue.ItemsSource = List1;
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            RentRoomCustom ptct = (sender as Button).DataContext as RentRoomCustom;
            if (ptct != null)
            {
                RentRoomDetailWindow ctPT = new RentRoomDetailWindow(ptct);
                ctPT.ShowDialog();
            }
        }
    }
}
