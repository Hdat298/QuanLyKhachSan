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

            var DTPhong = (from p in DataProvider.Ins.DB.DichVuPhongs
                           join c in DataProvider.Ins.DB.ChiTietHoaDons on p.ID equals c.MaChiTietDVPhong into r
                           from x in r.DefaultIfEmpty()
                           group x by new { month = x.NgayLapPhieu.Value.Month, year = x.NgayLapPhieu.Value.Year } into d
                           select new
                           {
                               MaPhong = d.Sum(p => p.Phong.LoaiPhong.GiaNgay) == null ? 0 : d.Sum(p => p.Phong.LoaiPhong.GiaNgay),
                           }).ToList();

            var DTDVPhong = (from p in DataProvider.Ins.DB.DichVuPhongs
                           join c in DataProvider.Ins.DB.ChiTietHoaDons on p.ID equals c.MaChiTietDVPhong into r
                           from x in r.DefaultIfEmpty()
                           group x by new { month = x.NgayLapPhieu.Value.Month, year = x.NgayLapPhieu.Value.Year } into d
                           select new
                           {
                               MaDichVu = d.Sum(p => p.DichVuPhong.ThanhTien) == null ? 0 : d.Sum(p => p.DichVuPhong.ThanhTien),
                           }).ToList();

            foreach (var item in DTPhong)
            {
                dtp = dtp + item.MaPhong;
            }

            foreach (var item in DTDVPhong)
            {
                dtdvp = dtdvp + item.MaDichVu;
            }

            foreach (var item in DTPhong)
            {
                _DTPhong.Add(item.MaPhong.Value);
            }

            foreach (var item in DTDVPhong)
            {
                _DTDichVu.Add(item.MaDichVu.Value);
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

        //private void Revenue_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Revenues.AxisX.Add(new LiveCharts.Wpf.Axis
        //    {
        //        Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "August", "September", "October", "November", "December" }
        //    });

        //    Revenues.AxisY.Add(new LiveCharts.Wpf.Axis
        //    {
        //        LabelFormatter = value => value.ToString("C")
        //    });
        //}

        //private void btn_Load_Click(object sender, RoutedEventArgs e)

        //{
        //    //Revenues.Series.Clear();
        //    SeriesCollection series = new SeriesCollection();
        //    var years = (from o in DataProvider.Ins.DB.ChiTietHoaDons
        //                 select new { Year = o.NgayLapPhieu.Value.Year }).Distinct();
        //    foreach (var item in years)
        //    {
        //        List<int?> values = new List<int?>();
        //        for (int month = 1; month <= 12; month++)
        //        {
        //            int? value = 0;
        //            var data = from o in DataProvider.Ins.DB.ChiTietHoaDons
        //                       where o.NgayLapPhieu.Value.Year.Equals(item.Year) && o.NgayLapPhieu.Value.Month.Equals(month)
        //                       orderby o.NgayLapPhieu.Value.Month ascending
        //                       select new { o.MaPhong, o.NgayLapPhieu.Value.Month };
        //            if (data.SingleOrDefault() != null)
        //                value = data.SingleOrDefault().MaPhong;
        //            values.Add(value);
        //        }
        //        series.Add(new LineSeries() { Title = item.Year.ToString(), Values = new ChartValues<int?>(values) });
        //    }
        //    Revenues.Series = series;
        //}
    }
}
