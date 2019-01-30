using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankingApp.Models;

namespace BankingApp.Pages.Customers
{
    /// <summary>
    /// Creates a new account with a zero starting balance:
    /// TODO: There is no way to access your account if you forget your password:(
    /// </summary>
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly BankingApp.Models.BankingAppContext _context;

        public CreateModel(BankingApp.Models.BankingAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public Customer Customer { get; set; }
        public Account Account { get; set; }

        /// <summary>
        /// Adds customer to database.
        /// TODO: Right now a customer only has one account. This is to keep the 
        /// model simple. Here the account is set to checking as a default. There 
        /// is currently nothing stopping a customer from creating accounts with the 
        /// same name and password. If this happens, the first account
        /// in the query will be used. This could cause problems, if by chance two customers had
        /// the same first and last names and the same password. 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Account.AccountType = AccountType.CHECKING;
            Account.Balance = 0;
            Account.InitialTransactionDate = DateTime.Now;
            Account.Customer = Customer;

            Customer.Account = Account;

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Login");
        }
    }
}