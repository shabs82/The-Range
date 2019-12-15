using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
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
            if (customer.Id != default)
            {
                throw new NotSupportedException($"The customer id should not be specified");
            }
            else if (string.IsNullOrEmpty(customer.FirstName))
            {
                throw new InvalidDataException("You need to specify the customer's first name.");
            }
            else if (string.IsNullOrEmpty(customer.LastName))
            {
                throw new InvalidDataException("You need to specify the customer's last name.");
            }
            return _CustomerRepository.CreateCustomer(customer);
        }

        public Customer DeleteCustomer(int id)
        {
            Customer customer = _CustomerRepository.GetCustomerById(id);
            if (customer == null)
            {
                throw new NullReferenceException($"The customer with Id: {id} does not exist");
            }
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

        public Customer NewCustomer(int Id, string FirstName, string LastName, string Address, string Email, string PhoneNumber)
        {
            Customer cust = new Customer() { FirstName = FirstName, LastName = LastName, Address = Address,  Email = Email, PhoneNumber = PhoneNumber};
            return cust;
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            
                if (string.IsNullOrEmpty(customer.FirstName))
                {
                    throw new InvalidDataException("You need to specify the customer's first name.");
                }
                else if (string.IsNullOrEmpty(customer.LastName))
                {
                    throw new InvalidDataException("You need to specify the customer's last name.");
                }
            return _CustomerRepository.UpdateCustomer(id, customer);
            
        }
    }
}
