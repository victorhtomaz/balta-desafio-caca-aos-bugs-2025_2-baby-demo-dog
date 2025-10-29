using BugStore.Domain.Models;

namespace BugStore.Responses.Customers;

public class GetCustomerByIdResponse : Response
{
    public GetCustomerByIdResponse(Customer? customer, bool success, string message) : base(customer, success, message)
    {
    }
}