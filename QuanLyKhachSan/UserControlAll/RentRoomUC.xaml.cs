using QuanLyKhachSan.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyKhachSan.UserControlAll
{
    /// <summary>
    /// Interaction logic for RentRoomUC.xaml
    /// </summary>
    public partial class RentRoomUC : UserControl
    {
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
    }
}
