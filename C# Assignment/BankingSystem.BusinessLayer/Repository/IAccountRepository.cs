using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Repository
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        Account GetAccountById(int accountId);
        IEnumerable<Account> GetAllAccounts();
    }
}
