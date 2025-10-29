using BugStore.Responses.Customers;
using MediatR;

namespace BugStore.Requests.Customers;

public class UpdateCustomerRequest : IRequest<UpdateCustomerResponse>
{
    public Guid Id;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}