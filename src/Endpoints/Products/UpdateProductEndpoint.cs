using BugStore.Requests.Products;
using MediatR;

namespace BugStore.Endpoints.Products;

public class UpdateProductEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id:guid}", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IMediator mediator, Guid id, UpdateProductRequest request)
    {
        request.Id = id;
        var response = await mediator.Send(request);

        return response.Success ? Results.Created(string.Empty, response) : Results.BadRequest(response);
    }
}
