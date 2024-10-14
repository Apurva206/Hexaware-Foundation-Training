using BankingSystem.DAO.Repository;
using BankingSystem.Entities;
using System.Collections.Generic;

namespace BankingSystem.DAO.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepo)
        {
            customerRepository = customerRepo;
        }

        public void RegisterCustomer(Customer customer)
        {
            customerRepository.AddCustomer(customer);
        }

        public Customer RetrieveCustomer(int customerId)
        {
            return customerRepository.GetCustomerById(customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }
    }
}
