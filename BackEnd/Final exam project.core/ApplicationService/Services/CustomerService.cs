using System;
using System.Collections.Generic;
using System.Linq;
using Final_exam_project.core.ApplicationService;
using Final_exam_project.core.DomainService;
using TheRange.Core.Entity;

namespace TheRange.Core.ApplicationService.Services
{
    public class CustomerService : ICustomerService
    {
       private readonly ICustomerRepository _CustomerRepository;

       public CustomerService(ICustomerRepository customerRepository)
       {
           _CustomerRepository = customerRepository;
       }
        public Customer CreateCustomer(Customer customer)
        {
            return _CustomerRepository.CreateCustomer(customer);
        }

        public Customer DeleteCustomer(int id)
        {
            return _CustomerRepository.DeleteCustomer(id);
        }

        public List<Customer> GetCustomer()
        {
            return _CustomerRepository.GetCustomer().ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return this._CustomerRepository.GetCustomer()
                .FirstOrDefault(cust => cust.Id == id);
        }

        public Customer NewCustomer(int Id, string FirstName, string LastName, string Address, string Email, int PhoneNumber)
        {
            Customer cust = new Customer() { FirstName = FirstName, LastName = LastName, Address = Address,  Email = Email, PhoneNumber = PhoneNumber};
            return cust;
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
