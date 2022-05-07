using Microsoft.AspNetCore.Mvc;
using Bookkeeping.Models;
using OfficeOpenXml;

namespace Programs.Controllers
{
    public class TransactionController : Controller
    {
        private readonly BookkeepingContext _db;
        public TransactionController(BookkeepingContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
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
                        for (int row = 2; row < rowcount + 1; row++)
                        {
                            list.Add(new Transaction {
                                Date = worksheet.Cells[row,1].GetValue<System.DateTime>(),
                                AccountNumber = worksheet.Cells[row,2].GetValue<double>(),
                                Amount = worksheet.Cells[row,3].GetValue<decimal>(),
                                Memo = worksheet.Cells[row,4].GetValue<string>(),

                            });
                        }
                    }
                }
            }
            _db.AddRange(list);
            _db.SaveChanges();
            return list;
        }

        public IActionResult UploadTransaction()
        {
            return View();
        }
    }
}
