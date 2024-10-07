using System;
using System.Collections.Generic;
using System.Linq;
using BankingSystem.Entities;
using BankingSystem.DAO.Repository;
using BankingSystem.DAO.Service;

namespace BankingSystem.Main
{
    class Program
    {
        // Repositories and Services
        private static ICustomerRepository customerRepo = new CustomerRepository();
        private static ICustomerService customerService = new CustomerService(customerRepo);

        private static IAccountRepository accountRepo = new AccountRepository();
        private static IAccountService accountService = new AccountService(accountRepo);

        private static ITransactionRepository transactionRepo = new TransactionRepository();
        private static ITransactionService transactionService = new TransactionService(transactionRepo);

        static void Main(string[] args)
        {
            int option;
            do
            {
                Console.WriteLine("\n--- Banking System Menu ---");
                Console.WriteLine("1. Check Loan Eligibility");
                Console.WriteLine("2. ATM Transaction");
                Console.WriteLine("3. Calculate Compound Interest");
                Console.WriteLine("4. Looping Array and Data Validation");
                Console.WriteLine("5. Password Validation");
                Console.WriteLine("6. Password Creation");
                Console.WriteLine("7. Add Customer");
                Console.WriteLine("8. Create Account");
                Console.WriteLine("9. Record Transaction");
                Console.WriteLine("10. View Customer Details");
                Console.WriteLine("11. View Transactions");
                Console.WriteLine("12. Exit");
                Console.Write("Choose an option (1-12): ");

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 12.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        CheckLoanEligibility();
                        break;
                    case 2:
                        ATMTransaction();
                        break;
                    case 3:
                        CalculateCompoundInterest();
                        break;
                    case 4:
                        LoopingArrayValidation();
                        break;
                    case 5:
                        PasswordValidation();
                        break;
                    case 6:
                        PasswordCreation();
                        break;
                    case 7:
                        AddCustomer();
                        break;
                    case 8:
                        CreateAccount();
                        break;
                    case 9:
                        RecordTransaction();
                        break;
                    case 10:
                        ViewCustomerDetails();
                        break;
                    case 11:
                        ViewTransactions();
                        break;
                    case 12:
                        Console.WriteLine("Exiting the system. Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please choose a valid option.");
                        break;
                }
            } while (option != 12);
        }

        // Task 1: Check Loan Eligibility
        private static void CheckLoanEligibility()
        {
            Console.WriteLine("\n--- Check Loan Eligibility ---");
            Console.Write("Enter credit score: ");
            int creditScore = int.Parse(Console.ReadLine());

            Console.Write("Enter annual income: ");
            decimal annualIncome = decimal.Parse(Console.ReadLine());

            if (creditScore > 700 && annualIncome >= 50000)
            {
                Console.WriteLine("Customer is eligible for the loan.");
            }
            else
            {
                Console.WriteLine("Customer is not eligible for the loan.");
            }
        }

        // Task 2: ATM Transaction
        private static void ATMTransaction()
        {
            Console.WriteLine("\n--- ATM Transaction ---");
            Console.Write("Enter current balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            Console.Write("Enter transaction type (withdraw/deposit): ");
            string transactionType = Console.ReadLine().ToLower();

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (transactionType == "withdraw")
            {
                if (amount % 100 == 0 || amount % 500 == 0)
                {
                    if (amount <= balance)
                    {
                        balance -= amount;
                        Console.WriteLine($"Withdrawal successful! New balance is: {balance}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds.");
                    }
                }
                else
                {
                    Console.WriteLine("Withdrawal amount must be in multiples of 100 or 500.");
                }
            }
            else if (transactionType == "deposit")
            {
                balance += amount;
                Console.WriteLine($"Deposit successful! New balance is: {balance}");
            }
            else
            {
                Console.WriteLine("Invalid transaction type.");
            }
        }

        // Task 3: Calculate Compound Interest
        private static void CalculateCompoundInterest()
        {
            Console.WriteLine("\n--- Calculate Compound Interest ---");
            Console.Write("Enter initial balance: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            Console.Write("Enter annual interest rate (in %): ");
            float interestRate = float.Parse(Console.ReadLine());

            Console.Write("Enter number of years: ");
            int years = int.Parse(Console.ReadLine());

            decimal futureBalance = initialBalance * (decimal)Math.Pow((1 + interestRate / 100), years);
            Console.WriteLine($"Future balance after {years} years: {futureBalance}");
        }

        // Task 4: Looping Array and Data Validation
        private static void LoopingArrayValidation()
        {
            Console.WriteLine("\n--- Looping Array and Data Validation ---");
            List<decimal> balances = new List<decimal>();
            string input;

            do
            {
                Console.Write("Enter account balance (or type 'exit' to finish): ");
                input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal balance))
                {
                    balances.Add(balance);
                }
                else if (input.ToLower() != "exit")
                {
                    Console.WriteLine("Invalid input! Please enter a valid balance.");
                }
            } while (input.ToLower() != "exit");

            Console.WriteLine("Account Balances:");
            foreach (var bal in balances)
            {
                Console.WriteLine($"- {bal}");
            }
        }

