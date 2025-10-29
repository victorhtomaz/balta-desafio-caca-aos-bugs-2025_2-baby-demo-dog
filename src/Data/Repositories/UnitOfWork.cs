using BugStore.Domain.Repositories;

namespace BugStore.Data.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task Commit()
    {
        await context.SaveChangesAsync();
    }
}
