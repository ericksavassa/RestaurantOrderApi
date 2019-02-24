using System;
using RestaurantOrder.Domain.Model;
using RestaurantOrder.Domain.Services;
using Xunit;

namespace RestaurantOrder.Tests.Domain
{
    public class UtilServiceTest
    {
        [Fact]
        public void Calculate_DuplicatedValues_ReturnDistinct()
        {
            var response = UtilService.GetEnumByName<DayTime>("morning");

            Assert.Equal(DayTime.morning, response);
        }


        [Fact]
        public void ReturnExcp()
        {
            Assert.Throws<ArgumentException>(() => UtilService.GetEnumByName<DayTime>("test"));
        }

        [Fact]
        public void Excp2()
        {
            Assert.Throws<ArgumentException>(() => UtilService.GetEnumByName<int>("test"));
        }

        [Fact]
        public void test2()
        {
            var response = UtilService.GetEnumName<Morning>("2");

            Assert.Equal(Morning.toast.ToString(), response);
        }

        [Fact]
        public void test3()
        {
            var response = UtilService.GetEnumName<Morning>("5");

            Assert.Equal("error", response);
        }

        [Fact]
        public void test4()
        {
            Assert.Throws<ArgumentException>(() => UtilService.GetEnumName<int>("test"));
        }


        [Fact]
        public void test7()
        {
            var response = UtilService.IsNumeric("morning");

            Assert.False(response);
        }

        [Fact]
        public void test8()
        {
            var response = UtilService.IsNumeric("1");

            Assert.True(response);
        }
    }
}
