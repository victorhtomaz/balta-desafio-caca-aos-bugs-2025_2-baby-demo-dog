using BugStore.Domain.Models;
using BugStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Data.Repositories;

public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public async Task Add(Customer customer)
    {
        await context.Customers.AddAsync(customer);
    }

    public void Delete(Customer customer)
    {
        context.Customers.Remove(customer);
    }

    public async Task<List<Customer>> GetAll()
    {
        return await context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetById(Guid id)
    {
        return await context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
    }

    public void Update(Customer customer)
    {
        context.Customers.Update(customer);
    }
}
