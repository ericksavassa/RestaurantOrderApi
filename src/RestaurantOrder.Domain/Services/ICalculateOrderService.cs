using System;
using RestaurantOrder.Domain.Model;

namespace RestaurantOrder.Domain.Services
{
    public interface ICalculateOrderService
    {
        DayTime Operator { get; }

        string CalculateOrder(string[] input);
    }
}
