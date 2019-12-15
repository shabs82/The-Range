using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_exam_project.core.DomainService;
using Microsoft.EntityFrameworkCore;
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
            _ctx.Attach(customer).State = EntityState.Added;
            _ctx.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(int Id)
        {
            Customer customer = GetCustomerById(Id);
            _ctx.Attach(customer).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return customer;
        }

        public IEnumerable<Customer> GetCustomer()
        {
            return _ctx.Customers.ToList();
        }

        public Customer GetCustomerById(int Id)
        {
            return _ctx.Customers.AsNoTracking().Include(c=> c.Orders).FirstOrDefault(o => o.Id == Id);
        }

        public Customer NewCustomer(int Id, string FirstName, string LastName, string Address, string Email, string PhoneNumber)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(int Id, Customer customer)
        {
            _ctx.Attach(customer).State = EntityState.Modified;
            _ctx.Entry(customer).Collection(c => c.Orders).IsModified = true;
            _ctx.SaveChanges();
            return customer;
        }
    }
}
