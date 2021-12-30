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
        private PhongUC phongUC;
        private EmployeesUC employeeUC;
        private CustomerUC customerUC;
        private ServiceUC serviceUC;
        private SuplierUC suplierUC;

        public MainWindow()
        {
            InitializeComponent();
        }


        //private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    this.DataContext = this;
        //    Home = new HomeUC();
        //    contenDisplayMain.Content = Home;

        //}

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
                tt_invoice.Visibility = Visibility.Collapsed;
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
                tt_invoice.Visibility = Visibility.Visible;
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
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        if (customerUC == null)
                        {
                            customerUC = new CustomerUC();
                        }
                        contenDisplayMain.Content = customerUC;
                        break;
                    case 5:
                        if (serviceUC == null)
                        {
                            serviceUC = new ServiceUC();
                        }
                        contenDisplayMain.Content = serviceUC;
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                }
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

