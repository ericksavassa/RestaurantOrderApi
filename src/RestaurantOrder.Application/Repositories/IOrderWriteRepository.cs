using RestaurantOrder.Domain.Model;
using System.Threading.Tasks;

namespace RestaurantOrder.Application.Repositories
{
    public interface IOrderWriteRepository
    {
        /// <summary>
        /// Create new order
        /// </summary>
        /// <param name="order">The order</param>
        Task Add(Order order);
    }
}
