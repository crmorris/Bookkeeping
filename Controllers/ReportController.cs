using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bookkeeping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Programs.ViewModels;

namespace Programs.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly BookkeepingContext _db;

        public ReportController(ILogger<AccountsController> logger, BookkeepingContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public ActionResult GetTransactionReport()
        {
            var query = from t in _db.Transactions
                        from a in _db.Accounts
                        where a.AccountId == t.AccountId
                        select new AccountTransactionViewModel
                        {
                            Id = a.AccountId,
                            Account = a,
                            Transaction = t
                        };

            return View("~/Views/Report/TransactionReport.cshtml", query);
        }
    }
}
