using System;
namespace RestaurantOrder.Application
{
    public class InvalidInputException : ApplicationException
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
