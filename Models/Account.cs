using Bookkeeping.Enums;
using System.ComponentModel.DataAnnotations;

namespace Bookkeeping.Models
{
    public class Account
    {
        [Key]
        public int Number { get; set; }
        public string Name { get; set; }
        public Subledger ProcessIn {get; set;} = Bookkeeping.Enums.Subledger.GL;
        public AccountType AccountType {get; set;}

    }
}