using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApp.Models
{
    /// <summary>
    /// A single transaction is tied to 1 account.
    /// </summary>
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransactionID { get; set; }

        public int AccountID { get; set; }

        [Column(TypeName = "money")]
        public decimal StartBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal TransactionAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal EndBalance { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss tt}")]
        public DateTime TransactionTime { get; set; }

        //NAVIGATION
        public Account Account { get; set; }
    }
}
