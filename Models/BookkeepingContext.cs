using Microsoft.EntityFrameworkCore;
using Programs.ViewModels;

namespace Bookkeeping.Models
{
    public class BookkeepingContext : DbContext
    {
        public BookkeepingContext(DbContextOptions<BookkeepingContext> options) :base(options)
        {
           
        }

        public DbSet<Account> Accounts {get; set;}
        public DbSet<Transaction> Transactions { get; set; }
    }
}