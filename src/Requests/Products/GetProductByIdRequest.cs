using BugStore.Responses.Products;
using MediatR;

namespace BugStore.Requests.Products;

public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
{
    public Guid Id;
}