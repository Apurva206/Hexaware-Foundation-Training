using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Service
{
    public interface IAccountService
    {
        void CreateAccount(Account account);
        Account GetAccount(int accountId);
        IEnumerable<Account> GetAllAccounts();
    }
}
