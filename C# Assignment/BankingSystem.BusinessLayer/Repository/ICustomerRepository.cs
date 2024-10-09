using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Repository
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int customerId);
        IEnumerable<Customer> GetAllCustomers();
    }
}
