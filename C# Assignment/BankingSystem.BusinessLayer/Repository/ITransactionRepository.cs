using BankingSystem.Entities;
using System;
using System.Collections.Generic;

namespace BankingSystem.DAO.Repository
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
        IEnumerable<Transaction> GetTransactionsByAccountId(int accountId);
    }
}
