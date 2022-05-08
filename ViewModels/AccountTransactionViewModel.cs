using Bookkeeping.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programs.ViewModels
{
    public class AccountTransactionViewModel
    {
        [Key]
        [NotMapped]
        public int Id { get; set; }
        [NotMapped]
        public Account Account { get; set; }
        [NotMapped]
        public Transaction Transaction { get; set; }
    }
}
