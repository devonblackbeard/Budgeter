using BudgeterDB;
using CoreServices;
using Microsoft.AspNetCore.Mvc;

namespace BudgeterAPI.Controllers
{
    [ApiController]
    [Route("controller")]
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
        public IActionResult CreateExpense(Budget expense)
        {
            var newExpense = _budgetService.CreateExpense(expense);
            return CreatedAtRoute("GetExpense", new { newExpense.Id}, newExpense);
        }

        [HttpDelete]
        public IActionResult DeleteExpense(Budget expense)
        {
            _budgetService.DeleteExpense(expense);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditExpense(Budget expense)
        {
            return Ok(_budgetService.EditExpense(expense));
        }       
            
    }
}
