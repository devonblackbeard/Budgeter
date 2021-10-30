using Microsoft.EntityFrameworkCore;

namespace BudgeterDB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Budget> Expenses { get; set; }
        

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BudgeterDb;Integrated Security=True");
        }
    }
}
