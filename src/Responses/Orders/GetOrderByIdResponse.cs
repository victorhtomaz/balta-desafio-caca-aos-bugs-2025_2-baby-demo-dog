using BugStore.Domain.Models;

namespace BugStore.Responses.Orders;

public class GetOrderByIdResponse : Response
{
    public GetOrderByIdResponse(Order? order, bool success, string message) : base(order, success, message)
    {
    }
}