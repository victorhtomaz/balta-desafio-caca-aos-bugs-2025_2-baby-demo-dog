using BugStore.Domain.Repositories;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using MediatR;

namespace BugStore.Handlers.Customers;

public class GetCustomerHandler(ICustomerRepository customerRepository)
    : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
{
    public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        var customers = await customerRepository.GetAll();

        return new GetCustomerResponse(customers, true, string.Empty);
    }
}
