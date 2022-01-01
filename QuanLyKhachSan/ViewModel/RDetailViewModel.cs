using QuanLyKhachSan.Model;
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
    public class RDetailViewModel : BaseViewModel
    {
        public ICommand ServiceCommand { get; set; }


        public RDetailViewModel()
        {
            ServiceCommand = new RelayCommand<object>((p) => { return true; }, (p) => { AddServiceWindow wd = new AddServiceWindow(); wd.ShowDialog();});
        }
    }
}
