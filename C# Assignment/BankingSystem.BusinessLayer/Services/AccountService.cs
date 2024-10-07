using BankingSystem.DAO.Repository;
using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepo)
        {
            accountRepository = accountRepo;
        }

        public void CreateAccount(Account account)
        {
            accountRepository.AddAccount(account);
        }

        public Account GetAccount(int accountId)
        {
            return accountRepository.GetAccountById(accountId);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accountRepository.GetAllAccounts();
        }
    }
}
