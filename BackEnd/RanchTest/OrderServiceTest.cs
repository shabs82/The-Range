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
    public class OrderServiceTest
    {
        [Fact]
        public void CreateOrder_ValidateOrder()
        {
            //Arrange

            DateTime DeliveryDate = DateTime.Now;
            DateTime OrderDate = DateTime.Now;
            int Id = 1;
            string Address = "UK";

            Order inputOrder = new Order()
            {
                id = Id,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Address = "Uk",
                
            };

            Order expectedOutputOrder = new Order()
            {
                id = Id,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Address = "Uk",

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.CreateOrder(inputOrder)).Returns(expectedOutputOrder);

            IOrderService orderService = new OrderService(orderRepository.Object);

            //Act

            Order actual = orderService.CreateOrder(inputOrder);

            //Assert

            Assert.Equal(expectedOutputOrder, actual);
        }


        [Fact]
        public void Create_OrderNull_ThrowsArgumentNullException()
        {
            //Arrange
            Order invalidOrder = null;

            int Id = 1;
            Order ord1 = new Order()
            {
                id = Id,

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.CreateOrder(ord1)).Returns(ord1);

            IOrderService orderService = new OrderService(orderRepository.Object);

            //Act

            Action actual = () => orderService.CreateOrder(invalidOrder);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);


           
        }


    }
}
