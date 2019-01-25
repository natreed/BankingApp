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

        [BindProperty]
        public Customer Customer { get; set; }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Customers.Add(Customer);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyCustomer = new Customer();
            //Try update sync ensures input conforms to customer object. Nothing extra.
            if (await TryUpdateModelAsync<Customer>(
                emptyCustomer,
                "customer",   // Prefix for form value.
                s => s.Name, s => s.Phone))
            {
                _context.Customers.Add(emptyCustomer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}