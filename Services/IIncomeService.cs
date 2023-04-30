using Data.DTOs;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IIncomeService
    {
        public Transaction AddIncome(int userId, TransactionCreation income);
        public List<Transaction> GetAllIncome(int userId);
        public List<Transaction> GetIncomeByDate(int userId, DateTime sDate, DateTime eDate);
        public Transaction GetIncome(int userId, int incomeId);
    }
}
