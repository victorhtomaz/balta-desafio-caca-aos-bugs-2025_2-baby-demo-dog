using BugStore.Domain.Repositories;
using BugStore.Requests.Orders;
using BugStore.Responses.Orders;
using MediatR;

namespace BugStore.Handlers.Order;

public class GetOrderByIdHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
{
    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetById(request.Id);
        if (order is null)
            return new GetOrderByIdResponse(null, false, "Pedido não encontrado");

        return new GetOrderByIdResponse(order, true, string.Empty);
    }
}
