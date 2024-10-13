using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BankingSystem.Entities;
using BankingSystem.BusinessLayer.Repository;

public class BankRepositoryImpl : IBankRepository
{
    private readonly string connectionString = "Data Source=DESKTOP-5VEHB15;Initial Catalog=HMBank;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"; // Use your actual connection string

    public object DBUtil { get; private set; }

    // Method to create an account in the database
    public void CreateAccount(Customer customer, long accNo, string accType, decimal balance)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Accounts (AccountNumber, CustomerId, AccountType, Balance) VALUES (@accNo, @customerId, @accType, @balance)";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@accNo", accNo);
                cmd.Parameters.AddWithValue("@customerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@accType", accType);
                cmd.Parameters.AddWithValue("@balance", balance);
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Method to retrieve the balance of an account
    public decimal GetAccountBalance(long accountNumber)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT Balance FROM Accounts WHERE AccountNumber = @accountNumber";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }
    }

    // Method to withdraw amount from an account
    public void Withdraw(long accountNumber, decimal amount)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "UPDATE Accounts SET Balance = Balance - @amount WHERE AccountNumber = @accountNumber";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Method to deposit amount into an account
    public void Deposit(long accountNumber, decimal amount)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "UPDATE Accounts SET Balance = Balance + @amount WHERE AccountNumber = @accountNumber";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Method to get account details
    public Account GetAccountDetails(long accountNumber)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Accounts WHERE AccountNumber = @accountNumber";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Assuming you have the properties in the Account class
                        return new Account
                        {
                            AccountId = (int)reader["AccountId"],
                            CustomerId = (int)reader["CustomerId"],
                            AccountType = reader["AccountType"].ToString(),
                            Balance = (decimal)reader["Balance"]
                        };
                    }
                }
            }
        }
        return null; // Return null if account is not found
    }

    // Method to list all accounts
    public List<Account> ListAccounts()
    {
        var accounts = new List<Account>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Accounts";
            using (var cmd = new SqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(new Account
                        {
                            AccountId = (int)reader["AccountId"],
                            CustomerId = (int)reader["CustomerId"],
                            AccountType = reader["AccountType"].ToString(),
                            Balance = (decimal)reader["Balance"]
                        });
                    }
                }
            }
        }
        return accounts;
    }

    // Method to transfer funds from one account to another
    public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    Withdraw(fromAccountNumber, amount);
                    Deposit(toAccountNumber, amount);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw; // Rethrow the exception after rollback
                }
            }
        }
    }

    public void CreateAccount(Customer customer, long accNo, string accType, float balance)
    {
        throw new NotImplementedException();
    }

    float IBankRepository.GetAccountBalance(long accountNumber)
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

    public List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
    {
        throw new NotImplementedException();
    }
}
