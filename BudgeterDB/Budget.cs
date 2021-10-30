using System;
using System.ComponentModel.DataAnnotations;

namespace BudgeterDB
{
    public class Budget
    {
        [Key]
        public int Id { get; set; } //pk
        public double Amount { get; set; }
        public string Description { get; set; }
          
    }
}
