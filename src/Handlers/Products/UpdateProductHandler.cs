using BugStore.Domain.Repositories;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using MediatR;

namespace BugStore.Handlers.Products;

public class UpdateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
{
    public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.Id);
        if (product is null)
            return new UpdateProductResponse(false, "Produto não encontrado");

        product.Title = request.Title;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Slug = request.Title.ToLower();

        productRepository.Update(product);
        await unitOfWork.Commit();

        return new UpdateProductResponse(true, "Produto atualizado com sucesso");
    }
}
