using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Pages.Customers
{
    /// <summary>
    /// Login is firstname, last name and password.
    /// </summary>
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly BankingApp.Models.BankingAppContext _context;

        public LoginModel(BankingApp.Models.BankingAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string wrongNameOrPassword { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check to see if customer first last and password show a match
            var customers_query = from a in _context.Accounts
                                  join c in _context.Customers
                                  on a.AccountID equals c.ID
                                  where c.FirstName.Equals(FirstName)
                                  where c.LastName.Equals(LastName)
                                  where a.Password.Equals(Password)
                                  select c;

            var customer = customers_query.FirstOrDefault<Customer>();
                                  
            if (customer == null)
            {
                wrongNameOrPassword = "Wrong user name or Password. Try again.";
                return Page();
            }

            int cust_id = customer.ID;

            _context.Entry(customer).State = EntityState.Detached;

            //Access database context to update Account entity userVerified status.
            var Customer = await _context.Customers
                        .Include(a => a.Account)
                            .ThenInclude(t => t.Transactions)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ID == customer.ID);

            Customer.Account.userVerified = true;

            _context.Update(Customer);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(e => e.ID == Customer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            // TODO: If there are more than two customers with the same name and password, the wrong account could be accessed.
            // I could make 'password' unique to avoid this. 
            return RedirectToPage("./ManageAccount", new { id = customer.ID });
        }
    }
}