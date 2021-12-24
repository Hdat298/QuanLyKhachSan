using QuanLyKhachSan.UserControlAll;
using QuanLyKhachSan.View;
using System;
using System.Collections.Generic;
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
        public ICommand HomeCommand { get; set; }


        // xử lý
        public MainViewModel()
        {
            HomeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MainWindow mainWibn;
                HomeUC ucHome = new HomeUC();
                mainWibn
            }
                );



        }
    }
}
