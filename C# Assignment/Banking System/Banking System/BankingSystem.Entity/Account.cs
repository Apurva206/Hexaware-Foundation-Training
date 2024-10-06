using System;

namespace BankingSystem.Entity
{
    public abstract class Account
    {
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
    }

    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        public override void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        public void CalculateInterest()
        {
            Balance += Balance * (InterestRate / 100);
        }
    }

    public class CurrentAccount : Account
    {
        public double OverdraftLimit { get; set; }

        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        public override void Withdraw(double amount)
        {
            if (Balance + OverdraftLimit >= amount)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Withdrawal exceeds overdraft limit.");
            }
        }
    }
}
