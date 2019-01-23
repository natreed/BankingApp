using System.Collections;

namespace BankingApp.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public int PersonID { get; set; }
        public int BankID { get; set; }
        public ArrayList Transactions { get; set; }
        public float Balance { get; set; }
        
        public Bank Bank { get; set; }
        public Person Person { get; set; }
    }
}