using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyKhachSan.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<KhachHang> _List;
        public ObservableCollection<KhachHang> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private KhachHang _SelectedItem;
        public KhachHang SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    TenKhachHang = SelectedItem.TenKhachHang;
                    DiaChi = SelectedItem.DiaChi;
                    SDT = SelectedItem.SDT;
                    QuocTinh = SelectedItem.QuocTinh;
                    SoHoChieu = SelectedItem.SoHoChieu;
                    CCCD = SelectedItem.CCCD;
                }
            }
        }

        private string _TenKhachHang;
        public string TenKhachHang { get => _TenKhachHang; set { _TenKhachHang = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }
        private string _QuocTinh;
        public string QuocTinh { get => _QuocTinh; set { _QuocTinh = value; OnPropertyChanged(); } }
        private string _SoHoChieu;
        public string SoHoChieu { get => _SoHoChieu; set { _SoHoChieu = value; OnPropertyChanged(); } }
        private string _CCCD;
        public string CCCD { get => _CCCD; set { _CCCD = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand FindCommand { get; set; }



        public CustomerViewModel()
        {
            List = new ObservableCollection<KhachHang>(DataProvider.Ins.DB.KhachHangs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => 
            {
                var KH = new KhachHang() { TenKhachHang = TenKhachHang , CCCD = CCCD , DiaChi = DiaChi , SDT = SDT , QuocTinh = QuocTinh , SoHoChieu = SoHoChieu};

                DataProvider.Ins.DB.KhachHangs.Add(KH);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(KH);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.KhachHangs.Where(x => x.ID == SelectedItem.ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var KH = DataProvider.Ins.DB.KhachHangs.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();

                KH.TenKhachHang = TenKhachHang;
                KH.CCCD = CCCD;
                KH.DiaChi = DiaChi;
                KH.SDT = SDT;
                KH.QuocTinh = QuocTinh;
                KH.SoHoChieu = SoHoChieu;

                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.TenKhachHang = TenKhachHang;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.KhachHangs.Where(x => x.ID == SelectedItem.ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var KH = DataProvider.Ins.DB.KhachHangs.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();

                DataProvider.Ins.DB.KhachHangs.Remove(KH);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(KH);
            });

            FindCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                List.Clear();

                List<KhachHang> KH = DataProvider.Ins.DB.KhachHangs.Where(x => x.TenKhachHang == TenKhachHang || x.DiaChi == DiaChi || x.CCCD == CCCD || x.SDT == SDT || x.QuocTinh ==QuocTinh || x.SoHoChieu == SoHoChieu ).ToList();
                if (KH.Count == 0) 
                    List = new ObservableCollection<KhachHang>(DataProvider.Ins.DB.KhachHangs);
                else
                    List = new ObservableCollection<KhachHang>(KH);
            });
        }
    }
}
