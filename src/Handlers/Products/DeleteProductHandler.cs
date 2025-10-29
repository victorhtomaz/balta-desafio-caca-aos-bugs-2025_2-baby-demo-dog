using BugStore.Domain.Repositories;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using MediatR;

namespace BugStore.Handlers.Products;

public class DeleteProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
{
    public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.Id);
        if (product is null)
            return new DeleteProductResponse(false, "Produto não encontrado");

        productRepository.Delete(product);
        await unitOfWork.Commit();

        return new DeleteProductResponse(true, string.Empty);
    }
}
