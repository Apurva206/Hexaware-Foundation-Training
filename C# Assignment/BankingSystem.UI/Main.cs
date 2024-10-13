using System;
using System.Collections.Generic;
using BankingSystem.Entities;
using BankingSystem.DAO.Repository;
using BankingSystem.DAO.Service;

namespace BankingSystem.App
{
    class BankApp
    {
        // Initialize repositories and services
        private static ICustomerRepository customerRepo = new CustomerRepository();
        private static ICustomerService customerService = new CustomerService(customerRepo);

        private static IAccountRepository accountRepo = new AccountRepository();
        private static IAccountService accountService = new AccountService(accountRepo);

        private static ITransactionRepository transactionRepo = new TransactionRepository();
        private static ITransactionService transactionService = new TransactionService(transactionRepo);

        static void Main(string[] args)
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("\n--- Banking System Menu ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Transfer Funds");
                Console.WriteLine("6. View Account Details");
                Console.WriteLine("7. List All Accounts");
                Console.WriteLine("8. View Transactions");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option (1-9): ");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        Deposit();
                        break;
                    case "3":
                        Withdraw();
                        break;
                    case "4":
                        CheckBalance();
                        break;
                    case "5":
                        TransferFunds();
                        break;
                    case "6":
                        ViewAccountDetails();
                        break;
                    case "7":
                        ListAllAccounts();
                        break;
                    case "8":
                        ViewTransactions();
                        break;
                    case "9":
                        Console.WriteLine("Exiting the system. Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please choose a valid option.");
                        break;
                }

                if (option != "9")
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            } while (option != "9");
        }

        private static void CreateAccount()
        {
            Console.WriteLine("\n--- Create Account ---");
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose Account Type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.Write("Select an option (1-2): ");
            string accountTypeChoice = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            long accountNumber = new Random().Next(100000, 999999); // Generates a random account number

            if (accountTypeChoice == "1")
            {
                var savingsAccount = new SavingsAccount(accountNumber, customerId, initialBalance, 4.5m); // Example interest rate
                accountService.CreateAccount(savingsAccount);
                Console.WriteLine("Savings Account created successfully!");
            }
            else if (accountTypeChoice == "2")
            {
                var currentAccount = new CurrentAccount(accountNumber, customerId, initialBalance, 1000m); // Example overdraft limit
                accountService.CreateAccount(currentAccount);
                Console.WriteLine("Current Account created successfully!");
            }
            else
            {
                Console.WriteLine("Invalid account type selection.");
            }
        }

        private static void Deposit()
        {
            Console.WriteLine("\n--- Deposit ---");
            Console.Write("Enter Account Number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter Amount to Deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            accountService.Deposit(accountNumber, amount);
            Console.WriteLine("Deposit successful!");
        }

        private static void Withdraw()
        {
            Console.WriteLine("\n--- Withdraw ---");
            Console.Write("Enter Account Number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter Amount to Withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            accountService.Withdraw(accountNumber, amount);
            Console.WriteLine("Withdrawal successful!");
        }

        private static void CheckBalance()
        {
            Console.WriteLine("\n--- Check Balance ---");
            Console.Write("Enter Account Number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            decimal balance = accountService.GetBalance(accountNumber);
            Console.WriteLine($"Current Balance: {balance}");
        }

        private static void TransferFunds()
        {
            Console.WriteLine("\n--- Transfer Funds ---");
            Console.Write("Enter Source Account Number: ");
            long fromAccountNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter Destination Account Number: ");
            long toAccountNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter Amount to Transfer: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            accountService.Transfer(fromAccountNumber, toAccountNumber, amount);
            Console.WriteLine("Transfer successful!");
        }

        private static void ViewAccountDetails()
        {
            Console.WriteLine("\n--- View Account Details ---");
            Console.Write("Enter Account Number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            Account account = (Account)accountService.GetAccountDetails(accountNumber);
            if (account != null)
            {
                Console.WriteLine($"Account ID: {account.AccountId}, Customer ID: {account.CustomerId}, Type: {account.AccountType}, Balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private static void ListAllAccounts()
        {
            Console.WriteLine("\n--- List All Accounts ---");
            List<Account> accounts = (List<Account>)accountService.ListAccounts();
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account ID: {account.AccountId}, Customer ID: {account.CustomerId}, Type: {account.AccountType}, Balance: {account.Balance}");
            }
        }

        private static void ViewTransactions()
        {
            Console.WriteLine("\n--- View Transactions ---");
            Console.Write("Enter Account Number: ");
            long accountNumber = long.Parse(Console.ReadLine());

            List<Transaction> transactions = (List<Transaction>)transactionService.GetTransactions(accountNumber);
            Console.WriteLine($"Transactions for Account Number: {accountNumber}");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Type: {transaction.TransactionType}, Amount: {transaction.Amount}, Date: {transaction.TransactionDate}");
            }
        }
    }

    internal class CurrentAccount : Account
    {
        private long accountNumber;
        private decimal initialBalance;
        private decimal v;

        public CurrentAccount(long accountNumber, int customerId, decimal initialBalance, decimal v)
        {
            this.accountNumber = accountNumber;
            CustomerId = customerId;
            this.initialBalance = initialBalance;
            this.v = v;
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.Linq;
using BankingSystem.Entities;
using BankingSystem.DAO.Repository;
using BankingSystem.DAO.Service;
using BankingSystem.Exceptions;

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
                Console.WriteLine("12. Withdraw Funds");
                Console.WriteLine("13. Transfer Funds");
                Console.WriteLine("14. Exit");
                Console.Write("Choose an option (1-14): ");

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
                        HandleWithdrawWithExceptionHandling(); // Task 12: Withdraw with Exception Handling
                        break;
                    case 13:
                        HandleTransferWithExceptionHandling();  // Task 12: Transfer with Exception Handling
                        break;
                    case 14:
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

        //Task 12: Exception Handling
        private static void HandleWithdrawWithExceptionHandling()
        {
            try
            {
                Console.WriteLine("\n--- Withdraw Funds (With Exception Handling) ---");
                Console.Write("Enter Total Account Balance: ");
                decimal totalBalance = decimal.Parse(Console.ReadLine());

                Console.Write("Enter amount to withdraw: ");
                decimal withdrawAmount = decimal.Parse(Console.ReadLine());


                if (withdrawAmount > totalBalance)
                {
                    throw new InsufficientFundException($"Withdrawal amount {withdrawAmount} exceeds the available balance of {totalBalance}.");
                }

                totalBalance -= withdrawAmount;

                Console.WriteLine($"Withdrawal of {withdrawAmount} successful. New balance: {totalBalance}");
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        private static void HandleTransferWithExceptionHandling()
        {
            try
            {
                Console.WriteLine("\n--- Transfer Funds (With Exception Handling) ---");
                Console.Write("Enter Total Account Balance of Source Account: ");
                decimal totalBalance = decimal.Parse(Console.ReadLine());

                Console.Write("Enter amount to transfer: ");
                decimal transferAmount = decimal.Parse(Console.ReadLine());

                if (transferAmount > totalBalance)
                {
                    throw new InsufficientFundException($"Transfer amount {transferAmount} exceeds the available balance of {totalBalance}.");
                }

                totalBalance -= transferAmount;

                Console.WriteLine($"Transfer of {transferAmount} successful. New balance: {totalBalance}");
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

    }
}
*/