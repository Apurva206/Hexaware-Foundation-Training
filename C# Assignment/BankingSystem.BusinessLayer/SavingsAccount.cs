using System;

namespace BankingSystem.Entities
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }
        public long AccountNumber { get; internal set; }

        private const decimal MinimumBalance = 500.0m;  // Set minimum balance as decimal
        private long accNo;
        private decimal initialBalance;
        private decimal v;

        public SavingsAccount(int accountId, int customerId, decimal initialBalance, decimal interestRate)
        {
            AccountId = accountId;
            CustomerId = customerId;
            AccountType = "Savings";
            Balance = initialBalance >= MinimumBalance ? initialBalance : throw new InvalidOperationException("Savings account requires a minimum balance of 500.");
            InterestRate = interestRate;
        }

        public SavingsAccount(long accNo, int customerId, decimal initialBalance, decimal v)
        {
            this.accNo = accNo;
            CustomerId = customerId;
            this.initialBalance = initialBalance;
            this.v = v;
        }

        // Withdraw method enforcing minimum balance rule
        public void Withdraw(decimal amount)
        {
            if (Balance - amount >= MinimumBalance)
                Balance -= amount;
            else
                throw new InvalidOperationException("Withdrawal would violate minimum balance of 500.");
        }

        // Calculate interest based on current balance and interest rate
        public decimal CalculateInterest()
        {
            return Balance * (InterestRate / 100);
        }
    }
}
