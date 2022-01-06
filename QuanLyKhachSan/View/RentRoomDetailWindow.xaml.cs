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
    /// Interaction logic for RentRoomDetailWindow.xaml
    /// </summary>
    public partial class RentRoomDetailWindow : Window
    {
        private ObservableCollection<CTThueCustom> _List1;
        public ObservableCollection<CTThueCustom> List1 { get => _List1; set { _List1 = value; } }

        public RentRoomDetailWindow()
        {
            InitializeComponent();
        }

        public RentRoomDetailWindow(RentRoomCustom ptct) : this()
        {
            int temp = checkPT((int)ptct.MaPhieuThue);
            var ctp = DataProvider.Ins.DB.ChiTietPhieuThues.Where(p => p.ID == temp).ToList();
            var ls1 = (from p in ctp
                       select new CTThueCustom()
                       {
                           SoPhong = p.ID,
                           NgayBD = p.NgayBD,
                           NgayKT = p.NgayKT
                       }
                       ).ToList();

            txblTenKH.Text = ptct.TenKH;
            txblNgayLapHD.Text = ptct.NgayLap.ToString();
            txblTenNV.Text = ptct.TenNV;
            txblTieuDe.Text += ptct.MaPhieuThue;
            //lsCTPT = new List<CTThueCustom>(ctp);
            List1 = new ObservableCollection<CTThueCustom>(ls1);
            lvCTPT.ItemsSource = List1;
        }
        public int checkPT(int MaPT)
        {
            List<ChiTietPhieuThue> lsPhong = DataProvider.Ins.DB.ChiTietPhieuThues.ToList();
            foreach (var item in lsPhong)
            {
                if (MaPT == item.MaPhong)
                {
                    return item.ID;
                }
            }
            return 0;
        }

    }
}
