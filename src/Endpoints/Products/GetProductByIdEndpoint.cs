using BugStore.Requests.Products;
using MediatR;

namespace BugStore.Endpoints.Products;

public class GetProductByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id:guid}", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IMediator mediator, Guid id)
    {
        var request = new GetProductByIdRequest
        {
            Id = id
        };

        var response = await mediator.Send(request);

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}
