using System;

namespace CoreServices.DTO
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        public static explicit operator ExpenseDTO(BudgeterDB.Expense e) => new ExpenseDTO
        {
            Id = e.Id,
            Description = e.Description,
            Amount = e.Amount
        };
}
}
