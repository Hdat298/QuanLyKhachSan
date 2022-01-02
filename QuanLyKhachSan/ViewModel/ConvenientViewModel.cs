using QuanLyKhachSan.Model;
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
    class ConvenientViewModel : BaseViewModel
    {
        private ObservableCollection<TienNghi> _List;
        public ObservableCollection<TienNghi> List { get => _List; set { _List = value; OnPropertyChanged(); } }



        private string _TenTienNghi;
        public string TenTienNghi { get => _TenTienNghi; set { _TenTienNghi = value; OnPropertyChanged(); } }
        private int? _Luong;
        public int? Luong { get => _Luong; set { _Luong = value; OnPropertyChanged(); } }



        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }



        public ConvenientViewModel()
        {

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var KH = new TienNghi() { TenTienNghi = TenTienNghi};

                DataProvider.Ins.DB.TienNghis.Add(KH);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });

            CancelCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                TenTienNghi = null;
            });
        }
    }
}
