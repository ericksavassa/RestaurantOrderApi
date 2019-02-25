using RestaurantOrder.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrder.Application.Repositories
{
    public interface IOrderReadRepository
    {
        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>List with all orders</returns>
        Task<IList<Order>> GetAll();
    }
}
