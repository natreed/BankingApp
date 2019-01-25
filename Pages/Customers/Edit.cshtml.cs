using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankingApp.Models;

namespace BankingApp.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly BankingApp.Models.BankingAppContext _context;

        public EditModel(BankingApp.Models.BankingAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.FindAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customerToUpdate = await _context.Customers.FindAsync(id);

            //replaced commented code below with ..

            if (await TryUpdateModelAsync<Customer>(
            customerToUpdate,
            "student",
            s => s.Name, s => s.Phone))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            return Page();
        }
            //

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!CustomerExists(Customer.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return RedirectToPage("./Index");
            //}

            //private bool CustomerExists(int id)
            //{
            //    return _context.Customers.Any(e => e.ID == id);
            //}
        }
}
