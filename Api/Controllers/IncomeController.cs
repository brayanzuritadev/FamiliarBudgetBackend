using Data.DTOs;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/users/{userId:int}/income")]
    public class IncomeController: ControllerBase
    {
        private readonly IIncomeService incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            this.incomeService = incomeService;
        }

        [HttpPost]
        public ActionResult<Transaction> Post(int userId, TransactionCreation transactionCreation)
        {
            var ingreso = incomeService.AddIncome(userId, transactionCreation);

            if (ingreso == null)
            {
                return BadRequest();
            }

            return ingreso;
        }
    }
}
