
using BugStore.Requests.Customers;
using MediatR;

namespace BugStore.Endpoints.Customers;

public class GetCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IMediator mediator)
    {
        var request = new GetCustomerRequest();

        var response = await mediator.Send(request);

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}
