using CoreServices.DTO;
using CoreServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgeterAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgeterServices _budgetService;

        public BudgetController(IBudgeterServices budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public IActionResult GetExpenses()
        {
            return Ok(_budgetService.GetExpenses());
        }

        [HttpGet("{id}", Name = "GetExpense")]
        public IActionResult GetExpense(int id)
        {

            return Ok(_budgetService.GetExpenseById(id));
        }

        [HttpPost]
        public IActionResult CreateExpense(BudgeterDB.Expense expense)
        {
            var newExpense = _budgetService.CreateExpense(expense);
            return CreatedAtRoute("GetExpense", new { newExpense.Id}, newExpense);
        }

        [HttpDelete]
        public IActionResult DeleteExpense(ExpenseDTO expense)
        {
            _budgetService.DeleteExpense(expense);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditExpense(ExpenseDTO expense)
        {
            return Ok(_budgetService.EditExpense(expense));
        }       
            
    }
}
