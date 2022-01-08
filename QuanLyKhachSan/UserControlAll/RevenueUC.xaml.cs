using LiveCharts;
using LiveCharts.Wpf;
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
using QuanLyKhachSan.Model;

namespace QuanLyKhachSan.UserControlAll
{
    /// <summary>
    /// Interaction logic for Revenue.xaml
    /// </summary>
    public partial class Revenue : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private readonly ChartValues<double> _DTPhong;
        private readonly ChartValues<double> _DTDichVu;
        public int? DTPhong1 { get; set; }
        public int? DTDVPhong1 { get; set; }

        public Revenue()
        {
            InitializeComponent();

            _DTPhong = new ChartValues<double>();
            _DTDichVu = new ChartValues<double>();
            int? dtp = 0;
            int? dtdvp = 0;

            var DTPhong = (from p in DataProvider.Ins.DB.HoaDons                           
                           group p by new { month = p.NgayLap.Value.Month, year = p.NgayLap.Value.Year } into d
                           select new
                           {
                               DVPhong = d.Sum(p => p.TongTienDichVu) == null ? 0 : d.Sum(p => p.TongTienDichVu),
                           }).ToList();

            var DTDVPhong = (from p in DataProvider.Ins.DB.HoaDons
                             group p by new { month = p.NgayLap.Value.Month, year = p.NgayLap.Value.Year } into d
                             select new
                             {
                                 CTPhieuThue = d.Sum(p => p.ChiTietPhieuThue.TienPhong) == null ? 0 : d.Sum(p => p.ChiTietPhieuThue.TienPhong),
                             }).ToList();

            foreach (var item in DTPhong)
            {
                dtp = dtp + item.DVPhong;
            }

            foreach (var item in DTDVPhong)
            {
                dtdvp = dtdvp + item.CTPhieuThue;
            }

            foreach (var item in DTPhong)
            {
                _DTPhong.Add(item.DVPhong.Value);
            }

            foreach (var item in DTDVPhong)
            {
                _DTDichVu.Add(item.CTPhieuThue.Value);
            }


            SeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Doanh thu phòng",
                        Values = _DTPhong,
                        PointGeometry = DefaultGeometries.Diamond,
                        PointGeometrySize = 15
                    },
                    new LineSeries
                    {
                        Title = "Doanh thu dịch vụ",
                        Values = _DTDichVu,
                        PointGeometry = DefaultGeometries.Triangle,
                        PointGeometrySize = 15
                    },
                };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "August", "September", "October", "November", "December" };
            YFormatter = value => value.ToString("C");
            DataContext = this;
            DTPhong1 = dtp;
            DTDVPhong1 = dtdvp;
        }
    }
}
