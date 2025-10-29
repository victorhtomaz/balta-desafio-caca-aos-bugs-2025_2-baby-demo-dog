using BugStore.Domain.Models;
using BugStore.Domain.Repositories;
using BugStore.Requests.Orders;
using BugStore.Responses.Orders;
using MediatR;

namespace BugStore.Handlers.Order;

public class CreateOrderHandler
    (IOrderRepository orderRepository,
    ICustomerRepository customerRepository,
    IProductRepository productRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
{
    public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetById(request.CustomerId);
        if (customer is null)
            return new CreateOrderResponse(false, "Cliente não encontrado");

        var productsIds = request.Lines.Select(x => x.ProductId).ToList();
        var products = await productRepository.GetProductsWithId(productsIds);

        if (products.Count != request.Lines.Count)
            return new CreateOrderResponse(false, "Um ou mais produtos não foram encontrados");

        var orderLines = request.Lines
            .Join(products, line => line.ProductId, product => product.Id,
            (line, product) => new OrderLine
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Product = product,
                Quantity = line.Quantity,
                Total = product.Price * line.Quantity
             })
            .ToList();

        var order = new Domain.Models.Order
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CustomerId = customer.Id,
            Customer = customer,
            Lines = orderLines
        };

        await orderRepository.Add(order);
        await unitOfWork.Commit();

        return new CreateOrderResponse(true, "Criado com sucesso");
    }
}
