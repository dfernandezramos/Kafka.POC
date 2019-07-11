using AutoMapper;
using Common.Contracts;
using Kafka.POC.Customers.Domain.Commands;

namespace Kafka.POC.Customers.Domain
{
    public class CommandToContractMapperProfile : Profile
    {
        public CommandToContractMapperProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(c => c.Id, options => options.MapFrom(source => source.Id))
                .ForMember(c => c.Name, options => options.MapFrom(source => source.Name))
                .ForMember(c => c.CreditLimit, options => options.MapFrom(source => source.CreditLimit));
        }
    }
}
