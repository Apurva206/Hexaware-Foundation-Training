using BankingSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem.Main
{
    class MainModule
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nBanking System Menu:");
                Console.WriteLine("1. Loan Eligibility Check");
                Console.WriteLine("2. Simulate ATM Transaction");
                Console.WriteLine("3. Compound Interest Calculation");
                Console.WriteLine("4. Check Multiple Account Balances");
                Console.WriteLine("5. Password Validation");
                Console.WriteLine("6. Transaction History");
                Console.WriteLine("7. Create and Use Objects (Class and Object)");
                Console.WriteLine("8. Demonstrate Inheritance and Polymorphism");
                Console.WriteLine("9. Demonstrate Abstraction");
                Console.WriteLine("10. Has-A Relationship (Association)");
                Console.WriteLine("11. Interface/Abstract Class");
                Console.WriteLine("12. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CheckLoanEligibility();
                        break;
                    case 2:
                        SimulateATMTransaction();
                        break;
                    case 3:
                        CalculateCompoundInterest();
                        break;
                    case 4:
                        CheckMultipleAccountBalances();
                        break;
                    case 5:
                        ValidatePassword();
                        break;
                    case 6:
                        HandleTransactionHistory();
                        break;
                    case 7:
                        CreateAndUseObjects();
                        break;
                    case 8:
                        DemonstrateInheritancePolymorphism();
                        break;
                    case 9:
                        DemonstrateAbstraction();
                        break;
                    case 10:
                        DemonstrateAssociation();
                        break;
                    case 11:
                        DemonstrateInterfaceAbstractClass();
                        break;
                    case 12:
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        // Task 1: Loan Eligibility Check
        static void CheckLoanEligibility()
        {
            Console.Write("Enter your credit score: ");
            int creditScore = int.Parse(Console.ReadLine());
            Console.Write("Enter your annual income: ");
            double annualIncome = double.Parse(Console.ReadLine());

            if (creditScore > 700 && annualIncome >= 50000)
            {
                Console.WriteLine("You are eligible for a loan.");
            }
            else
            {
                Console.WriteLine("You are not eligible for a loan.");
            }
        }

        // Task 2: Simulate ATM Transaction
        static void SimulateATMTransaction()
        {
            Console.Write("Enter your current balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.WriteLine("ATM Options: 1) Check Balance 2) Withdraw 3) Deposit");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.WriteLine($"Your balance is {balance}");
            }
            else if (option == 2)
            {
                Console.Write("Enter amount to withdraw: ");
                double amount = double.Parse(Console.ReadLine());

                if (amount % 100 == 0 && amount <= balance)
                {
                    balance -= amount;
                    Console.WriteLine($"Withdrawal successful! New balance: {balance}");
                }
                else
                {
                    Console.WriteLine("Invalid withdrawal amount or insufficient balance.");
                }
            }
            else if (option == 3)
            {
                Console.Write("Enter amount to deposit: ");
                double amount = double.Parse(Console.ReadLine());

                balance += amount;
                Console.WriteLine($"Deposit successful! New balance: {balance}");
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }

        // Task 3: Compound Interest Calculation
        static void CalculateCompoundInterest()
        {
            Console.Write("Enter the initial balance: ");
            double initialBalance = double.Parse(Console.ReadLine());

            Console.Write("Enter the annual interest rate (%): ");
            double interestRate = double.Parse(Console.ReadLine());

            Console.Write("Enter the number of years: ");
            int years = int.Parse(Console.ReadLine());

            double futureBalance = initialBalance;
            for (int i = 0; i < years; i++)
            {
                futureBalance *= (1 + interestRate / 100);
            }

            Console.WriteLine($"Future balance after {years} years: {futureBalance}");
        }

        // Task 4: Check Multiple Account Balances
        static void CheckMultipleAccountBalances()
        {
            int[] validAccountNumbers = { 1001, 1002, 1003 };  // Example accounts
            double[] balances = { 5000.00, 12000.00, 7500.00 };

            while (true)
            {
                Console.Write("Enter your account number: ");
                int accountNumber = int.Parse(Console.ReadLine());

                int index = Array.IndexOf(validAccountNumbers, accountNumber);

                if (index != -1)
                {
                    Console.WriteLine($"Account Balance: {balances[index]}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid account number. Try again.");
                }
            }
        }

        // Task 5: Password Validation
        static void ValidatePassword()
        {
            Console.Write("Create a password: ");
            string password = Console.ReadLine();

            if (password.Length >= 8 &&
                password.Any(char.IsUpper) &&
                password.Any(char.IsDigit))
            {
                Console.WriteLine("Password is valid.");
            }
            else
            {
                Console.WriteLine("Invalid password. It must be at least 8 characters, include one uppercase letter, and one digit.");
            }
        }

        // Task 6: Transaction History
        static void HandleTransactionHistory()
        {
            var transactions = new List<string>();

            while (true)
            {
                Console.WriteLine("1) Add Deposit 2) Add Withdrawal 3) View Transaction History 4) Exit");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter deposit amount: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    transactions.Add($"Deposit: {depositAmount}");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter withdrawal amount: ");
                    double withdrawAmount = double.Parse(Console.ReadLine());
                    transactions.Add($"Withdrawal: {withdrawAmount}");
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Transaction History:");
                    foreach (var transaction in transactions)
                    {
                        Console.WriteLine(transaction);
                    }
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }

        // Task 7: Create and Use Objects (Class and Object)
        static void CreateAndUseObjects()
        {
            Customer customer = new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Main St"
            };

            Console.WriteLine($"Customer Created: {customer.FirstName} {customer.LastName}");
        }

        // Task 8: Demonstrate Inheritance and Polymorphism
        static void DemonstrateInheritancePolymorphism()
        {
            Account savingsAccount = new SavingsAccount
            {
                AccountNumber = 1001,
                AccountType = "Savings",
                Balance = 2000,
                InterestRate = 4.5
            };

            Account currentAccount = new CurrentAccount
            {
                AccountNumber = 1002,
                AccountType = "Current",
                Balance = 5000,
                OverdraftLimit = 1000
            };

            savingsAccount.Deposit(500);
            currentAccount.Withdraw(3000);

            Console.WriteLine($"Savings Account Balance: {savingsAccount.Balance}");
            Console.WriteLine($"Current Account Balance: {currentAccount.Balance}");
        }

        // Task 9: Demonstrate Abstraction
        static void DemonstrateAbstraction()
        {
            SavingsAccount savings = new SavingsAccount
            {
                AccountNumber = 1003,
                AccountType = "Savings",
                Balance = 1500,
                InterestRate = 5.0
            };

            savings.CalculateInterest();
            Console.WriteLine($"Savings Account Balance after Interest: {savings.Balance}");
        }

        // Task 10: Has-A Relationship (Association)
        static void DemonstrateAssociation()
        {
            Customer customer = new Customer
            {
                CustomerId = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "0987654321",
                Address = "456 Elm St"
            };

            Account customerAccount = new SavingsAccount
            {
                AccountNumber = 1004,
                AccountType = "Savings",
                Balance = 3000,
                InterestRate = 4.0
            };

            Console.WriteLine($"{customer.FirstName} has a {customerAccount.AccountType} account with balance: {customerAccount.Balance}");
        }

        // Task 11: Demonstrate Interface/Abstract Class
        interface IAccountService
        {
            void Deposit(double amount);
            void Withdraw(double amount);
        }

        class AccountService : IAccountService
        {
            private double _balance;

            public AccountService(double initialBalance)
            {
                _balance = initialBalance;
            }

            public void Deposit(double amount)
            {
                _balance += amount;
                Console.WriteLine($"Deposited: {amount}. New balance: {_balance}");
            }

            public void Withdraw(double amount)
            {
                if (_balance >= amount)
                {
                    _balance -= amount;
                    Console.WriteLine($"Withdrew: {amount}. New balance: {_balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
        }

        static void DemonstrateInterfaceAbstractClass()
        {
            AccountService accountService = new AccountService(1000);
            accountService.Deposit(200);
            accountService.Withdraw(500);
        }
    }
}
