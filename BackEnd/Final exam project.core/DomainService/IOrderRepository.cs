using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using TheRange.Core.Entity;

namespace Final_exam_project.core.DomainService
{
    public interface IOrderRepository
    {
        Order NewOrder(int Id, DateTime date);
        Order CreateOrder(Order order);
        List<Order> ReadAllOrders();
        List<Order> ReadById(int id);
        Order Update(Order order);
        Order Delete(int id);
        List<Order> GetFilteredOrders(Filter filter);
    }
}
