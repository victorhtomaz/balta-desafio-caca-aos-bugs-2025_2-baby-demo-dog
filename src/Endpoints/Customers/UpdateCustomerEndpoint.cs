using BugStore.Requests.Customers;
using MediatR;

namespace BugStore.Endpoints.Customers;

public class UpdateCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id:guid}", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IMediator mediator, Guid id, UpdateCustomerRequest request)
    {
        request.Id = id;

        var response = await mediator.Send(request);

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}
