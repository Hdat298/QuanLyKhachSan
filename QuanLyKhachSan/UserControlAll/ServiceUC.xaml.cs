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
    /// Interaction logic for ServiceUC.xaml
    /// </summary>
    public partial class ServiceUC : System.Windows.Controls.UserControl
    {
        public ServiceUC()
        {
            InitializeComponent();
        }

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            List<DichVu> kh = DataProvider.Ins.DB.DichVus.ToList();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "Tên dịch vụ";
                    ws.Cells[1, 2] = "Loại dịch vụ";
                    ws.Cells[1, 3] = "Đơn giá";
                    int i = 2;
                    foreach (var item in kh)
                    {
                        ws.Cells[i, 1] = item.TenDichVu;
                        ws.Cells[i, 2] = item.LoaiDichVu.LoaiDichVu1;
                        ws.Cells[i, 3] = item.DonGia;
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
