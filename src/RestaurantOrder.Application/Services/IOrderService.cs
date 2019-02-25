using RestaurantOrder.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrder.Application.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Create an order
        /// </summary>
        /// <param name="input">Input with order values</param>
        /// <returns>Output with order created</returns>
        Task<string> Order(string input);

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>List with all orders</returns>
        Task<IEnumerable<Order>> GetAll();
    }
}
