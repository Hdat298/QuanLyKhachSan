using QuanLyKhachSan.Model;
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
using System.Windows.Shapes;

namespace QuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        public AddRoomWindow()
        {
            InitializeComponent();
        }

        #region method
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                new DialogCustom("Vui lòng nhập số phòng", "Thông báo", DialogCustom.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbLoaiPhong.Text))
            {
                new DialogCustom("Vui lòng chọn loại phòng", "Thông báo", DialogCustom.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbTinhTrang.Text))
            {
                new DialogCustom("Vui lòng chọn tình trạng", "Thông báo", DialogCustom.OK).Show();
                return false;
            }
            return true;
        }

        private string checkLoaiPhong(string LoaiPhong)
        {
            if (LoaiPhong == "Single Room")
            {
                return "1";
            }
            if (LoaiPhong == "Twin Room")
            {
                return "2";
            }
            if (LoaiPhong == "Double Room")
            {
                return "3";
            }
            if (LoaiPhong == "Family Room")
            {
                return "4";
            }
            return null;
        }
        #endregion

        #region event
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string temp = checkLoaiPhong(cmbLoaiPhong.Text);
            if (!KiemTra())
            {
                return;
            }
            else
            {
                Phong p = new Phong()
                {
                    MaLoaiPhong = int.Parse(temp),
                    SoPhong = txtSoPhong.Text,
                    TinhTrangPhong = cmbTinhTrang.Text,
                };
                DataProvider.Ins.DB.Phongs.Add(p);
                DataProvider.Ins.DB.SaveChanges();
                new DialogCustom("Thêm phòng mới thành công!", "Thông báo", DialogCustom.OK).Show();
                this.Close();
            }
        }
        #endregion
    }
}
