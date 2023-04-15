using DocumentFormat.OpenXml.Wordprocessing;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetsTaskOVEN.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace TetsTaskOVEN.Services
{
    public static class ExcelManager
    {
        public static void ExportFlightInfo(string filename, List<FlightInfo> flights)
        {
            Excel.Application ex = new Excel.Application();
            //Отобразить Excel
            ex.Visible = false;
            //Количество листов в рабочей книге
            ex.SheetsInNewWorkbook = 1;
            //Добавить рабочую книгу
            Excel.Workbook workBook = ex.Workbooks.Add();

            //Получаем первый лист документа (счет начинается с 1)
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);

            string[] headers = { "id", "Время вылета", "Номер рейса", "ФИО" };
            for (int i = 0; i < headers.Length; i++)
            {
                sheet.Cells[1, i + 1] = headers[i];
            }

            for (int i = 0; i < flights.Count; i++)
            {
                sheet.Cells[i + 2, 1] = flights[i].Id;
                sheet.Cells[i + 2, 2] = flights[i].DepartureTime;
                sheet.Cells[i + 2, 3] = flights[i].RouteNumber;
                sheet.Cells[i + 2, 4] = flights[i].FIO;
            }

            Excel.Range range = sheet.UsedRange;

            range.Cells.Font.Size = 14;

            range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;

            range.EntireColumn.AutoFit();
            range.EntireRow.AutoFit();

            workBook.Close(true, filename);
            ex.Quit();
        }

        public static void ImportFlightInfo(string filename, List<FlightInfo> flights, DataGridView dataGridView)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Чтение данных из Excel-файла в DataTable
                using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var dataSet = reader.AsDataSet();
                        DataTable dataTable = dataSet.Tables[0];

                        dataGridView.DataSource = dataSet;
                    }
                }
            }
        }
    }
}
