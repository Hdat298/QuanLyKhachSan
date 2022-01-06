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
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        private Room phong;
        private int maNV;
        private List<Service2> ls;
        public Room Phong { get => phong; set => phong = value; }
        public int MaNV { get => maNV; set => maNV = value; }

        public InvoiceWindow()
        {
            InitializeComponent();
        }

        public InvoiceWindow(Room p, ObservableCollection<Service2> lsDV) : this()
        {
            this.MaNV = maNV;
            this.Phong = p;
            ls = lsDV.ToList();
            try
            {
                int? tienPhong = 0;
                int? tienDV = 0;
                int temp = int.Parse(checkMP(Phong.MaPhong));
                int? temp1 = int.Parse(checkKH(Phong.TenKH));
                var ds = DataProvider.Ins.DB.ChiTietPhieuThues.Where(o => o.MaPhong == temp).ToList();
                foreach (var item in ds)
                {
                    tienPhong = item.TienPhong;
                }

                var ds1 = DataProvider.Ins.DB.DichVuPhongs.Where(q => q.MaChiTietPhieuThue == Phong.MaCTPT).ToList();
                foreach (var item in ds1)
                {
                    tienDV += item.ThanhTien;
                }
                txbSoPhong.Text = Phong.MaPhong;
                txbTenKH.Text = Phong.TenKH;
                txbSoNgay.Text = Phong.SoNgayO.ToString();
                txbNgayLapHD.Text = DateTime.Now.ToString();
                txbTongTien.Text = string.Format("{0:0,0 VND}", ((tienDV == null ? 0 : tienDV) + tienPhong));

                HoaDon hd = new HoaDon()
                {
                    MaPhong = temp,
                    MaKhachHang = temp1,
                    MaCTPT = Phong.MaCTPT,
                    TongTienDichVu = (tienDV == null ? 0 : tienDV),
                    TongTienThanhToan = (tienDV == null ? 0 : tienDV) + tienPhong,
                    NgayLap = DateTime.Now,
                };
                DataProvider.Ins.DB.HoaDons.Add(hd);
                DataProvider.Ins.DB.SaveChanges();


                Service2 dv = new Service2()
                {
                    SoLuong = Phong.SoNgayO,
                    TenDV = "Thuê phòng",
                    //Gia = PhongBUS.GetInstance().layTienPhongTheoSoPhong(Phong),
                    ThanhTien = tienPhong
                };
                ls.Add(dv);
                lvDichVuDaSD.ItemsSource = ls;

            }
            catch (Exception)
            {
                new DialogCustom("Lỗi load thông tin!", "Thông báo", DialogCustom.OK).ShowDialog();
            }
        }

        #region method
        private string checkMP (string MaPhong)
        {
            List<Phong> dsPhong = DataProvider.Ins.DB.Phongs.ToList();
            foreach (var item in dsPhong)
            {
                if (MaPhong == item.MaPhong)
                {
                    return item.ID.ToString();
                }
            }
            return null;
        }

        private string checkKH (string KH)
        {
            List<KhachHang> dsKH = DataProvider.Ins.DB.KhachHangs.ToList();
            foreach (var item in dsKH)
            {
                if (KH == item.TenKhachHang)
                {
                    return item.ID.ToString();
                }
            }
            return null;
        }
        #endregion

        private void btnInHoaDon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnInHoaDon.Visibility = Visibility.Hidden;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "In Hóa đơn");
                    new DialogCustom("In hóa đơn thành công!", "Thông báo", DialogCustom.OK).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                new DialogCustom("In hóa đơn thất bại! \n Lỗi: " + ex.Message, "Thông báo", DialogCustom.OK).ShowDialog();
            }
            finally
            {
                btnInHoaDon.Visibility = Visibility.Visible;
            }
        }
    }
}
