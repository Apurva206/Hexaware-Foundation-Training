using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Service
{
    public interface ICustomerService
    {
        void RegisterCustomer(Customer customer);
        Customer RetrieveCustomer(int customerId);
        IEnumerable<Customer> GetAllCustomers();
    }
}
