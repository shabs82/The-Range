using System;
using System.Collections.Generic;
using System.Text;
using Final_exam_project.core.DomainService;
using TheRange.Core.Entity;

namespace TheRange.Infrastructure.SQL.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly TheRangeContext _ctx;

        public CustomerRepository(TheRangeContext ctx)
        {
            _ctx = ctx;
        }
        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer DeleteCustomer(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomer()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int Id)
        {
            throw new NotImplementedException();
        }

        public Customer NewCustomer(int Id, string FirstName, string LastName, string Address, string Email, string PhoneNumber)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(int Id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
