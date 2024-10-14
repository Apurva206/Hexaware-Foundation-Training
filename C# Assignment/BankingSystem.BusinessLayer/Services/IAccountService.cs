using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Service
{
    public interface IAccountService
    {
        void CreateAccount(Account account);
        Account GetAccount(int accountId);
        void Withdraw(int accountId, decimal amount); 
        void Transfer(int fromAccountId, int toAccountId, decimal amount);
        IEnumerable<Account> GetAllAccounts();
        void Deposit(long accountNumber, decimal amount);
        void Withdraw(long accountNumber, decimal amount);
        decimal GetBalance(long accountNumber);
        void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount);
        object GetAccountDetails(long accountNumber);
        IEnumerable<object> ListAccounts();
    }
}
