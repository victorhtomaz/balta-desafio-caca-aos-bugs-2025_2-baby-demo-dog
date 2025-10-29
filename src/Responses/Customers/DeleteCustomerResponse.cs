namespace BugStore.Responses.Customers;

public class DeleteCustomerResponse : Response
{
    public DeleteCustomerResponse(bool success, string message) : base(null, success, message)
    {
    }
}