using BugStore.Domain.Models;
using BugStore.Domain.Repositories;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using MediatR;

namespace BugStore.Handlers.Products;

public class CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            Slug = request.Title.ToLower()
        };

        await productRepository.Add(product);
        await unitOfWork.Commit();

        return new CreateProductResponse(true, "Criado com sucesso");
    }
}
