using BankingSystem.BusinessLayer;
using BankingSystem.DAO.Repository;
using BankingSystem.Entities;
using System;
using System.Collections.Generic;

public class CustomerServiceProvider : ICustomerServiceProvider
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    // Constructor injection for repositories to interact with the database
    public CustomerServiceProvider(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    // Retrieve the balance for a specific account
    public decimal GetAccountBalance(long accountNumber)
    {
        return (decimal)_accountRepository.GetAccountBalance(accountNumber);
    }

    // Deposit a specified amount into an account and return the new balance
    public decimal Deposit(long accountNumber, decimal amount)
    {
        _accountRepository.Deposit(accountNumber, amount);
        return (decimal)_accountRepository.GetAccountBalance(accountNumber);
    }

    // Withdraw a specified amount from an account with balance checks
    public decimal Withdraw(long accountNumber, decimal amount)
    {
        var account = _accountRepository.GetAccountDetails(accountNumber);

        // Check if account is SavingsAccount and enforce minimum balance
        if (account is SavingsAccount savingsAccount && (savingsAccount.Balance - amount < 500))
        {
            throw new InvalidOperationException("Insufficient balance. Minimum balance of 500 is required for Savings Account.");
        }

        // Check if account is CurrentAccount and allow overdraft within the limit
        if (account is CurrentAccount currentAccount && (currentAccount.Balance - amount < -currentAccount.OverdraftLimit))
        {
            throw new InvalidOperationException("Withdrawal exceeds overdraft limit for Current Account.");
        }

        _accountRepository.Withdraw(accountNumber, amount);
        return (decimal)_accountRepository.GetAccountBalance(accountNumber);
    }

    // Transfer funds from one account to another
    public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
    {
        // Withdraw from the sender's account
        Withdraw(fromAccountNumber, amount);

        // Deposit into the recipient's account
        Deposit(toAccountNumber, amount);
    }

    // Get detailed information about a specific account, including the customer
    public Account GetAccountDetails(long accountNumber)
    {
        return (Account)_accountRepository.GetAccountDetails(accountNumber);
    }

    // Retrieve transactions for a specific account within a date range
    public List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
    {
        return _transactionRepository.GetTransactions(accountNumber, fromDate, toDate);
    }

    Account ICustomerServiceProvider.GetAccountDetails(long accountNumber)
    {
        throw new NotImplementedException();
    }

    List<Transaction> ICustomerServiceProvider.GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
    {
        throw new NotImplementedException();
    }

    float ICustomerServiceProvider.GetAccountBalance(long accountNumber)
    {
        throw new NotImplementedException();
    }

    public float Deposit(long accountNumber, float amount)
    {
        throw new NotImplementedException();
    }

    public float Withdraw(long accountNumber, float amount)
    {
        throw new NotImplementedException();
    }

    public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
    {
        throw new NotImplementedException();
    }
}
