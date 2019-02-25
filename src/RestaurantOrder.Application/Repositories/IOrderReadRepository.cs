using RestaurantOrder.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrder.Application.Repositories
{
    public interface IOrderReadRepository
    {
        Task<IList<Order>> GetAll();
    }
}
