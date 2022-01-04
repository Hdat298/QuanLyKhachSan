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
    public class ServiceViewModel : BaseViewModel
    {
        private ObservableCollection<DichVu> _List;
        public ObservableCollection<DichVu> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<LoaiDichVu> _Object;
        public ObservableCollection<LoaiDichVu> Object { get => _Object; set { _Object = value; OnPropertyChanged(); } }

        private DichVu _SelectedItem;
        public DichVu SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    TenDichVu = SelectedItem.TenDichVu;
                    DonGia = SelectedItem.DonGia;
                    SelectedLoai = SelectedItem.LoaiDichVu;
                }
            }
        }

        private LoaiDichVu _SelectedLoai;
        public LoaiDichVu SelectedLoai
        {
            get => _SelectedLoai;
            set
            {
                _SelectedLoai = value;
                OnPropertyChanged();
            }
        }

        private string _TenDichVu;
        public string TenDichVu { get => _TenDichVu; set { _TenDichVu = value; OnPropertyChanged(); } }

        private int? _DonGia;
        public int? DonGia { get => _DonGia; set { _DonGia = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand FindCommand { get; set; }



        public ServiceViewModel()
        {
            List = new ObservableCollection<DichVu>(DataProvider.Ins.DB.DichVus);
            Object = new ObservableCollection<LoaiDichVu>(DataProvider.Ins.DB.LoaiDichVus);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var KH = new DichVu() { TenDichVu = TenDichVu , DonGia = DonGia, MaLoaiDichVu = SelectedLoai.ID};

                DataProvider.Ins.DB.DichVus.Add(KH);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(KH);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.DichVus.Where(x => x.ID == SelectedItem.ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var KH = DataProvider.Ins.DB.DichVus.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();

                KH.TenDichVu = TenDichVu;
                KH.DonGia = DonGia;
                KH.MaLoaiDichVu = SelectedLoai.ID;

                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.TenDichVu = TenDichVu;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.DichVus.Where(x => x.ID == SelectedItem.ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var KH = DataProvider.Ins.DB.DichVus.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();

                DataProvider.Ins.DB.DichVus.Remove(KH);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(KH);
            });

            FindCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                List.Clear();

                List<DichVu> KH = DataProvider.Ins.DB.DichVus.Where(x => x.TenDichVu == TenDichVu || x.DonGia == DonGia || x.MaLoaiDichVu == SelectedLoai.ID).ToList();
                if (KH.Count == 0)
                    List = new ObservableCollection<DichVu>(DataProvider.Ins.DB.DichVus);
                else
                    List = new ObservableCollection<DichVu>(KH);
            });
        }
    }
}
