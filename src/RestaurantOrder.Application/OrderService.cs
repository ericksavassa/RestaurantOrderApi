using System;
using System.Linq;
using RestaurantOrder.Domain.Model;
using RestaurantOrder.Domain.Services;

namespace RestaurantOrder.Application
{
    public class OrderService : IOrderService
    {
        private readonly IDayTimeStrategy _dayTimeStrategy;

        public OrderService(IDayTimeStrategy dayTimeStrategy)
        {
            _dayTimeStrategy = dayTimeStrategy;
        }

        public string Order(string input)
        {
            string[] inputSplited = input.Split(',');

            if (!ValidateInput(inputSplited))
                throw new InvalidInputException("Invalid parameters!");

            var dayTime = Enum.Parse<DayTime>(inputSplited[0]);
            inputSplited = inputSplited.Where((source, index) => index != 0).ToArray();

            return _dayTimeStrategy.CalculateOrder(inputSplited, dayTime);
        }

        private bool ValidateInput(string[] inputWords)
        {
            return inputWords.Length > 0 &&
                (inputWords[0].ToLower().Equals("morning") ||
                inputWords[0].ToLower().Equals("night"));
        }
    }
}
