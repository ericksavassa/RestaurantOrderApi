using System;
using System.Linq;
using RestaurantOrder.Domain.Model;

namespace RestaurantOrder.Domain.Services
{
    public class NightService : ICalculateOrderService
    {
        public DayTime Operator => DayTime.night;

        public string CalculateOrder(string[] input)
        {
            var output = string.Empty;
            Array.Sort(input);

            var distinctInputs = input.Distinct();

            foreach (string uniqueInput in distinctInputs)
            {
                var result = UtilService.GetEnumName<Night>(uniqueInput);

                if (uniqueInput.Equals("2"))
                {
                    var count = input.Count(w => w.Equals("2"));
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
