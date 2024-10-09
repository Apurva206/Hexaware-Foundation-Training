using BankingSystem.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem.DAO.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private List<Account> accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account GetAccountById(int accountId)
        {
            return accounts.FirstOrDefault(a => a.AccountId == accountId);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}
