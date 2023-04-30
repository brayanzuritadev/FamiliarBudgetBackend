using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.DTOs;
using Data.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class TransactionDAO : ITransactionDAO
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TransactionDAO(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Transaction AddTransaction(Transaction transaction)
        {
            var transactionEntity = context.Transactions.Add(transaction);
            context.SaveChanges();

            return transactionEntity.Entity;
        }

        public List<Transaction> GetAllTransactions(int id)
        {
            var transactionsEntity = context.Transactions.Where(x => x.UserId == id).ToList();
            return transactionsEntity;
        }

        public List<Transaction> GetAllTransactionsByDate(int id, DateTime sDate, DateTime eDate)
        {
            var transactions = context.Transactions.Where(x => x.UserId == id
                                                         && x.Date >= sDate
                                                         && x.Date <= eDate
                                                         ).ToList();
            return transactions;
        }

        public List<TransactionResponse> GetAllTransactionsByDate(string familyCode, DateTime startDate, DateTime endDate)
        {

            var transactions = context.Set<TransactionResponse>().FromSqlRaw("EXEC S_Get_Transaction_by_Date @FamilyCode = {0}, @StartDate = {1}, @EndDate = {2}", familyCode, startDate, endDate).ToList();

            return transactions;
        }

        public List<Transaction> GetAllTransactionsByFamilyCode(string familyCode)
        {

 
            var transactions = context.Transactions.FromSqlRaw("EXEC S_Get_Transactions @familyCode", new SqlParameter("@familyCode", familyCode)).ToList();

            return transactions;
        }

        public Transaction GetTransaction(int id)
        {
            var transaction = context.Transactions.FirstOrDefault(x => x.TransactionId == id);
            return transaction;
        }

        public Transaction UpdateTransaction(Transaction transaction)
        {
            var transactionEntity = context.Transactions.Update(transaction);
            context.SaveChanges();
            return transactionEntity.Entity;
        }
    }
}
