using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApp.Models
{
    public class Bank
    {
        //Type verification
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BankID { get; set; }
        public string BankName { get; set; }
        
        public ICollection<Account> Accounts { get; set; }
        
    }
}