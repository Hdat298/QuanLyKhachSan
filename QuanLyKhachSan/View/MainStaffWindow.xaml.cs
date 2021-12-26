using QuanLyKhachSan.UserControlAll;
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
    /// Interaction logic for MainStaffWindow.xaml
    /// </summary>
    public partial class MainStaffWindow : Window
    {
        private HomeUC Home;
        private PhongUC phongUC;

        public MainStaffWindow()
        {
            InitializeComponent();
        }

        private void mainStaffWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            Home = new HomeUC();
            contenDisplayMain.Content = Home;

        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_room.Visibility = Visibility.Collapsed;
                tt_bookroom.Visibility = Visibility.Collapsed;
                tt_customer.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_room.Visibility = Visibility.Visible;
                tt_bookroom.Visibility = Visibility.Visible;
                tt_customer.Visibility = Visibility.Visible;
            }
        }

        private void LV_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (LV.SelectedValue != null)
            {
                switch (LV.SelectedIndex)
                {
                    case 0:
                        if (Home == null)
                        {
                            Home = new HomeUC();
                        }
                        contenDisplayMain.Content = Home;
                        break;
                    case 1:
                        if (phongUC == null)
                        {
                            phongUC = new PhongUC();
                        }
                        contenDisplayMain.Content = phongUC;
                        break;
                }
            }
        }
    }
}
