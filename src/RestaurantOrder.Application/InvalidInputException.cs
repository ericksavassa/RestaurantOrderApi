using System;
namespace RestaurantOrder.Application
{
    public class InvalidInputException : ApplicationException
    {
        /// <summary>
        /// Exception for Invalid input
        /// </summary>
        /// <param name="message">The message</param>
        public InvalidInputException(string message) : base(message) { }
    }
}
