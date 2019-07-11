using System;

namespace Kafka.POC.Orders.Data
{
    public class OrderNotFoundException : ArgumentException
    {
        public OrderNotFoundException(string message) : base(message)
        {
        }
    }
}