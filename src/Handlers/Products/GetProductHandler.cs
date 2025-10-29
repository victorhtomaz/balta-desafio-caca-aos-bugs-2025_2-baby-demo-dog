using BugStore.Domain.Repositories;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using MediatR;

namespace BugStore.Handlers.Products;

public class GetProductHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductRequest, GetProductResponse>
{
    public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAll();

        return new GetProductResponse(products, true, string.Empty);
    }
}
