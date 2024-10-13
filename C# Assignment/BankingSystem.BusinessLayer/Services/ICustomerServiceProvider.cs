using BankingSystem.Entities;
using System;
using System.Collections.Generic;
public interface ICustomerServiceProvider
{
    float GetAccountBalance(long accountNumber);
    float Deposit(long accountNumber, float amount);
    float Withdraw(long accountNumber, float amount);
    void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
    Account GetAccountDetails(long accountNumber);
    List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
}
