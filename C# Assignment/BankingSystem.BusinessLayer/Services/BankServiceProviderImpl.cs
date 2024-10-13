using BankingSystem.BusinessLayer;
using BankingSystem.DAO.Repository;
using BankingSystem.Entities;
using System;
using System.Collections.Generic;

public class BankServiceProvider : IBankServiceProvider
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICustomerRepository _customerRepository;

    public BankServiceProvider(IAccountRepository accountRepository, ICustomerRepository customerRepository)
    {
        _accountRepository = accountRepository;
        _customerRepository = customerRepository;
    }

    public void CreateAccount(Customer customer, string accType, float balance)
    {
        _accountRepository.CreateAccount(customer, accType, balance);
    }

    public List<Account> ListAccounts()

    {
        return _accountRepository.ListAccounts();
    }

    public Account GetAccountDetails(long accountNumber)
    {
        return (Account)_accountRepository.GetAccountDetails(accountNumber);
    }

    public void CalculateInterest()
    {
        List<Account> accounts = _accountRepository.ListAccounts();
        foreach (var account in accounts)
        {
            if (account is SavingsAccount savingsAccount)
            {
                float interest = (float)(savingsAccount.Balance * (savingsAccount.InterestRate / 100));
                _accountRepository.Deposit(savingsAccount.AccountNumber, interest);
            }
        }
    }

    public void create_account(Customer customer, int v, string accType, float balance)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<object> getTransations(long accountNumber, DateTime fromDate, DateTime toDate)
    {
        throw new NotImplementedException();
    }

    public float deposit(long accountNumber, float amount)
    {
        throw new NotImplementedException();
    }

    public float withdraw(long accountNumber, float amount)
    {
        throw new NotImplementedException();
    }

    public void transfer(long fromAccountNumber, long toAccountNumber, float amount)
    {
        throw new NotImplementedException();
    }

    public float get_account_balance(long accountNumber)
    {
        throw new NotImplementedException();
    }
}

