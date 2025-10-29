using BugStore.Domain.Models;

namespace BugStore.Responses.Products;

public class GetProductByIdResponse : Response
{
    public GetProductByIdResponse(Product? product, bool success, string message) : base(product, success, message)
    {
    }
}