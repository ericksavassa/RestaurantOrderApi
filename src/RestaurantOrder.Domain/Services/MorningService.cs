using RestaurantOrder.Domain.Model;
using System;
using System.Linq;

namespace RestaurantOrder.Domain.Services
{
    public class MorningService : ICalculateOrderService
    {
        public DayTime Operator => DayTime.morning;

        public string CalculateOrder(string[] input)
        {
            var output = string.Empty;
            Array.Sort(input);

            var distinctInputs = input.Distinct();

            foreach (string uniqueInput in distinctInputs)
            {
                var result = UtilService.GetEnumName<MorningMeals>(uniqueInput);

                if (uniqueInput.Equals("3"))
                {
                    var count = input.Count(w => w.Equals("3"));
                    if (count > 1)
                        result = string.Concat(result, "(x", count, ")");
                }

                output = output.Equals(string.Empty) ? 
                    result : 
                    output + ", " + result;
            }

            return output;
        }
    }
}
