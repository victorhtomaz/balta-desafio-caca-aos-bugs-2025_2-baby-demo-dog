
using BugStore.Requests.Customers;
using MediatR;

namespace BugStore.Endpoints.Customers;

public class DeleteCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id:guid}", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IMediator mediator, Guid id)
    {
        var request = new DeleteCustomerRequest
        {
            Id = id
        };

        var response = await mediator.Send(request);

        return response.Success ? Results.Ok(response) : Results.BadRequest(response);
    }
}
