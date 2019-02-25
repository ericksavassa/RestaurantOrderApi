using RestaurantOrder.Domain.Model;

namespace RestaurantOrder.Domain.Services
{
    public interface IDayTimeStrategy
    {
        string CalculateOrder(string[] input, DayTime op);
    }
}
