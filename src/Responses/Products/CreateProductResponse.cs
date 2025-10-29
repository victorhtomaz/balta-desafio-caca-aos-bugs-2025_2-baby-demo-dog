using BugStore.Domain.Models;

namespace BugStore.Responses.Products;

public class CreateProductResponse : Response
{
    public CreateProductResponse(bool success, string message) : base(null, success, message)
    {
    }
}