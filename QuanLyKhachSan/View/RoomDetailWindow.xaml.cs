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
        private ObservableCollection<ServiceRoomDetail> _lvServiceRoomDetail;
        public ObservableCollection<ServiceRoomDetail> lvServiceRoomDetail { get => _lvServiceRoomDetail; set { _lvServiceRoomDetail = value; } }
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
                icDayorHour.Kind = MaterialDesignThemes.Wpf.PackIconKind.CalendarToday;
                txblSoNgay.Text = phong.SoNgayO.ToString() + " ngày";
            }
            cbTinhTrang.Text = phong.TrangThai;
            txblNgayDen.Text = phong.NgayDen.ToString();
            //Lấy ra mã CT phiếu thuê
            maCTPhieuThue = phong.MaCTPT;

        }

        private string checkMP (string MaPhong)
        {
            List<Phong> lsPhong = DataProvider.Ins.DB.Phongs.ToList();
            foreach (var item in lsPhong)
            {
                if (MaPhong == item.MaPhong)
                {
                    return item.ID.ToString();
                }
            }
            return null;
        }

        private void Click_Charge(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Visibility = Visibility.Hidden;

            ChiTietPhieuThue lsCTHD = DataProvider.Ins.DB.ChiTietPhieuThues.FirstOrDefault(p => p.MaPhong.ToString() == checkMP(txblTieuDe.Text).FirstOrDefault().ToString());
            ChiTietPhieuThue ctpt = new ChiTietPhieuThue() { TrangThai = "Đã thanh toán" };
            DataProvider.Ins.DB.ChiTietPhieuThues.Add(ctpt);
            DataProvider.Ins.DB.SaveChanges();
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
                        join dv in DataProvider.Ins.DB.DichVus on dvp.MaDichVu equals dv.ID into t
                        from dv in t.DefaultIfEmpty()
                        where maCTPhieuThue == dvp.MaChiTietPhieuThue
                        select new ServiceRoomDetail()
                        {
                            TenDV = dv.TenDichVu,
                            SoLuong = dvp.SoLuong,
                            ThanhTien = dvp.ThanhTien,
                        }
                        ).ToList();
            lvServiceRoomDetail = new ObservableCollection<ServiceRoomDetail>(list);
            lvSuDungDV.ItemsSource = lvServiceRoomDetail;
        }
    }
}
