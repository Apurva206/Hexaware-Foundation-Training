using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Repository
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        void Deposit(long accountNumber, float amount);
        float GetAccountBalance(long accountNumber);
        Account GetAccountById(int accountId);
        object GetAccountDetails(long accountNumber);
        IEnumerable<Account> GetAllAccounts();
        void Withdraw(long accountNumber, float amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        void CreateAccount(Customer customer, string accType, float balance);
        List<Account> ListAccounts();
        void Deposit(object accountNumber, float interest);
        void Withdraw(long accountNumber, decimal amount);
        void Deposit(long accountNumber, decimal amount);
    }
}
