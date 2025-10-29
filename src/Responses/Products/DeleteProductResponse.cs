namespace BugStore.Responses.Products;

public class DeleteProductResponse : Response
{
    public DeleteProductResponse(bool success, string message) : base(null, success, message)
    {
    }
}