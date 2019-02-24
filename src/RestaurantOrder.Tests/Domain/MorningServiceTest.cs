using System;
using Moq;
using RestaurantOrder.Application;
using RestaurantOrder.Domain.Model;
using RestaurantOrder.Domain.Services;
using Xunit;

namespace RestaurantOrder.Tests.Application
{
    public class MorningServiceTest
    {
        [Fact]
        public void Calculate_DuplicatedValues_ReturnDistinct()
        {
            var service = new MorningService();
            var array = new string[] { "1", "1", "2", "3" };

            var output = service.CalculateOrder(array);

            Assert.Equal("eggs, toast, coffee", output);
        }

        [Fact]
        public void Calculate_DoubleCoffe_ReturnCoffeCount()
        {
            var service = new MorningService();
            var array = new string[] { "1", "3", "2", "3" };

            var output = service.CalculateOrder(array);

            Assert.Equal("eggs, toast, coffee(x2)", output);
        }
    }
}
