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
                    MaChiTietPhieuThue = Phong.MaCTPT,
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

        public InvoiceWindow(int mahd) : this()
        {
            try
            {
                int MACT = 0;
                
                var hd = DataProvider.Ins.DB.HoaDons.Where(h => h.ID == mahd).ToList();
                if (hd == null)
                {
                    new DialogCustom("Hóa đơn không tồn tại!", "Thông báo", DialogCustom.OK).ShowDialog();
                    return;
                }
                var hd1 = (from p in hd
                           join ctpt in DataProvider.Ins.DB.ChiTietPhieuThues on p.MaChiTietPhieuThue equals ctpt.ID into k
                           from q in k.DefaultIfEmpty()
                           select new classInvoiceWindow()
                           {
                               SoPhong = p.ChiTietPhieuThue.MaPhong,
                               NgayBD = p.ChiTietPhieuThue.NgayBD,
                               NgayKT = p.ChiTietPhieuThue.NgayKT,
                               TenKH = checkMaKH(p.ChiTietPhieuThue.MaPhieuThue.ToString()),
                               NgayLap = p.NgayLap,
                               TongTien = p.TongTienThanhToan
                           }
                           ).ToList();
                foreach (var item in hd1)
                {
                    txbSoPhong.Text = item.SoPhong.ToString();
                    txbSoNgay.Text = (item.NgayKT - item.NgayBD).ToString();
                    txbTenKH.Text = item.TenKH;
                    txbNgayLapHD.Text = item.NgayLap.ToString();
                    txbTongTien.Text = string.Format("{0:0,0 VND}", item.TongTien);
                }

                foreach (var item in hd)
                {
                    MACT = (int)item.MaChiTietPhieuThue;
                }
                var listDV = DataProvider.Ins.DB.DichVuPhongs.Where(dvp => dvp.MaChiTietPhieuThue == MACT).ToList();
                var listDV2 = (from ldv in listDV
                               select new Service2()
                               {
                                   MaDV = ldv.MaDichVu,
                                   TenDV = checkDV(ldv.MaDichVu.ToString()),
                                   SoLuong = ldv.SoLuong,
                                   Gia = checkPrice((int)ldv.MaDichVu),
                                   ThanhTien = ldv.ThanhTien
                               }
                               );
                ls = new List<Service2>(listDV2);

                int temp = 0;
                int temp1 = 0;
                var lsDV = DataProvider.Ins.DB.ChiTietPhieuThues.Where(ctpt => ctpt.ID == MACT).ToList();
                var lsDV2 = (from p in hd
                             join r in DataProvider.Ins.DB.Phongs on p.MaPhong equals r.ID into t
                             from o in t.DefaultIfEmpty()
                             select new classInvoiceWindow2()
                             {
                                 Gia = p.Phong.LoaiPhong.GiaNgay,
                             }
                             );
                foreach (var item in lsDV2)
                {
                    temp1 = (int)item.Gia;
                }

                foreach (var item in lsDV)
                {
                    temp = (int)item.TienPhong;
                }
                Service2 dv = new Service2()
                {
                    TenDV = "Thuê phòng",
                    ThanhTien = temp,
                    Gia = temp1
                };
                ls.Add(dv);
                lvDichVuDaSD.ItemsSource = ls;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region method
        private int checkPrice (int MaDV)
        {
            List<DichVu> lsDichVu = DataProvider.Ins.DB.DichVus.ToList();
            foreach (var item in lsDichVu)
            {
                if (MaDV == item.ID)
                {
                    return (int)item.DonGia;
                }
            }
            return 0;
        }
        private string checkDV (string MaDV)
        {
            List<DichVu> lsDichVu = DataProvider.Ins.DB.DichVus.ToList();
            foreach (var item in lsDichVu)
            {
                if (MaDV == item.ID.ToString())
                {
                    return item.TenDichVu;
                }
            }
            return null;
        }
        private string checkMaKH (string MaKH)
        {
            List<KhachHang> lsCustom = DataProvider.Ins.DB.KhachHangs.ToList();
            foreach (var item in lsCustom)
            {
                if (MaKH == item.ID.ToString())
                {
                    return item.TenKhachHang;
                }
            }
            return null;
        }

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
