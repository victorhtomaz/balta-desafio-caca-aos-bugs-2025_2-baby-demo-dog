using BugStore.Domain.Models;
using BugStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Data.Repositories;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task Add(Order order)
    {
        await context.Orders.AddAsync(order);
    }

    public async Task<Order?> GetById(Guid id)
    {
        return await context.Orders
            .Include(order => order.Customer)
            .Include(order => order.Lines)
            .FirstOrDefaultAsync(order => order.Id == id); 
    }
}
