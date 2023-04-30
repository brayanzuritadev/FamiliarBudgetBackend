using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class IncomeDAO : IIncomeDAO
    {
        private readonly ApplicationDbContext context;

        public IncomeDAO(ApplicationDbContext context) 
        {
            this.context = context;
        }
        public Transaction AddIncome(Transaction income)
        {
            var incomeDao = context.Add(income);
            context.SaveChanges();

            return incomeDao.Entity;
        }

        public List<Transaction> GetAllIncome(int userId)
        {
            throw new NotImplementedException();
        }

        public Transaction GetIncome(int userId, int incomeId)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetIncomeByDate(int userId, DateTime sDate, DateTime eDate)
        {
            throw new NotImplementedException();
        }
    }
}
