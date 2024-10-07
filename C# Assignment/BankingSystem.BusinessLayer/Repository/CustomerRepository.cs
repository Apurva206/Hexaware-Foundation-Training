using BankingSystem.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem.DAO.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer GetCustomerById(int customerId)
        {
            return customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }
    }
}
