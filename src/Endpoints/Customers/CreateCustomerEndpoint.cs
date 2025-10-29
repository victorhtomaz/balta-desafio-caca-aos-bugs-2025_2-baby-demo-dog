using BugStore.Requests.Customers;
using MediatR;

namespace BugStore.Endpoints.Customers;

public class CreateCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IMediator mediator, CreateCustomerRequest request)
    {
        var response = await mediator.Send(request);

        return response.Success ? Results.Created(string.Empty, response) : Results.BadRequest(response);
    }
}
