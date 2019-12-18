using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Final_exam_project.core.ApplicationService;
using Final_exam_project.core.DomainService;
using TheRange.Core.Entity;

namespace TheRange.Core.ApplicationService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }



        public Order CreateOrder(Order newOrder)
        {
            Order order = _orderRepository.CreateOrder(newOrder);// create method is being called of order repository object with input parameter of type order which returns object order of the type Order.
            return order;
            //return _orderRepository.CreateOrder(newOrder);
        }

        public Order Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public List<Order> GetFilteredOrders(Filter filter = null)
        {
            return _orderRepository.GetFilteredOrders(filter).ToList();
        }

        public Order NewOrder(int Id, DateTime date)
        {
            Order order = new Order() {id = Id, OrderDate = date};
            return order;
        }

        public List<Order> ReadAllOrders()
        {
            return _orderRepository.ReadAllOrders().ToList();
        }

        public Order ReadById(int id)
        {
            return _orderRepository.ReadById(id);
        }

        public Order Update(Order updatedOrder)
        {
            ValidateUpdate(updatedOrder);
            return _orderRepository.Update(updatedOrder);
        }

        private void ValidateUpdate(Order order)
        {
            ValidateNull(order);
            ValidateOrderDate(order);
            ValidateDeliveryDate(order);
            ValidateAddress(order);
            //ValidateFirstName(order);
            //ValidateLastName(order);
            //ValidateEmail(order);
            //ValidatePhone(order);
            if (_orderRepository.ReadById(order.id) == null)
            {
                throw new ArgumentException($"Cannot find a Order with an ID: {order.id}");
            }
        }


        private void ValidateCreate(Order order)
        {
            ValidateNull(order);
            if (order.id != default)
            {
                throw new ArgumentException("You are not allowed to specify an ID when creating a Order.");
            }

            ValidateOrderDate(order);
            ValidateDeliveryDate(order);
            ValidateAddress(order);


            //ValidateFirstName(order);
            //ValidateLastName(order);
            //ValidateEmail(order);
            //ValidatePhone(order);
        }

        private void ValidateNull(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("Order is null");
            }
        }

        private void ValidateOrderDate(Order order)
        {
            if (order.OrderDate.Day > DateTime.Now.Day)
            {
                throw new ArgumentException("OrderDate is after today");
            }
        }

        private void ValidateDeliveryDate(Order order)
        {
            if (order.DeliveryDate < order.OrderDate)
            {
                throw new ArgumentException("Delivery Date is before Order Date.");
            }
        }

        private void ValidateAddress(Order order)
        {
            if (string.IsNullOrEmpty(order.Address))
            {
                throw new ArgumentException("Address is null or empty");
            }
        }
    }
}









