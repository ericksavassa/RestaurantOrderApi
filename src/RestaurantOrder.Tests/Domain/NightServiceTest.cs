using System;
using Moq;
using RestaurantOrder.Application;
using RestaurantOrder.Domain.Model;
using RestaurantOrder.Domain.Services;
using Xunit;

namespace RestaurantOrder.Tests.Application
{
    public class NightServiceTest
    {
        [Fact]
        public void Calculate_DuplicatedValues_ReturnDistinct()
        {
            var service = new NightService();
            var array = new string[] { "1", "1", "2", "3" };

            var output = service.CalculateOrder(array);

            Assert.Equal("steak, potato, wine", output);
        }

        [Fact]
        public void Calculate_DoubleCoffe_ReturnCoffeCount()
        {
            var service = new NightService();
            var array = new string[] { "1", "2", "3", "4", "2" };

            var output = service.CalculateOrder(array);

            Assert.Equal("steak, potato(x2), wine, cake", output);
        }
    }
}
