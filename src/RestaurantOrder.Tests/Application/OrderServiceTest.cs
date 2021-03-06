﻿using Moq;
using RestaurantOrder.Application;
using RestaurantOrder.Application.Repositories;
using RestaurantOrder.Application.Services;
using RestaurantOrder.Domain.Model;
using RestaurantOrder.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace RestaurantOrder.Tests.Application
{
    public class OrderServiceTest
    {
        [Fact]
        public async Task Order_InvalidDayTime_ThrowException()
        {
            var dayTimeStrategy = new Mock<IDayTimeStrategy>();
            var orderWriteRepository = new Mock<IOrderWriteRepository>();
            var orderReadRepository = new Mock<IOrderReadRepository>();

            OrderService service = new OrderService(dayTimeStrategy.Object,
                orderWriteRepository.Object,
                orderReadRepository.Object);

            await Assert.ThrowsAsync<InvalidInputException>(() => service.Order("test,1,1,1"));
        }

        [Fact]
        public async Task Order_ValidParameters_ReturnOutput()
        {
            string outputMock = "test";
            var dayTimeStrategy = new Mock<IDayTimeStrategy>();
            var orderWriteRepository = new Mock<IOrderWriteRepository>();
            var orderReadRepository = new Mock<IOrderReadRepository>();

            dayTimeStrategy
                .Setup(d => d.CalculateOrder(It.IsAny<string[]>(), It.IsAny<DayTime>()))
                .Returns(outputMock);

            OrderService service = new OrderService(dayTimeStrategy.Object,
                orderWriteRepository.Object,
                orderReadRepository.Object);

            var output = await service.Order("morning,1,1,1");

            Assert.Equal(output, outputMock);
        }

        [Fact]
        public async Task GetAllOrders_ReturnOrders()
        {
            var dayTimeStrategy = new Mock<IDayTimeStrategy>();
            var orderWriteRepository = new Mock<IOrderWriteRepository>();
            var orderReadRepository = new Mock<IOrderReadRepository>();

            var ordersList = new List<Order>()
            {
                new Order()
                {
                    Input = "morning,1",
                    Output = "eggs"
                }
            };

            orderReadRepository
                .Setup(o => o.GetAll())
                .ReturnsAsync(ordersList);

            OrderService service = new OrderService(dayTimeStrategy.Object,
                orderWriteRepository.Object,
                orderReadRepository.Object);

            var output = await service.GetAll();
            
            Assert.Single(output);
            Assert.Equal("eggs", output.First().Output);
        }
    }
}
