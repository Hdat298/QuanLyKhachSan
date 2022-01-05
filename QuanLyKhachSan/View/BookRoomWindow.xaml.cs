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
        public ObservableCollection<ChiTietPhieuThue> lsPDaChons;
        public ObservableCollection<CTThueCustom> lsCT;

        List<PhongTrong> lsPhongCaches;
        private int maNV;

        public int MaNV { get => maNV; set => maNV = value; }

        public BookRoomWindow()
        {
            InitializeComponent();
        }

        public BookRoomWindow(int maNV) : this()
        {
            this.MaNV = maNV;
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
                          MaPhong = p.ID,
                          LoaiPhong = p.LoaiPhong.TenLoaiPhong,
                          MaLoaiPhong = p.MaLoaiPhong
                      }
                      ).ToList();

            lsPhongTrongs = new ObservableCollection<PhongTrong>(ls);
            lvPhongTrong.ItemsSource = lsPhongTrongs;
        }

        private void bookRoomWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dtpNgayKT.Text = new DateTime().ToShortDateString();
            dtpNgayBD.Text = new DateTime().ToShortDateString();

            lsCT = new ObservableCollection<CTThueCustom>();
            lsPDaChons = new ObservableCollection<ChiTietPhieuThue>();
            lsPhongCaches = new List<PhongTrong>();
            lvPhongDaChon.ItemsSource = lsPDaChons;
            getPhongTrongTheoNgayGio();
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {

            PhongTrong ephongTrong = (sender as Button).DataContext as PhongTrong;
            lsPhongCaches.Add(ephongTrong);
            lsPhongTrongs.Remove(ephongTrong);
            ChiTietPhieuThue phongDaChon = new ChiTietPhieuThue()
            {
                MaPhong = ephongTrong.MaPhong,
                NgayBD = DateTime.Parse(dtpNgayBD.Text),
                NgayKT = DateTime.Parse(dtpNgayKT.Text),
                TienPhong = tienPhong((int)ephongTrong.MaLoaiPhong)
            };
            lsPDaChons.Add(phongDaChon);
        }

        private bool kiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txbHoTen.Text))
            {
                txbHoTen.Focus();
                new DialogCustom("Nhập đầy đủ họ tên !", "Thông báo", DialogCustom.OK).ShowDialog();
                return false;
            }
            //Kiểm tra textbox CCCD rỗng hoặc nhập kí tự chữ không
            if (string.IsNullOrWhiteSpace(txbCCCD.Text))
            {
                txbCCCD.Focus();
                new DialogCustom("Nhập đầy đủ căn cước công dân !", "Thông báo", DialogCustom.OK).ShowDialog();
                return false;
            }
            else
            {
                if (!long.TryParse(txbCCCD.Text, out long temp))
                {
                    txbCCCD.Focus();
                    new DialogCustom("Nhập căn cước công dân đúng định dạng số !", "Thông báo", DialogCustom.OK).ShowDialog();
                    return false;
                }
                if (txbCCCD.Text.Length > 12)
                {
                    txbCCCD.Focus();
                    new DialogCustom("Nhập căn cước công dân không quá 12 ký tự !", "Thông báo", DialogCustom.OK).ShowDialog();
                    return false;
                }
            }
            //Kiểm tra textbox SDT rỗng hoặc có nhập chữ không
            if (string.IsNullOrWhiteSpace(txbSDT.Text))
            {
                txbSDT.Focus();
                new DialogCustom("Nhập đầy đủ số điện thoại !", "Thông báo", DialogCustom.OK).ShowDialog();
                return false;
            }
            else
            {
                if (!long.TryParse(txbSDT.Text, out long temp))
                {
                    txbSDT.Focus();
                    new DialogCustom("Nhập số điện thoại đúng định dạng số !", "Thông báo", DialogCustom.OK).ShowDialog();
                    return false;
                }
                if (txbSDT.Text.Length > 10)
                {
                    txbSDT.Focus();
                    new DialogCustom("Nhập số điện thoại không quá 10 ký tự !", "Thông báo", DialogCustom.OK).ShowDialog();
                    return false;
                }
            }
            //Kiểm tra ô nhập địa chỉ
            if (string.IsNullOrWhiteSpace(txbDiaChi.Text))
            {
                txbDiaChi.Focus();
                new DialogCustom("Nhập đầy đủ địa chỉ !", "Thông báo", DialogCustom.OK).ShowDialog();
                return false;
            }
            //kiểm tra ô quốc tịch
            if (string.IsNullOrWhiteSpace(txbQuocTich.Text))
            {
                txbQuocTich.Focus();
                new DialogCustom("Nhập đầy đủ quốc tịch !", "Thông báo", DialogCustom.OK).ShowDialog();
                return false;
            }
            //Kiểm tra xem đã có phòng nào được chọn chưa
            if (lsPDaChons.Count == 0)
            {
                new DialogCustom("Vui lòng chọn phòng trước khi lưu !", "Thông báo", DialogCustom.OK).ShowDialog();
                return false;
            }
            return true;
        }

        private void DT_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string ngayBD = dtpNgayBD.Text;
            string ngayKT = dtpNgayKT.Text;
            DateTime dtNBD;
            DateTime dtNKT;
            if (!DateTime.TryParse(ngayBD, out dtNBD))
            {
                return;
            }

            if (!DateTime.TryParse(ngayKT, out dtNKT))
            {
                return;
            }
            //nếu ngày bắt đầu lớn hơn ngày kết thúc thì phải báo lỗi ngay
            if (dtNBD > dtNKT)
            {
                new DialogCustom("Ngày bắt đầu không thể lớn hơn ngày kết thúc !", "Thông báo", DialogCustom.OK).ShowDialog();
                dtpNgayBD.Text = ngayKT;
                dtpNgayKT.Text = ngayKT;
                return;
            }
            getPhongTrongTheoNgayGio();
        }
        #region method
        private string checkKH(string CCCD)
        {
            List <KhachHang> lstKH = DataProvider.Ins.DB.KhachHangs.ToList();
            foreach (var item in lstKH)
            {
                if (CCCD == item.CCCD)
                {
                    return item.CCCD;
                }
            }
            return null;
        }
        private string checkMaKH(string CCCDD)
        {
            List<KhachHang> lshKH2 = DataProvider.Ins.DB.KhachHangs.ToList();
            foreach (var item in lshKH2)
            {
                if (CCCDD == item.CCCD)
                {
                    return item.ID.ToString();
                }
            }
            return null;

        }

        private int tienPhong(int MaPhong)
        {
            int a = 0;
            if (MaPhong == 1)
            {
                a = 200000;
            }
            if (MaPhong == 2)
            {
                a = 240000;
            }
            if (MaPhong == 3)
            {
                a = 240000;
            }
            if (MaPhong == 4)
            {
                a = 260000;
            }
            return a;
        }
        #endregion
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (kiemTraDayDuThongTin())
            {
                KhachHang kh = new KhachHang()
                {
                    CCCD = txbCCCD.Text,
                    TenKhachHang = txbHoTen.Text,
                    DiaChi = txbDiaChi.Text,
                    QuocTinh = txbQuocTich.Text,
                    SDT = txbSDT.Text
                };
                
                if (checkKH(txbCCCD.Text) == null)
                {
                    new DialogCustom("Thêm khách hàng mới và đặt phòng thành công " , "Thông báo", DialogCustom.OK).ShowDialog();
                    DataProvider.Ins.DB.KhachHangs.Add(kh);
                    DataProvider.Ins.DB.SaveChanges();
                    
                }
            }

            PhieuThue pt = new PhieuThue()
            {
                Ngaylap = DateTime.Now,
                MaKhachHang = Convert.ToInt32(checkMaKH(txbCCCD.Text)),
                MaNhanVien = Convert.ToInt32(txtMaNV.Text)
            };
            DataProvider.Ins.DB.PhieuThues.Add(pt);
            DataProvider.Ins.DB.SaveChanges();

            foreach (var item in lsPDaChons)
            {
                ChiTietPhieuThue ctpt = new ChiTietPhieuThue()
                {
                    MaPhong = item.MaPhong,
                    NgayBD = dtpNgayBD.SelectedDate,
                    NgayKT = dtpNgayKT.SelectedDate,
                    TrangThai = "Chưa thanh toán",
                    MaPhieuThue = pt.ID,
                    TienPhong = item.TienPhong
                };
                DataProvider.Ins.DB.ChiTietPhieuThues.Add(ctpt);
                DataProvider.Ins.DB.SaveChanges();
            }
            
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            ChiTietPhieuThue phongDaChon = (sender as Button).DataContext as ChiTietPhieuThue;
            foreach (PhongTrong pt in lsPhongCaches)
            {
                if (pt.MaPhong.Equals(phongDaChon.MaPhong))
                {
                    lsPhongTrongs.Add(pt);
                    lsPhongCaches.Remove(pt);
                    break;
                }
            }
            lsPDaChons.Remove(phongDaChon);
        }
    }
}
