using System;
using Moq;
using RestaurantOrder.Application;
using RestaurantOrder.Domain.Model;
using RestaurantOrder.Domain.Services;
using Xunit;

namespace RestaurantOrder.Tests.Application
{
    public class OrderServiceTest
    {

        [Fact]
        public void Order_InvalidDayTime_ThrowException()
        {
            var dayTimeStrategy = new Mock<IDayTimeStrategy>();
            OrderService service = new OrderService(dayTimeStrategy.Object);

            Assert.Throws<InvalidInputException>(() => service.Order("test,1,1,1"));
        }

        [Fact]
        public void Order_ValidParameters_ReturnOutput()
        {
            string outputMock = "test";
            var dayTimeStrategy = new Mock<IDayTimeStrategy>();

            dayTimeStrategy
                .Setup(d => d.CalculateOrder(It.IsAny<string[]>(), It.IsAny<DayTime>()))
                .Returns(outputMock);

            OrderService service = new OrderService(dayTimeStrategy.Object);

            var output = service.Order("morning,1,1,1");

            Assert.Equal(output, outputMock);
        }
    }
}
