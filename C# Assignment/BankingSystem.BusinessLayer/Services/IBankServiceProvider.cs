using BankingSystem.Entities;
using System;
using System.Collections.Generic;

public interface IBankServiceProvider
{
    void CreateAccount(Customer customer, string accType, float balance);
    List<Account> ListAccounts();
    Account GetAccountDetails(long accountNumber);
    void CalculateInterest();
    void create_account(Customer customer, int v, string accType, float balance);
    IEnumerable<object> getTransations(long accountNumber, DateTime fromDate, DateTime toDate);
    float deposit(long accountNumber, float amount);
    float withdraw(long accountNumber, float amount);
    void transfer(long fromAccountNumber, long toAccountNumber, float amount);
    float get_account_balance(long accountNumber);
}
