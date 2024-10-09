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
    }
}
