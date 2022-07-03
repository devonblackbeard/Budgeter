using CoreServices.DTO;
using System.Collections.Generic;


namespace CoreServices
{
    public interface IBudgeterServices
    {
        List<ExpenseDTO> GetExpenses();
        ExpenseDTO GetExpenseById(int id);
        ExpenseDTO CreateExpense(BudgeterDB.Expense expense);
        void DeleteExpense(ExpenseDTO expense);
        ExpenseDTO EditExpense(ExpenseDTO expense);
    }
}
