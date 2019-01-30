using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankingApp.Models;

namespace BankingApp.Pages.Customers
{
    /// <summary>
    /// Displays all of the Customer details.
    /// </summary>
    public class DetailsModel : PageModel
    {
        private readonly BankingApp.Models.BankingAppContext _context;

        public DetailsModel(BankingApp.Models.BankingAppContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers
                        .Include(a => a.Account)
                            .ThenInclude(t => t.Transactions)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
