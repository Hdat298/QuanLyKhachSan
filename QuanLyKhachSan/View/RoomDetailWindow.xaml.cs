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
    /// Interaction logic for RoomDetailWindow.xaml
    /// </summary>
    public partial class RoomDetailWindow : Window
    {
        public delegate void truyenDataPhong(Room phong);
        public truyenDataPhong truyenData;
        ObservableCollection<Service2> obDichVu;
        private Room phong_CTPhong;
        private int? maCTPhieuThue;


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

        private void Click_Charge(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Visibility = Visibility.Hidden;
        }

        private void ButtonService_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow RoomService = new AddServiceWindow(maCTPhieuThue);
            RoomService.truyenData = new AddServiceWindow.Delegate_CTPDV(nhanData);
            RoomService.ShowDialog();
        }
        void nhanData(ObservableCollection<Service2> obDVCT)
        {
            foreach (var item in obDVCT)
            {
                obDichVu.Add(item);
            }
        }

        private void bookRoomWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var list = (from dvp in DataProvider.Ins.DB.DichVuPhongs
                        where )
        }
    }
}
