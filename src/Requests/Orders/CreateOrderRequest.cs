using BugStore.Responses.Orders;
using MediatR;

namespace BugStore.Requests.Orders;

public class CreateOrderRequest : IRequest<CreateOrderResponse>
{
    public Guid CustomerId { get; set; }
    public List<OrderLineRequest> Lines { get; set; } = [];
}