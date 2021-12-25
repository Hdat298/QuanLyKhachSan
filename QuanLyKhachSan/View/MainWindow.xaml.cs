using QuanLyKhachSan.UserControlAll;
using System;
using System.Collections.Generic;
using System.Data.Linq;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HomeUC Home;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
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
                tt_room2.Visibility = Visibility.Collapsed;
                tt_bookroom.Visibility = Visibility.Collapsed;
                tt_customer.Visibility = Visibility.Collapsed;
                tt_service.Visibility = Visibility.Collapsed;
                tt_service2.Visibility = Visibility.Collapsed;
                tt_furniture.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_room.Visibility = Visibility.Visible;
                tt_room2.Visibility = Visibility.Visible;
                tt_bookroom.Visibility = Visibility.Visible;
                tt_customer.Visibility = Visibility.Visible;
                tt_service.Visibility = Visibility.Visible;
                tt_service2.Visibility = Visibility.Visible;
                tt_furniture.Visibility = Visibility.Visible;
            }
        }

        //private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    img_bg.Opacity = 1;
        //}

        //private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        //{
        //    img_bg.Opacity = 0.3;
        //}

        //private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Tg_Btn.IsChecked = false;
        //}

        //private void CloseBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}
    }
}

