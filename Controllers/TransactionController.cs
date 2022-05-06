using Microsoft.AspNetCore.Mvc;
using Bookkeeping.Models;
using OfficeOpenXml;

namespace Programs.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<List<Transaction>> Import(IFormFile file)
        {
            var list = new List<Transaction>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                {
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowcount = worksheet.Dimension.Rows;
                        for (int row = 2; row < rowcount; row++)
                        {
                            list.Add(new Transaction {
                                Date = worksheet.Cells[row,1].GetValue<System.DateTime>(),
                                Account = worksheet.Cells[row,2].GetValue<double>(),
                                Amount = worksheet.Cells[row,3].GetValue<decimal>(),
                                Memo = worksheet.Cells[row,4].GetValue<string>(),

                            });
                        }
                    }
                }
            }
            return list;
        }

        public IActionResult UploadTransaction()
        {
            return View();
        }
    }
}
