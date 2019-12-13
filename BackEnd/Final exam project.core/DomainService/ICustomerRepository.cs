using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity;

namespace Final_exam_project.core.DomainService
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomer();
        Customer GetCustomerById(int Id);
        Customer NewCustomer(int Id, string FirstName, string LastName, string Address, string Email, string PhoneNumber);
        Customer CreateCustomer(Customer customer);
        Customer DeleteCustomer(int Id);
        Customer UpdateCustomer(int Id, Customer customer);
    }
}
