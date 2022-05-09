using System.Diagnostics;
using Bookkeeping.Enums;
using Bookkeeping.Models;
using Microsoft.AspNetCore.Mvc;
using Programs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

    public IActionResult EditAccount(int id)
    {
        var query = from account in _db.Accounts where account.AccountId == id select account;
        return View(query.FirstOrDefault());
    }

    public Account PostAccount(int accountNumber, string accountName, Subledger subledger, AccountType accountType)
    {
        Account account = new Account();
        account.AccountId = accountNumber;
        account.Name = accountName;
        account.ProcessIn = subledger;
        account.AccountType = accountType;
        _db.Accounts.Add(account);
        _db.SaveChanges();
        return account;
    }

    public ActionResult<Account> Index()
    {
        var account = _db.Accounts.ToList();
        return View(account);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}