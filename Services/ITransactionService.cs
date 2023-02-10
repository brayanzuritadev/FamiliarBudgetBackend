using Data.DTOs;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITransactionService
    {
        public Transaction AddTransaction(TransactionCreation transactionCreation, int id);
        //public Transaction UpdateTransaction(Transaction transaction);
        public Transaction UpdateTransaction(int userId, int id, TransactionCreation transactionCreation);

        //todas las transacciones del usuario por fecha
        public List<Transaction> GetAllTransactionsByDate(int userId, DateTime startDate, DateTime endDate );

        //una transaccion
        public Transaction GetTransaction(int userId, int id);

        //family
        //el usuario obtendra todas las transacciones de la familia
        public List<TransactionResponse> GetAllTransactionsByFamilyCode(string familyCode,DateTime starDate, DateTime endDate);
    }
}
