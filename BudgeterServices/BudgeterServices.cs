using BudgeterDB;
using System.Linq;
using System.Collections.Generic;

namespace CoreServices
{
    public class BudgeterServices : IBudgeterServices
    {
        private AppDbContext _context;
        public BudgeterServices(AppDbContext context)
        {
            _context = context;
        }

        public List<Budget> GetExpenses()
        {
            return _context.Expenses.ToList();
        }

        public Budget GetExpenseById(int id)
        {
            return _context.Expenses.FirstOrDefault(e=> e.Id == id);
        }

        public Budget CreateExpense(Budget expense)
        {
            _context.Add(expense);
            _context.SaveChanges();

            return expense;
        }

        public void DeleteExpense(Budget expense)
        {
            _context.Expenses.Remove(expense);
            _context.SaveChanges();           
        }

        public Budget EditExpense(Budget expense)
        {
            var dbExpense = _context.Expenses.First(e => e.Id == expense.Id);
            dbExpense.Description = expense.Description;
            dbExpense.Amount = expense.Amount;

            _context.SaveChanges();
            return expense;
        }
    }
}
