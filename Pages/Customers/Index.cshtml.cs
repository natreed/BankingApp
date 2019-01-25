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
    public class IndexModel : PageModel
    {
        private readonly BankingApp.Models.BankingAppContext _context;

        public IndexModel(BankingApp.Models.BankingAppContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            Customer = await _context.Customers.ToListAsync();
        }
    }
}
