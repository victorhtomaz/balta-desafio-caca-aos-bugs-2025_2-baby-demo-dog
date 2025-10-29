using BugStore.Requests.Orders;
using MediatR;

namespace BugStore.Endpoints.Order;

public class GetOrderByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id:guid}", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IMediator mediator, Guid id)
    {
        var request = new GetOrderByIdRequest
        {
            Id = id
        };

        var response = await mediator.Send(request);

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}
