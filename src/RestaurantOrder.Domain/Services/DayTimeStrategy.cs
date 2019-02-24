using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantOrder.Domain.Model;

namespace RestaurantOrder.Domain.Services
{
    public class DayTimeStrategy : IDayTimeStrategy
    {
        private readonly IEnumerable<ICalculateOrderService> _dayTimes;

        public DayTimeStrategy(IEnumerable<ICalculateOrderService> dayTimes)
        {
            _dayTimes = dayTimes;
        }

        public string CalculateOrder(string[] input, DayTime dayTime)
        {
            return _dayTimes.FirstOrDefault(x => x.Operator == dayTime)?.CalculateOrder(input) ?? 
                throw new ArgumentNullException(nameof(dayTime));
        }
    }
}
