namespace BugStore.Responses.Customers;

public class UpdateCustomerResponse : Response
{
    public UpdateCustomerResponse(bool success, string message) : base(null, success, message)
    {

    }
}