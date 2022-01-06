﻿using Microsoft.Office.Interop.Excel;
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
    /// Interaction logic for SuplierUC.xaml
    /// </summary>
    public partial class SuplierUC : System.Windows.Controls.UserControl
    {
        public SuplierUC()
        {
            InitializeComponent();
        }

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            List<NhaCungCap> kh = DataProvider.Ins.DB.NhaCungCaps.ToList();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "Tên nhà cung cấp";
                    ws.Cells[1, 2] = "Địa chỉ";
                    ws.Cells[1, 3] = "Số điện thoại";
                    int i = 2;
                    foreach (var item in kh)
                    {
                        ws.Cells[i, 1] = item.TenNhaCungCap;
                        ws.Cells[i, 2] = item.DiaChi;
                        ws.Cells[i, 3] = item.SDT;
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
