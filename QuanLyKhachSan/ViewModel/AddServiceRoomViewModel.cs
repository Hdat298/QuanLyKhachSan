using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace QuanLyKhachSan.ViewModel
{
    public class AddServiceRoomViewModel : BaseViewModel
    {
        private ObservableCollection<Service> _ServiceList;
        public ObservableCollection<Service> ServiceList { get => _ServiceList; set { _ServiceList = value; OnPropertyChanged(); } }

        public AddServiceRoomViewModel()
        {
            var ls = (from dv in DataProvider.Ins.DB.DichVus
                      join ldv in DataProvider.Ins.DB.LoaiDichVus on dv.MaLoaiDichVu equals ldv.ID into t
                      from ldv in t.DefaultIfEmpty()
                      select new Service()
                      {
                          TenDV = dv.TenDichVu,
                          DonGia = dv.DonGia,
                          LoaiDV = ldv.LoaiDichVu1
                      }).ToList();
            ServiceList = new ObservableCollection<Service>(ls);
        }
    }
}
