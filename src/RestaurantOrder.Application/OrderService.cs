using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantOrder.Application.Repositories;
using RestaurantOrder.Domain.Model;
using RestaurantOrder.Domain.Services;

namespace RestaurantOrder.Application
{
    public class OrderService : IOrderService
    {
        private readonly IDayTimeStrategy _dayTimeStrategy;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        public OrderService(IDayTimeStrategy dayTimeStrategy, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _dayTimeStrategy = dayTimeStrategy;
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        public async Task<string> Order(string input)
        {
            string[] inputSplited = input.Split(',');

            if (!ValidateInput(inputSplited))
                throw new InvalidInputException("Invalid parameters!");

            var dayTime = Enum.Parse<DayTime>(inputSplited[0]);
            inputSplited = inputSplited.Where((source, index) => index != 0).ToArray();

            var output = _dayTimeStrategy.CalculateOrder(inputSplited, dayTime);

            var order = BuildOrder(input, output);
            await _orderWriteRepository.Add(order);

            return output;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _orderReadRepository.GetAll();
        }

        private bool ValidateInput(string[] inputWords)
        {
            return inputWords.Length > 0 &&
                (inputWords[0].ToLower().Equals("morning") ||
                inputWords[0].ToLower().Equals("night"));
        }

        private Order BuildOrder(string input, string output)
        {
            return new Order()
            {
                Input = input,
                Output = output,
            };
        }
    }
}
