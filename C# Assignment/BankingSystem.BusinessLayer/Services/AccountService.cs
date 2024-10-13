using System;
using System.Collections.Generic;
using BankingSystem.Entities;
using BankingSystem.Exceptions;
using BankingSystem.DAO.Repository;

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
            var account = accountRepository.GetAccountById(accountId);
            if (account == null)
            {
                throw new InvalidAccountException($"Account with ID {accountId} does not exist.");
            }
            return account;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accountRepository.GetAllAccounts();
        }

        public void Withdraw(int accountId, decimal amount)
        {
            var account = GetAccount(accountId); 
            if (account.Balance < amount)
            {
                throw new InsufficientFundException($"Withdrawal amount {amount} exceeds the available balance of {account.Balance}.");
            }

            account.Balance -= amount;
        }

        public void Transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAccount = GetAccount(fromAccountId); 
            var toAccount = GetAccount(toAccountId); 

            if (fromAccount.Balance < amount)
            {
                throw new InsufficientFundException($"Transfer amount {amount} exceeds the available balance of {fromAccount.Balance}.");
            }

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;
        }

        public void WithdrawWithOverdraft(int accountId, decimal amount, decimal overdraftLimit)
        {
            var account = GetAccount(accountId); 
            if (account.Balance + overdraftLimit < amount)
            {
                throw new OverDraftLimitExceededException($"Withdrawal of {amount} exceeds the overdraft limit of {overdraftLimit}.");
            }

            account.Balance -= amount;
        }

        public void Deposit(long accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(long accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance(long accountNumber)
        {
            throw new NotImplementedException();
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        public object GetAccountDetails(long accountNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> ListAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
