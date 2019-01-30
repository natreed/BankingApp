using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BankingApp.Models;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApp.Pages.Customers
{
    [BindProperties]
    public class ManageAccountModel : PageModel
    {
        private readonly BankingApp.Models.BankingAppContext _context;

        public ManageAccountModel(BankingApp.Models.BankingAppContext context)
        {
            _context = context;
        }


        [Column(TypeName = "money")]
        public decimal AccountBalance { get; set; }
        public Customer Customer { get; set; } 
        [Range(0, int.MaxValue, ErrorMessage = "Deposit must be a positive number greater than 0.")]
        public decimal DepositAmount { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Withdrawal must be a positive number greater than 0.")]
        public decimal WithdrawAmount { get; set; }

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

            //Make sure user has logged in. If not, redirect to login.
            if (!Customer.Account.userVerified)
            {
                return RedirectToPage("./Login");
            }

            AccountBalance = Customer.Account.Balance;

            return Page();
        }

        /// <summary>
        /// Adds new transaction with amount to deposit. Updates account balance. Updates db.
        /// QUESTION: It doesn't seem like it would be necessary to get the customer again from 
        /// the dbContext when it's already been done in the get() method and should be in scope. 
        /// For some reason I don't have access to the Customer Account in this function body. Which 
        /// is why I grabbed it again from _context. Feels like a work-around though.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDeposit(int? id)
        {
            Customer = await _context.Customers
                        .Include(a => a.Account)
                            .ThenInclude(t => t.Transactions)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ID == id);

            int transactionID = _context.Transactions.Count();
            // Get Starting Balance
            decimal startingBalance = Customer.Account.Balance;
            // Add transaction with customer account as FK
            addTransaction(startingBalance, DepositAmount, Customer.ID, transactionID);
            // Change current balance to reflect transaction
            Customer.Account.Balance += DepositAmount;

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

            AccountBalance = Customer.Account.Balance;

            return Page();
        }

        /// <summary>
        /// Adds new transaction with amount to withdraw. Updates account balance. Updates db.
        /// For not page reloads if withdrawal amount exceeds balance.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostWithdraw(int? id)
        {
            Customer = await _context.Customers
                        .Include(a => a.Account)
                            .ThenInclude(t => t.Transactions)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ID == id);

            int transactionID = _context.Transactions.Count();
            // Get Starting Balance
            decimal startingBalance = Customer.Account.Balance;

            if (startingBalance < WithdrawAmount)
            {
                // TODO: Use Alert or attributes to display message
                // For now just reload the page if withdrawal amount is too much.
                AccountBalance = Customer.Account.Balance;
                return Page();
            }
            // Add transaction with customer account as FK
            addTransaction(startingBalance, WithdrawAmount, Customer.ID, transactionID);
            // Change current balance to reflect transaction
            Customer.Account.Balance -= WithdrawAmount;

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

            AccountBalance = Customer.Account.Balance;

            return Page();
        }

        /// <summary>
        /// Set userverified to false after logging out. 
        /// If user tries to revisit URL they will be redirected to Index. (See onGet method)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostLogout(int? id)
        {
            Customer = await _context.Customers
                        .Include(a => a.Account)
                            .ThenInclude(t => t.Transactions)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ID == id);

            Customer.Account.userVerified = false;

            _context.Update(Customer);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

        /// <summary>
        /// Creates New Transaction with AccountID. Adds to Transactions table.
        /// </summary>
        /// <param name="startBalance"></param>
        /// <param name="transactionAmount"></param>
        /// <param name="_AccountID"></param>
        /// <param name="_TransactionID"></param>
        public async void addTransaction(decimal startBalance,
            decimal transactionAmount,
            int _AccountID,
            int _TransactionID)
        {
            Transaction transaction = new Transaction
            {
                StartBalance = startBalance,
                AccountID = _AccountID,
                TransactionID = _TransactionID,
                TransactionAmount = transactionAmount,
                EndBalance = startBalance + transactionAmount,
                TransactionTime = DateTime.Now
            };

            _context.Transactions.Add(transaction);
        }
    }
}