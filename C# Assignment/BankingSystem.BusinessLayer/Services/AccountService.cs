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
            accountRepository.UpdateAccount(account); // Ensure the updated balance is saved
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

            accountRepository.UpdateAccount(fromAccount); // Save changes to both accounts
            accountRepository.UpdateAccount(toAccount);
        }

        public void WithdrawWithOverdraft(int accountId, decimal amount, decimal overdraftLimit)
        {
            var account = GetAccount(accountId);
            if (account.Balance + overdraftLimit < amount)
            {
                throw new OverDraftLimitExceededException($"Withdrawal of {amount} exceeds the overdraft limit of {overdraftLimit}.");
            }

            account.Balance -= amount;
            accountRepository.UpdateAccount(account); // Save the updated balance
        }

        public void Deposit(long accountNumber, decimal amount)
        {
            // Retrieve the account
            var account = accountRepository.GetAccountById(accountNumber);
            if (account == null)
            {
                throw new InvalidAccountException($"Account with ID {accountNumber} does not exist.");
            }

            account.Balance += amount; // Increase balance
            accountRepository.UpdateAccount(account); // Save the updated balance
        }

        public decimal GetBalance(long accountNumber)
        {
            var account = accountRepository.GetAccountById(accountNumber);
            if (account == null)
            {
                throw new InvalidAccountException($"Account with ID {accountNumber} does not exist.");
            }

            return account.Balance; // Return the current balance
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
        {
            var fromAccount = accountRepository.GetAccountById(fromAccountNumber);
            var toAccount = accountRepository.GetAccountById(toAccountNumber);

            if (fromAccount == null)
            {
                throw new InvalidAccountException($"Source account with ID {fromAccountNumber} does not exist.");
            }

            if (toAccount == null)
            {
                throw new InvalidAccountException($"Destination account with ID {toAccountNumber} does not exist.");
            }

            if (fromAccount.Balance < amount)
            {
                throw new InsufficientFundException($"Transfer amount {amount} exceeds the available balance of {fromAccount.Balance}.");
            }

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            accountRepository.UpdateAccount(fromAccount);
            accountRepository.UpdateAccount(toAccount);
        }

        public object GetAccountDetails(long accountNumber)
        {
            var account = accountRepository.GetAccountById(accountNumber);
            if (account == null)
            {
                throw new InvalidAccountException($"Account with ID {accountNumber} does not exist.");
            }

            return account; // Return account details
        }

        public IEnumerable<object> ListAccounts()
        {
            return accountRepository.GetAllAccounts(); // Returns all accounts from repository
        }

        public void Withdraw(long accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
