using RestaurantOrder.Domain.Model;
using System.Threading.Tasks;

namespace RestaurantOrder.Application.Repositories
{
    public interface IOrderWriteRepository
    {
        Task Add(Order order);
    }
}
