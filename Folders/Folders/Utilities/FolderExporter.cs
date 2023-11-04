
using Folders.Models;
using OfficeOpenXml;

namespace Folders.Utilities
{
    public class FolderExporter
    {
        public byte[] ExportToExcel(List<Folder> folders)
        {
            using (var package = new ExcelPackage())
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets.Add("Folders");

                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Parent";

                int currentRow = 2;

                foreach (var folder in folders)
                {
                    worksheet.Cells[currentRow, 1].Value = folder.Name;

                    if (folder.ParentFolder != null)
                    {
                        worksheet.Cells[currentRow, 2].Value = folder.ParentFolder.Name;
                    }
                    else
                    {
                        worksheet.Cells[currentRow, 2].Value = null;
                    }

                    currentRow++;
                }

                return package.GetAsByteArray();
            }
        }
    }
}
