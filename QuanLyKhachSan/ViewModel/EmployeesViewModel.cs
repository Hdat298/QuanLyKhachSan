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
    class EmployeesViewModel : BaseViewModel
    {
        private ObservableCollection<NhanVien> _List;
        public ObservableCollection<NhanVien> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<BoPhan> _Object;
        public ObservableCollection<BoPhan> Object { get => _Object; set { _Object = value; OnPropertyChanged(); } }

        private ObservableCollection<LoaiTK> _Account;
        public ObservableCollection<LoaiTK> Account { get => _Account; set { _Account = value; OnPropertyChanged(); } }

        private ObservableCollection<GioiTinh> _Gender;
        public ObservableCollection<GioiTinh> Gender { get => _Gender; set { _Gender = value; OnPropertyChanged(); } }

        private NhanVien _SelectedItem;
        public NhanVien SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    TenNhanVien = SelectedItem.TenNhanVien;
                    DiaChi = SelectedItem.DiaChi;
                    SDT = SelectedItem.SDT;
                    CCCD = SelectedItem.CCCD;
                    NgaySinh = SelectedItem.NgaySinh;
                    TenTaiKhoan = SelectedItem.TenTaiKhoan;
                    MatKhau = SelectedItem.MatKhau;
                    SelectedGender = SelectedItem.GioiTinh;
                    SelectedBoPhan = SelectedItem.BoPhan;
                    SelectedAccount = SelectedItem.LoaiTK;
                }
            }
        }

        private BoPhan _SelectedBoPhan;
        public BoPhan SelectedBoPhan
        {
            get => _SelectedBoPhan;
            set
            {
                _SelectedBoPhan = value;
                OnPropertyChanged();
            }
        }
        private LoaiTK _SelectedAccount;
        public LoaiTK SelectedAccount
        {
            get => _SelectedAccount;
            set
            {
                _SelectedAccount = value;
                OnPropertyChanged();
            }
        }

        private GioiTinh _SelectedGender;
        public GioiTinh SelectedGender
        {
            get => _SelectedGender;
            set
            {
                _SelectedGender = value;
                OnPropertyChanged();
            }
        }



        private string _TenNhanVien;
        public string TenNhanVien { get => _TenNhanVien; set { _TenNhanVien = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }
        private string _CCCD;
        public string CCCD { get => _CCCD; set { _CCCD = value; OnPropertyChanged(); } }
        private string _TenTaiKhoan;
        public string TenTaiKhoan { get => _TenTaiKhoan; set { _TenTaiKhoan = value; OnPropertyChanged(); } }
        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; OnPropertyChanged(); } }
        private DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand FindCommand { get; set; }



        public EmployeesViewModel()
        {
            List = new ObservableCollection<NhanVien>(DataProvider.Ins.DB.NhanViens);
            Object = new ObservableCollection<BoPhan>(DataProvider.Ins.DB.BoPhans);
            Account = new ObservableCollection<LoaiTK>(DataProvider.Ins.DB.LoaiTKs);
            Gender = new ObservableCollection<GioiTinh>(DataProvider.Ins.DB.GioiTinhs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedBoPhan == null || SelectedAccount == null || SelectedGender == null)
                    return false;
                return true;
            }, (p) =>
            {
                var KH = new NhanVien() { TenNhanVien = TenNhanVien, CCCD = CCCD, DiaChi = DiaChi, SDT = SDT, TenTaiKhoan = TenTaiKhoan, MatKhau = MatKhau, MaBoPhan = SelectedBoPhan.ID , MaTaiKhoan = SelectedAccount.ID , Phai = SelectedGender.ID};

                DataProvider.Ins.DB.NhanViens.Add(KH);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(KH);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.NhanViens.Where(x => x.ID == SelectedItem.ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var KH = DataProvider.Ins.DB.NhanViens.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();

                KH.TenNhanVien = TenNhanVien;
                KH.CCCD = CCCD;
                KH.DiaChi = DiaChi;
                KH.SDT = SDT;
                KH.NgaySinh = NgaySinh;
                KH.TenTaiKhoan = TenTaiKhoan;
                KH.MatKhau = MatKhau;
                KH.MaBoPhan = SelectedBoPhan.ID;
                KH.MaTaiKhoan = SelectedAccount.ID;
                KH.Phai = SelectedGender.ID;
               
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.TenNhanVien = TenNhanVien;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.NhanViens.Where(x => x.ID == SelectedItem.ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var KH = DataProvider.Ins.DB.NhanViens.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();

                DataProvider.Ins.DB.NhanViens.Remove(KH);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(KH);
            });

            FindCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                List.Clear();

                List<NhanVien> KH = DataProvider.Ins.DB.NhanViens.Where(x => x.TenNhanVien == TenNhanVien || x.DiaChi == DiaChi || x.CCCD == CCCD || x.SDT == SDT || x.TenTaiKhoan == TenTaiKhoan || x.MatKhau == MatKhau || x.MaBoPhan == SelectedBoPhan.ID || x.MaTaiKhoan == SelectedAccount.ID || x.Phai == SelectedGender.ID).ToList();
                if (KH.Count == 0)
                    List = new ObservableCollection<NhanVien>(DataProvider.Ins.DB.NhanViens);
                else
                    List = new ObservableCollection<NhanVien>(KH);
            });
        }
    }
}
