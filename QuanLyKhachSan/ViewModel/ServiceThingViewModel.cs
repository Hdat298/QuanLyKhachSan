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
    class ServiceThingViewModel : BaseViewModel
    {
        private ObservableCollection<LoaiDichVu> _List;
        public ObservableCollection<LoaiDichVu> List { get => _List; set { _List = value; OnPropertyChanged(); } }



        private string _TenTienNghi;
        public string TenTienNghi { get => _TenTienNghi; set { _TenTienNghi = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }



        public ServiceThingViewModel()
        {

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var KH = new LoaiDichVu() { LoaiDichVu1 = TenTienNghi };

                DataProvider.Ins.DB.LoaiDichVus.Add(KH);
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
