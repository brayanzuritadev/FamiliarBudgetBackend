using Data.DTOs;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public interface IIncomeDAO
    {
        public Transaction AddIncome(Transaction income);
        public List<Transaction> GetAllIncome(int userId);
        public List<Transaction> GetIncomeByDate(int userId, DateTime sDate, DateTime eDate);
        public Transaction GetIncome(int userId, int incomeId);
    }
}
