using Microsoft.Office.Interop.Excel;
using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyKhachSan.UserControlAll
{
    /// <summary>
    /// Interaction logic for EmployeesUC.xaml
    /// </summary>
    public partial class EmployeesUC : System.Windows.Controls.UserControl
    {
        public EmployeesUC()
        {
            InitializeComponent();
        }

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            List<NhanVien> kh = DataProvider.Ins.DB.NhanViens.ToList();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "Tên nhân viên";
                    ws.Cells[1, 2] = "Phái";
                    ws.Cells[1, 3] = "Ngày sinh";
                    ws.Cells[1, 4] = "Địa chỉ";
                    ws.Cells[1, 5] = "Số điện thoại";
                    ws.Cells[1, 6] = "CCCD";
                    ws.Cells[1, 7] = "Chức vụ";
                    ws.Cells[1, 8] = "Loại tài khoản";
                    ws.Cells[1, 9] = "Tên tài khoản";
                    ws.Cells[1, 10] = "Mật khẩu";
                    int i = 2;
                    foreach (var item in kh)
                    {
                        ws.Cells[i, 1] = item.TenNhanVien;
                        ws.Cells[i, 2] = item.GioiTinh.GioiTinh1;
                        ws.Cells[i, 3] = item.NgaySinh;
                        ws.Cells[i, 4] = item.DiaChi;
                        ws.Cells[i, 5] = item.SDT;
                        ws.Cells[i, 6] = item.CCCD;
                        ws.Cells[i, 7] = item.BoPhan.TenBoPhan;
                        ws.Cells[i, 8] = item.LoaiTK.TenTaiKhoan;
                        ws.Cells[i, 9] = item.TenTaiKhoan;
                        ws.Cells[i, 10] = item.MatKhau;
                        i++;
                    }
                    wb.SaveAs(saveFileDialog.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Windows.MessageBox.Show("Your data has been successfully exported.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
