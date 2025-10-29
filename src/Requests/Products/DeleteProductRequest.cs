using BugStore.Responses.Products;
using MediatR;

namespace BugStore.Requests.Products;

public class DeleteProductRequest : IRequest<DeleteProductResponse>
{
    public Guid Id;
}