using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Service
{
    public interface ITransactionService
    {
        IEnumerable<object> GetTransactions(long accountNumber);
        void RecordTransaction(Transaction transaction);
        IEnumerable<Transaction> RetrieveTransactions(int accountId);
    }
}
