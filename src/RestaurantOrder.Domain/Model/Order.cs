using System;

namespace RestaurantOrder.Domain.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int Input { get; set; }
        public int Output { get; set; }
    }
}
