using AutoMapper;
using Data.DataAccess;
using Data.DTOs;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Services.Utilities;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionDAO transactionDAO;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly CurrentUser currentUser;
        private readonly IFamilyDAO familyDAO;

        public TransactionService(ITransactionDAO transactionDAO, 
            IMapper mapper, 
            IHttpContextAccessor contextAccessor, 
            CurrentUser currentUser,
            IFamilyDAO familyDAO
            )
        {
            this.transactionDAO = transactionDAO;
            this.mapper = mapper;
            this.contextAccessor = contextAccessor;
            this.currentUser = currentUser;
            this.familyDAO = familyDAO;
        }
        public Transaction AddTransaction(TransactionCreation transactionCreation, int id)
        {
            var user = currentUser.GetCurrentUser();

            if (user.Id != id)
            {
                return null;
            }

            var transaction = mapper.Map<Transaction>(transactionCreation);

            transaction.UserId = user.Id;

            var transactionCreated = transactionDAO.AddTransaction(transaction);

            if (transactionCreated == null)
            {
                return null;
            }

            return transactionCreated;
        }

        public List<Transaction> GetAllTransactionsByDate(int id, DateTime startDate, DateTime endDate)
        {
            var transactionList = new List<Transaction>();

            var user = currentUser.GetCurrentUser();

            if (id != user.Id)
            {
                return null;
            }

            if (startDate.ToString() == "1/1/0001 12:00:00 AM" && endDate.ToString() == "1/1/0001 12:00:00 AM")
            {
                return transactionList = transactionDAO.GetAllTransactions(id);
            }

            if (startDate.ToString() == "1/1/0001 12:00:00 AM" || endDate.ToString() == "1/1/0001 12:00:00 AM")
            {
                return null;
            }

            if (startDate>endDate)
            {
                return null;
            }
            
            return transactionList = transactionDAO.GetAllTransactionsByDate(id, startDate, endDate); ;
        }


        public List<TransactionResponse> GetAllTransactionsByFamilyCode(string familyCode, DateTime startDate, DateTime endDate)
        {

            var user = currentUser.GetCurrentUser();

            var family = familyDAO.GetFamily(familyCode);

            if (user.FamilyId != family.Id)
            {
                return null;
            }

            if (startDate.ToString() == "1/1/0001 12:00:00 AM" && endDate.ToString() == "1/1/0001 12:00:00 AM")
            {
                var transactions = transactionDAO.GetAllTransactionsByFamilyCode(familyCode);

                var transactionList = mapper.Map<List<TransactionResponse>>(transactions);

                return transactionList;
            }

            if (startDate.ToString() == "1/1/0001 12:00:00 AM" || endDate.ToString() == "1/1/0001 12:00:00 AM")
            {
                return null;
            }

            if (startDate > endDate)
            {
                return null;
            }

            var transactionsByDate = transactionDAO.GetAllTransactionsByDate(familyCode, startDate, endDate);

            var transactionListByDate = mapper.Map<List<TransactionResponse>>(transactionsByDate);

            return transactionListByDate;
        }

        public Transaction GetTransaction(int userId,int id)
        {
            var user = currentUser.GetCurrentUser();

            if (userId != user.Id)
            {
                return null;
            }

            var transaction = transactionDAO.GetTransaction(id);

            return transaction;
        }

        public Transaction UpdateTransaction(int userId, int id, TransactionCreation transactionCreation)
        {
            var user = currentUser.GetCurrentUser();

            if (userId != user.Id)
            {
                return null;
            }

            var transaction = mapper.Map<Transaction>(transactionCreation);
            transaction.Id = id;
            var transactionCreated = transactionDAO.UpdateTransaction(transaction);
            return transactionCreated;
        }
    }
}
