using BugStore.Requests.Products;
using MediatR;

namespace BugStore.Endpoints.Products;

public class CreateProductEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IMediator mediator, CreateProductRequest request)
    {
        var response = await mediator.Send(request);

        return response.Success ? Results.Created(string.Empty, response) : Results.BadRequest(response);
    }
}
