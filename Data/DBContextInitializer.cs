using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApp.Models;
using System.Data.SqlClient;


namespace BankingApp.Data
{
    public class DBContextInitializer
    {
        public static void Initialize(BankingAppContext context)
        {
            //Look for any Customers
            //if (context.Customers.Any())
            //{
            //    return; //DB has been seeded
            //}

            var customers = new Customer[]
            {
                new Customer{ Name="Bill",  Phone="222-222-222" },
                new Customer{ Name="Bob", Phone="222-222-222" },
                new Customer{ Name="June", Phone="222-222-222" },
                new Customer{ Name="Mary", Phone="222-222-222" },
                new Customer{ Name="Steve", Phone="222-222-222" },
                new Customer{ Name="Alex", Phone="222-222-222" }
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
               
            }
            context.SaveChanges();


            var accounts = new Account[]
            {
               //new Account{CustomerID=1, Balance=605.5, InitialTransactionDate=new DateTime() },
                //new Account{AccountID=2, Balance=705.5, InitialTransactionDate=new DateTime() },
                //new Account{AccountID=3, Balance=805.5, InitialTransactionDate=new DateTime() },
                //new Account{AccountID=4, Balance=905.5, InitialTransactionDate=new DateTime() },
                //new Account{AccountID=5, Balance=405.5, InitialTransactionDate=new DateTime() },
                //new Account{AccountID=6, Balance=305.5, InitialTransactionDate=new DateTime() }
            };
            foreach (Account a in accounts)
            {
                context.Accounts.Add(a);
                Console.WriteLine("");
                //if (context.Accounts.Count() == 0)
                //{
                //    throw new System.Exception();
                //}
            }
            context.SaveChanges();

            //var transactions = new Transaction[]
            //{
            //    new Transaction{TransactionID=1, AccountID=3, StartBalance=20, TransactionAmount=-20, EndBalance=0, TransactionTime=new DateTime() },
            //    new Transaction{TransactionID=2, AccountID=2, TransactionAmount=-20, EndBalance=0, TransactionTime=new DateTime() },
            //    new Transaction{TransactionID=3, AccountID=1, StartBalance=20, TransactionAmount=-20, EndBalance=0, TransactionTime=new DateTime() },
            //    new Transaction{TransactionID=4, AccountID=1, StartBalance=20, TransactionAmount=-20, EndBalance=0, TransactionTime=new DateTime() },
            //    new Transaction{TransactionID=5, AccountID=1, StartBalance=20, TransactionAmount=-20, EndBalance=0, TransactionTime=new DateTime() },
            //    new Transaction{TransactionID=6, AccountID=1, StartBalance=20, TransactionAmount=-20, EndBalance=0, TransactionTime=new DateTime() },
            //};
            //foreach (Transaction t in transactions)
            //{
            //    context.Transactions.Add(t);
            //}
            //context.SaveChanges();
        }
    }
}
