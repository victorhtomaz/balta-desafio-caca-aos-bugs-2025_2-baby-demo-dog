using BugStore.Domain.Models;

namespace BugStore.Responses.Orders;

public class CreateOrderResponse : Response
{
    public CreateOrderResponse(bool success, string message) : base(null, success, message)
    {
    }
}