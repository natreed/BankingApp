using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApp.Models
{
    public enum AccountType
    {
        CHECKING, SAVINGS
    }

    /// <summary>
    /// 1-1 relationship with customer entity (i.e. 1 Customer entity with access)
    /// Stores Customer entity account state.
    /// TODO: USE A PASSWORD MANAGER!
    /// For now, keep the password as a non-visible field.
    /// Use post to keep it out of URL.
    /// TODO: Implement the user verified field to prevent multiple
    /// login Attempts.
    /// TODO: If more than one person/company were accessing
    /// this account, there would need to be a system in place for controling read/write access
    /// so that the data was being displayed and updated as expected. Maybe some other time:)
    /// </summary>
    public class Account
    {
        // ATTRIBUTES
        [ForeignKey("Customer")]
        public int AccountID { get; set; }

        public AccountType AccountType { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
       
        [ScaffoldColumn(false)]
        public string Password { get; set; }

        // Set to true at login. Set to false at logout.
        // TODO: Not yet implemented
        [ScaffoldColumn(false)]
        public bool userVerified { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime InitialTransactionDate { get; set; }

        // NAVIGATION
        public Customer Customer { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}