        // Task 5: Password Validation
        private static void PasswordValidation()
        {
            Console.WriteLine("\n--- Password Validation ---");
            Console.Write("Enter a password to validate: ");
            string password = Console.ReadLine();

            if (password.Length >= 8 &&
                password.Any(char.IsUpper) &&
                password.Any(char.IsDigit))
            {
                Console.WriteLine("Password is valid.");
            }
            else
            {
                Console.WriteLine("Password must be at least 8 characters long, contain at least one uppercase letter, and one digit.");
            }
        }

        // Task 6: Password Creation
        private static void PasswordCreation()
        {
            Console.WriteLine("\n--- Password Creation ---");
            Console.Write("Create a new password: ");
            string password = Console.ReadLine();

            // You could implement further checks here if needed
            Console.WriteLine("Password created successfully.");
        }

        // Task 7: Add Customer
        private static void AddCustomer()
        {
            Console.WriteLine("\n--- Add Customer ---");
            var customer = new Customer();

            Console.Write("Enter Customer ID: ");
            customer.CustomerId = int.Parse(Console.ReadLine());

            Console.Write("Enter First Name: ");
            customer.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            customer.LastName = Console.ReadLine();

            Console.Write("Enter Email: ");
            customer.Email = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            customer.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Address: ");
            customer.Address = Console.ReadLine();

            customerService.RegisterCustomer(customer);
            Console.WriteLine("Customer added successfully.");
        }

        // Task 8: Create Account
        private static void CreateAccount()
        {
            Console.WriteLine("\n--- Create Account ---");
            var account = new Account();

            Console.Write("Enter Account ID: ");
            account.AccountId = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer ID: ");
            account.CustomerId = int.Parse(Console.ReadLine());

            Console.Write("Enter Account Type (Savings/Current): ");
            account.AccountType = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            account.Balance = decimal.Parse(Console.ReadLine());

            accountService.CreateAccount(account);
            Console.WriteLine("Account created successfully.");
        }

        // Task 9: Record Transaction
        private static void RecordTransaction()
        {
            Console.WriteLine("\n--- Record Transaction ---");
            var transaction = new Transaction();

            Console.Write("Enter Transaction ID: ");
            transaction.TransactionId = int.Parse(Console.ReadLine());

            Console.Write("Enter Account ID: ");
            transaction.AccountId = int.Parse(Console.ReadLine());

            Console.Write("Enter Transaction Type (Deposit/Withdrawal): ");
            transaction.TransactionType = Console.ReadLine();

            Console.Write("Enter Amount: ");
            transaction.Amount = decimal.Parse(Console.ReadLine());

            transaction.TransactionDate = DateTime.Now;

            transactionService.RecordTransaction(transaction);
            Console.WriteLine("Transaction recorded successfully.");
        }

        // Task 10: View Customer Details
        private static void ViewCustomerDetails()
        {
            Console.WriteLine("\n--- View Customer Details ---");
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            var customer = customerService.RetrieveCustomer(customerId);
            if (customer != null)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}, Phone: {customer.PhoneNumber}, Address: {customer.Address}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        // Task 11: View Transactions
        private static void ViewTransactions()
        {
            Console.WriteLine("\n--- View Transactions ---");
            Console.Write("Enter Account ID: ");
            int accountId = int.Parse(Console.ReadLine());

            var transactions = transactionService.RetrieveTransactions(accountId);
            Console.WriteLine($"Transactions for Account ID: {accountId}");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Type: {transaction.TransactionType}, Amount: {transaction.Amount}, Date: {transaction.TransactionDate}");
            }
        }
    }
}
