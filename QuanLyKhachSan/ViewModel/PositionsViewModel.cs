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
    class PositionsViewModel : BaseViewModel
    {
        private ObservableCollection<BoPhan> _List;
        public ObservableCollection<BoPhan> List { get => _List; set { _List = value; OnPropertyChanged(); } }



        private string _TenBoPhan;
        public string TenBoPhan { get => _TenBoPhan; set { _TenBoPhan = value; OnPropertyChanged(); } }
        private int? _Luong;
        public int? Luong { get => _Luong; set { _Luong = value; OnPropertyChanged(); } }



        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }



        public PositionsViewModel()
        {

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var KH = new BoPhan() { TenBoPhan = TenBoPhan, Luong = (int)Luong };

                DataProvider.Ins.DB.BoPhans.Add(KH);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });

            CancelCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                TenBoPhan = null;
                Luong = null;
            });
        }
    }
}
