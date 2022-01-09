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
    /// Interaction logic for CustomerUC.xaml
    /// </summary>
    public partial class CustomerUC : System.Windows.Controls.UserControl
    {
        public CustomerUC()
        {
            InitializeComponent();
        }

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            List<KhachHang> kh = DataProvider.Ins.DB.KhachHangs.ToList();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "Tên Khách hàng";
                    ws.Cells[1, 2] = "CCCD";
                    ws.Cells[1, 3] = "Địa chỉ";
                    ws.Cells[1, 4] = "Số điện thoại";
                    ws.Cells[1, 5] = "Quốc tịch";
                    ws.Cells[1, 6] = "Số hộ chiếu";
                    int i = 2;
                    foreach (var item in kh)
                    {
                        ws.Cells[i, 1] = item.TenKhachHang;
                        ws.Cells[i, 2] = item.CCCD;
                        ws.Cells[i, 3] = item.DiaChi;
                        ws.Cells[i, 4] = item.SDT;
                        ws.Cells[i, 5] = item.QuocTich;
                        ws.Cells[i, 6] = item.SoHoChieu;
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
