using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantOrder.Application.Repositories;
using RestaurantOrder.Domain.Model;

namespace RestaurantOrder.Infrastructure.InMemoryDataAccess.Repositories
{
    public class OrderRepository : IOrderWriteRepository, IOrderReadRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(Order order)
        {
            _context.Orders.Add(order);
            await Task.CompletedTask;
        }

        public async Task<IList<Order>> GetAll()
        {
            IList<Order> orders = _context.Orders;
            return await Task.FromResult(orders);
        }
    }
}