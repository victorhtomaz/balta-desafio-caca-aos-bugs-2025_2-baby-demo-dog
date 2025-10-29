namespace BugStore.Responses.Customers;

public class CreateCustomerResponse : Response
{
    public CreateCustomerResponse(bool success, string message) : base(null, success, message)
    {
    }
}