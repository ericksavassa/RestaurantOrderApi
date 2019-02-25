using RestaurantOrder.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrder.Application
{
    public interface IOrderService
    {
        Task<string> Order(string input);
        Task<IEnumerable<Order>> GetAll();
    }
}
