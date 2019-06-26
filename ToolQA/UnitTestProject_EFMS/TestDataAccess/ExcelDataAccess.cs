using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace UnitTestProject_EFMS.TestDataAccess
{
    public class ExcelDataAccess
    {
        public static UserData GetTestData(string keyName)
        {
            var file = GetPathFile();
            UserData user = null;
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Login"];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;
                for (int row = 2; row <= rowCount; row++)
                {
                    if(worksheet.Cells[row, 1].Value?.ToString() == keyName)
                    {
                        user = new UserData
                        {
                            Key = worksheet.Cells[row, 1]?.ToString(),
                            Username = worksheet.Cells[row, 2].Value?.ToString(),
                            Password = worksheet.Cells[row, 3].Value?.ToString()
                        };
                        break;
                    }
                }
            }
            return user;
        }
        public static void SetResultTestData(string keyName, string result)
        {
            var file = GetPathFile();
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;
                for (int row = 2; row <= rowCount; row++)
                {
                    if (worksheet.Cells[row, 1].Value?.ToString() == keyName)
                    {
                        worksheet.Cells[row, 4].Value = result;
                        package.Save();
                        break;
                    }
                }
            }
        }

        private static FileInfo GetPathFile()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appconfig.json").Build();

            var pathData = config["TestDataSheetPath"];
            FileInfo file = new FileInfo(Path.Combine(pathData, "TestData.xlsx"));
            return file;
        }
    }
}
