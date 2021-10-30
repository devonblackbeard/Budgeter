using BudgeterDB;
using System.Collections.Generic;


namespace CoreServices
{
    public interface IBudgeterServices
    {
        List<Budget> GetExpenses();
        Budget GetExpenseById(int id);
        Budget CreateExpense(Budget expense);
        void DeleteExpense(Budget expense);
        Budget EditExpense(Budget expense);
    }
}
