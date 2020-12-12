using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebScraper
{
    class ExcelOutputer : Outputer, IOutputer
    {
        protected override string GenerateSavePathAndFileName()
        {
            return base.GenerateSavePathAndFileName() + ".xls";
        }

        public void GenerateOutput(Scrapper scrapper)
        {
            Excel.Application excelApp = new Excel.Application();
            if (excelApp != null)
            {
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets.Add();

                int headingsRow = 1;
                for (int i = 0; i < scrapper.Headings.Count; i++)
                {
                    int column = i + 1;
                    excelWorksheet.Cells[headingsRow, column] = scrapper.Headings[i];
                }

                for (int i = 0; i < scrapper.TableRows.Count; i++)
                {
                    int row = i + 2;

                    List<string> tableRow = scrapper.TableRows[i];
                    for (int j = 0; j < tableRow.Count; j++)
                    {
                        int column = j + 1;
                        excelWorksheet.Cells[row, column] = tableRow[j];
                    }
                }

                excelApp.ActiveWorkbook.SaveAs(GenerateSavePathAndFileName(), Excel.XlFileFormat.xlWorkbookNormal);

                excelWorkbook.Close();
                excelApp.Quit();

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorksheet);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorkbook);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    
    }
}
