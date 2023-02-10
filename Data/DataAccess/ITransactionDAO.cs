using Data.DTOs;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public interface ITransactionDAO
    {
        public Transaction AddTransaction(Transaction transaction);

        public Transaction UpdateTransaction(Transaction transaction);

        public List<Transaction> GetAllTransactions(int userId);

        //todas las transacciones del usuario por fecha
        public List<Transaction> GetAllTransactionsByDate(int userId, DateTime sDate, DateTime eDate);

        //una transaccion
        public Transaction GetTransaction(int id);

        //el usuario obtendra todas las transacciones de la familia
        public List<Transaction> GetAllTransactionsByFamilyCode(string familyCode);

        //el usuario obtendra todas las transacciones de la familia
        public List<Transaction> GetAllTransactionsByDate(string familyCode, DateTime startDate, DateTime endDate);
    }
}
