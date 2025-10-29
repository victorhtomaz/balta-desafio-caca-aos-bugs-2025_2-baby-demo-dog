using BugStore.Domain.Models;

namespace BugStore.Domain.Repositories;

public interface ICustomerRepository
{
    Task Add(Customer customer);
    Task<Customer?> GetById(Guid id);
    Task<List<Customer>> GetAll();
    void Update(Customer customer);
    void Delete(Customer customer);
}
