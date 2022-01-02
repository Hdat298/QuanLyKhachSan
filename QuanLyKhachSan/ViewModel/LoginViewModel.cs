using QuanLyKhachSan.Model;
using QuanLyKhachSan.UserControlAll;
using QuanLyKhachSan.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKhachSan.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        //Xu ly
        public LoginViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        void Login(Window p)
        {
            if (p == null)
                return;

            var accAdmin = DataProvider.Ins.DB.NhanViens.Where(x => x.TenTaiKhoan == UserName && x.MatKhau == Password && x.MaTaiKhoan == 1).Count();
            var accStaff = DataProvider.Ins.DB.NhanViens.Where(x => x.TenTaiKhoan == UserName && x.MatKhau == Password && x.MaTaiKhoan == 2).Count();

            if (accAdmin > 0)
            {
                IsLogin = true;
                p.Close();
                return;
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Show();
                //return;
            }
            if (accStaff > 0)
            {
                //IsLogin = true;
                p.Close();
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Close();
                MainStaffWindow staffWindow = new MainStaffWindow();
                staffWindow.Show();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}
