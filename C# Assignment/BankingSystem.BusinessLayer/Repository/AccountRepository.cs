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

        public void CreateAccount(Customer customer, string accType, float balance)
        {
            throw new System.NotImplementedException();
        }

        public void Deposit(long accountNumber, float amount)
        {
            throw new System.NotImplementedException();
        }

        public void Deposit(object accountNumber, float interest)
        {
            throw new System.NotImplementedException();
        }

        public void Deposit(long accountNumber, decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public float GetAccountBalance(long accountNumber)
        {
            throw new System.NotImplementedException();
        }

        public Account GetAccountById(int accountId)
        {
            return accounts.FirstOrDefault(a => a.AccountId == accountId);
        }

        public object GetAccountDetails(long accountNumber)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accounts;
        }

        public List<Account> ListAccounts()
        {
            throw new System.NotImplementedException();
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            throw new System.NotImplementedException();
        }

        public void Withdraw(long accountNumber, float amount)
        {
            throw new System.NotImplementedException();
        }

        public void Withdraw(long accountNumber, decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
