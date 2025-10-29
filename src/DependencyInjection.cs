using BugStore.Data;
using BugStore.Data.Repositories;
using BugStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BugStore;

public static class DependencyInjection
{
    public static void AddDependency(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddMediator(services);
        AddRepositories(services);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
    }

    private static void AddMediator(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
