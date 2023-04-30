using Data.DTOs;
using Data.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/users/{userId:int}/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService, IHttpContextAccessor contextAccessor)
        {
            this.transactionService = transactionService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public ActionResult<Transaction> Post(int userId, TransactionCreation transactionCreation)
        {
            var transaction = transactionService.AddTransaction(transactionCreation, userId);
            if (transaction == null)
            {
                return BadRequest("could not create Transaction");
            }
            return transaction;
        }

        [HttpPut("{id:int}")]
        public ActionResult<Transaction> Update(int userId, int id, TransactionCreation transactionCreation)
        {
            var transaction = transactionService.UpdateTransaction(userId, id, transactionCreation);

            if (transaction == null)
            {
                return BadRequest();
            }

            return transaction;
        }
        
        [HttpGet]
        public ActionResult<List<Transaction>> GetAllByDate(int userId, DateTime sDate, DateTime eDate)
        {
            var transactions = transactionService.GetAllTransactionsByDate(userId, sDate, eDate);

            if (transactions==null)
            {
                return NotFound();
            }

            return transactions;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Transaction> Get(int userId,int id)
        {
            var transaction = transactionService.GetTransaction(userId,id);

            if (transaction==null)
            {
                return NotFound();
            }

            return transaction;
        }

        
    }
}
