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
        private ObservableCollection<Room> _List2;
        public ObservableCollection<Room> List2 { get => _List2; set { _List2 = value;  } }
        private ObservableCollection<Room> _List3;
        public ObservableCollection<Room> List3 { get => _List3; set { _List3 = value;  } }
        private ObservableCollection<Room> _List4;
        public ObservableCollection<Room> List4 { get => _List4; set { _List4 = value;  } }
        ObservableCollection<Room> lsTrong;
        List<Room> lsPhong;


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

            var ls2 = (from p in DataProvider.Ins.DB.Phongs
                       join ct in lsCTPT on p.ID equals ct.MaPhong into t
                       from ct in t.DefaultIfEmpty()
                       where p.MaLoaiPhong == 2
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
            List2 = new ObservableCollection<Room>(ls2);

            var ls3 = (from p in DataProvider.Ins.DB.Phongs
                       join ct in lsCTPT on p.ID equals ct.MaPhong into t
                       from ct in t.DefaultIfEmpty()
                       where p.MaLoaiPhong == 3
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
            List3 = new ObservableCollection<Room>(ls3);

            var ls4 = (from p in DataProvider.Ins.DB.Phongs
                       join ct in lsCTPT on p.ID equals ct.MaPhong into t
                       from ct in t.DefaultIfEmpty()
                       where p.MaLoaiPhong == 4
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
            List4 = new ObservableCollection<Room>(ls4);
        }


        #region method
        private void timKiemTheomaPhong()
        {
            CollectionView viewSingleRoom = (CollectionView)CollectionViewSource.GetDefaultView(lvSingleRoom.ItemsSource);
            viewSingleRoom.Filter = filterTimKiem;
            CollectionView viewDoubleRoom = (CollectionView)CollectionViewSource.GetDefaultView(lvDoubleRoom.ItemsSource);
            viewDoubleRoom.Filter = filterTimKiem;
            CollectionView viewTwinRoom = (CollectionView)CollectionViewSource.GetDefaultView(lvTwinRoom.ItemsSource);
            viewTwinRoom.Filter = filterTimKiem;
            CollectionView viewFamilyRoom = (CollectionView)CollectionViewSource.GetDefaultView(lvFamilyRoom.ItemsSource);
            viewFamilyRoom.Filter = filterTimKiem;
            refreshListView();
        }
        private bool filterTimKiem(object obj)
        {
            if (String.IsNullOrEmpty(txbTimKiem.Text))
                return true;
            else
                return (obj as Room).MaPhong.Contains(txbTimKiem.Text);
        }

        private void refreshListView()
        {
            CollectionViewSource.GetDefaultView(lvSingleRoom.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(lvDoubleRoom.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(lvTwinRoom.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(lvFamilyRoom.ItemsSource).Refresh();
        }

        private void checkLoaiPhong(RadioButton rd)
        {
            if (rd.Content.Equals("Single Room"))
            {
                lvSingleRoom.ItemsSource = List1;
                lvDoubleRoom.ItemsSource = lsTrong;
                lvTwinRoom.ItemsSource = lsTrong;
                lvFamilyRoom.ItemsSource = lsTrong;
                refreshListView();
            }
            else if (rd.Content.Equals("Double Room"))
            {
                lvSingleRoom.ItemsSource = lsTrong;
                lvDoubleRoom.ItemsSource = List2;
                lvTwinRoom.ItemsSource = lsTrong;
                lvFamilyRoom.ItemsSource = lsTrong;
                refreshListView();
            }
            else if (rd.Content.Equals("Twin Room"))
            {
                lvSingleRoom.ItemsSource = lsTrong;
                lvDoubleRoom.ItemsSource = lsTrong;
                lvTwinRoom.ItemsSource = List3;
                lvFamilyRoom.ItemsSource = lsTrong;
                refreshListView();
            }
            else if (rd.Content.Equals("Family Room"))
            {
                lvSingleRoom.ItemsSource = lsTrong;
                lvDoubleRoom.ItemsSource = lsTrong;
                lvTwinRoom.ItemsSource = lsTrong;
                lvFamilyRoom.ItemsSource = List4;
                refreshListView();
            }
            else if (rd.Content.Equals("Tất cả loại phòng"))
            {
                lvSingleRoom.ItemsSource = List1;
                lvDoubleRoom.ItemsSource = List2;
                lvTwinRoom.ItemsSource = List3;
                lvFamilyRoom.ItemsSource = List4;
                refreshListView();
            }

        }
        #endregion

        #region event
        private void rb_Click(object sender, RoutedEventArgs e)
        {

            if (((sender as RadioButton).Parent as StackPanel).Name.ToString().Equals("spLoaiPhong"))
            {
                checkLoaiPhong(sender as RadioButton);
            }

        }
        private void roomWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lsPhong = new List<Room>();
            lsTrong = new ObservableCollection<Room>();
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

            var ls2 = (from p in DataProvider.Ins.DB.Phongs
                       join ct in lsCTPT on p.ID equals ct.MaPhong into t
                       from ct in t.DefaultIfEmpty()
                       where p.MaLoaiPhong == 2
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
            List2 = new ObservableCollection<Room>(ls2);
            lvDoubleRoom.ItemsSource = List2;

            var ls3 = (from p in DataProvider.Ins.DB.Phongs
                       join ct in lsCTPT on p.ID equals ct.MaPhong into t
                       from ct in t.DefaultIfEmpty()
                       where p.MaLoaiPhong == 3
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
            List3 = new ObservableCollection<Room>(ls3);
            lvTwinRoom.ItemsSource = List3;

            var ls4 = (from p in DataProvider.Ins.DB.Phongs
                       join ct in lsCTPT on p.ID equals ct.MaPhong into t
                       from ct in t.DefaultIfEmpty()
                       where p.MaLoaiPhong == 4
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
            List4 = new ObservableCollection<Room>(ls4);
            lvFamilyRoom.ItemsSource = List4;

        }

        private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            timKiemTheomaPhong();
        }
        #endregion


    }
}
