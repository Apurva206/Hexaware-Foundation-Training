using BankingSystem.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem.DAO.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public IEnumerable<Transaction> GetTransactionsByAccountId(int accountId)
        {
            return transactions.Where(t => t.AccountId == accountId);
        }
    }
}
