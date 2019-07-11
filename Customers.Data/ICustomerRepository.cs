using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;

namespace Kafka.POC.Customers.Data
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(Guid id, CancellationToken cancellationToken);
        Task New(Customer customer, CancellationToken cancellationToken);
        Task UpdateCreditLimit(Guid customerId, decimal newCreditLimit, CancellationToken cancellationToken);
    }
}