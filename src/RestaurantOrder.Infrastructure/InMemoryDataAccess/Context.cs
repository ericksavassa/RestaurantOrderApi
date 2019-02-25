using System.Collections.ObjectModel;
using RestaurantOrder.Domain.Model;

namespace RestaurantOrder.Infrastructure.InMemoryDataAccess
{
    public class Context
    {
        public Collection<Order> Orders { get; set; }

        public Context()
        {
            Orders = new Collection<Order>();
        }
    }
}
