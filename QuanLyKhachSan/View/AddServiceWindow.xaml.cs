using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public delegate void Delegate_CTPDV(ObservableCollection<Service2> obDVCT);
        public Delegate_CTPDV truyenData;

        private int? maCTPhieuThue;
        public ObservableCollection<Service> lsdichVu_Customs;
        public ObservableCollection<Service2> lsDichVu_DaChon;
        List<Service> lsCache;

        public AddServiceWindow()
        {
            InitializeComponent();
        }

        public AddServiceWindow(int? mactpt) : this()
        {
            maCTPhieuThue = mactpt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Service dvct = (sender as Button).DataContext as Service;
            lsDichVu_DaChon.Add(new Service2() { ThanhTien = dvct.Gia, SoLuong = 1, TenDV = dvct.TenDV, Gia = dvct.Gia, MaDV = dvct.MaDV });
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
                          MaDV = dv.ID,
                          TenDV = dv.TenDichVu,
                          Gia = dv.DonGia,
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
                DichVuPhong dvp = new DichVuPhong()
                {
                    MaChiTietPhieuThue = maCTPhieuThue,
                    MaDichVu = item.MaDV,
                    SoLuong = item.SoLuong == null ? 0 : int.Parse(item.SoLuong.ToString()),
                    ThanhTien = item.ThanhTien == null ? 0 : int.Parse(item.ThanhTien.ToString())
                };
                DataProvider.Ins.DB.DichVuPhongs.Add(dvp);
                DataProvider.Ins.DB.SaveChanges();
                new DialogCustom("Thêm thành công!", "Thông báo!", DialogCustom.OK).ShowDialog();
                this.Close();
            }
        }

        private void TextBoxSL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox txb = sender as TextBox;
                Service2 dvdc = (sender as TextBox).DataContext as Service2;
                int soLuong = 1;
                if (!int.TryParse(txb.Text, out soLuong))
                {
                    MessageBox.Show("Nhập số nguyên");
                    //new DialogCustoms("Lỗi: Nhập số lượng kiểu số nguyên!", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return;
                }
                dvdc.SoLuong = soLuong;
                dvdc.ThanhTien = dvdc.Gia * soLuong;
            }
        }

        private void TextBoxSL_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = sender as TextBox;
            Service2 dvdc = (sender as TextBox).DataContext as Service2;
            int soLuong = 1;
            if (!int.TryParse(txb.Text, out soLuong))
            {
                MessageBox.Show("Nhập số nguyên");
                //new DialogCustoms("Lỗi: Nhập số lượng kiểu số nguyên!", "Thông báo", DialogCustoms.OK).ShowDialog();
                return;
            }
            dvdc.SoLuong = soLuong;
            dvdc.ThanhTien = dvdc.Gia * soLuong;
        }

        private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView viewDV = (CollectionView)CollectionViewSource.GetDefaultView(lvDanhSachDV.ItemsSource);
            viewDV.Filter = filterTimKiem;
        }

        #region method
        private bool filterTimKiem(object obj)
        {
            if (String.IsNullOrEmpty(txbTimKiem.Text))
                return true;
            else
            {
                string objTenDV = RemoveVietnameseTone((obj as Service).TenDV);
                string timkiem = RemoveVietnameseTone(txbTimKiem.Text);
                return objTenDV.Contains(timkiem);
            }
        }

        public string RemoveVietnameseTone(string text)
        {
            string result = text.ToLower();
            result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
            result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
            result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
            result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            result = Regex.Replace(result, "đ", "d");
            return result;
        }
        #endregion
    }
}
