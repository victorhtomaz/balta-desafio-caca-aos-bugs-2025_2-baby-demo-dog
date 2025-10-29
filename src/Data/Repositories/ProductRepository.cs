using BugStore.Domain.Models;
using BugStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Data.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task Add(Product product)
    {
        await context.Products.AddAsync(product);
    }

    public void Delete(Product product)
    {
        context.Products.Remove(product);
    }

    public async Task<List<Product>> GetAll()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Product>> GetProductsWithId(List<Guid> ids)
    {
        return await context.Products.Where(product => ids.Contains(product.Id)).ToListAsync();
    }

    public void Update(Product product)
    {
        context.Products.Update(product);
    }
}
