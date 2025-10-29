using BugStore.Domain.Models;

namespace BugStore.Responses.Products;

public class GetProductResponse : Response
{
    public GetProductResponse(List<Product> products, bool success, string message) : base(products, success, message)
    {
    }
}