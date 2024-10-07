using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Repository
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactionsByAccountId(int accountId);
    }
}
