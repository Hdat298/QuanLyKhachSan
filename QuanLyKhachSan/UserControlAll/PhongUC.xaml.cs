using QuanLyKhachSan.Model;
using QuanLyKhachSan.View;
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

namespace QuanLyKhachSan.UserControlAll
{
    /// <summary>
    /// Interaction logic for PhongUC.xaml
    /// </summary>
    public partial class PhongUC : UserControl
    {
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
    }
}
