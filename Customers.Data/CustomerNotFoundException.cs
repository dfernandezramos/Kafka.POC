using System;

namespace Kafka.POC.Customers.Data
{
    public class CustomerNotFoundException : ArgumentException
    {
        public CustomerNotFoundException(string message) : base(message)
        {

        }
    }
}