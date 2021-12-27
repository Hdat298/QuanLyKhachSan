using QuanLyKhachSan.Model;
using QuanLyKhachSan.UserControlAll;
using QuanLyKhachSan.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKhachSan.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoad = false;
        public ICommand LoadedWindowCommand { get; set; }


        // xử lý
        public MainViewModel()
        {
            //LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            //{
            //    IsLoad = true;
            //    if (p == null)
            //        return;

            //    p.Hide();
            //    LoginWindow loginWindow = new LoginWindow();
            //    loginWindow.ShowDialog();

            //    if (loginWindow.DataContext == null)
            //        return;
            //    var loginVM = loginWindow.DataContext as LoginViewModel;

            //    if (loginVM.IsLogin)
            //    {
            //        p.Show();
            //    }
            //    else
            //    {
            //        p.Close();
            //    }
            //}
            //    );
        }
    }
}
