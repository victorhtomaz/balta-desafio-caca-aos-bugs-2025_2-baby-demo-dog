using BugStore.Requests.Products;
using MediatR;

namespace BugStore.Endpoints.Products;

public class GetProductEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IMediator mediator)
    {
        var request = new GetProductRequest();

        var response = await mediator.Send(request);

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}
