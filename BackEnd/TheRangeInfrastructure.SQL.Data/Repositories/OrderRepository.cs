using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_exam_project.core.DomainService;
using Microsoft.EntityFrameworkCore;
using TheRange.Core.Entity;

namespace TheRange.Infrastructure.SQL.Data
{
    public class OrderRepository : IOrderRepository
    {
        readonly TheRangeContext _ctx;

        public OrderRepository(TheRangeContext ctx)
        {
            _ctx = ctx;
        }

        public Order CreateOrder(Order newOrder)
        {
            _ctx.Orders.Attach(newOrder).State = EntityState.Added;
            _ctx.SaveChanges();
            return newOrder;
        }

        public Order Delete(int id)
        {
            var orderToDelete = _ctx.Orders.FirstOrDefault(o => o.id == id);
            _ctx.Orders.Remove(orderToDelete);
            _ctx.SaveChanges();
            return orderToDelete;
        }

        public IEnumerable<Order> GetFilteredOrders(Filter filter)
        {
            if (filter == null)
            {
                return _ctx.Orders.ToList();
            }

            return _ctx.Orders
                .Skip((filter.CurrentPage - 1) * filter.ItemsPerPage)
                .Take(filter.ItemsPerPage);
        }



        public Order NewOrder(int Id, DateTime date)
        {
            return null;
        }

            public IEnumerable<Order> ReadAllOrders()
            {
                return _ctx.Orders.ToList();
        }

            public IEnumerable<Order> ReadById(int Id)
            {
            //return _ctx.Orders.AsNoTracking().FirstOrDefault(o => o.Id == Id);
             return _ctx.Orders.ToList();
            }

            public Order Update(Order updatedOrder)
            {
            _ctx.Orders.Attach(updatedOrder).State = EntityState.Modified;
            _ctx.Entry(updatedOrder);
            _ctx.SaveChanges();
            return updatedOrder;
        }
        }
    }
