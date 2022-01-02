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
    class DetailConvenientViewModel : BaseViewModel
    {
        private ObservableCollection<ChiTietTienNghi> _List;
        public ObservableCollection<ChiTietTienNghi> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<TienNghi> _Convenient;
        public ObservableCollection<TienNghi> Convenient { get => _Convenient; set { _Convenient = value; OnPropertyChanged(); } }

        private ObservableCollection<Phong> _Room;
        public ObservableCollection<Phong> Room { get => _Room; set { _Room = value; OnPropertyChanged(); } }

        private ChiTietTienNghi _SelectedItem;
        public ChiTietTienNghi SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Soluong = SelectedItem.Soluong;
                    SelectedConvenient = SelectedItem.TienNghi;
                    SelectedRoom = SelectedItem.Phong;
                }
            }
        }

        private TienNghi _SelectedConvenient;
        public TienNghi SelectedConvenient
        {
            get => _SelectedConvenient;
            set
            {
                _SelectedConvenient = value;
                OnPropertyChanged();
            }
        }

        private Phong _SelectedRoom;
        public Phong SelectedRoom
        {
            get => _SelectedRoom;
            set
            {
                _SelectedRoom = value;
                OnPropertyChanged();
            }
        }


        private int? _Soluong;
        public int? Soluong { get => _Soluong; set { _Soluong = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand FindCommand { get; set; }



        public DetailConvenientViewModel()
        {
            List = new ObservableCollection<ChiTietTienNghi>(DataProvider.Ins.DB.ChiTietTienNghis);
            Convenient = new ObservableCollection<TienNghi>(DataProvider.Ins.DB.TienNghis);
            Room = new ObservableCollection<Phong>(DataProvider.Ins.DB.Phongs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var KH = new ChiTietTienNghi() { Soluong = Soluong , MaPhong = SelectedRoom.ID , MaTienNghi = SelectedConvenient.ID};

                DataProvider.Ins.DB.ChiTietTienNghis.Add(KH);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(KH);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.ChiTietTienNghis.Where(x => x.MaPhong == SelectedRoom.ID && x.MaTienNghi == SelectedConvenient.ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var KH = DataProvider.Ins.DB.ChiTietTienNghis.Where(x => x.MaPhong == SelectedRoom.ID && x.MaTienNghi == SelectedConvenient.ID).SingleOrDefault();

                KH.Soluong = Soluong;
                KH.MaPhong = SelectedRoom.ID;
                KH.MaTienNghi = SelectedConvenient.ID;

                DataProvider.Ins.DB.SaveChanges();

            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.ChiTietTienNghis.Where(x => x.MaPhong == SelectedRoom.ID && x.MaTienNghi == SelectedConvenient.ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var KH = DataProvider.Ins.DB.ChiTietTienNghis.Where(x => x.MaPhong == SelectedRoom.ID && x.MaTienNghi == SelectedConvenient.ID).SingleOrDefault();

                DataProvider.Ins.DB.ChiTietTienNghis.Remove(KH);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(KH);
            });

            FindCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                List.Clear();

                List<ChiTietTienNghi> KH = DataProvider.Ins.DB.ChiTietTienNghis.Where(x => x.Soluong == Soluong || x.MaPhong == SelectedRoom.ID || x.MaTienNghi == SelectedConvenient.ID).ToList();
                if (KH.Count == 0)
                    List = new ObservableCollection<ChiTietTienNghi>(DataProvider.Ins.DB.ChiTietTienNghis);
                else
                    List = new ObservableCollection<ChiTietTienNghi>(KH);

            });
        }
    }
}
