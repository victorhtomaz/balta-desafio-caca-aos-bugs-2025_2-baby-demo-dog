namespace BugStore.Responses.Products;

public class UpdateProductResponse : Response
{
    public UpdateProductResponse(bool success, string message) : base(null, success, message)
    {
    }
}