using System;
using Final_exam_project.core.ApplicationService;
using Final_exam_project.core.DomainService;
using Moq;
using TheRange.Core.ApplicationService.Services;
using TheRange.Core.Entity;
using Xunit;

namespace ServicesTest
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

        [Fact]
        public void Create_AddressEmpty_ThrowsArgumentException()
        {

            //Arrange

            DateTime DeliveryDate = DateTime.Now;
            DateTime OrderDate = DateTime.Now;
            int Id = 1;
            string Address = "";

            Order inputOrder = new Order()
            {
                id = Id,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Address = "",

            };


            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.CreateOrder(inputOrder));

            IOrderService orderService = new OrderService(orderRepository.Object);

            //Act

            Action actual = () => orderService.CreateOrder(inputOrder);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Create_AddressIncorrect_ThrowsArgumentException()
        {
            //Arrange

            DateTime DeliveryDate = DateTime.Now;
            DateTime OrderDate = DateTime.Now;
            int Id = 1;
            string Address = "uk";

            Order inputOrder = new Order()
            {
                id = Id,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Address = "incorrectAddress",

            };


            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.CreateOrder(inputOrder));

            IOrderService orderService = new OrderService(orderRepository.Object);

            //Act

            Action actual = () => orderService.CreateOrder(inputOrder);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Update_OrderValid_ReturnsUpdatedOrder()
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
            orderRepository.Setup(repo => repo.Update(inputOrder)).Returns(expectedOutputOrder);

            IOrderService orderService = new OrderService(orderRepository.Object);

            //Act

            Order actual = orderService.CreateOrder(inputOrder);

            //Assert


            Assert.Equal(expectedOutputOrder, actual);

        }

        [Fact]
        public void Update_OrderNull_ThrowsArgumentNullException()
        {
            //Arrange
            Order invalidOrder = null;

            int Id = 1;
            Order ord1 = new Order()
            {
                id = Id,

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Update(ord1)).Returns(ord1);

            IOrderService orderService = new OrderService(orderRepository.Object);

            //Act

            Action actual = () => orderService.CreateOrder(invalidOrder);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);



        }

        [Fact]
        public void Delete_IdExisting_ReturnsDeletedOrderWithSpecifiedId()
        {
            //Arrange

            DateTime DeliveryDate = DateTime.Now;
            DateTime OrderDate = DateTime.Now;
            string Address = "UK";
            int existingId = 2;

            Order inputOrder = new Order()

            {
                id = existingId,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Address = "Uk",

            };

            Order expectedOutputOrder = new Order()
            {
                id = existingId,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Address = "Uk",

            };

            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Delete(existingId)).Returns(expectedOutputOrder);

            IOrderService orderService = new OrderService(orderRepository.Object);

            //Act

            Order actual = orderService.CreateOrder(inputOrder);

            //Assert


            Assert.Equal(expectedOutputOrder, actual);

        }

        [Fact]
        public void Delete_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int existingId = 2;
            Order expectedOutputOrder = null;


            Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(repo => repo.Delete(existingId)).Returns(expectedOutputOrder);

            IOrderService orderService = new OrderService(orderRepository.Object);

            //Act

            Action actual = () => orderService.Delete(existingId);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);


        }
    }
}
    




