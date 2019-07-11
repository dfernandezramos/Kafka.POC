using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.POC.Customers.Domain
{
    public interface ICustomerService
    {
        Task<bool> IsCreditLimitAvailable(Guid customerId, decimal allocatedCredit, CancellationToken cancellationToken);
    }
}