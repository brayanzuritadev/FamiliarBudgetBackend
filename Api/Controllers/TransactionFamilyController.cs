using Data.DTOs;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Reflection.Metadata.Ecma335;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/family/{familyCode}/transactions")]
    public class TransactionFamilyController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionFamilyController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet]
        public ActionResult<List<TransactionResponse>> GetTransactionsByFamilyCode (string familyCode, DateTime sDate, DateTime eDate)
        {
            var transactions = transactionService.GetAllTransactionsByFamilyCode(familyCode, sDate, eDate);
            
            if (transactions == null)
            {
                return BadRequest();
            }

            return transactions;
        }
    }
}
