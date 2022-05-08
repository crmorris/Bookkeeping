using Bookkeeping.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programs.ViewModels
{
    public class AccountTransactionViewModel
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public Transaction Transaction { get; set; }
    }
}
