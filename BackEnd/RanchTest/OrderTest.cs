using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Final_exam_project.core.ApplicationService;
using Final_exam_project.core.DomainService;
using TheRange.Core.ApplicationService.Services;
using TheRange.Core.Entity;
using Xunit;

namespace RanchTest
{
    public class OrderTest
    {
        [Fact]
        public void CreateOrder_ValidData()
        {

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            int Id = 1;
            Order ord1 = new Order()
            {
                id = Id,
                
            };


            orderRepository.Setup(repo => repo.CreateOrder(ord1)).Returns(ord1);

            IOrderService orderService = new OrderService(orderRepository.Object);


            var actual = orderService.CreateOrder(ord1);
            Assert.Equal(ord1, actual);
        }


        [Fact]
        public void CreateOrder_InValidData_CustomerExceptions()
        {

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            int Id = 1;
            Order ord1 = new Order()
            {
                id = Id,

            };


            orderRepository.Setup(repo => repo.CreateOrder(ord1)).Returns(ord1);

            IOrderService orderService = new OrderService(orderRepository.Object);


            Assert.Throws<ArgumentException>((Action)(() => orderService.CreateOrder(ord1)));
        }


    }
}
