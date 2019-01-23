using System;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.IdentityModel.Xml;


/*
 * TODO: Person should have one to many relationship with Account
 * 
 */
namespace BankingApp.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        
        
        // TODO: Person should have one to many relationship with Account
        // This would require account number to be entered at login
        // Keep it simple for now with 1 to 1 relationship
        public Account Account { get; set; }
        
        //public ICollection<Account> Accounts { get; set; }       
    } 
}

