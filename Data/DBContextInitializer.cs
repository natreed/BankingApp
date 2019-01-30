using System;
using BankingApp.Models;



namespace BankingApp.Data
{
    public class DBContextInitializer
    {
        public static void Initialize(BankingAppContext context)
        {
           
            var customers = new Customer[]
            {
                new Customer{ FirstName="Bill",  LastName="Ash", Phone="222-222-222" },
                new Customer{ FirstName="Bob", LastName="Barker", Phone="222-222-222" },
                new Customer{ FirstName="June", LastName="Sims", Phone="222-222-222" },
                new Customer{ FirstName="Mary", LastName="Williams", Phone="222-222-222" },
                new Customer{ FirstName="Steve", LastName="Bond", Phone="222-222-222" },
                new Customer{ FirstName="Alex", LastName="Sims", Phone="222-222-222" }
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);             
            }
            context.SaveChanges();


            var accounts = new Account[]
            {
               new Account{AccountID=1, AccountType=AccountType.CHECKING, Balance=605.53m, Password="password1",  InitialTransactionDate=DateTime.Now },
               new Account{AccountID=2, AccountType=AccountType.CHECKING, Balance=300m, Password="password2",  InitialTransactionDate=DateTime.Now },
               new Account{AccountID=3, AccountType=AccountType.CHECKING, Balance=150.54m, Password="password3",  InitialTransactionDate=DateTime.Now },
               new Account{AccountID=4, AccountType=AccountType.CHECKING, Balance=1000m, Password="password4",  InitialTransactionDate=DateTime.Now },
               new Account{AccountID=5, AccountType=AccountType.CHECKING, Balance=10m, Password="password5",  InitialTransactionDate=DateTime.Now },
               new Account{AccountID=6, AccountType=AccountType.CHECKING, Balance=605.53m, Password="password6",  InitialTransactionDate=DateTime.Now }
            };
            foreach (Account a in accounts)
            {
                context.Accounts.Add(a);
                Console.WriteLine("");           
            }
            context.SaveChanges();

            var transactions = new Transaction[]
            {
                new Transaction{TransactionID=0, AccountID=3, StartBalance=150.54m, TransactionAmount=-20m, EndBalance=120.54m, TransactionTime=new DateTime() },
                new Transaction{TransactionID=1, AccountID=2, StartBalance=300, TransactionAmount=-20m, EndBalance=280m, TransactionTime=new DateTime() },
                new Transaction{TransactionID=2, AccountID=1, StartBalance=605.23m, TransactionAmount=-20m, EndBalance=585.23m, TransactionTime=new DateTime() },
                new Transaction{TransactionID=3, AccountID=1, StartBalance=585.23m, TransactionAmount=-20m, EndBalance=565.23m, TransactionTime=new DateTime() },
                new Transaction{TransactionID=4, AccountID=1, StartBalance=565.23m, TransactionAmount=-20m, EndBalance=545.23m, TransactionTime=new DateTime() },
                new Transaction{TransactionID=5, AccountID=1, StartBalance=545.23m, TransactionAmount=-20m, EndBalance=525.23m, TransactionTime=new DateTime() },
            };

            foreach (Transaction t in transactions)
            {
                context.Transactions.Add(t);
            }

            context.SaveChanges();
        }
    }
}
