using BugStore.Requests.Orders;
using MediatR;

namespace BugStore.Endpoints.Order;

public class CreateOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IMediator mediator, CreateOrderRequest request)
    {
        var response = await mediator.Send(request);

        return response.Success ? Results.Created(string.Empty, response) : Results.BadRequest(response);
    }
}
