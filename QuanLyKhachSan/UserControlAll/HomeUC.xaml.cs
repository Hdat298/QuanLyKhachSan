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
    /// Interaction logic for HomeUC.xaml
    /// </summary>
    public partial class HomeUC : UserControl
    {
        int i = 1;

        public HomeUC()
        {
            InitializeComponent();
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            i--;

            if (i < 1)
            {
                i = 4;
            }

            Pic.Source = new BitmapImage(new Uri(@"/Source/Home/" + i + ".png", UriKind.Relative));
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            i++;

            if (i > 4)
            {
                i = 1;
            }

            Pic.Source = new BitmapImage(new Uri(@"/Source/Home/" + i + ".png", UriKind.Relative));
        }
    }
}
