using BugStore.Domain.Repositories;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using MediatR;

namespace BugStore.Handlers.Customers;

public class GetCustomerByIdHandler(ICustomerRepository customerRepository)
    : IRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
{
    public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetById(request.Id);
        if (customer is null)
            return new GetCustomerByIdResponse(null, true, "Cliente não encontrado");

        return new GetCustomerByIdResponse(customer, true, string.Empty);
    }
}
