using BugStore.Domain.Models;

namespace BugStore.Responses.Customers;

public class GetCustomerResponse : Response
{
    public GetCustomerResponse(List<Customer> customers, bool success, string message) : base(customers, success, message)
    {
    }
}