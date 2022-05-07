using System.ComponentModel.DataAnnotations;

namespace Bookkeeping.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
    }
}