using BugStore.Domain.Models;

namespace BugStore.Domain.Repositories;

public interface IProductRepository
{
    Task Add(Product product);
    Task<Product?> GetById(Guid id);
    Task<List<Product>> GetAll();
    void Update(Product product);
    void Delete(Product product);
    Task<List<Product>> GetProductsWithId(List<Guid> ids);
}
