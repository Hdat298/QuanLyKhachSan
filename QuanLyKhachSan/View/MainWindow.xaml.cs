using QuanLyKhachSan.Model;
using QuanLyKhachSan.UserControlAll;
using QuanLyKhachSan.ViewModel;
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
        private RentRoomUC rentRoomUC;
        private QLPhongUC manageRoomUC;
        private InvoiceUC invoiceUC;
        private Revenue revenueUC;
        private DetailConvenientUC detailConUC;

        NhanVien nhanVien;
        public MainWindow()
        {
            InitializeComponent();
        }
        private int maNV;
        public int MaNV { get => maNV; set => maNV = value; }
        public MainWindow(NhanVien nv) : this()
        {
            this.nhanVien = nv;
            this.MaNV = nv.ID;
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {

            //if (Tg_Btn.IsChecked == true)
            //{
            //    tt_home.Visibility = Visibility.Collapsed;
            //    tt_room.Visibility = Visibility.Collapsed;
            //    tt_room2.Visibility = Visibility.Collapsed;
            //    tt_bookroom.Visibility = Visibility.Collapsed;
            //    tt_customer.Visibility = Visibility.Collapsed;
            //    tt_service.Visibility = Visibility.Collapsed;
            //    tt_furniture.Visibility = Visibility.Collapsed;
            //    tt_invoice.Visibility = Visibility.Collapsed;
            //    tt_revenue.Visibility = Visibility.Collapsed;
            //    tt_employee.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    tt_home.Visibility = Visibility.Visible;
            //    tt_room.Visibility = Visibility.Visible;
            //    tt_room2.Visibility = Visibility.Visible;
            //    tt_bookroom.Visibility = Visibility.Visible;
            //    tt_customer.Visibility = Visibility.Visible;
            //    tt_service.Visibility = Visibility.Visible;
            //    tt_furniture.Visibility = Visibility.Visible;
            //    tt_invoice.Visibility = Visibility.Visible;
            //    tt_revenue.Visibility = Visibility.Visible;
            //    tt_employee.Visibility = Visibility.Visible;
            //}
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
                        BG.Visibility = Visibility.Collapsed;
                        contenDisplayMain.Content = Home;
                        break;
                    case 1:
                        if (phongUC == null)
                        {
                            phongUC = new PhongUC();
                        }
                        else
                        {
                            phongUC.Refresh();
                        }
                        contenDisplayMain.Content = phongUC;
                        break;
                    case 2:
                        if (manageRoomUC == null)
                        {
                            manageRoomUC = new QLPhongUC();
                        }
                        contenDisplayMain.Content = manageRoomUC;
                        break;
                    case 3:
                        if (rentRoomUC == null)
                        {
                            rentRoomUC = new RentRoomUC(MaNV);
                        }
                        contenDisplayMain.Content = rentRoomUC;
                        break;
                    case 4:
                        if (customerUC == null)
                        {
                            customerUC = new CustomerUC();
                        }
                        contenDisplayMain.Content = customerUC;
                        break;
                    case 5:
                        if (employeeUC == null)
                        {
                            employeeUC = new EmployeesUC();
                        }
                        contenDisplayMain.Content = employeeUC;
                        break;
                    case 6:
                        if (serviceUC == null)
                        {
                            serviceUC = new ServiceUC();
                        }
                        contenDisplayMain.Content = serviceUC;
                        break;
                    case 7:
                        if (detailConUC == null)
                        {
                            detailConUC = new DetailConvenientUC();
                        }
                        contenDisplayMain.Content = detailConUC;
                        break;
                    case 8:
                        if (invoiceUC == null)
                        {
                            invoiceUC = new InvoiceUC();
                        }
                        contenDisplayMain.Content = invoiceUC;
                        break;
                    case 9:
                        if (revenueUC == null)
                        {
                            revenueUC = new Revenue();
                        }
                        contenDisplayMain.Content = revenueUC;
                        break;

                }
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            DialogCustom dialog = new DialogCustom("Bạn có muốn đăng xuất ?", "Thông báo", DialogCustom.YesNo);
            if (dialog.ShowDialog() == true)
            {
                this.Close();
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

