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
    public class SuplierViewModel: BaseViewModel
    {
    private ObservableCollection<NhaCungCap> _List;
    public ObservableCollection<NhaCungCap> List { get => _List; set { _List = value; OnPropertyChanged(); } }

    private NhaCungCap _SelectedItem;
    public NhaCungCap SelectedItem
    {
        get => _SelectedItem;
        set
        {
            _SelectedItem = value;
            OnPropertyChanged();
            if (SelectedItem != null)
            {
                TenNhaCungCap = SelectedItem.TenNhaCungCap;
                DiaChi = SelectedItem.DiaChi;
                SDT = SelectedItem.SDT;
            }
        }
    }
    

    private string _TenNhaCungCap;
    public string TenNhaCungCap { get => _TenNhaCungCap; set { _TenNhaCungCap = value; OnPropertyChanged(); } }

    private string _DiaChi;
    public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }

    private string _SDT;
    public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }
    public ICommand AddCommand { get; set; }
    public ICommand EditCommand { get; set; }
    public ICommand DeleteCommand { get; set; }
    public ICommand FindCommand { get; set; }



    public SuplierViewModel()
    {
        List = new ObservableCollection<NhaCungCap>(DataProvider.Ins.DB.NhaCungCaps);

        AddCommand = new RelayCommand<object>((p) =>
        {
            return true;
        }, (p) =>
        {
            var KH = new NhaCungCap() { TenNhaCungCap = TenNhaCungCap, DiaChi = DiaChi, SDT = SDT};

            DataProvider.Ins.DB.NhaCungCaps.Add(KH);
            DataProvider.Ins.DB.SaveChanges();

            List.Add(KH);
        });

        EditCommand = new RelayCommand<object>((p) =>
        {
            if (SelectedItem == null)
                return false;

            var displayList = DataProvider.Ins.DB.NhaCungCaps.Where(x => x.ID == SelectedItem.ID);
            if (displayList != null && displayList.Count() != 0)
                return true;

            return false;

        }, (p) =>
        {
            var KH = DataProvider.Ins.DB.NhaCungCaps.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();

            KH.TenNhaCungCap = TenNhaCungCap;
            KH.DiaChi = DiaChi;
            KH.SDT = SDT;

            DataProvider.Ins.DB.SaveChanges();

            SelectedItem.TenNhaCungCap = TenNhaCungCap;
        });

        DeleteCommand = new RelayCommand<object>((p) =>
        {
            if (SelectedItem == null)
                return false;

            var displayList = DataProvider.Ins.DB.NhaCungCaps.Where(x => x.ID == SelectedItem.ID);
            if (displayList != null && displayList.Count() != 0)
                return true;

            return false;
        }, (p) =>
        {
            var KH = DataProvider.Ins.DB.NhaCungCaps.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();

            DataProvider.Ins.DB.NhaCungCaps.Remove(KH);
            DataProvider.Ins.DB.SaveChanges();

            List.Remove(KH);
        });

        FindCommand = new RelayCommand<object>((p) =>
        {
            return true;
        }, (p) =>
        {
            List.Clear();

            List<NhaCungCap> KH = DataProvider.Ins.DB.NhaCungCaps.Where(x => x.TenNhaCungCap == TenNhaCungCap || x.DiaChi == DiaChi || x.SDT == SDT).ToList();
            if (KH.Count == 0)
                List = new ObservableCollection<NhaCungCap>(DataProvider.Ins.DB.NhaCungCaps);
            else
                List = new ObservableCollection<NhaCungCap>(KH);
        });
    }
}
}
