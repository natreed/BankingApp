using Microsoft.EntityFrameworkCore;

namespace BankingApp.Models
{
    public class BankingAppContext : DbContext
    {
        public BankingAppContext (DbContextOptions<BankingAppContext> options)
            : base(options)
        {
        }

        //InMemoryAccounts inMemAccounts = new InMemoryAccounts();

        public DbSet<BankingApp.Models.Customer> Customers { get; set; }
        public DbSet<BankingApp.Models.Account> Accounts { get; set; }
        public DbSet<BankingApp.Models.Transaction> Transactions { get; set; }

    }
}
