using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using CoreServices.DTO;


namespace CoreServices
{
    public class BudgeterServices : IBudgeterServices
    {
        private BudgeterDB.AppDbContext _context;
        private readonly BudgeterDB.User _user;
        public BudgeterServices(BudgeterDB.AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _user = _context.Users.First(u => u.UserName == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public List<ExpenseDTO> GetExpenses()
        {
            return _context.Expenses.Where(e => e.User.Id == _user.Id).Select(e => (ExpenseDTO)e).ToList();
        }

        public ExpenseDTO GetExpenseById(int id)
        {
            return _context.Expenses.Where(e=> e.User.Id == _user.Id && e.Id == id).Select(e => (ExpenseDTO)e).FirstOrDefault();
        }

        public ExpenseDTO CreateExpense(BudgeterDB.Expense expense)
        {
            expense.User = _user;
            _context.Add(expense);
            _context.SaveChanges();

            return (ExpenseDTO)expense;
        }

        public void DeleteExpense(ExpenseDTO expense)
        {
            var dbExpense = _context.Expenses.First(e => e.User.Id == _user.Id && e.Id == expense.Id);
            _context.Expenses.Remove(dbExpense);
            _context.SaveChanges();           
        }

        public ExpenseDTO EditExpense(ExpenseDTO expense)
        {
            var dbExpense = _context.Expenses.First(e => e.Id == expense.Id);
            dbExpense.Description = expense.Description;
            dbExpense.Amount = expense.Amount;

            _context.SaveChanges();
            return expense;
        }
    }
}
