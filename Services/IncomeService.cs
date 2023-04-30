using AutoMapper;
using Data.DataAccess;
using Data.DTOs;
using Data.Entity;
using Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeDAO incomeDAO;
        private readonly IMapper mapper;
        private readonly CurrentUser currentUser;

        public IncomeService(
            IIncomeDAO incomeDAO,
            IMapper mapper,
            CurrentUser currentUser) 
        { 
            this.incomeDAO= incomeDAO;
            this.mapper = mapper;
            this.currentUser = currentUser;
        }
        public Transaction AddIncome(int userId, TransactionCreation income)
        {
            if (currentUser.GetCurrentUser().UserId!=userId)
            {
                return null;
            }
            var mappedIcome = mapper.Map<Transaction>(income);

            mappedIcome.UserId=userId;

            return incomeDAO.AddIncome(mappedIcome);
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
