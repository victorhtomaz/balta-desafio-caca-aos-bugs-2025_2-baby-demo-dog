using BugStore.Responses.Customers;
using MediatR;

namespace BugStore.Requests.Customers;

public class DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
{
    public Guid Id;
}