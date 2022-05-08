using Bookkeeping.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookkeeping.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountId { get; set; }
        public string Name { get; set; }
        public Subledger ProcessIn {get; set;} = Bookkeeping.Enums.Subledger.GL;
        public AccountType AccountType {get; set;}
        public List<Transaction>? Transactions { get; set; }

    }
}