using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Final_exam_project.core.DomainService;
using TheRange.Core.Entity;

namespace TheRange.Infrastructure.SQL.Data
{
    public class OrderRepository : IOrderRepository
    {
        public Order CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetFilteredOrders(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Order NewOrder(int Id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Order> ReadAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<Order> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
