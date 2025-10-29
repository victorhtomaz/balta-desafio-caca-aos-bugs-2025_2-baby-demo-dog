using BugStore.Endpoints.Customers;
using BugStore.Endpoints.Order;
using BugStore.Endpoints.Products;

namespace BugStore.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGroup("v1/customers")
            .MapEndpoint<CreateCustomerEndpoint>()
            .MapEndpoint<DeleteCustomerEndpoint>()
            .MapEndpoint<GetCustomerEndpoint>()
            .MapEndpoint<GetCustomerByIdEndpoint>()
            .MapEndpoint<UpdateCustomerEndpoint>();

        app.MapGroup("v1/products")
            .MapEndpoint<CreateProductEndpoint>()
            .MapEndpoint<DeleteProductEndpoint>()
            .MapEndpoint<GetProductEndpoint>()
            .MapEndpoint<GetProductByIdEndpoint>()
            .MapEndpoint<UpdateProductEndpoint>();

        app.MapGroup("v1/orders")
            .MapEndpoint<CreateOrderEndpoint>()
            .MapEndpoint<GetOrderByIdEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
