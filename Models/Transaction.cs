using System.ComponentModel.DataAnnotations;

namespace Bookkeeping.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public Account Account { get; set; }
    }
}