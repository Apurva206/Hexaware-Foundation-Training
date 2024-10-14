using BankingSystem.Entities;
using System.Collections.Generic;
using System.Linq;
using BankingSystem.Exceptions; // Ensure to include custom exceptions

namespace BankingSystem.DAO.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private List<Account> accounts = new List<Account>();

        // Adds a new account to the repository
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        // Creates a new account for a customer with specified type and balance
        public void CreateAccount(int customerId, string accType, double balance)
        {
            var account = new Account
            {
                CustomerId = customerId, 
                AccountType = accType,
                Balance = (decimal)balance
            };
            AddAccount(account);
        }

        // Deposits a specified amount into the account identified by accountNumber
        public void Deposit(long accountNumber, decimal amount)
        {
            var account = GetAccountById(accountNumber);
            if (account == null)
            {
                throw new InvalidAccountException($"Account with ID {accountNumber} does not exist.");
            }
            account.Balance += (decimal)amount; // Increase balance
            UpdateAccount(account); // Update the account in the repository
        }

        // Withdraws a specified amount from the account identified by accountNumber
        public void Withdraw(long accountNumber, decimal amount)
        {
            var account = GetAccountById(accountNumber);
            if (account == null)
            {
                throw new InvalidAccountException($"Account with ID {accountNumber} does not exist.");
            }

            if (account.Balance < (decimal)amount)
            {
                throw new InsufficientFundException($"Withdrawal amount {amount} exceeds the available balance of {account.Balance}.");
            }

            account.Balance -= (decimal)amount; // Decrease balance
            UpdateAccount(account); // Update the account in the repository
        }

        // Transfers amount from one account to another
        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
        {
            var fromAccount = GetAccountById(fromAccountNumber);
            var toAccount = GetAccountById(toAccountNumber);

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

            // Perform transfer
            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            UpdateAccount(fromAccount); // Update source account
            UpdateAccount(toAccount); // Update destination account
        }

        // Gets the balance of an account identified by accountNumber
        public float GetAccountBalance(long accountNumber)
        {
            var account = GetAccountById(accountNumber);
            if (account == null)
            {
                throw new InvalidAccountException($"Account with ID {accountNumber} does not exist.");
            }
            return (float)account.Balance; // Return the balance as float
        }

        // Gets an account by its integer ID
        public Account GetAccountById(int accountId)
        {
            return accounts.FirstOrDefault(a => a.AccountId == accountId);
        }

        // Gets an account by its long account number
        public Account GetAccountById(long accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountId == accountNumber); // Assuming AccountId is being used as account number
        }

        // Retrieves account details
        public object GetAccountDetails(long accountNumber)
        {
            var account = GetAccountById(accountNumber);
            if (account == null)
            {
                throw new InvalidAccountException($"Account with ID {accountNumber} does not exist.");
            }
            return account; // Return account details
        }

        // Gets all accounts in the repository
        public IEnumerable<Account> GetAllAccounts()
        {
            return accounts;
        }

        // Updates the account details in the repository
        public void UpdateAccount(Account account)
        {
            var existingAccount = GetAccountById(account.AccountId);
            if (existingAccount != null)
            {
                existingAccount.Balance = account.Balance; // Update the balance
                existingAccount.AccountType = account.AccountType; // Update account type
                // Update any other necessary properties here
            }
            else
            {
                throw new InvalidAccountException($"Account with ID {account.AccountId} does not exist.");
            }
        }

        // Lists all accounts in the repository
        public List<Account> ListAccounts()
        {
            return accounts.ToList(); // Return a list of all accounts
        }
    }
}
