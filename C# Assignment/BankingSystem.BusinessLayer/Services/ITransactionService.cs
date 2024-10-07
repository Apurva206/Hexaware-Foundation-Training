using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Service
{
    public interface ITransactionService
    {
        void RecordTransaction(Transaction transaction);
        IEnumerable<Transaction> RetrieveTransactions(int accountId);
    }
}
