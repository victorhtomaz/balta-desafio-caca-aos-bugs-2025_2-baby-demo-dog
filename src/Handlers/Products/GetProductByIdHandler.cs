using BugStore.Domain.Repositories;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using MediatR;

namespace BugStore.Handlers.Products;

public class GetProductByIdHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
{
    public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.Id);
        if (product is null)
            return new GetProductByIdResponse(null, false, "Produto não encontrado");

        return new GetProductByIdResponse(product, true, string.Empty);
    }
}
