using BugStore.Domain.Models;

namespace BugStore.Domain.Repositories;

public interface IOrderRepository
{
    Task Add(Order order);
    Task<Order?> GetById(Guid id);
}
