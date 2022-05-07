using System.Diagnostics;
using Bookkeeping.Enums;
using Bookkeeping.Models;
using Microsoft.AspNetCore.Mvc;
using Programs.Models;

namespace Programs.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly BookkeepingContext _db;

    public AccountController(ILogger<AccountController> logger, BookkeepingContext db)
    {
        _logger = logger;
        _db = db;
    }
    
    public IActionResult AddAccount()
    {
        return View();
    }

    public IActionResult EditAccount()
    {
        return View();
    }

    public Account PostAccount(int accountNumber, string accountName, Subledger subledger, AccountType accountType)
    {
        Account account = new Account();
        account.Number = accountNumber;
        account.Name = accountName;
        account.ProcessIn = subledger;
        account.AccountType = accountType;
        _db.Accounts.Add(account);
        _db.SaveChanges();
        return account;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}