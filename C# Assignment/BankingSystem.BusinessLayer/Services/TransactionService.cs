using BankingSystem.DAO.Repository;
using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionService(ITransactionRepository transactionRepo)
        {
            transactionRepository = transactionRepo;
        }

        public void RecordTransaction(Transaction transaction)
        {
            transactionRepository.AddTransaction(transaction);
        }

        public IEnumerable<Transaction> RetrieveTransactions(int accountId)
        {
            return transactionRepository.GetTransactionsByAccountId(accountId);
        }
    }
}
